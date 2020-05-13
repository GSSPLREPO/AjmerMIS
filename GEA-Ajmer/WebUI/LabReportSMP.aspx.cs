using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using GEA_Ajmer.BL;
using GEA_Ajmer.BO;
using GEA_Ajmer.Common;
using log4net;
using System.IO;
using System.Web;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Collections.Generic;
using iTextSharp.text.html.simpleparser;
using System.Text;

namespace GEA_Ajmer.WebUI
{
    public partial class LabReportSMP : PageBase
    {

        private static ILog log = LogManager.GetLogger(typeof(LabReportSMP));

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) return;
                if (Session[ApplicationSession.Userid] != null)
                {
                    ViewState["Mode"] = "Save";
                    BindLabReportSMP();
                    // PanelVisibilityMode(true, false);
                }
                else
                {
                    Response.Redirect("../Default.aspx?SessionMode=Logout", false);
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


        #region Bind LabReportSMP
        private void BindLabReportSMP()
        {
            try
            {
                LabReportSMPBl objLabReportSMPBl = new LabReportSMPBl();
                var objResult = objLabReportSMPBl.LabReportSMP_SelectAll();
                if (objResult != null)
                {
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        gvLabReportSMP.DataSource = objResult.ResultDt;
                        gvLabReportSMP.DataBind();
                        PanelVisibilityMode(true, false);
                    }
                    else
                    {
                        PanelVisibilityMode(false, true);
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
        }
        #endregion

        #region Button btnSave Click Event
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                LabReportSMPBo objLabReportSMPBo = new LabReportSMPBo();
                //ApplicationResult objResult = new ApplicationResult();
                LabReportSMPBl objLabReportSMPBl = new LabReportSMPBl();
                objLabReportSMPBo.Date = DateTime.ParseExact(txtDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objLabReportSMPBo.TypeOfPowder = (txtTypeofPowder.Text.Trim());
                objLabReportSMPBo.Time = DateTime.ParseExact(txtTime.Text.Trim(), "HH:mm:ss", CultureInfo.InvariantCulture);
                objLabReportSMPBo.BatchNo = txtBatchNo.Text.Trim();
                objLabReportSMPBo.BagNos = Convert.ToInt32(txtBatchNo.Text.Trim());
                objLabReportSMPBo.Weight = float.Parse(txtWeight.Text.Trim());
                objLabReportSMPBo.Appearance = txtAppearance.Text.Trim();
                objLabReportSMPBo.Moisture = float.Parse(txtMoisture.Text.Trim());
                objLabReportSMPBo.TotalSolid = float.Parse(txtTotalSolids.Text.Trim());
                objLabReportSMPBo.BulkDensity = float.Parse(txtBulkDensity.Text.Trim());
                objLabReportSMPBo.MilkFat = float.Parse(txtMilkFat.Text.Trim());
                objLabReportSMPBo.Acidity = txtAcidity.Text.Trim();
                objLabReportSMPBo.Wettability = txtWettability.Text.Trim();
                objLabReportSMPBo.ScorchedParticle = txtScorchedparticle.Text.Trim();
                objLabReportSMPBo.SolIndex = txtSolIndex.Text.Trim();
                objLabReportSMPBo.CoffeTest = txtCoffeeTest.Text.Trim();
                objLabReportSMPBo.Flavour = txtFlavour.Text.Trim();
                objLabReportSMPBo.Protein = txtProtein.Text != "" ? float.Parse(txtProtein.Text.Trim(), CultureInfo.InvariantCulture) : 0;
                objLabReportSMPBo.ASH = txtAsh.Text != "" ? float.Parse(txtAsh.Text.Trim(), CultureInfo.InvariantCulture) : 0;
                objLabReportSMPBo.Lumpiness = txtLumpiness.Text.Trim();
                objLabReportSMPBo.Adultration = txtAdultration.Text.Trim();
                objLabReportSMPBo.UserId = Convert.ToInt32(Session[ApplicationSession.Userid]);

                switch (ViewState["Mode"].ToString())
                {
                    case "Save":
                        objLabReportSMPBo.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objLabReportSMPBo.CreatedDate = DateTime.UtcNow.AddHours(5.5);
                        break;
                    case "Edit":
                        objLabReportSMPBo.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objLabReportSMPBo.LastModifiedDate = DateTime.UtcNow.AddHours(5.5);
                        break;
                }
                if (ViewState["Mode"].ToString() == "Save")
                {
                    var objResult = objLabReportSMPBl.LabReportSMP_Insert(objLabReportSMPBo);
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Saved Successfully.');</script>");
                        ClearAll();
                        BindLabReportSMP();
                        //PanelVisibilityMode(true, false);
                    }
                }
                else if (ViewState["Mode"].ToString() == "Edit")
                {
                    objLabReportSMPBo.Id = Convert.ToInt32(ViewState["LabReportSMPID"].ToString());
                    var objResult = objLabReportSMPBl.LabReportSMP_Update(objLabReportSMPBo);
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Updated Successfully.');</script>");
                        ClearAll();
                        BindLabReportSMP();
                        // PanelVisibilityMode(true, false);
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

        #region Button btnViewList Click Event
        protected void btnViewList_OnClick(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                PanelVisibilityMode(true, false);
                BindLabReportSMP();
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion



        #region gvLabReportSMP Pre Render Event
        protected void gvLabReportSMP_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvLabReportSMP.Rows.Count <= 0) return;
                gvLabReportSMP.UseAccessibleHeader = true;
                gvLabReportSMP.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region gvLabReportSMP Row Command Event
        protected void gvLabReportSMP_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                LabReportSMPBl objLabReportSMPBL = new LabReportSMPBl();
                if (e.CommandName == "Edit1")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["LabReportSMPID"] = e.CommandArgument.ToString();
                    var objResult = objLabReportSMPBL.LabReportSMP_Select(Convert.ToInt32(ViewState["LabReportSMPID"].ToString()));
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            txtDate.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_DATE].ToString();
                            txtTypeofPowder.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_TYPEOFPOWDER].ToString();
                            txtTime.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_TIME].ToString();
                            txtBatchNo.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_BATCHNO].ToString();
                            txtBagNos.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_BAGNOS].ToString();
                            txtWeight.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_WEIGHT].ToString();
                            txtAppearance.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_APPEARANCE].ToString();
                            txtMoisture.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_MOISTURE].ToString();
                            txtTotalSolids.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_TOTALSOLID].ToString();
                            txtBulkDensity.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_BULKDENSITY].ToString();
                            txtMilkFat.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_MILKFAT].ToString();
                            txtAcidity.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_ACIDITY].ToString();
                            txtWettability.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_WETTABILITY].ToString();
                            txtScorchedparticle.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_SCORCHEDPARTICLE].ToString();
                            txtSolIndex.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_SOLINDEX].ToString();
                            txtCoffeeTest.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_COFFETEST].ToString();
                            txtFlavour.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_FLAVOUR].ToString();
                            txtProtein.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_PROTEIN].ToString();
                            txtAsh.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_ASH].ToString();
                            txtLumpiness.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_LUMPINESS].ToString();
                            txtAdultration.Text = objResult.ResultDt.Rows[0][LabReportSMPBo.LABREPORTSMP_ADULTRATION].ToString();
                            PanelVisibilityMode(false, true);
                        }
                    }
                }
                else if (e.CommandName == "Delete1")
                {
                    var objResult = objLabReportSMPBL.LabReportSMP_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid].ToString()), DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully.');</script>");
                        //  PanelVisibilityMode(true, false);
                        BindLabReportSMP();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('You can not delete this LabReportSMP because it is in used.');</script>");
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
                string filename = "LabReportSMP_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvLabReportSMP.AllowPaging = false;
                gvLabReportSMP.GridLines = GridLines.Both;
                gvLabReportSMP.Columns[23].Visible = false;
                gvLabReportSMP.Columns[24].Visible = false;
                gvLabReportSMP.RenderControl(hw);
                string strSubTitle = "LAB REPORT SMP";

                string content = "<div align='center'><img align='left' style='height: 40px; width: 109px' src='" + Session[ApplicationSession.Logo] + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
             "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/></div>" +

             "</div><br/><div align='center' style='font-family:verdana;font-size:11px'><span style='font-size:11px;color:Maroon;'>" + strSubTitle + "</ span><br/>" +
              "<br/>" + sw.ToString() + "<br/></div>";

                string style = @"<!--mce:2-->";
                Response.Write(style);
                Response.Output.Write(content);
                gvLabReportSMP.GridLines = GridLines.None;
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

        #region Export To Word
        protected void imgbtnWord_OnClick(object sender, EventArgs e)
        {
            try
            {
                string filename = "LabReportSMP_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".doc";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Charset = "";
                Response.ContentType = "application/msword ";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvLabReportSMP.AllowPaging = false;
                gvLabReportSMP.GridLines = GridLines.Both;
                gvLabReportSMP.Columns[23].Visible = false;
                gvLabReportSMP.Columns[24].Visible = false;
                gvLabReportSMP.RenderControl(hw);

                string content = "<div align='center' style='font-family:verdana;font-size:13px'><span style='font-size:16px;font-weight:bold;color:Maroon;'>LAB REPORT OF SKIMMED MILK POWDER TESTING</span>" +
                    "<br/><span align='center' style='font-family:verdana;font-size:11px'><strong>Organisation Name :" + "Nandini Hi-Tech" + "</strong></span><br/> "
                    + sw.ToString() + "<br/></div>";
                Response.Output.Write(content);
                gvLabReportSMP.GridLines = GridLines.None;
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

        protected void imgPdfButton_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Session[ApplicationSession.OrganisationName].ToString();
                string text1 = Session[ApplicationSession.OrganisationAddress].ToString();
                string text2 = "Lab Report SMP";

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

                      
                        sb.Append("<br/>");

                        PdfPTable pdfPTable = new PdfPTable(gvLabReportSMP.HeaderRow.Cells.Count);

                        //TableCell headerCell = new TableCell();

                        PdfPCell headerCell = new PdfPCell(new Phrase("Sr No."));
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


                        PdfPCell headerCell2 = new PdfPCell(new Phrase("Type Of Powder"));
                        headerCell2.Padding = 5;
                        headerCell2.BorderWidth = 1.5f;
                        headerCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell2);

                        PdfPCell headerCell3 = new PdfPCell(new Phrase("Time"));
                        headerCell3.Padding = 5;
                        headerCell3.BorderWidth = 1.5f;
                        headerCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell3);

                        PdfPCell headerCell4 = new PdfPCell(new Phrase("Batch no"));
                        headerCell4.Padding = 5;
                        headerCell4.BorderWidth = 1.5f;
                        headerCell4.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell4.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell4);

                        PdfPCell headerCell5 = new PdfPCell(new Phrase("Bag No"));
                        headerCell5.Padding = 5;
                        headerCell5.BorderWidth = 1.5f;
                        headerCell5.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell5);

                        PdfPCell headerCell6 = new PdfPCell(new Phrase("Weight."));
                        headerCell6.Padding = 5;
                        headerCell6.BorderWidth = 1.5f;
                        headerCell6.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell6.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell6);

                        PdfPCell headerCell7 = new PdfPCell(new Phrase("Appearance"));
                        headerCell7.Padding = 5;
                        headerCell7.BorderWidth = 1.5f;
                        headerCell7.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell7.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell7);

                        PdfPCell headerCell8 = new PdfPCell(new Phrase("Moisture"));
                        headerCell8.Padding = 5;
                        headerCell8.BorderWidth = 1.5f;
                        headerCell8.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell8.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell8);

                        PdfPCell headerCell9 = new PdfPCell(new Phrase("Total solids"));
                        headerCell9.Padding = 5;
                        headerCell9.BorderWidth = 1.5f;
                        headerCell9.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell9.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell9);

                        PdfPCell headerCell10 = new PdfPCell(new Phrase("Bulk density"));
                        headerCell10.Padding = 5;
                        headerCell10.BorderWidth = 1.5f;
                        headerCell10.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell10.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell10);

                        PdfPCell headerCell11 = new PdfPCell(new Phrase("Milk Fat"));
                        headerCell11.Padding = 5;
                        headerCell11.BorderWidth = 1.5f;
                        headerCell11.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell11.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell11);

                        PdfPCell headerCell12 = new PdfPCell(new Phrase("Acidity LA"));
                        headerCell12.Padding = 5;
                        headerCell12.BorderWidth = 1.5f;
                        headerCell12.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell12.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell12);

                        PdfPCell headerCell13 = new PdfPCell(new Phrase("Wettability"));
                        headerCell13.Padding = 5;
                        headerCell13.BorderWidth = 1.5f;
                        headerCell13.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell13.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell13);

                        PdfPCell headerCell14 = new PdfPCell(new Phrase("Scorched particle"));
                        headerCell14.Padding = 5;
                        headerCell14.BorderWidth = 1.5f;
                        headerCell14.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell14.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell14);

                        PdfPCell headerCel15 = new PdfPCell(new Phrase("Sol Index (MI)"));
                        headerCel15.Padding = 5;
                        headerCel15.BorderWidth = 1.5f;
                        headerCel15.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCel15.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCel15);

                        PdfPCell headerCell16 = new PdfPCell(new Phrase("Coffee Test"));
                        headerCell16.Padding = 5;
                        headerCell16.BorderWidth = 1.5f;
                        headerCell16.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell16.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell16);

                        PdfPCell headerCell17 = new PdfPCell(new Phrase("Flavour"));
                        headerCell17.Padding = 5;
                        headerCell17.BorderWidth = 1.5f;
                        headerCell17.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell17.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell17);

                        PdfPCell headerCell18 = new PdfPCell(new Phrase("Protein (%)"));
                        headerCell18.Padding = 5;
                        headerCell18.BorderWidth = 1.5f;
                        headerCell18.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell18.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell18);

                        PdfPCell headerCell19 = new PdfPCell(new Phrase("Ash (%)"));
                        headerCell19.Padding = 5;
                        headerCell19.BorderWidth = 1.5f;
                        headerCell19.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell19.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell19);

                        PdfPCell headerCell20 = new PdfPCell(new Phrase("Lumpiness"));
                        headerCell20.Padding = 5;
                        headerCell20.BorderWidth = 1.5f;
                        headerCell20.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell20.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell20);

                        PdfPCell headerCell21 = new PdfPCell(new Phrase("Adultration"));
                        headerCell21.Padding = 5;
                        headerCell21.BorderWidth = 1.5f;
                        headerCell21.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell21.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell21);

                        PdfPCell headerCell22 = new PdfPCell(new Phrase("User Id"));
                        headerCell22.Padding = 5;
                        headerCell22.BorderWidth = 1.5f;
                        headerCell22.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell22.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell22);

                        PdfPCell headerCell23 = new PdfPCell(new Phrase("Edit"));
                        headerCell23.Padding = 5;
                        headerCell23.BorderWidth = 1.5f;
                        headerCell23.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell23.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell23);

                        PdfPCell headerCell24 = new PdfPCell(new Phrase("Delete"));
                        headerCell24.Padding = 5;
                        headerCell24.BorderWidth = 1.5f;
                        headerCell24.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell24.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell24);



                        float[] widthsTAS = { 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f };
                        pdfPTable.SetWidths(widthsTAS);

                        for (int i = 0; i < gvLabReportSMP.Rows.Count; i++)
                        {
                            if (gvLabReportSMP.Rows[i].RowType == DataControlRowType.DataRow)
                            {
                                for (int j = 0; j < gvLabReportSMP.Columns.Count; j++)
                                {
                                    string cellText = Server.HtmlDecode(gvLabReportSMP.Rows[i].Cells[j].Text);
                                    gvLabReportSMP.Columns[1].Visible = false;
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

                        Response.AddHeader("content-disposition", "attachment;" + "filename=LabReportSMP" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf");
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
    }
}