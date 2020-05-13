﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GEA_Ajmer.BL;
using GEA_Ajmer.Common;
using log4net;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing;
using System.Globalization;

namespace GEA_Ajmer.ReportUI
{

    public partial class UtilityHotWaterStatus : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger(typeof(UtilityStatusReport));

        #region Page_Load
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

        #region Veify Control For check runat=server
        /* This is because when export to pdf, word, excel of gridview 
         * than it is require to check that control is placed inside runat=server. either it will through Exception */
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control); 
        }
        #endregion

        #region Button Go Click Event
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            try
            {
                LogBl objLogBl = new LogBl();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture);
                var objResult = objLogBl.UtilityHotWaterStatusReport(dtFromDateTime, dtToDateTime);
                gvReport2.DataSource = objResult.ResultDt;
                gvReport2.DataBind();
                if (gvReport2.Rows.Count > 0)
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
        protected void imgbtnWord_OnClick(object sender, EventArgs e)
        {

            try
            {
                string filename = "UtilityHotWaterStatusReport.docx";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Charset = "";
                Response.ContentType = "application/msword ";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvReport2.AllowPaging = false;
                gvReport2.GridLines = System.Web.UI.WebControls.GridLines.Both;
                gvReport2.RenderControl(hw);
                string content = "<div align='center' style='font-family:verdana;font-size:13px'><span style='font-size:16px;font-weight:bold;color:Maroon;'>Utility Hot Water Status Report</span><br/><span style='font-size:13px;font-weight:bold'></span><br/><span align='center' style='font-family:verdana;font-size:11px'><strong>Date :</strong>" + System.DateTime.Now.ToShortDateString() + "</span><br/><span align='center' style='font-family:verdana;font-size:11px'><br/><br/><br/> " + sw.ToString() + "<br/></div>";
                Response.Output.Write(content);
                gvReport2.GridLines = System.Web.UI.WebControls.GridLines.None;
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

        #region Export to Excel Button Click
        protected void imgbtnExcel_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.AddHeader("content-disposition", "attachment;filename=UtilityHotWaterStatusReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvReport2.AllowPaging = false;
                gvReport2.RenderControl(hw);
                string strTitle = "Panchamrut Dairy, Taloja";

                string Date = DateTime.UtcNow.AddHours(5.5).ToString();
                string strSubTitle = "Utility Hot Water Status Report</br> as on " + Date;

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
                  + sw.ToString() + "<br/></div>";

                Response.Output.Write(content);
                Response.Flush();
                Response.End();
            }
            catch (Exception)
            {
            }
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
                string filename = "UtilityHotWaterStatus_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    gvReport2.AllowPaging = false;
                    //   this.MilkStorageGrid();

                    gvReport2.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in gvReport2.HeaderRow.Cells)
                    {
                        cell.BackColor = gvReport2.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvReport2.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvReport2.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvReport2.RowStyle.BackColor;
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
                    gvReport2.RenderControl(hw);

                    string strSubTitle = "Utility Hot Water Status REPORT";
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
                      + sw.ToString() + "<br/></div>";
                    // string style = @"<!--mce:2-->";
                    StringReader sr = new StringReader(content);
                    Document pdfDoc = new Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
                    pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.Write(pdfDoc);
                    gvReport2.GridLines = GridLines.None;
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
            //CreateWordDocument(filename, saveAs, strType);
        }
        #endregion


        #region gvReport2_RowCreated
        protected void gvReport2_RowCreated(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    GridViewRow headerRow3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                    TableHeaderCell headerTableCell = new TableHeaderCell();

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 3;
                    headerTableCell.Text = "Date";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 3;
                    headerTableCell.Text = "Time";

                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    // headerTableCell.RowSpan = 3;
                    headerTableCell.ColumnSpan = 4;

                    headerTableCell.Text = "Process Section";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    //headerTableCell.RowSpan = 2;
                    headerTableCell.ColumnSpan = 4;
                    headerTableCell.Text = "Packing Section";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    //headerTableCell.RowSpan = 2;
                    headerTableCell.ColumnSpan = 4;
                    headerTableCell.Text = "CIP Section";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    //headerTableCell.RowSpan = 2;
                    headerTableCell.ColumnSpan = 4;
                    headerTableCell.Text = "CURD Section";
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
                    TableHeaderCell headerCell12;

                    TableHeaderCell headerCell13;
                    TableHeaderCell headerCell14;
                    TableHeaderCell headerCell15;
                    TableHeaderCell headerCell16;

                    TableHeaderCell headerCell17;
                    TableHeaderCell headerCell18;
                    TableHeaderCell headerCell19;
                    TableHeaderCell headerCell20;

                    TableHeaderCell headerCell21;
                    TableHeaderCell headerCell22;
                    TableHeaderCell headerCell23;
                    TableHeaderCell headerCell24;

                    TableHeaderCell headerCell25;
                    TableHeaderCell headerCell26;
                    TableHeaderCell headerCell27;
                    TableHeaderCell headerCell28;

                    TableHeaderCell headerCell29;
                    TableHeaderCell headerCell30;
                    TableHeaderCell headerCell31;
                    TableHeaderCell headerCell32;

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
                    headerCell12 = new TableHeaderCell();

                    headerCell13 = new TableHeaderCell();
                    headerCell14 = new TableHeaderCell();
                    headerCell15 = new TableHeaderCell();
                    headerCell16 = new TableHeaderCell();


                    headerCell17 = new TableHeaderCell();
                    headerCell18 = new TableHeaderCell();
                    headerCell19 = new TableHeaderCell();
                    headerCell20 = new TableHeaderCell();

                    headerCell21 = new TableHeaderCell();
                    headerCell22 = new TableHeaderCell();
                    headerCell23 = new TableHeaderCell();
                    headerCell24 = new TableHeaderCell();

                    headerCell25 = new TableHeaderCell();
                    headerCell26 = new TableHeaderCell();
                    headerCell27 = new TableHeaderCell();
                    headerCell28 = new TableHeaderCell();

                    headerCell29 = new TableHeaderCell();
                    headerCell30 = new TableHeaderCell();
                    headerCell31 = new TableHeaderCell();
                    headerCell32 = new TableHeaderCell();

                    headerCell1.Text = "Pressure";
                    headerCell2.Text = "Flow";
                    headerCell3.Text = "Supply Temp";
                    headerCell4.Text = "Return Temp";

                    headerCell5.Text = "Pressure";
                    headerCell6.Text = "Flow";
                    headerCell7.Text = "Supply Temp";
                    headerCell8.Text = "Return Temp";

                    headerCell9.Text = "Pressure";
                    headerCell10.Text = "Flow";
                    headerCell11.Text = "Supply Temp";
                    headerCell12.Text = "Return Temp";

                    headerCell13.Text = "Pressure";
                    headerCell14.Text = "Flow";
                    headerCell15.Text = "Supply Temp";
                    headerCell16.Text = "Return Temp";

                    headerCell17.Text = "Bar";
                    headerCell18.Text = "Lit/hr";
                    headerCell19.Text = "Deg C";
                    headerCell20.Text = "Deg C";

                    headerCell21.Text = "Bar";
                    headerCell22.Text = "Lit/hr";
                    headerCell23.Text = "Deg C";
                    headerCell24.Text = "Deg C";

                    headerCell25.Text = "Bar";
                    headerCell26.Text = "Lit/hr";
                    headerCell27.Text = "Deg C";
                    headerCell28.Text = "Deg C";

                    headerCell29.Text = "Bar";
                    headerCell30.Text = "Lit/hr";
                    headerCell31.Text = "Deg C";
                    headerCell32.Text = "Deg C";

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
                    headerRow2.Controls.Add(headerCell12);
                    headerRow2.Controls.Add(headerCell13);
                    headerRow2.Controls.Add(headerCell14);
                    headerRow2.Controls.Add(headerCell15);
                    headerRow2.Controls.Add(headerCell16);


                    headerRow3.Controls.Add(headerCell17);
                    headerRow3.Controls.Add(headerCell18);
                    headerRow3.Controls.Add(headerCell19);
                    headerRow3.Controls.Add(headerCell20);
                    headerRow3.Controls.Add(headerCell21);
                    headerRow3.Controls.Add(headerCell22);
                    headerRow3.Controls.Add(headerCell23);
                    headerRow3.Controls.Add(headerCell24);
                    headerRow3.Controls.Add(headerCell25);
                    headerRow3.Controls.Add(headerCell26);
                    headerRow3.Controls.Add(headerCell27);
                    headerRow3.Controls.Add(headerCell28);
                    headerRow3.Controls.Add(headerCell29);
                    headerRow3.Controls.Add(headerCell30);
                    headerRow3.Controls.Add(headerCell31);
                    headerRow3.Controls.Add(headerCell32);

                    gvReport2.Controls[0].Controls.AddAt(0, headerRow3);
                    gvReport2.Controls[0].Controls.AddAt(0, headerRow2);
                    gvReport2.Controls[0].Controls.AddAt(0, headerRow1);
                }
            }
        }
        #endregion
    }




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
    //                    for (int coloumnIndex = 6; coloumnIndex >= 1; coloumnIndex--)
    //                    {
    //                        if (coloumnIndex != 4)
    //                        {
    //                            objTable.Cell(rowIndex, coloumnIndex).Range.Select();
    //                            wordApp.Selection.MoveDown(ref moveUnit, ref moveCount, ref moveExtend);
    //                            wordApp.Selection.Cells.Merge();
    //                        }
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


}