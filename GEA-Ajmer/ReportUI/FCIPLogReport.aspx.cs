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
    public partial class FCIPLogReport : PageBase
    {
        //private Word.Application wordApp;
        //Word.Document aDoc = null;
        private static ILog log = LogManager.GetLogger(typeof(PCIPLogReport));

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            divExport.Visible = false;
            divNo.Visible = false;
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }
        #endregion



        #region Go button Click Event
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            try
            {
                LogBl objLogBl = new LogBl();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                var objResult = objLogBl.FCIPLogReport(dtFromDateTime, dtToDateTime);
                gvFCIPLogReport.DataSource = objResult.ResultDt;
                gvFCIPLogReport.DataBind();
                if (gvFCIPLogReport.Rows.Count > 0)
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
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
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
            string filename = "FCIPLog_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvFCIPLogReport.AllowPaging = false;
            gvFCIPLogReport.GridLines = GridLines.Both;
            foreach (TableCell cell in gvFCIPLogReport.HeaderRow.Cells)
            {
                cell.BackColor = gvFCIPLogReport.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvFCIPLogReport.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvFCIPLogReport.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvFCIPLogReport.RowStyle.BackColor;
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

            gvFCIPLogReport.RenderControl(hw);
            string strSubTitle = "FCIP LOG REPORT";
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

        #region Export To Word Button Click
        protected void imgbtnDoc_OnClick(object sender, EventArgs e)
        {
            string filename = "FCIPLog_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".doc";
            Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            Response.Charset = "";
            Response.ContentType = "application/msword ";

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvFCIPLogReport.AllowPaging = false;
            gvFCIPLogReport.GridLines = GridLines.Both;
            foreach (TableCell cell in gvFCIPLogReport.HeaderRow.Cells)
            {
                cell.BackColor = gvFCIPLogReport.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvFCIPLogReport.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvFCIPLogReport.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvFCIPLogReport.RowStyle.BackColor;
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
            // gvFCIPLogReport.Columns[0].Visible = false;
            gvFCIPLogReport.RenderControl(hw);

            string strSubTitle = "FCIP LOG REPORT";
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
                string filename = "FCIP_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    gvFCIPLogReport.AllowPaging = false;
                    //   this.MilkStorageGrid();

                    gvFCIPLogReport.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in gvFCIPLogReport.HeaderRow.Cells)
                    {
                        cell.BackColor = gvFCIPLogReport.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvFCIPLogReport.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvFCIPLogReport.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvFCIPLogReport.RowStyle.BackColor;
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
                    //gvFCIPLogReport.Columns[0].Visible = false;
                    gvFCIPLogReport.RenderControl(hw);

                    string strSubTitle = "FCIP LOG REPORT";
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
                    // string style = @"<!--mce:2-->";
                    StringReader sr = new StringReader(content);
                    Document pdfDoc = new Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
                    pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4_LANDSCAPE.Rotate());
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.Write(pdfDoc);
                    gvFCIPLogReport.GridLines = GridLines.None;
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

        #region FCIP Log Report Row Created
        protected void gvFCIPLogReport_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                    TableHeaderCell headerTableCell = new TableHeaderCell();

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Sr No";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Date";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Start Time";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Stop Time";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Total Time";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Line No";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Route No";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Route Name";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Receipe";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Flow SP (Ltr/hr)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.ColumnSpan = 5;
                    headerTableCell.Text = "LYE RINSE";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.ColumnSpan = 5;
                    headerTableCell.Text = "ACID RINSE";
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.ColumnSpan = 4;
                    headerTableCell.Text = "INTERMEDIATE RINSE";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.ColumnSpan = 4;
                    headerTableCell.Text = "FINAL RINSE";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.ColumnSpan = 3;
                    headerTableCell.Text = "STERILIZATION";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.ColumnSpan = 1;
                    headerTableCell.Text = "SANITIZATION";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "STATUS";
                    headerRow1.Controls.Add(headerTableCell);

                    TableHeaderCell headerCell1;
                    TableHeaderCell headerCell2;
                    TableHeaderCell headerCell3;
                    TableHeaderCell headerCell4;
                    TableHeaderCell headerCell5;
                    TableHeaderCell headerCell6;
                    TableHeaderCell headerCell7;
                    TableHeaderCell headerCell8;
                    TableHeaderCell headerCell9;
                    TableHeaderCell headerCell10;
                    TableHeaderCell headerCell11;
                    //TableHeaderCell headerCell12;
                    TableHeaderCell headerCell13;
                    TableHeaderCell headerCell14;
                    TableHeaderCell headerCell15;
                    TableHeaderCell headerCell16;
                    //TableHeaderCell headerCell17;
                    TableHeaderCell headerCell18;
                    TableHeaderCell headerCell19;
                    TableHeaderCell headerCell20;
                    TableHeaderCell headerCell21;
                    TableHeaderCell headerCell22;
                    TableHeaderCell headerCell23;
                    TableHeaderCell headerCell24;
                    TableHeaderCell headerCell25;


                    headerCell1 = new TableHeaderCell();
                    headerCell2 = new TableHeaderCell();
                    headerCell3 = new TableHeaderCell();
                    headerCell4 = new TableHeaderCell();
                    headerCell5 = new TableHeaderCell();
                    headerCell6 = new TableHeaderCell();
                    headerCell7 = new TableHeaderCell();
                    headerCell8 = new TableHeaderCell();
                    headerCell9 = new TableHeaderCell();
                    headerCell10 = new TableHeaderCell();
                    headerCell11 = new TableHeaderCell();
                    //headerCell12 = new TableHeaderCell();
                    headerCell13 = new TableHeaderCell();
                    headerCell14 = new TableHeaderCell();
                    headerCell15 = new TableHeaderCell();
                    headerCell16 = new TableHeaderCell();
                   // headerCell17 = new TableHeaderCell();
                    headerCell18 = new TableHeaderCell();
                    headerCell19 = new TableHeaderCell();
                    headerCell20 = new TableHeaderCell();
                    headerCell21 = new TableHeaderCell();
                    headerCell22 = new TableHeaderCell();
                    headerCell23 = new TableHeaderCell();
                    headerCell24 = new TableHeaderCell();
                    headerCell25 = new TableHeaderCell();

                    headerCell1.Text = "Step Time (sec)";
                    headerCell2.Text = "Temp SP(Deg C)";
                    headerCell3.Text = "Return Temp (Deg C)";
                    headerCell4.Text = "LYE SP (ms/cm)";
                    headerCell5.Text = "Return Cond.(ms/cm)";
                    headerCell6.Text = "Step Time (sec)";
                    headerCell7.Text = "Temp SP (Deg C)";
                    headerCell8.Text = "Return Temp (Deg C)";
                    headerCell9.Text = "Acid SP (ms/cm)";
                    headerCell10.Text = "Return Cond. (ms/cm)";
                    headerCell11.Text = "Step Time (sec)";
                   // headerCell12.Text = "Temp SP";
                    headerCell13.Text = "Return Temp (Deg C)";
                    headerCell14.Text = "Cond SP (Deg C)";
                    headerCell15.Text = "Return Cond.(ms/cm)";
                    headerCell16.Text = "Step Time(sec)";
                   // headerCell17.Text = "Temp SP";
                    headerCell18.Text = "Return Temp (Deg C)";
                    headerCell19.Text = "Cond SP (Deg C)";
                    headerCell20.Text = "Return Cond.(ms/cm)";
                    headerCell21.Text = "Step Time (sec)";
                    headerCell22.Text = "Temp SP (Deg C)";
                    headerCell23.Text = "Return Temp (Deg C)";
                    headerCell24.Text = "Step Time (sec)";


                    headerRow2.Controls.Add(headerCell1);
                    headerRow2.Controls.Add(headerCell2);
                    headerRow2.Controls.Add(headerCell3);
                    headerRow2.Controls.Add(headerCell4);
                    headerRow2.Controls.Add(headerCell5);
                    headerRow2.Controls.Add(headerCell6);
                    headerRow2.Controls.Add(headerCell7);
                    headerRow2.Controls.Add(headerCell8);
                    headerRow2.Controls.Add(headerCell9);
                    headerRow2.Controls.Add(headerCell10);
                    headerRow2.Controls.Add(headerCell11);
                    //headerRow2.Controls.Add(headerCell12);
                    headerRow2.Controls.Add(headerCell13);
                    headerRow2.Controls.Add(headerCell14);
                    headerRow2.Controls.Add(headerCell15);
                    headerRow2.Controls.Add(headerCell16);
                    //headerRow2.Controls.Add(headerCell17);
                    headerRow2.Controls.Add(headerCell18);
                    headerRow2.Controls.Add(headerCell19);
                    headerRow2.Controls.Add(headerCell20);
                    headerRow2.Controls.Add(headerCell21);
                    headerRow2.Controls.Add(headerCell21);
                    headerRow2.Controls.Add(headerCell22);
                    headerRow2.Controls.Add(headerCell23);
                    headerRow2.Controls.Add(headerCell24);


                    gvFCIPLogReport.Controls[0].Controls.AddAt(0, headerRow2);
                    gvFCIPLogReport.Controls[0].Controls.AddAt(0, headerRow1);
                }
            }
        }
        #endregion
    }
}