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
using System.Drawing;
using System.Web;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
//using Word = Microsoft.Office.Interop.Word;

namespace GEA_Ajmer.ReportUI
{
    public partial class TCIPLogReport : Page
    {
        //private Word.Application wordApp;
        //Word.Document aDoc = null;
        private static ILog log = LogManager.GetLogger(typeof(TCIPLogReport));

        #region Page Load
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
        
        #region Go Button Click Event
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            try
            {
                LogBl objLogBl = new LogBl();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                var objResult = objLogBl.TCIPLogReport(dtFromDateTime, dtToDateTime);
                gvTCIPLogReport.DataSource = objResult.ResultDt;
                gvTCIPLogReport.DataBind();
                if (gvTCIPLogReport.Rows.Count > 0)
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
            string filename = "TCIPLog_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".doc";
            Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            Response.Charset = "";
            Response.ContentType = "application/msword ";

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvTCIPLogReport.AllowPaging = false;
            gvTCIPLogReport.GridLines = GridLines.Both;
            foreach (TableCell cell in gvTCIPLogReport.HeaderRow.Cells)
            {
                cell.BackColor = gvTCIPLogReport.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvTCIPLogReport.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvTCIPLogReport.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvTCIPLogReport.RowStyle.BackColor;
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
            // gvTCIPLogReport.Columns[0].Visible = false;
            gvTCIPLogReport.RenderControl(hw);

            string strSubTitle = "TCIP LOG REPORT";
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
            string filename = "TCIPLog_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvTCIPLogReport.AllowPaging = false;
            gvTCIPLogReport.GridLines = GridLines.Both;
            foreach (TableCell cell in gvTCIPLogReport.HeaderRow.Cells)
            {
                cell.BackColor = gvTCIPLogReport.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvTCIPLogReport.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvTCIPLogReport.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvTCIPLogReport.RowStyle.BackColor;
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

            gvTCIPLogReport.RenderControl(hw);
            string strSubTitle = "TCIP LOG REPORT";
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
                string filename = "TCIP_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    gvTCIPLogReport.AllowPaging = false;
                    //   this.MilkStorageGrid();

                    gvTCIPLogReport.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in gvTCIPLogReport.HeaderRow.Cells)
                    {
                        cell.BackColor = gvTCIPLogReport.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvTCIPLogReport.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvTCIPLogReport.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvTCIPLogReport.RowStyle.BackColor;
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
                    //gvTCIPLogReport.Columns[0].Visible = false;
                    gvTCIPLogReport.RenderControl(hw);

                    string strSubTitle = "TCIP LOG REPORT";
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
                    gvTCIPLogReport.GridLines = GridLines.None;
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



        #region CreateWordDocument Method
        //private void CreateWordDocument(object fileName, object saveAs, string strType)
        //{
        //    try
        //    {
        //        fileName = Server.MapPath("../template/" + fileName);
        //        object missing = System.Reflection.Missing.Value;
        //        object outputFileName = Server.MapPath("../output/" + saveAs);
        //        object fileFormat;

        //        if (File.Exists((string)fileName))
        //        {
        //            DateTime today = DateTime.Now;

        //            object readOnly = false;
        //            object isVisible = false;
        //            wordApp = new Word.Application();
        //            aDoc = null;
        //            wordApp.Visible = false;

        //            aDoc = wordApp.Documents.Open(ref @fileName, ref missing,
        //                ref readOnly, ref missing, ref missing, ref missing,
        //                ref missing, ref missing, ref missing, ref missing,
        //                ref missing, ref isVisible, ref missing, ref missing,
        //                ref missing, ref missing);

        //            aDoc.Activate();

        //            IList<int> lstTableCounts = new List<int>();
        //            for (int i = 1; i <= aDoc.Tables.Count; i++)
        //            {
        //                Word.Cell cell = aDoc.Tables[i].Cell(1, 1);

        //                if (cell.Range.Text.Contains("<lblMultiResults>"))
        //                {
        //                    lstTableCounts.Add(i);
        //                }
        //            }
        //            int[] inttablecounts = lstTableCounts.ToArray();
        //            FindAndReplace(wordApp, "<FromDate>", txtFromDate.Text);
        //            FindAndReplace(wordApp, "<ToDate>", txtToDate.Text);
        //            FindAndReplace(wordApp, "<FromTime>", txtFromTime.Text);
        //            FindAndReplace(wordApp, "<ToTime>", txtToTime.Text);

        //            if (gvReport2.Rows.Count > 0)
        //            {
        //                foreach (var d in inttablecounts)
        //                {
        //                    Word.Table objTable = aDoc.Tables[d];

        //                    for (int i = 1; i < gvReport2.Rows.Count; i++)
        //                    {
        //                        objTable.Rows.Add(objTable.Rows[i + 3]);
        //                        for (int j = 1; j <= objTable.Columns.Count; j++)
        //                        {
        //                            objTable.Cell(i + 3, j).Range.Text = gvReport2.Rows[i - 1].Cells[j - 1].Text.Replace("&nbsp;", "");
        //                        }
        //                    }
        //                    for (int i = 1; i <= objTable.Columns.Count; i++)
        //                    {
        //                        objTable.Cell(gvReport2.Rows.Count + 3, i).Range.Text = gvReport2.Rows[gvReport2.Rows.Count - 1].Cells[i - 1].Text.Replace("&nbsp;", "");
        //                    }
        //                    FindAndReplace(wordApp, "<lblMultiResults>", "");
        //                    object moveUnit = Microsoft.Office.Interop.Word.WdUnits.wdLine;
        //                    object moveCount = 1;
        //                    object moveExtend = Microsoft.Office.Interop.Word.WdMovementType.wdExtend;
        //                    int rowIndex = 2;
        //                    for (int coloumnIndex = 7; coloumnIndex >= 1; coloumnIndex--)
        //                    {
        //                        objTable.Cell(rowIndex, coloumnIndex).Range.Select();
        //                        wordApp.Selection.MoveDown(ref moveUnit, ref moveCount, ref moveExtend);
        //                        wordApp.Selection.Cells.Merge();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                FindAndReplace(wordApp, "<lblMultiResults>", "");
        //            }
        //            if (strType == "pdf")
        //                fileFormat = Word.WdSaveFormat.wdFormatPDF;
        //            else
        //                fileFormat = Word.WdSaveFormat.wdFormatDocumentDefault;
        //        }
        //        else
        //        {
        //            return;
        //        }

        //        aDoc.SaveAs(ref @outputFileName, ref fileFormat, ref missing, ref missing,
        //                ref missing, ref missing, ref missing, ref missing,
        //                ref missing, ref missing, ref missing, ref missing,
        //                ref missing, ref missing, ref missing, ref missing);

        //        object saveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
        //        aDoc.Close(ref saveChanges, ref missing, ref missing);
        //        wordApp.Quit();
        //        //System.Diagnostics.Process.Start(outputFileName.ToString());
        //        Response.Redirect("~/output/" + saveAs, false);
        //    }
        //    catch (Exception ex)
        //    {
        //        object missing = System.Reflection.Missing.Value;
        //        aDoc.Close(ref missing, ref missing, ref missing);
        //        throw ex;
        //    }
        //}
        #endregion

        #region FindAndReplace Method
        //private void FindAndReplace(Word.Application WordApp, object findText, object replaceWithText)
        //{
        //    object matchCase = true;
        //    object matchWholeWord = true;
        //    object matchWildCards = false;
        //    object matchSoundsLike = false;
        //    object nmatchAllWordForms = false;
        //    object forward = true;
        //    object format = false;
        //    object matchKashida = false;
        //    object matchDiacritics = false;
        //    object matchAlefHamza = false;
        //    object matchControl = false;
        //    object read_only = false;
        //    object visible = true;
        //    object replace = 2;
        //    object wrap = 1;

        //    WordApp.Selection.Find.Execute(ref findText,
        //        ref matchCase, ref matchWholeWord,
        //        ref matchWildCards, ref matchSoundsLike,
        //        ref nmatchAllWordForms, ref forward,
        //        ref wrap, ref format, ref replaceWithText,
        //        ref replace, ref matchKashida,
        //        ref matchDiacritics, ref matchAlefHamza,
        //        ref matchControl);
        //}
        #endregion

        #region VerifyRenderingInServerForm
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        #endregion

        #region TCIP Log Report Rowcreated
        protected void gvTCIPLogReport_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
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
                    headerTableCell.Text = "Tanker No";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Receipe";
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
                   // headerCell12 = new TableHeaderCell();
                    headerCell13 = new TableHeaderCell();
                    headerCell14 = new TableHeaderCell();
                    headerCell15 = new TableHeaderCell();
                    headerCell16 = new TableHeaderCell();
                    //headerCell17 = new TableHeaderCell();
                    headerCell18 = new TableHeaderCell();
                    headerCell19 = new TableHeaderCell();
                    headerCell20 = new TableHeaderCell();
                    headerCell21 = new TableHeaderCell();
                    headerCell22 = new TableHeaderCell();
                    headerCell23 = new TableHeaderCell();
                    headerCell24 = new TableHeaderCell();
                    headerCell25 = new TableHeaderCell();

                    headerCell1.Text = "Step Time (sec)";
                    headerCell2.Text = "Temp SP (Deg C)";
                    headerCell3.Text = "Return Temp (Deg C)";
                    headerCell4.Text = "LYE SP (ms/cm)";
                    headerCell5.Text = "Return Cond.(ms/cm)";
                    headerCell6.Text = "Step Time (sec)";
                    headerCell7.Text = "Temp SP (Deg C)";
                    headerCell8.Text = "Return Temp (Deg C)";
                    headerCell9.Text = "Acid SP (ms/cm)";
                    headerCell10.Text = "Return Cond. (ms/cm)";
                    headerCell11.Text = "Step Time (sec)";
                    //headerCell12.Text = "Temp SP";
                    headerCell13.Text = "Return Temp (Deg C)";
                    headerCell14.Text = "Cond. SP (Deg C)";
                    headerCell15.Text = "Return Cond. (ms/cm)";
                    headerCell16.Text = "Step Time (sec)";
                   // headerCell17.Text = "Temp SP";
                    headerCell18.Text = "Return Temp (Deg C)";
                    headerCell19.Text = "Cond. SP (Deg C)";
                    headerCell20.Text = "Return Cond. (ms/cm)";
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
                   // headerRow2.Controls.Add(headerCell17);
                    headerRow2.Controls.Add(headerCell18);
                    headerRow2.Controls.Add(headerCell19);
                    headerRow2.Controls.Add(headerCell20);
                    headerRow2.Controls.Add(headerCell21);
                    headerRow2.Controls.Add(headerCell21);
                    headerRow2.Controls.Add(headerCell22);
                    headerRow2.Controls.Add(headerCell23);
                    headerRow2.Controls.Add(headerCell24);
                    
                    gvTCIPLogReport.Controls[0].Controls.AddAt(0, headerRow2);
                    gvTCIPLogReport.Controls[0].Controls.AddAt(0, headerRow1);
                }
            }
        }
#endregion
    }
}