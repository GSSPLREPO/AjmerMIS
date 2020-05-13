using System;
using System.Data;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GEA_Ajmer.BL;
using log4net;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text;
using GEA_Ajmer.Common;
using Word = Microsoft.Office.Interop.Word;
using System.Drawing;

namespace GEA_Ajmer.ReportUI
{
    public partial class CipLogReport : System.Web.UI.Page
    {
        private Word.Application wordApp;
        Word.Document aDoc = null;
        DataTable dtCIPLog = new DataTable();

        const string msgFormat = "table[{0}], tr[{1}], td[{2}], a: {3}, b: {4}";
        const string table_pattern = "<table.*?>(.*?)</table>";
        const string tr_pattern = "<tr.*?>(.*?)</tr>";
        const string td_pattern = "<td.*?>(.*?)</td>";
        const string a_pattern = "<a href=\"(.*?)\"></a>";
        const string b_pattern = "<b>(.*?)</b>";

        private static ILog log = LogManager.GetLogger(typeof(UtilityStatusReport));
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divExport.Visible = divNo.Visible = false;
                //CipLog();
            }
        }


        #region export to PDF
        protected void imgbtnPDF_OnClick(object sender, EventArgs e)
        {

            try
            {
                string filename = "CIP_LogSheet_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                //gvCIPReport.AllowPaging = false;
                //gvCIPReport.GridLines = GridLines.Both;
                //gvCIPReport.RenderControl(hw);
                gvCIPReport.AllowPaging = false;
                //   this.MilkStorageGrid();

                gvCIPReport.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvCIPReport.HeaderRow.Cells)
                {
                    cell.BackColor = gvCIPReport.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvCIPReport.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvCIPReport.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvCIPReport.RowStyle.BackColor;
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
                //gvCIPReport.Columns[0].Visible = false;
                gvCIPReport.RenderControl(hw);
                string strSubTitle = "CIP LOG SHEET REPORT";
                string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/logo.gif";
                string content = "<div align='left' style='font-family:verdana;font-size:16px'><img src='" 
                    + strPath + "'/></div><div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                     "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/>" +
                        "<span align='center' style='font-family:verdana;font-size:13px'><strong>" + strSubTitle + "</strong></span><br/>" +
                        "<div align='center' style='font-family:verdana;font-size:12px'><strong>From Date :</strong>" +
                    DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                     "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
                     DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                     "</div><br/> "
                     + sw.ToString() + "<br/></div>";
                StringBuilder sb = new StringBuilder(content);
                StringReader sr = new StringReader(sb.ToString());

                Document pdfDoc = new Document(iTextSharp.text.PageSize.A3, 10f, 10f, 10f, 0f);
                //pdfDoc.SetPageSize(iTextSharp.text.PageSize.A3.Rotate());
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                gvCIPReport.GridLines = GridLines.None;
                Response.End();
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
        private void CreateWordDocument(object fileName, object saveAs, string strType)
        {
            try
            {
                fileName = Server.MapPath("../template/" + fileName);
                object missing = System.Reflection.Missing.Value;
                object outputFileName = Server.MapPath("../output/" + saveAs);
                object fileFormat;

                if (File.Exists((string)fileName))
                {
                    DateTime today = DateTime.Now;

                    object readOnly = false;
                    object isVisible = false;
                    wordApp = new Word.Application();
                    aDoc = null;
                    wordApp.Visible = false;

                    aDoc = wordApp.Documents.Open(ref @fileName, ref missing,
                        ref readOnly, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref isVisible, ref missing, ref missing,
                        ref missing, ref missing);

                    aDoc.Activate();

                    IList<int> lstTableCounts = new List<int>();
                    for (int i = 1; i <= aDoc.Tables.Count; i++)
                    {
                        Word.Cell cell = aDoc.Tables[i].Cell(1, 1);

                        if (cell.Range.Text.Contains("<lblMultiResults>"))
                        {
                            lstTableCounts.Add(i);
                        }
                    }
                    int[] inttablecounts = lstTableCounts.ToArray();
                    FindAndReplace(wordApp, "<FromDate>", txtFromDate.Text);
                    FindAndReplace(wordApp, "<ToDate>", txtToDate.Text);
                    FindAndReplace(wordApp, "<FromTime>", txtFromTime.Text);
                    FindAndReplace(wordApp, "<ToTime>", txtToTime.Text);

                    if (gvCIPReport.Rows.Count > 0)
                    {
                        foreach (var d in inttablecounts)
                        {
                            Word.Table objTable = aDoc.Tables[d];

                            for (int i = 1; i < gvCIPReport.Rows.Count; i++)
                            {
                                objTable.Rows.Add(objTable.Rows[2]);
                                for (int j = 1; j <= objTable.Columns.Count; j++)
                                {
                                    objTable.Cell(i + 3, j).Range.Text = gvCIPReport.Rows[i - 1].Cells[j - 1].Text.Replace("&nbsp;", "");
                                }
                            }
                            for (int i = 1; i <= objTable.Columns.Count; i++)
                            {
                                objTable.Cell(gvCIPReport.Rows.Count + 3, i).Range.Text = gvCIPReport.Rows[gvCIPReport.Rows.Count - 1].Cells[i - 1].Text.Replace("&nbsp;", "");
                            }
                            FindAndReplace(wordApp, "<lblMultiResults>", "");
                            object moveUnit = Microsoft.Office.Interop.Word.WdUnits.wdLine;
                            object moveCount = 1;
                            object moveExtend = Microsoft.Office.Interop.Word.WdMovementType.wdExtend;
                            int rowIndex = 2;
                            for (int coloumnIndex = 7; coloumnIndex >= 1; coloumnIndex--)
                            {
                                objTable.Cell(rowIndex, coloumnIndex).Range.Select();
                                wordApp.Selection.MoveDown(ref moveUnit, ref moveCount, ref moveExtend);
                                wordApp.Selection.Cells.Merge();
                            }
                        }
                    }
                    else
                    {
                        FindAndReplace(wordApp, "<lblMultiResults>", "");
                    }
                    if (strType == "pdf")
                        fileFormat = Word.WdSaveFormat.wdFormatPDF;
                    else
                        fileFormat = Word.WdSaveFormat.wdFormatDocumentDefault;
                }
                else
                {
                    return;
                }

                aDoc.SaveAs(ref @outputFileName, ref fileFormat, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing);

                object saveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
                aDoc.Close(ref saveChanges, ref missing, ref missing);
                wordApp.Quit();
                //System.Diagnostics.Process.Start(outputFileName.ToString());
                // Response.Redirect("~/output/" + saveAs, false);
            }
            catch (Exception ex)
            {
                object missing = System.Reflection.Missing.Value;
                aDoc.Close(ref missing, ref missing, ref missing);
                throw ex;
            }
        }
        #endregion

        #region FindAndReplace Method
        private void FindAndReplace(Word.Application WordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object nmatchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            WordApp.Selection.Find.Execute(ref findText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike,
                ref nmatchAllWordForms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiacritics, ref matchAlefHamza,
                ref matchControl);
        }
        #endregion

        #region VerifyRenderingInServerForm
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        #endregion

        #region Export to Excel
        protected void imgbtnExcel_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string filename = "CIPLOG_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvCIPReport.AllowPaging = false;
                gvCIPReport.GridLines = GridLines.Both;
                gvCIPReport.RenderControl(hw);
                //string strTitle = "Sandvik Asia Pvt Ltd, Chiplun.";
                string strSubTitle = "CIP LOG SHEET REPORT";

                string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/logo.gif";
                string content = "<div align='center' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
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
                gvCIPReport.GridLines = GridLines.None;
                Response.Flush();
                Response.Clear();
                Response.End();
            }
            catch (Exception ex)
            {
                log.Error("Button EXCEL", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Oops! There is some technical issue. Please Contact to your administrator.');", true);
            }
        }
        #endregion

        #region Export to Word
        protected void imgbtnWord_OnClick(object sender, EventArgs e)
        {
            try
            {
                string filename = "CIPLOG_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".doc";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Charset = "";
                Response.ContentType = "application/msword ";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvCIPReport.AllowPaging = false;
                gvCIPReport.GridLines = GridLines.Both;
                gvCIPReport.RenderControl(hw);
                string strSubTitle = "CIP LOG SHEET REPORT";
                string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/logo.gif";
                string content = "<div align='center' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                    "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/>" +
                       "<span align='center' style='font-family:verdana;font-size:13px'><strong>" + strSubTitle + "</strong></span><br/>" +
                       "<div align='center' style='font-family:verdana;font-size:12px'><strong>From Date :</strong>" +
                   DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                    "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
                    DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
                    "</div><br/> "
                    + sw.ToString() + "<br/></div>";
                Response.Output.Write(content);
                gvCIPReport.GridLines = GridLines.None;
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
                log.Error("Button WORD", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Oops! There is some technical issue. Please Contact to your administrator.');", true);
            }
        }
        #endregion

        #region Button GO Click Event
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            try
            {
                CIPLogReportBL objCIPLogReportBL = new CIPLogReportBL();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                      CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                var objResult = objCIPLogReportBL.CIPLogReport(dtFromDateTime, dtToDateTime);
                gvCIPReport.DataSource = objResult.ResultDt;
                gvCIPReport.DataBind();
                ViewState["dtdata"] = objResult.ResultDt;
                if (gvCIPReport.Rows.Count > 0)
                {
                    divExport.Visible = true;
                    divNo.Visible = false;
                }
                else
                {
                    gvCIPReport.DataSource = null;
                    gvCIPReport.DataBind();
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

        protected void gvCIPReport_OnPreRender(object sender, EventArgs e)
        {

        }

        protected void gvCIPReport_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        

        #region PCIP Log Report Row Created
        protected void gvCIPReport_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
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
                    headerTableCell.Text = "Date";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "CIP Route";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "CIP Program";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "LYE";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "ACID";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "Sterilization";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "FINAL RINSE";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "CIP Start time";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "CIP End Time";
                    headerRow1.Controls.Add(headerTableCell);
                                    

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Total CIP Time";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.ColumnSpan = 2;
                    headerTableCell.Text = "CIP Status";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.ColumnSpan = 2;
                    headerTableCell.Text = "User Id";
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
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
                    //TableHeaderCell headerCell10;
                    //TableHeaderCell headerCell11;
                    //TableHeaderCell headerCell12;
                    //TableHeaderCell headerCell13;
                    //TableHeaderCell headerCell14;
                    //TableHeaderCell headerCell15;
                    //TableHeaderCell headerCell16;
                    //TableHeaderCell headerCell17;
                    //TableHeaderCell headerCell18;
                    //TableHeaderCell headerCell19;
                    //TableHeaderCell headerCell20;
                    //TableHeaderCell headerCell21;
                    //TableHeaderCell headerCell22;
                    //TableHeaderCell headerCell23;
                    //TableHeaderCell headerCell24;
                    //TableHeaderCell headerCell25;


                    headerCell1 = new TableHeaderCell();
                    headerCell2 = new TableHeaderCell();
                    headerCell3 = new TableHeaderCell();
                    headerCell4 = new TableHeaderCell();
                    headerCell5 = new TableHeaderCell();
                    headerCell6 = new TableHeaderCell();
                    headerCell7 = new TableHeaderCell();
                    headerCell8 = new TableHeaderCell();
                    headerCell9 = new TableHeaderCell();
                    //headerCell10 = new TableHeaderCell();
                    //headerCell11 = new TableHeaderCell();
                    //headerCell12 = new TableHeaderCell();
                    //headerCell13 = new TableHeaderCell();
                    //headerCell14 = new TableHeaderCell();
                    //headerCell15 = new TableHeaderCell();
                    //headerCell16 = new TableHeaderCell();
                    //headerCell17 = new TableHeaderCell();
                    //headerCell18 = new TableHeaderCell();
                    //headerCell19 = new TableHeaderCell();
                    //headerCell20 = new TableHeaderCell();
                    //headerCell21 = new TableHeaderCell();
                    //headerCell22 = new TableHeaderCell();
                    //headerCell23 = new TableHeaderCell();
                    //headerCell24 = new TableHeaderCell();
                    //headerCell25 = new TableHeaderCell();

                    headerCell1.Text = "Temp.";
                    headerCell2.Text = "Cond.";
                    headerCell3.Text = "Step Time";
                    headerCell4.Text = "Temp.";
                    headerCell5.Text = "Cond.";
                    headerCell6.Text = "Step Time";
                    headerCell7.Text = "Temp.";
                    headerCell8.Text = "Step Time";
                    headerCell9.Text = "Step Time";
                    //headerCell10.Text = "Return Cond. (ms/cm)";
                    //headerCell11.Text = "Step Time (sec)";
                    //headerCell12.Text = "Temp SP";
                    //headerCell13.Text = "Return AVG Temp (Deg C)";
                    //headerCell14.Text = "Lye SP";
                    //headerCell15.Text = "Return Cond. (ms/cm)";
                    //headerCell16.Text = "Step Time (sec)";
                    //headerCell17.Text = "Temp SP";
                    //headerCell18.Text = "Return AVG Temp (Deg C)";
                    //headerCell19.Text = "Acid SP";
                    //headerCell20.Text = "Return Cond. (ms/cm)";
                    //headerCell21.Text = "Step Time (sec)";
                    //headerCell22.Text = "Temp SP (Deg C)";
                    //headerCell23.Text = "Return Temp (Deg C)";
                    //headerCell24.Text = "Step Time (sec)";


                    headerRow2.Controls.Add(headerCell1);
                    headerRow2.Controls.Add(headerCell2);
                    headerRow2.Controls.Add(headerCell3);
                    headerRow2.Controls.Add(headerCell4);
                    headerRow2.Controls.Add(headerCell5);
                    headerRow2.Controls.Add(headerCell6);
                    headerRow2.Controls.Add(headerCell7);
                    headerRow2.Controls.Add(headerCell8);
                    headerRow2.Controls.Add(headerCell9);
                    //headerRow2.Controls.Add(headerCell10);
                    //headerRow2.Controls.Add(headerCell11);
                    //headerRow2.Controls.Add(headerCell12);
                    //headerRow2.Controls.Add(headerCell13);
                    //headerRow2.Controls.Add(headerCell14);
                    //headerRow2.Controls.Add(headerCell15);
                    //headerRow2.Controls.Add(headerCell16);
                    //headerRow2.Controls.Add(headerCell17);
                    //headerRow2.Controls.Add(headerCell18);
                    //headerRow2.Controls.Add(headerCell19);
                    //headerRow2.Controls.Add(headerCell20);
                    //headerRow2.Controls.Add(headerCell21);
                    //headerRow2.Controls.Add(headerCell21);
                    //headerRow2.Controls.Add(headerCell22);
                    //headerRow2.Controls.Add(headerCell23);
                    //headerRow2.Controls.Add(headerCell24);


                    gvCIPReport.Controls[0].Controls.AddAt(0, headerRow2);
                    gvCIPReport.Controls[0].Controls.AddAt(0, headerRow1);
                }
            }

        }
        #endregion
    }
}