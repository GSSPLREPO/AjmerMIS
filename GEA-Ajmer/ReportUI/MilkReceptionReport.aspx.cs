using GEA_Ajmer.BL;
using GEA_Ajmer.Common;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GEA_Ajmer.ReportUI
{
    public partial class MilkReceptionReport : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger(typeof(MilkReceptionReport));
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindShiftNo();

                BindSILO();
                BindReceptionLineNo();
                //BindTankerId();
                imgWordButton.Visible = imgPDFButton.Visible = imgExcelButton.Visible = divId.Visible = false;
                ViewState["Mode"] = "Save";
                // MilkStorageGrid();
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }

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
                    objControls.BindDropDown_ListBox(objResult.ResultDt, ddlShiftNo, "Name", "ShiftId");
                }
                ddlShiftNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select All--", "-1"));
            }
        }
        #endregion

        //#region Bind Tanker Id
        //protected void BindTankerId()
        //{
        //    //ddlTankerID.Items.Clear();
        //    Controls objControls = new Controls();
        //    DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
        //      CultureInfo.InvariantCulture);
        //    DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
        //        CultureInfo.InvariantCulture);
        //    Reception_PLCBl objReceptionPlcBl = new Reception_PLCBl();
        //    var objResult = objReceptionPlcBl.Reception_PLC_SelectAll(Convert.ToInt32(ddlReceptionLineNo.SelectedValue),dtFromDateTime,dtToDateTime);
        //    if (objResult != null)
        //    {
        //        if (objResult.ResultDt.Rows.Count > 0)
        //        {
        //            objControls.BindDropDown_ListBox(objResult.ResultDt, ddlTankerID, "Tanker_ID", "Tanker_ID");
        //        }
        //        ddlTankerID.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select All--", "-1"));
        //    }
        //}
        //#endregion

        #region Bind Reception Line NO
        protected void BindReceptionLineNo()
        {
            Controls objControls = new Controls();
            ReceptionBl objReceptionBl = new ReceptionBl();
            var objResult = objReceptionBl.Reception_SelectAll();
            if (objResult != null)
            {
                if (objResult.ResultDt.Rows.Count > 0)
                {
                    objControls.BindDropDown_ListBox(objResult.ResultDt, ddlReceptionLineNo, "Name", "PLCValue");
                }
                ddlReceptionLineNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select All--", "-1"));
            }
        }
        #endregion

        #region Bind SILO
        protected void BindSILO()
        {
            Controls objControls = new Controls();
            SiloBl objSiloBl = new SiloBl();
            var objResult = objSiloBl.Silo_SelectAll();
            if (objResult != null)
            {
                if (objResult.ResultDt.Rows.Count > 0)
                {
                    objControls.BindDropDown_ListBox(objResult.ResultDt, ddlSILONo, "Name", "PLCValue");
                }
                ddlSILONo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select All--", "-1"));
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
                string filename = "MilkReception_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    StringWriter sw1 = new StringWriter();
                    HtmlTextWriter hw1 = new HtmlTextWriter(sw1);

                    //To Export all pages
                    gvMilkReception.AllowPaging = false;
                    //gvTotalQty.AllowPaging = false;
                    //   this.MilkStorageGrid();

                    gvMilkReception.HeaderRow.BackColor = Color.White;
                    //gvTotalQty.HeaderRow.BackColor = Color.White;

                    foreach (TableCell cell in gvMilkReception.HeaderRow.Cells)
                    {
                        cell.BackColor = gvMilkReception.HeaderStyle.BackColor;
                    }

                    foreach (GridViewRow row in gvMilkReception.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvMilkReception.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvMilkReception.RowStyle.BackColor;
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
                    //gvMilkReception.Columns[0].Visible = false;
                    gvMilkReception.RenderControl(hw);
                    //gvTotalQty.RenderControl(hw1);


                    string strSubTitle = "MILK RECEPTION REPORT";
                    //string strPath ="../images/Logo1.gif";
                    string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Logo1.gif";
                    //string content = "<div align='left' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/></div><div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                    string content = "<div align='left' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/></div><div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                      "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/>" +
                         "<span align='center' style='font-family:verdana;font-size:13px'><strong>" + strSubTitle + "</strong></span><br/>" +
                         "<div align='center' style='font-family:verdana;font-size:12px'><strong>From Date :</strong>" +
                     DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                      "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
                      DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                      "</div><br/> "
                      + sw.ToString() + "<br/> <br/><br/>"
                      + sw1.ToString() + "<br/></div>";
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
                    gvMilkReception.GridLines = GridLines.None;
                    //gvTotalQty.GridLines = GridLines.None;
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
                string filename = "MilkReception_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    StringWriter sw1 = new StringWriter();
                    HtmlTextWriter hw1 = new HtmlTextWriter(sw1);

                    //To Export all pages
                    gvMilkReception.AllowPaging = false;
                    //gvTotalQty.AllowPaging = false;
                    //   this.MilkStorageGrid();

                    gvMilkReception.HeaderRow.BackColor = Color.White;
                    //gvTotalQty.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in gvMilkReception.HeaderRow.Cells)
                    {
                        cell.BackColor = gvMilkReception.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvMilkReception.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvMilkReception.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvMilkReception.RowStyle.BackColor;
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
                    //gvMilkReception.Columns[0].Visible = false;
                    gvMilkReception.RenderControl(hw);
                    //gvTotalQty.RenderControl(hw1);

                    string strSubTitle = "MILK RECEPTION REPORT";
                    string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Logo1.gif";
                    string content = "<div align='center' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                        "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/>" +
                           "<span align='center' style='font-family:verdana;font-size:13px'><strong>" + strSubTitle + "</strong></span><br/>" +
                           "<div align='center' style='font-family:verdana;font-size:12px'><strong>From Date :</strong>" +
                       DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                        "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
                        DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                        "</div><br/> "
                        + sw.ToString() + "<br/> <br/> <br/>" + sw1.ToString() + "<br/></div>";
                    string style = @"<!--mce:2-->";
                    Response.Write(style);
                    Response.Output.Write(content);
                    gvMilkReception.GridLines = GridLines.None;
                    //gvTotalQty.GridLines = GridLines.None;
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
                string filename = "MilkReception_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".doc";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Charset = "";
                Response.ContentType = "application/msword ";

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    StringWriter sw1 = new StringWriter();
                    HtmlTextWriter hw1 = new HtmlTextWriter(sw1);

                    //To Export all pages
                    gvMilkReception.AllowPaging = false;
                    //gvTotalQty.AllowPaging = false;
                    //   this.MilkStorageGrid();

                    gvMilkReception.HeaderRow.BackColor = Color.White;
                   // gvTotalQty.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in gvMilkReception.HeaderRow.Cells)
                    {
                        cell.BackColor = gvMilkReception.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvMilkReception.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvMilkReception.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvMilkReception.RowStyle.BackColor;
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
                    //gvMilkReception.Columns[0].Visible = false;
                    gvMilkReception.RenderControl(hw);
                    //gvTotalQty.RenderControl(hw);

                    string strSubTitle = "MILK RECEPTION REPORT";
                    string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Logo1.gif";
                    string content = "<div align='center' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                        "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/>" +
                           "<span align='center' style='font-family:verdana;font-size:13px'><strong>" + strSubTitle + "</strong></span><br/>" +
                           "<div align='center' style='font-family:verdana;font-size:12px'><strong>From Date :</strong>" +
                       DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                        "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
                        DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                        "</div><br/> "
                        + sw.ToString() + "<br/><br/><br/>" + sw1.ToString() + "<br/></div>";
                    //string style = @"<!--mce:2-->";
                    //Response.Write(style);
                    Response.Output.Write(content);
                    gvMilkReception.GridLines = GridLines.None;
                    //gvTotalQty.GridLines = GridLines.None;
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

        #region Bind Grid
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            MilkReceptionGrid();
        }
        #endregion

        #region MilkStorage Data Bind
        public void MilkReceptionGrid()
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
               CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                objResult = new MilkReceptionBL().MilkReception_SelectAll(dtFromDateTime, dtToDateTime, Convert.ToInt32(ddlShiftNo.SelectedValue), "-1", Convert.ToDouble(ddlReceptionLineNo.SelectedValue), Convert.ToDouble(ddlSILONo.SelectedValue));
                //ViewState["DataTableMilkStorage"] = objResult.ResutlDs.Tables[0];
                gvMilkReception.DataSource = objResult.ResutlDs.Tables[0];
                gvMilkReception.DataBind();
                //gvTotalQty.DataSource = objResult.ResutlDs.Tables[1];
                //gvTotalQty.DataBind();

                if (gvMilkReception.Rows.Count > 1)
                {

                    imgWordButton.Visible = imgPDFButton.Visible = imgExcelButton.Visible = divId.Visible = true;
                    divId.Visible = false;
                }
                else
                {
                    imgWordButton.Visible = imgPDFButton.Visible = imgExcelButton.Visible = divId.Visible = false;
                    divId.Visible = true;
                    gvMilkReception.DataSource = null;
                    gvMilkReception.DataBind();
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

        protected void gvMilkReception_OnPreRender(object sender, EventArgs e)
        {

        }

        protected void gvMilkReception_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

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

        protected void ddlReceptionLineNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                //BindTankerId();
            }
        }
    }
}