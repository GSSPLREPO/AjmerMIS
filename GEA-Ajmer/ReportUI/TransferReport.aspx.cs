using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using GEA_Ajmer.BL;
using GEA_Ajmer.Common;
using System.Globalization;
using log4net;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Web;
//using Word = Microsoft.Office.Interop.Word;

namespace GEA_Ajmer.ReportUI
{
    public partial class TransferReport : PageBase
    {
        //private Word.Application wordApp;
        //Word.Document aDoc = null;
        private static ILog log = LogManager.GetLogger(typeof(TransferReport));

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    imgWordButton.Visible = imgPDFButton.Visible = imgExcelButton.Visible = divId.Visible = false;
                    ViewState["Mode"] = "Save";
                    BindSilo();
                    txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region
        public void BindSilo()
        {
            TransferDispatchBl objTransferBl = new TransferDispatchBl();
            ApplicationResult objResult = new ApplicationResult();

             objResult= objTransferBl.TransferSilo();
            if (objResult.Status == ApplicationResult.CommonStatusType.Success)
            {
                if (objResult.ResultDt.Rows.Count > 0)
                {
                    Controls objControls = new Controls();
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        objControls.BindDropDown_ListBox(objResult.ResultDt, ddlSource, "TankName", "Id");
                        objControls.BindDropDown_ListBox(objResult.ResultDt, ddlDestination, "TankName", "Id");
                    }
                    ddlSource.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select All--", "-1"));
                    ddlDestination.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select All--", "-1"));
                }
            }
            

        } 
        #endregion

        #region Button Go Click Event
        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                TransferDispatchBl objTransferDispatchBl = new TransferDispatchBl();
                var objResult = new ApplicationResult();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                objResult = new TransferDispatchBl().Transfer_SelectAll(dtFromDateTime, dtToDateTime,Convert.ToInt32(ddlSource.SelectedValue), Convert.ToInt32(ddlDestination.SelectedValue));
                //ViewState["DataTableMilkStorage"] = objResult.ResutlDs.Tables[0];
                gvTransfer.DataSource = objResult.ResultDt;
                gvTransfer.DataBind();

                if (gvTransfer.Rows.Count > 0)
                {
                    imgWordButton.Visible = imgPDFButton.Visible = imgExcelButton.Visible = divId.Visible = true;
                    divId.Visible = false;
                }
                else
                {
                    imgWordButton.Visible = imgPDFButton.Visible = imgExcelButton.Visible = divId.Visible = false;
                    divId.Visible = true;
                    gvTransfer.DataSource = null;
                    gvTransfer.DataBind();
                    // ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    //"<script>alert('No Record Found.');</script>");
                }
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region Export to Word Button Click
        protected void imgbtnDoc_OnClick(object sender, EventArgs e)
        {
            string filename = "Transfer_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".doc";
            Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            Response.Charset = "";
            Response.ContentType = "application/msword ";

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvTransfer.AllowPaging = false;
            gvTransfer.GridLines = GridLines.Both;
            foreach (TableCell cell in gvTransfer.HeaderRow.Cells)
            {
                cell.BackColor = gvTransfer.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvTransfer.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvTransfer.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvTransfer.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                    List<Control> controls = new List<Control>();

                    //Add controls to be removed to Generic List
                    foreach (Control control in cell.Controls)
                    {
                        controls.Add(control);
                    }

                    //Loop through the controls to be removed and replace then with Literal
                    foreach (Control control in controls)
                    {
                        switch (control.GetType().Name)
                        {
                            case "HyperLink":
                                cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                break;
                            case "TextBox":
                                cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                break;
                            case "LinkButton":
                                cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                break;
                            case "CheckBox":
                                cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                break;
                            case "RadioButton":
                                cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                break;
                        }
                        cell.Controls.Remove(control);
                    }
                }
            }
            // gvTransfer.Columns[0].Visible = false;
            gvTransfer.RenderControl(hw);

            string strSubTitle = "TRANSFER REPORT";
            //string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Logo1.gif";
            //string content = "<div align='left' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/></div><div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
            string content = "<div align='center'><img align='left' style='height: 40px; width: 109px' src='" + Session[ApplicationSession.Logo] + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
            "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/></div>" +
               "<div align='center' style='font-family:verdana;font-size:11px'><strong>From Date :</strong>" +
           DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
            "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
            DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
            "</div><br/><div align='center' style='font-family:verdana;font-size:11px'><span style='font-size:11px;color:Maroon;'>" + strSubTitle + "</ span><br/>" +
             "<br/>" + sw.ToString() + "<br/></div>";
            Response.Output.Write(content);
            Response.Flush();
            Response.End();
        }
        #endregion

        #region Export to Excel Button Click
        protected void imgbtnExcel_OnClick(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            string filename = "Transfer_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvTransfer.AllowPaging = false;
            gvTransfer.GridLines = GridLines.Both;
            foreach (TableCell cell in gvTransfer.HeaderRow.Cells)
            {
                cell.BackColor = gvTransfer.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvTransfer.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvTransfer.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvTransfer.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                    List<Control> controls = new List<Control>();

                    //Add controls to be removed to Generic List
                    foreach (Control control in cell.Controls)
                    {
                        controls.Add(control);
                    }

                    //Loop through the controls to be removed and replace then with Literal
                    foreach (Control control in controls)
                    {
                        switch (control.GetType().Name)
                        {
                            case "HyperLink":
                                cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                break;
                            case "TextBox":
                                cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                break;
                            case "LinkButton":
                                cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                break;
                            case "CheckBox":
                                cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                break;
                            case "RadioButton":
                                cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                break;
                        }
                        cell.Controls.Remove(control);
                    }
                }
            }

            gvTransfer.RenderControl(hw);
            string strSubTitle = "TRANSFER REPORT";
            //string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Logo1.gif";
            //string content = "<div align='left' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/></div><div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
            string content = "<div align='center'><img align='left' style='height: 40px; width: 109px' src='" + Session[ApplicationSession.Logo] + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
            "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/></div>" +
               "<div align='center' style='font-family:verdana;font-size:11px'><strong>From Date :</strong>" +
           DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
            "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
            DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
            "</div><br/><div align='center' style='font-family:verdana;font-size:11px'><span style='font-size:11px;color:Maroon;'>" + strSubTitle + "</ span><br/>" +
             "<br/>" + sw.ToString() + "<br/></div>";
            string style = @"<!--mce:2-->";
            Response.Write(style);
            Response.Output.Write(content);
            //gvOEEReport.GridLines = GridLines.None;
            Response.Flush();
            Response.Clear();
            Response.End();
        }
        #endregion

        #region Export to PDF Button Click
        protected void imgbtnPDF_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string filename = "TransferReport_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    gvTransfer.AllowPaging = false;
                    //   this.MilkStorageGrid();

                    gvTransfer.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in gvTransfer.HeaderRow.Cells)
                    {
                        cell.BackColor = gvTransfer.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvTransfer.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvTransfer.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvTransfer.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                            List<Control> controls = new List<Control>();

                            //Add controls to be removed to Generic List
                            foreach (Control control in cell.Controls)
                            {
                                controls.Add(control);
                            }

                            //Loop through the controls to be removed and replace then with Literal
                            foreach (Control control in controls)
                            {
                                switch (control.GetType().Name)
                                {
                                    case "HyperLink":
                                        cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                        break;
                                    case "TextBox":
                                        cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                        break;
                                    case "LinkButton":
                                        cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                        break;
                                    case "CheckBox":
                                        cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                        break;
                                    case "RadioButton":
                                        cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                        break;
                                }
                                cell.Controls.Remove(control);
                            }
                        }
                    }
                    gvTransfer.Columns[0].Visible = false;
                    gvTransfer.RenderControl(hw);

                    string strSubTitle = "TRANSFER REPORT";
                    string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Logo1.gif";
                    //string content = "<div align='left' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/></div><div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                    string content = "<div align='center'><img align='left' style='height: 40px; width: 109px' src='" + Session[ApplicationSession.Logo] + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                     "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/></div>" +
                        "<div align='center' style='font-family:verdana;font-size:11px'><strong>From Date :</strong>" +
                    DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                     "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
                     DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                     "</div><br/><div align='center' style='font-family:verdana;font-size:11px'><span style='font-size:11px;color:Maroon;'>" + strSubTitle + "</ span><br/>" +
                      "<br/>" + sw.ToString() + "<br/></div>";
                    // string style = @"<!--mce:2-->";
                    StringReader sr = new StringReader(content);
                    Document pdfDoc = new Document(iTextSharp.text.PageSize.A3, 10f, 10f, 10f, 0f);
                    pdfDoc.SetPageSize(iTextSharp.text.PageSize.A3.Rotate());
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.Write(pdfDoc);
                    gvTransfer.GridLines = GridLines.None;
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion
        
        #region VerifyRenderingInServerForm
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        #endregion
    }
}