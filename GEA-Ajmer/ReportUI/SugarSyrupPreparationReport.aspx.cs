﻿using System;
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
using GEA_Ajmer.Common;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Drawing;
using System.Text;

namespace GEA_Ajmer.ReportUI
{
    public partial class SugarSyrupPreparationReport : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger(typeof(SugarSyrupPreparationReport));
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divExport.Visible = false;
                //divNo.Visible = false;
                divExport1.Visible = false;
                divRecord.Visible = false;
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                // SugarSyrupReport();
            }
        }

        #region VerifyRenderingInServerForm
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        #endregion

        #region Export to Word Button Click
        
        #endregion

        #region Export to Excel Button Click
        protected void imgbtnExcel_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string filename = "SugarSyrupPreprationReport" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvSugarSyrup.AllowPaging = false;
                gvSugarSyrup.GridLines = GridLines.Both;
                foreach (TableCell cell in gvSugarSyrup.HeaderRow.Cells)
                {
                    cell.BackColor = gvSugarSyrup.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvSugarSyrup.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvSugarSyrup.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvSugarSyrup.RowStyle.BackColor;
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

                gvSugarSyrup.RenderControl(hw);
                string strSubTitle = "SUGAR SYRUP PREPRATION REPORT";

                string content = "<div align='center'><img align='left' style='height: 40px; width: 109px' src='" + Session[ApplicationSession.Logo] + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/></div>" +
                  "<div align='center' style='font-family:verdana;font-size:11px'><strong>From Date :</strong>" +
                (DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToShortDateString() +
                 "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
                 (DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToShortDateString() +
                "</div><br/><div align='center' style='font-family:verdana;font-size:11px'><span style='font-size:11px;color:Maroon;'>" + strSubTitle + "</ span><br/>" +
                 "<br/>" + sw.ToString() + "<br/></div>";

                string style = @"<!--mce:2-->";
                Response.Write(style);
                Response.Output.Write(content);
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

        #region Export to PDF Button Click
        protected void imgbtnPDF_OnClick(object sender, EventArgs e)
        {
            try
            {
                string text = Session[ApplicationSession.OrganisationName].ToString();
                string text1 = Session[ApplicationSession.OrganisationAddress].ToString();
                string text2 = "Sugar Syrup Prepration Report";

                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<div align='center' style='font-size:16px;font-weight:bold;color:Black;'>");
                        sb.Append(text);
                        sb.Append("</div>");
                        sb.Append("<br/>");
                        sb.Append("<div align='center' style='font-size:13px;font-weight:bold;color:Black;'>");
                        sb.Append(text1);
                        sb.Append("</div>");
                        sb.Append("<br/>");
                        sb.Append("<div align='center' style='font-size:26px;color:Maroon;'><b>");
                        sb.Append(text2);
                        sb.Append("</b></div>");
                        sb.Append("<br/>");

                        string content = "<table style='display: table;width: 900px; clear:both;'> <tr> <th colspan='10' style='float: left;padding-left: 220px;'><div align='left'><strong>Start Date: </strong>" + txtFromDate.Text + "</div></th>";

                        content += "<th style='float:left; padding-left:-210px;'></th>";

                        content += "<th style='float:left; padding-left:-210px;'></th>";

                        content += "<th colspan='1' align='left' style=' float: left; padding-left:-200px;'><strong> End Date: </strong>" + //colspan='4' 
                        txtToDate.Text + "</th>" +
                        "</tr></table>";
                        sb.Append(content);
                        sb.Append("<br/>");

                        PdfPTable pdfPTable = new PdfPTable(gvSugarSyrup.HeaderRow.Cells.Count);

                        //TableCell headerCell = new TableCell();

                        PdfPCell headerCell = new PdfPCell(new Phrase("ID"));
                        headerCell.Padding = 5;
                        headerCell.BorderWidth = 1.5f;
                        headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell);

                        PdfPCell headerCell1 = new PdfPCell(new Phrase("Date"));
                        headerCell1.Padding = 5;
                        headerCell1.BorderWidth = 1.5f;
                        headerCell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell1);

                        PdfPCell headerCell2 = new PdfPCell(new Phrase("Time"));
                        headerCell2.Padding = 5;
                        headerCell2.BorderWidth = 1.5f;
                        headerCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell2);

                        PdfPCell headerCell3 = new PdfPCell(new Phrase("Vat No."));
                        headerCell3.Padding = 5;
                        headerCell3.BorderWidth = 1.5f;
                        headerCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell3);

                        PdfPCell headerCell4 = new PdfPCell(new Phrase("Qty of Water taken (Ltr)"));
                        headerCell4.Padding = 5;
                        headerCell4.BorderWidth = 1.5f;
                        headerCell4.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell4.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell4);

                        PdfPCell headerCell5 = new PdfPCell(new Phrase("Qty of Sugar taken (Ltr)"));
                        headerCell5.Padding = 5;
                        headerCell5.BorderWidth = 1.5f;
                        headerCell5.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell5);

                        PdfPCell headerCell6 = new PdfPCell(new Phrase("Batch Start Time"));
                        headerCell6.Padding = 5;
                        headerCell6.BorderWidth = 1.5f;
                        headerCell6.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell6.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell6);

                        PdfPCell headerCell7 = new PdfPCell(new Phrase("Batch End Time"));
                        headerCell7.Padding = 5;
                        headerCell7.BorderWidth = 1.5f;
                        headerCell7.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell7.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell7);

                        PdfPCell headerCell8 = new PdfPCell(new Phrase("Batch Total Time"));
                        headerCell8.Padding = 5;
                        headerCell8.BorderWidth = 1.5f;
                        headerCell8.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell8.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell8);

                        PdfPCell headerCell9 = new PdfPCell(new Phrase("Tank"));
                        headerCell9.Padding = 5;
                        headerCell9.BorderWidth = 1.5f;
                        headerCell9.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell9.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell9);

                        PdfPCell headerCell10 = new PdfPCell(new Phrase("Sugar Silo"));
                        headerCell10.Padding = 5;
                        headerCell10.BorderWidth = 1.5f;
                        headerCell10.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell10.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell10);

                        PdfPCell headerCell11 = new PdfPCell(new Phrase("Qty of Water taken (Ltr)"));
                        headerCell11.Padding = 5;
                        headerCell11.BorderWidth = 1.5f;
                        headerCell11.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell11.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell11);

                        PdfPCell headerCell12 = new PdfPCell(new Phrase("Qty of Sugar taken (Kg)"));
                        headerCell12.Padding = 5;
                        headerCell12.BorderWidth = 1.5f;
                        headerCell12.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell12.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell12);

                        PdfPCell headerCell13 = new PdfPCell(new Phrase("Batch Temp"));
                        headerCell13.Padding = 5;
                        headerCell13.BorderWidth = 1.5f;
                        headerCell13.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell13.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell13);

                        PdfPCell headerCell14 = new PdfPCell(new Phrase("Transfer to Silo No."));
                        headerCell14.Padding = 5;
                        headerCell14.BorderWidth = 1.5f;
                        headerCell14.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell14.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell14);

                        PdfPCell headerCell15 = new PdfPCell(new Phrase("Qty. Of Sugar syrup trasferred (Ltr)"));
                        headerCell15.Padding = 5;
                        headerCell15.BorderWidth = 1.5f;
                        headerCell15.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell15.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell15);

                        PdfPCell headerCell16 = new PdfPCell(new Phrase("Transfer Start Time"));
                        headerCell16.Padding = 5;
                        headerCell16.BorderWidth = 1.5f;
                        headerCell16.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell16.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell16);

                        PdfPCell headerCell17 = new PdfPCell(new Phrase("Transfer End Time"));
                        headerCell17.Padding = 5;
                        headerCell17.BorderWidth = 1.5f;
                        headerCell17.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell17.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell17);

                        PdfPCell headerCell18 = new PdfPCell(new Phrase("Total Transfer Time"));
                        headerCell18.Padding = 5;
                        headerCell18.BorderWidth = 1.5f;
                        headerCell18.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell18.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell18);



                        float[] widthsTAS = { 180f, 180f, 180f, 180f, 180f, 180f, 180f, 180f, 180f, 180f, 180f, 180f, 180f, 180f, 180f,180f, 180f, 180f, 180f };
                        pdfPTable.SetWidths(widthsTAS);

                        for (int i = 0; i < gvSugarSyrup.Rows.Count; i++)
                        {
                            if (gvSugarSyrup.Rows[i].RowType == DataControlRowType.DataRow)
                            {
                                for (int j = 0; j < gvSugarSyrup.Columns.Count; j++)
                                {
                                    string cellText = Server.HtmlDecode(gvSugarSyrup.Rows[i].Cells[j].Text);

                                    DateTime dDate;
                                    double dbvalue;
                                    int intvalue;

                                    if (DateTime.TryParse(cellText, out dDate))
                                    {
                                        PdfPCell CellTwoHdr = new PdfPCell(new Phrase(cellText));
                                        CellTwoHdr.HorizontalAlignment = Element.ALIGN_CENTER;
                                        CellTwoHdr.VerticalAlignment = Element.ALIGN_MIDDLE;
                                        CellTwoHdr.Padding = 5;
                                        pdfPTable.AddCell(CellTwoHdr);
                                    }
                                    else if (double.TryParse(cellText, out dbvalue) || Int32.TryParse(cellText, out intvalue))
                                    {
                                        PdfPCell CellTwoHdr = new PdfPCell(new Phrase(cellText));
                                        CellTwoHdr.HorizontalAlignment = Element.ALIGN_CENTER;
                                        CellTwoHdr.VerticalAlignment = Element.ALIGN_MIDDLE;
                                        CellTwoHdr.Padding = 5;
                                        pdfPTable.AddCell(CellTwoHdr);
                                    }
                                    else
                                    {
                                        PdfPCell CellTwoHdr = new PdfPCell(new Phrase(cellText));
                                        CellTwoHdr.HorizontalAlignment = Element.ALIGN_CENTER;
                                        CellTwoHdr.VerticalAlignment = Element.ALIGN_MIDDLE;
                                        CellTwoHdr.Padding = 5;
                                        pdfPTable.AddCell(CellTwoHdr);
                                    }
                                }
                                pdfPTable.HeaderRows = 1;
                            }
                        }
                       
                        var imageURL = Server.MapPath(".") + "\\GEAProcess_large_20122024.jpg";
                        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);

                        jpg.Alignment = Element.ALIGN_CENTER;
                        jpg.SetAbsolutePosition(30, 1060);

                        //For IDMC Logo
                        var imageURL1 = Server.MapPath(".") + "\\GEAProcess_large_20122024.jpg";
                        iTextSharp.text.Image jpg1 = iTextSharp.text.Image.GetInstance(imageURL1);

                        jpg1.Alignment = Element.ALIGN_RIGHT;
                        jpg1.SetAbsolutePosition(700, 1060);

                        StringReader sr = new StringReader(sb.ToString());
                        //StringReader sr1 = new StringReader(sb1.ToString());
                        Document pdfDoc = new Document(PageSize.A1, -150f, -150f, 10f, 0f);

                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        PDFBackgroundHelper pageEventHelper = new PDFBackgroundHelper();
                        writer.PageEvent = pageEventHelper;
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Add(jpg);
                        pdfDoc.Add(jpg1);
                        pdfDoc.Add(pdfPTable);
                        //htmlparser.Parse(sr1);

                        //----------- FOOTER -----------
                        PdfPTable footer = new PdfPTable(2);
                        PdfPTable footer2 = new PdfPTable(2);
                        PdfPCell footer_Cell1 = new PdfPCell(new Phrase("Shift"));
                        PdfPCell footer2_Cell1 = new PdfPCell(new Phrase("Shift Incharge"));
                        PdfPCell common_Cell = new PdfPCell(new Phrase(": ____________________"));

                        float[] cols = new float[] { 100, 300 };

                        footer.SetWidthPercentage(cols, PageSize.A1);
                        footer2.SetWidthPercentage(cols, PageSize.A1);
                        footer_Cell1.Border = 0;
                        footer2_Cell1.Border = 0;
                        common_Cell.Border = 0;
                        footer.AddCell(footer_Cell1);
                        footer.AddCell(common_Cell);
                        footer2.AddCell(footer2_Cell1);
                        footer2.AddCell(common_Cell);
                        footer.WriteSelectedRows(0, -1, pdfDoc.LeftMargin + 125, 90, writer.DirectContent);
                        footer2.WriteSelectedRows(0, -1, pdfDoc.LeftMargin + 125, 70, writer.DirectContent);
                        //----------- /FOOTER -----------

                        pdfDoc.Close();
                        Response.ContentType = "application/pdf";

                        Response.AddHeader("content-disposition", "attachment;" + "filename=SugarSyrupPreprationReport" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Write(pdfDoc);
                        Response.Flush();
                        Response.Clear();
                        Response.End();

                    }
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

        #region create datatable for merge for 2 tables from sp
        public DataTable createDT()
        {
            DataTable dtRes = new DataTable();
            dtRes.Columns.Add("n");
            dtRes.Columns.Add("Date");
            dtRes.Columns.Add("Time");
            dtRes.Columns.Add("VatNo");
            dtRes.Columns.Add("QtyWaterTaken");
            dtRes.Columns.Add("SugarQtyTaken");
            dtRes.Columns.Add("Tank");
            dtRes.Columns.Add("BatchTemp");
            dtRes.Columns.Add("TransferTrigger");
            dtRes.Columns.Add("TrasnferSiloNo");
            dtRes.Columns.Add("QtyOfSugarSyrupTransferred");
            dtRes.Columns.Add("SugarSyrupTempQry");
            dtRes.Columns.Add("StartTrigger");
            dtRes.Columns.Add("Id");
            dtRes.Columns.Add("Date-2");
            dtRes.Columns.Add("Time-2");
            dtRes.Columns.Add("SugarSilo");
            dtRes.Columns.Add("SugarQty");
            dtRes.Columns.Add("BatchStartTime");
            dtRes.Columns.Add("BatchStopTime");
            dtRes.Columns.Add("BatchTotalTime");
            dtRes.Columns.Add("WaterQty");
            dtRes.Columns.Add("TransferSiloNo");
            dtRes.Columns.Add("SugarSyrupTransferQty");
            dtRes.Columns.Add("TransferStartTime");
            dtRes.Columns.Add("TransferStopTime");
            dtRes.Columns.Add("TransferTotalTime");

            return dtRes;
        }
        #endregion

        #region Button GO Click Event
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataTable dtRes = createDT();
                LogBl objLogBl = new LogBl();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var objResult = objLogBl.SugarsyrpReport(dtFromDateTime, dtToDateTime);
                for (int i = 0; i < objResult.ResutlDs.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dtRes.NewRow();
                    dr["Id"] = objResult.ResutlDs.Tables[0].Rows[i]["Id"].ToString();
                    dr["Date"] = objResult.ResutlDs.Tables[1].Rows[i]["Date"].ToString();
                    dr["Time"] = objResult.ResutlDs.Tables[1].Rows[i]["Time"].ToString();
                    dr["VatNo"] = objResult.ResutlDs.Tables[0].Rows[i]["VatNo"].ToString();
                    dr["QtyWaterTaken"] = objResult.ResutlDs.Tables[0].Rows[i]["QtyWaterTaken"].ToString();
                    dr["SugarQtyTaken"] = objResult.ResutlDs.Tables[0].Rows[i]["SugarQtyTaken"].ToString();
                    dr["BatchStartTime"] = objResult.ResutlDs.Tables[1].Rows[i]["BatchStartTime"].ToString();
                    dr["BatchStopTime"] = objResult.ResutlDs.Tables[1].Rows[i]["BatchStopTime"].ToString();
                    dr["BatchTotalTime"] = objResult.ResutlDs.Tables[1].Rows[i]["BatchTotalTime"].ToString();
                    dr["Tank"] = objResult.ResutlDs.Tables[0].Rows[i]["Tank"].ToString();
                    dr["SugarSilo"] = objResult.ResutlDs.Tables[1].Rows[i]["SugarSilo"].ToString();
                    dr["WaterQty"] = objResult.ResutlDs.Tables[1].Rows[i]["WaterQty"].ToString();
                    dr["SugarQty"] = objResult.ResutlDs.Tables[1].Rows[i]["SugarQty"].ToString();
                    dr["BatchTemp"] = objResult.ResutlDs.Tables[1].Rows[i]["BatchTemp"].ToString();
                    dr["TransferSiloNo"] = objResult.ResutlDs.Tables[1].Rows[i]["TransferSiloNo"].ToString();
                    dr["SugarSyrupTransferQty"] = objResult.ResutlDs.Tables[1].Rows[i]["SugarSyrupTransferQty"].ToString();
                    dr["TransferStartTime"] = objResult.ResutlDs.Tables[1].Rows[i]["TransferStartTime"].ToString();
                    dr["TransferStopTime"] = objResult.ResutlDs.Tables[1].Rows[i]["TransferStopTime"].ToString();
                    dr["TransferTotalTime"] = objResult.ResutlDs.Tables[1].Rows[i]["TransferTotalTime"].ToString();
                    
                    dtRes.Rows.Add(dr);
                }
                //var objSweetMilk = objLogBl.SweetMilkReport(dtFromDateTime, dtToDateTime);
                if (dtRes.Rows.Count > 0)
                {
                    gvSugarSyrup.DataSource = dtRes;
                    gvSugarSyrup.DataBind();
                    divExport.Visible = divExport1.Visible = true;
                    divRecord.Visible = false;
                    for (int i = 0; i < gvSugarSyrup.Rows.Count; i++)
                    {
                        TextBox txt = (TextBox)gvSugarSyrup.Rows[i].FindControl("txtQtySugar");
                        txt.Text = dtRes.Rows[i]["SugarQtyTaken"].ToString();
                        TextBox txt2 = (TextBox)gvSugarSyrup.Rows[i].FindControl("txtID");
                        txt2.Text = dtRes.Rows[i]["Id"].ToString();
                    }
                }
                else
                {
                    divExport.Visible = divExport1.Visible = false;
                    divRecord.Visible = true;
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


        protected void gvSugarSyrup_OnPreRender(object sender, EventArgs e)
        {

        }

        protected void gvSugarSyrup_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        #region button save click event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var objSugarSyrupBL = new SugarSyrupBL();
            var objResult = new ApplicationResult();
            for (int j = 0; j < gvSugarSyrup.Rows.Count; j++)
            {
                TextBox txtQtySugar = (TextBox)gvSugarSyrup.Rows[j].FindControl("txtQtySugar");
                double qty = Convert.ToDouble(txtQtySugar.Text);
                txtQtySugar = (TextBox)gvSugarSyrup.Rows[j].FindControl("txtID"); // Row ID
                int rowId = Convert.ToInt32(txtQtySugar.Text);
                objResult = objSugarSyrupBL.SugarSyrupInsert(rowId, qty);
                if (objResult.Status != ApplicationResult.CommonStatusType.Success)
                {
                    log.Error("Insert error for Sugar Syrup Report");
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                        "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
                }
            }
        }
        #endregion

        #region PDFBackgroundHelper Event
        class PDFBackgroundHelper : PdfPageEventHelper
        {

            private PdfContentByte cb;
            private List<PdfTemplate> templates;
            //constructor
            public PDFBackgroundHelper()
            {
                this.templates = new List<PdfTemplate>();
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);

                cb = writer.DirectContentUnder;
                PdfTemplate templateM = cb.CreateTemplate(500, 500);
                templates.Add(templateM);

                int pageN = writer.CurrentPageNumber;
                String pageText = "Page No : " + (writer.PageNumber);
                DateTime dtTime = DateTime.Now;
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                float len = bf.GetWidthPoint(pageText, 15);
                float len1 = bf.GetWidthPoint(dtTime.ToString(), 15);
                cb.BeginText();
                cb.SetFontAndSize(bf, 15);
                cb.SetTextMatrix(document.LeftMargin + 80, document.PageSize.GetBottom(document.BottomMargin) - 13);
                cb.ShowText(dtTime.ToString());
                cb.SetTextMatrix(document.LeftMargin + 750, document.PageSize.GetBottom(document.BottomMargin) - 13);
                cb.ShowText(pageText);
                cb.EndText();
                cb.AddTemplate(templateM, document.LeftMargin + 750 + len, document.PageSize.GetBottom(document.BottomMargin) - 13);
            }
        }
        #endregion
    }
}