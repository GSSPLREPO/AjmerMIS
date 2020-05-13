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
using System.Web;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
//using Word = Microsoft.Office.Interop.Word;

namespace GEA_Ajmer.ReportUI
{
    public partial class DispatchReport : PageBase
    {
        //private Word.Application wordApp;
        //Word.Document aDoc = null;
        private static ILog log = LogManager.GetLogger(typeof(DispatchReport));

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) return;
                BindShiftNo();
                //BindReceptionLineNo();
                //BindTankerId();
                BindSILO();
                divExport.Visible = false;
                divNo.Visible = false;
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region Bind Shift No
        //protected void BindReceptionLineNo()
        //{

        //    ddlReceptionLineNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select All--", "-1"));
        //    ddlReceptionLineNo.Items.Insert(1, new System.Web.UI.WebControls.ListItem("RMST", "1"));
        //    ddlReceptionLineNo.Items.Insert(2, new System.Web.UI.WebControls.ListItem("PMST", "2"));
        //    ddlReceptionLineNo.Items.Insert(3, new System.Web.UI.WebControls.ListItem("CBST", "3"));
        //}
        #endregion


        #region Bind Shift No
        protected void BindShiftNo()
        {
            Controls objControls = new Controls();
            ShiftBl objShiftBl = new ShiftBl();
            var objResult = objShiftBl.Shift_SelectAll();
            if (objResult != null)
            {
                if (objResult.ResultDt.Rows.Count > 0)
                {
                    //objControls.BindDropDown_ListBox(objResult.ResultDt, ddlShiftNo, "Name", "ShiftId");
                }
                //ddlShiftNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select All--", "-1"));
            }
        }
        #endregion

        #region Bind Tanker Id
        //protected void BindTankerId()
        //{
        //    //ddlTankerID.Items.Clear();
        //    Controls objControls = new Controls();
        //    DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
        //      CultureInfo.InvariantCulture);
        //    DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
        //        CultureInfo.InvariantCulture);
        //    TransferDispatchBl objTransferDispatchBl = new TransferDispatchBl();
        //    var objResult = objTransferDispatchBl.Transfer_Dispatch_PLC_SelectAll(Convert.ToInt32(ddlReceptionLineNo.SelectedValue), dtFromDateTime, dtToDateTime);
        //    if (objResult != null)
        //    {
        //        if (objResult.ResultDt.Rows.Count > 0)
        //        {
        //            objControls.BindDropDown_ListBox(objResult.ResultDt, ddlTankerID, "Tanker_ID", "Tanker_ID");
        //        }
        //        ddlTankerID.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select All--", "-1"));
        //    }
        //}
        #endregion

        #region Bind SILO
        protected void BindSILO()
        {
            ddlTransferFrom.Items.Clear();
            Controls objControls = new Controls();
            TransferDispatchBl objTransferDispatchBl = new TransferDispatchBl();
            //var objResult = objTransferDispatchBl.Silo_Select_Dispatch(Convert.ToInt32(ddlReceptionLineNo.SelectedValue));
            var objResult = objTransferDispatchBl.Silo_Select_Dispatch(-1);
            if (objResult != null)
            {
                if (objResult.ResultDt.Rows.Count > 0)
                {
                    objControls.BindDropDown_ListBox(objResult.ResultDt, ddlTransferFrom, "Name", "Line");
                }
                ddlTransferFrom.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select All--", "-1"));
            }
        }
        #endregion



        #region Button Go Click Event
        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text,
                    "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                //string[] str = ddlTransferFrom.SelectedValue.Split('-');
                ApplicationResult objResult = new ApplicationResult();
                objResult = new TransferDispatchBl().Dispatch_SelectAll(dtFromDateTime, dtToDateTime, Convert.ToInt32(ddlTransferFrom.SelectedValue));
                if (objResult != null)
                {
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        
                        gvDispatch.DataSource = null;
                        gvDispatch.DataBind();
                      
                        gvDispatch.DataSource = objResult.ResultDt;
                        gvDispatch.DataBind();
                       
                    }
                }
                if (gvDispatch.Rows.Count > 0)
                {
                    divExport.Visible = true;
                    divNo.Visible = false;
                }
                else
                {
                    divExport.Visible = false;
                    divNo.Visible = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Dispatch Load Event", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region Export to PDF
        protected void imgbtnPDF_OnClick(object sender, EventArgs e)
        {
            try
            {

                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string filename = "Dispatch_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    gvDispatch.AllowPaging = false;
                    //   this.MilkStorageGrid();

                    gvDispatch.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in gvDispatch.HeaderRow.Cells)
                    {
                        cell.BackColor = gvDispatch.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvDispatch.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvDispatch.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvDispatch.RowStyle.BackColor;
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
                    //gvDispatch.Columns[0].Visible = false;
                    gvDispatch.RenderControl(hw);

                    string strSubTitle = "DISPATCH REPORT";
                    string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Logo1.gif";
                    //string content = "<div align='left' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/></div><div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                    string content = "<div align='left' style='font-family:verdana;font-size:16px'></div><div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                      "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/>" +
                         "<span align='center' style='font-family:verdana;font-size:13px'><strong>" + strSubTitle + "</strong></span><br/>" +
                         "<div align='center' style='font-family:verdana;font-size:12px'><strong>From Date :</strong>" +
                     DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                      "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
                      DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                      "</div><br/> "
                      + sw.ToString() + "<br/></div>";
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
                    gvDispatch.GridLines = GridLines.None;
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

        #region Export to Excel
        protected void imgbtnExcel_OnClick(object sender, EventArgs e)
        {
            try
            {
                //DataTable dt = new DataTable();
                //  dt = ViewState["DataTableMilkStorage"].ToString();
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string filename = "Dispatch_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    gvDispatch.AllowPaging = false;
                    //   this.MilkStorageGrid();

                    gvDispatch.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in gvDispatch.HeaderRow.Cells)
                    {
                        cell.BackColor = gvDispatch.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvDispatch.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvDispatch.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvDispatch.RowStyle.BackColor;
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
                    // gvDispatch.Columns[0].Visible = false;
                    gvDispatch.RenderControl(hw);

                    string strSubTitle = "DISPATCH REPORT";
                    string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Logo1.gif";
                    string content = "<div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                        "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/>" +
                           "<span align='center' style='font-family:verdana;font-size:13px'><strong>" + strSubTitle + "</strong></span><br/>" +
                           "<div align='center' style='font-family:verdana;font-size:12px'><strong>From Date :</strong>" +
                       DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                        "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
                        DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                        "</div><br/> "
                        + sw.ToString() + "<br/></div>";
                    string style = @"<!--mce:2-->";
                    Response.Write(style);
                    Response.Output.Write(content);
                    gvDispatch.GridLines = GridLines.None;
                    Response.Flush();
                    Response.Clear();
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                log.Error("Button EXCEL", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Oops! There is some technical issue. Please Contact to your administrator.');", true);
            }

        }
        #endregion

        #region VerifyRenderingInServerForm
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        #endregion

        #region Export To Word
        protected void imgbtnWord_OnClick(object sender, EventArgs e)
        {
            try
            {
                string filename = "Dispatch_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".doc";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Charset = "";
                Response.ContentType = "application/msword ";

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    gvDispatch.AllowPaging = false;
                    //   this.MilkStorageGrid();

                    gvDispatch.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in gvDispatch.HeaderRow.Cells)
                    {
                        cell.BackColor = gvDispatch.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvDispatch.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvDispatch.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvDispatch.RowStyle.BackColor;
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
                    //gvDispatch.Columns[0].Visible = false;
                    gvDispatch.RenderControl(hw);

                    string strSubTitle = "DISPATCH REPORT";
                    string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Logo1.gif";
                    //string content = "<div align='center' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                    string content = "<div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                    "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/>" +
                       "<span align='center' style='font-family:verdana;font-size:13px'><strong>" + strSubTitle + "</strong></span><br/>" +
                       "<div align='center' style='font-family:verdana;font-size:12px'><strong>From Date :</strong>" +
                   DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                    "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
                    DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                    "</div><br/> "
                    + sw.ToString() + "<br/></div>";
                    // string style = @"<!--mce:2-->";
                    // Response.Write(style);
                    Response.Output.Write(content);
                    gvDispatch.GridLines = GridLines.None;
                    Response.Flush();
                    Response.Clear();
                    Response.End();
                }

            }
            catch (Exception ex)
            {
                log.Error("Button WORD", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Oops! There is some technical issue. Please Contact to your administrator.');", true);
            }
        }
        #endregion

        protected void ddlReceptionLineNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
               // BindTankerId();
            }
            BindSILO();
        }

        #region ToDate TextChange Event
        protected void txtToDate_TextChanged(object sender, EventArgs e)
        {
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                //BindTankerId();
            }
        }
        #endregion

        #region FromDate TextChange Event
        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                //BindTankerId();
            }
        }
        #endregion

    }
}