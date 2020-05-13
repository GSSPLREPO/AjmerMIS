using GEA_Ajmer.BL;
using GEA_Ajmer.BO;
using GEA_Ajmer.Common;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GEA_Ajmer.WebUI
{
    public partial class PowderProduction : PageBase
    {

        private static ILog log = LogManager.GetLogger(typeof(PowderProduction));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            {
                if (Session[ApplicationSession.Userid] != null)
                {

                    ViewState["Mode"] = "Save";
                    BindgvPowderProduction();

                }
                else
                {
                    Response.Redirect("../Default.aspx?SessionMode=Logout", false);
                }
            }
        }


        #region Bind PowderProduction
        private void BindgvPowderProduction()
        {
            try
            {
                PowderProductionBl objPowderProductionBl = new PowderProductionBl();
                var objResult = objPowderProductionBl.PowderProduction_SelectAll();
                if (objResult != null)
                {
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        gvPowderProduction.DataSource = objResult.ResultDt;
                        gvPowderProduction.DataBind();
                        PanelVisibilityMode(true, false);
                    }
                    else
                    {
                        PanelVisibilityMode(false, true);
                        ClearAll();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Button btnAddNew Click Event
        protected void btnAddNew_OnClick(object sender, EventArgs e)
        {
            ClearAll();
            PanelVisibilityMode(false, true);
            txtDate.Text = DateTime.UtcNow.AddHours(5.5).ToString("dd/MM/yyyy");
        }
        #endregion

        #region Button btnViewList Click Event
        protected void btnViewList_OnClick(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                // PanelVisibilityMode(true, false);
                BindgvPowderProduction();
                // BindgvShift();
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region PanelVisibilityMode Method
        private void PanelVisibilityMode(bool blDivGrid, bool blDivPanel)
        {
            divGrid.Visible = blDivGrid;
            divPanel.Visible = blDivPanel;
        }
        #endregion

        #region ClearAll Method
        private void ClearAll()
        {
            Controls objcontrol = new Controls();
            objcontrol.ClearForm(Master.FindControl("ContentPlaceHolder1"));
            ViewState["Mode"] = "Save";
        }
        #endregion

        #region Buttton btnSave Click Event
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                PowderProductionBo objPowderProductionBO = new PowderProductionBo();
                PowderProductionBl objPowderProductionBl = new PowderProductionBl();
                objPowderProductionBO.Date = Convert.ToDateTime(txtDate.Text);
                objPowderProductionBO.ProductType = Convert.ToDateTime(txtProductType.Text);
                objPowderProductionBO.BatchNo = txtBatchNo.Text;
                objPowderProductionBO.ProductionTime = Convert.ToDateTime(txtProductionTime.Text.Trim());
                objPowderProductionBO.PackQuantity = Convert.ToInt32(txtPackQuantity.Text.Trim());
                objPowderProductionBO.TypePacking = txtTypePacking.Text.Trim();
                objPowderProductionBO.NoOfUnits = Convert.ToInt32(txtNOU.Text.Trim());
                objPowderProductionBO.QualityParameter = txtQualityParameters.Text.Trim();
                objPowderProductionBO.UserId = Convert.ToInt32(Session[ApplicationSession.Userid]);
                objPowderProductionBO.Remark = txtRemark.Text.Trim();
                objPowderProductionBO.IsDeleted = 0;

                if (ViewState["Mode"].ToString() == "Save")
                {
                    objPowderProductionBO.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objPowderProductionBO.CreatedDate = DateTime.UtcNow.AddHours(5.5);
                    var objResult = objPowderProductionBl.PowderProduction_Insert(objPowderProductionBO);
                    if (objResult != null)
                    {

                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Saved Successfully.');</script>");
                        ClearAll();
                        BindgvPowderProduction();

                    }
                }
                else if (ViewState["Mode"].ToString() == "Edit")
                {
                    objPowderProductionBO.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objPowderProductionBO.LastModifiedDate = DateTime.UtcNow.AddHours(5.5);
                    objPowderProductionBO.Id = Convert.ToInt32(ViewState["ID"].ToString());
                    var objResult = objPowderProductionBl.PowderProduction_Update(objPowderProductionBO);
                    if (objResult != null)
                    {

                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Updated Successfully.');</script>");
                        ClearAll();
                        BindgvPowderProduction();

                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion


        #region gvPowderProduction Pre Render Event
        protected void gvPowderProduction_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvPowderProduction.Rows.Count <= 0) return;
                gvPowderProduction.UseAccessibleHeader = true;
                gvPowderProduction.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region gvPowderProduction Row Command Event
        protected void gvPowderProduction_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                PowderProductionBl objPowderProductionBL = new PowderProductionBl();
                if (e.CommandName == "Edit1")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["ID"] = e.CommandArgument.ToString();
                    var objResult = objPowderProductionBL.PowderProduction_Select(Convert.ToInt32(ViewState["ID"].ToString()));
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            txtDate.Text = objResult.ResultDt.Rows[0][PowderProductionBo.POWDERPRODUCTION_DATE].ToString();
                            txtProductType.Text = objResult.ResultDt.Rows[0][PowderProductionBo.POWDERPRODUCTION_PRODUCTTYPE].ToString();
                            txtBatchNo.Text = objResult.ResultDt.Rows[0][PowderProductionBo.POWDERPRODUCTION_BATCHNO].ToString();
                            txtProductionTime.Text = objResult.ResultDt.Rows[0][PowderProductionBo.POWDERPRODUCTION_PRODUCTIONTIME].ToString();
                            txtPackQuantity.Text = objResult.ResultDt.Rows[0][PowderProductionBo.POWDERPRODUCTION_PACKQUANTITY].ToString();
                            txtTypePacking.Text = objResult.ResultDt.Rows[0][PowderProductionBo.POWDERPRODUCTION_TYPEPACKING].ToString();
                            txtNOU.Text = objResult.ResultDt.Rows[0][PowderProductionBo.POWDERPRODUCTION_NOOFUNITS].ToString();
                            txtQualityParameters.Text = objResult.ResultDt.Rows[0][PowderProductionBo.POWDERPRODUCTION_QUALITYPARAMETER].ToString();
                            txtRemark.Text = objResult.ResultDt.Rows[0][PowderProductionBo.POWDERPRODUCTION_REMARK].ToString();

                            PanelVisibilityMode(false, true);
                        }
                    }
                }
                else if (e.CommandName == "Delete1")
                {
                    var objResult = objPowderProductionBL.PowderProduction_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid].ToString()), System.DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully.');</script>");
                        BindgvPowderProduction();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('You can not delete this Reception because it is in used.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion


        #region VerifyRenderingInServerForm
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        #endregion


        #region Export to excel
        protected void imgbtnExcel_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string filename = "POWDER PRODUCTION LOG" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvPowderProduction.AllowPaging = false;
                gvPowderProduction.GridLines = GridLines.Both;
                gvPowderProduction.Columns[11].Visible = false;
                gvPowderProduction.Columns[12].Visible = false;
                gvPowderProduction.RenderControl(hw);
                string strSubTitle = "POWDER PRODUCTION REPORT";

                string content = "<div align='center'><img align='left' style='height: 40px; width: 109px' src='" + Session[ApplicationSession.Logo] + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/></div>" +

                "</div><br/><div align='center' style='font-family:verdana;font-size:11px'><span style='font-size:11px;color:Maroon;'>" + strSubTitle + "</ span><br/>" +
                 "<br/>" + sw.ToString() + "<br/></div>";
                string style = @"<!--mce:2-->";
                Response.Write(style);
                Response.Output.Write(content);
                gvPowderProduction.GridLines = GridLines.None;
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

        #region export to PDF
        protected void imgbtnWord_OnClick(object sender, EventArgs e)
        {
            try
            {

                string filename = "POWDER PRODUCTION LOG" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".doc";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Charset = "";
                Response.ContentType = "application/msword ";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvPowderProduction.AllowPaging = false;
                gvPowderProduction.GridLines = GridLines.Both;
                gvPowderProduction.Columns[11].Visible = false;
                gvPowderProduction.Columns[12].Visible = false;
                gvPowderProduction.RenderControl(hw);
                string content = "<div align='center' style='font-family:verdana;font-size:13px'><span style='font-size:16px;font-weight:bold;color:Maroon;'>POWDER PRODUCTION LOG</ span><br/>" +
                "<span style='font-size:13px;font-weight:bold'></span><br/><span align='center' style='font-family:verdana;font-size:11px'><strong>Organisation Name :" + "Nandini Hi-Tech" + "</strong></span><br/> "
                + sw.ToString() + "<br/></div>";
                Response.Output.Write(content);
                gvPowderProduction.GridLines = GridLines.None;
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

        protected void imgPdfButton_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Session[ApplicationSession.OrganisationName].ToString();
                string text1 = Session[ApplicationSession.OrganisationAddress].ToString();
                string text2 = "Powder Production Report";

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

                        //string content = "<table style='display: table;width: 900px; clear:both;'> <tr> <th colspan='10' style='float: left;padding-left: 220px;'><div align='left'><strong>Start Date: </strong>" + txtFromDate.Text + "</div></th>";

                        //content += "<th style='float:left; padding-left:-180px;'></th>";

                        //content += "<th style='float:left; padding-left:-210px;'></th>";

                        //content += "<th colspan='1' align='left' style=' float: left; padding-left:-200px;'><strong> End Date: </strong>" + //colspan='4' 
                        //txtToDate.Text + "</th>" +
                        //"</tr></table>";
                        //sb.Append(content);
                        sb.Append("<br/>");

                        PdfPTable pdfPTable = new PdfPTable(gvPowderProduction.HeaderRow.Cells.Count);

                        //TableCell headerCell = new TableCell();

                        PdfPCell headerCell = new PdfPCell(new Phrase("Sr. No."));
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


                        PdfPCell headerCell2 = new PdfPCell(new Phrase("Product Type"));
                        headerCell2.Padding = 5;
                        headerCell2.BorderWidth = 1.5f;
                        headerCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell2);

                        PdfPCell headerCell3 = new PdfPCell(new Phrase("Batch No"));
                        headerCell3.Padding = 5;
                        headerCell3.BorderWidth = 1.5f;
                        headerCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell3);

                        PdfPCell headerCell4 = new PdfPCell(new Phrase("Production Time"));
                        headerCell4.Padding = 5;
                        headerCell4.BorderWidth = 1.5f;
                        headerCell4.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell4.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell4);

                        PdfPCell headerCell5 = new PdfPCell(new Phrase("Pack Quantity"));
                        headerCell5.Padding = 5;
                        headerCell5.BorderWidth = 1.5f;
                        headerCell5.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell5);

                        PdfPCell headerCell6 = new PdfPCell(new Phrase("Type of Packing"));
                        headerCell6.Padding = 5;
                        headerCell6.BorderWidth = 1.5f;
                        headerCell6.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell6.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell6);

                        PdfPCell headerCell7 = new PdfPCell(new Phrase("No of Units"));
                        headerCell7.Padding = 5;
                        headerCell7.BorderWidth = 1.5f;
                        headerCell7.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell7.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell7);

                        PdfPCell headerCell8 = new PdfPCell(new Phrase("Quality Parameters"));
                        headerCell8.Padding = 5;
                        headerCell8.BorderWidth = 1.5f;
                        headerCell8.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell8.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell8);

                        PdfPCell headerCell9 = new PdfPCell(new Phrase("Remark"));
                        headerCell9.Padding = 5;
                        headerCell9.BorderWidth = 1.5f;
                        headerCell9.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell9.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell9);

                        PdfPCell headerCell10 = new PdfPCell(new Phrase("User Name"));
                        headerCell10.Padding = 5;
                        headerCell10.BorderWidth = 1.5f;
                        headerCell10.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell10.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell10);

                        PdfPCell headerCell11 = new PdfPCell(new Phrase("Edit"));
                        headerCell11.Padding = 5;
                        headerCell11.BorderWidth = 1.5f;
                        headerCell11.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell11.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell11);

                        PdfPCell headerCell12 = new PdfPCell(new Phrase("Delete"));
                        headerCell12.Padding = 5;
                        headerCell12.BorderWidth = 1.5f;
                        headerCell12.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell12.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell12);



                        float[] widthsTAS = { 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f};
                        pdfPTable.SetWidths(widthsTAS);

                        for (int i = 0; i < gvPowderProduction.Rows.Count; i++)
                        {
                            if (gvPowderProduction.Rows[i].RowType == DataControlRowType.DataRow)
                            {
                                for (int j = 0; j < gvPowderProduction.Columns.Count; j++)
                                {
                                    string cellText = Server.HtmlDecode(gvPowderProduction.Rows[i].Cells[j].Text);
                                    gvPowderProduction.Columns[1].Visible = false;
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
                        //StringBuilder sb1 = new StringBuilder();
                        //sb1.Append("<br/><div align='left' style='font-size:16px;padding-left:90px'>");
                        //sb1.Append("Shift : ____________________");
                        //sb1.Append("</div>");
                        //sb1.Append("<br/>");
                        //sb1.Append("<div align='left' style='font-size:16px;padding-left:90px'>");
                        //sb1.Append("Shift Incharge : ____________________");
                        //sb1.Append("</div>");

                        var imageURL = Server.MapPath("\\images") + "\\GEAProcess_large_20122024.jpg";
                        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);

                        jpg.Alignment = Element.ALIGN_CENTER;
                        jpg.SetAbsolutePosition(30, 1060);

                        //For IDMC Logo
                        var imageURL1 = Server.MapPath("\\images") + "\\GEAProcess_large_20122024.jpg";
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

                        footer.SetWidthPercentage(cols, PageSize.A3);
                        footer2.SetWidthPercentage(cols, PageSize.A3);
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

                        Response.AddHeader("content-disposition", "attachment;" + "filename=PowderProductionReport" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf");
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