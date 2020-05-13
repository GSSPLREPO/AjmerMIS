using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI;
using GEA_Ajmer.BL;
using GEA_Ajmer.Common;
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
    public partial class PCIPLogReport : PageBase
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
                var objResult = objLogBl.PCIPLogReport(dtFromDateTime, dtToDateTime);
                gvPCIPLogReport.DataSource = objResult.ResultDt;
                gvPCIPLogReport.DataBind();
                if (gvPCIPLogReport.Rows.Count > 0)
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

        #region Export to Word Button Click
        protected void imgbtnDoc_OnClick(object sender, EventArgs e)
        {
            string filename = "PCIPLog_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".doc";
            Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            Response.Charset = "";
            Response.ContentType = "application/msword ";

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvPCIPLogReport.AllowPaging = false;
            gvPCIPLogReport.GridLines = GridLines.Both;
            foreach (TableCell cell in gvPCIPLogReport.HeaderRow.Cells)
            {
                cell.BackColor = gvPCIPLogReport.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvPCIPLogReport.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvPCIPLogReport.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvPCIPLogReport.RowStyle.BackColor;
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
            // gvPCIPLogReport.Columns[0].Visible = false;
            gvPCIPLogReport.RenderControl(hw);

            string strSubTitle = "PCIP LOG REPORT";
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
            string filename = "PCIPLog_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvPCIPLogReport.AllowPaging = false;
            gvPCIPLogReport.GridLines = GridLines.Both;
            foreach (TableCell cell in gvPCIPLogReport.HeaderRow.Cells)
            {
                cell.BackColor = gvPCIPLogReport.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvPCIPLogReport.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvPCIPLogReport.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvPCIPLogReport.RowStyle.BackColor;
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

            gvPCIPLogReport.RenderControl(hw);
            string strSubTitle = "PCIP LOG REPORT";
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
                string filename = "PCIP_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    gvPCIPLogReport.AllowPaging = false;
                    //   this.MilkStorageGrid();

                    gvPCIPLogReport.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in gvPCIPLogReport.HeaderRow.Cells)
                    {
                        cell.BackColor = gvPCIPLogReport.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvPCIPLogReport.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvPCIPLogReport.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvPCIPLogReport.RowStyle.BackColor;
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
                    //gvPCIPLogReport.Columns[0].Visible = false;
                    gvPCIPLogReport.RenderControl(hw);

                    string strSubTitle = "PCIP LOG REPORT";
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
                    Document pdfDoc = new Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
                    pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4_LANDSCAPE.Rotate());
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.Write(pdfDoc);
                    gvPCIPLogReport.GridLines = GridLines.None;
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

        #region PCIP Log Report Row Created
        protected void gvPCIPLogReport_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
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
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerTableCell.ColumnSpan = 1;
                    headerTableCell.Text = "Sr No";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.ColumnSpan = 1;
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerTableCell.Text = "Date";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.ColumnSpan = 1;
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerTableCell.Text = "CIP Route";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.ColumnSpan = 1;
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerTableCell.Text = "CIP Program";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 3;
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerTableCell.Text = "LYE";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 3;
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerTableCell.Text = "ACID";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 2;
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerTableCell.Text = "Sterilization";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 1;
                    headerTableCell.Text = "FINAL RINSE";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.ColumnSpan = 1;
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerTableCell.Text = "CIP Start Time";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.ColumnSpan = 1;
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerTableCell.Text = "CIP End Time";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.ColumnSpan = 1;
                    headerTableCell.RowSpan = 2;
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerTableCell.Text = "Total CIP Time";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.ColumnSpan = 1;
                    headerTableCell.RowSpan = 2;
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerTableCell.Text = "CIP Status";
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.ColumnSpan = 1;
                    headerTableCell.RowSpan = 2;
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerTableCell.Text = "User Id";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
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

                    headerCell1 = new TableHeaderCell();
                    headerCell2 = new TableHeaderCell();
                    headerCell3 = new TableHeaderCell();
                    headerCell4 = new TableHeaderCell();
                    headerCell5 = new TableHeaderCell();
                    headerCell6 = new TableHeaderCell();
                    headerCell7 = new TableHeaderCell();
                    headerCell8 = new TableHeaderCell();
                    headerCell9 = new TableHeaderCell();
                    
                    headerCell1.Text = "Temp. (Deg C)";
                    headerCell1.HorizontalAlign = HorizontalAlign.Center;
                    headerCell1.VerticalAlign = VerticalAlign.Middle;
                    headerCell2.Text = "Cond. (ms/cm)";
                    headerCell2.HorizontalAlign = HorizontalAlign.Center;
                    headerCell2.VerticalAlign = VerticalAlign.Middle;
                    headerCell3.Text = "Step Time (sec)";
                    headerCell3.HorizontalAlign = HorizontalAlign.Center;
                    headerCell3.VerticalAlign = VerticalAlign.Middle;
                    headerCell4.Text = "Temp. (Deg C)";
                    headerCell4.HorizontalAlign = HorizontalAlign.Center;
                    headerCell4.VerticalAlign = VerticalAlign.Middle;
                    headerCell5.Text = "Cond. (ms/cm)";
                    headerCell5.HorizontalAlign = HorizontalAlign.Center;
                    headerCell5.VerticalAlign = VerticalAlign.Middle;
                    headerCell6.Text = "Step Time (sec)";
                    headerCell6.HorizontalAlign = HorizontalAlign.Center;
                    headerCell6.VerticalAlign = VerticalAlign.Middle;
                    headerCell7.Text = "Temp. (Deg C)";
                    headerCell7.HorizontalAlign = HorizontalAlign.Center;
                    headerCell7.VerticalAlign = VerticalAlign.Middle;
                    headerCell8.Text = "Cond. (ms/cm)";
                    headerCell8.HorizontalAlign = HorizontalAlign.Center;
                    headerCell8.VerticalAlign = VerticalAlign.Middle;
                    headerCell9.Text = "Step Time (sec)";
                    headerCell9.HorizontalAlign = HorizontalAlign.Center;
                    headerCell9.VerticalAlign = VerticalAlign.Middle;

                    headerRow2.Controls.Add(headerCell1);
                    headerRow2.Controls.Add(headerCell2);
                    headerRow2.Controls.Add(headerCell3);
                    headerRow2.Controls.Add(headerCell4);
                    headerRow2.Controls.Add(headerCell5);
                    headerRow2.Controls.Add(headerCell6);
                    headerRow2.Controls.Add(headerCell7);
                    headerRow2.Controls.Add(headerCell8);
                    headerRow2.Controls.Add(headerCell9);
                    
                    gvPCIPLogReport.Controls[0].Controls.AddAt(0, headerRow2);
                    gvPCIPLogReport.Controls[0].Controls.AddAt(0, headerRow1);
                }
            }

        }
        #endregion
    }
}