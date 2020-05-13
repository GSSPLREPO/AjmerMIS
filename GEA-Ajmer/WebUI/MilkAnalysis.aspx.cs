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
    public partial class MilkAnalysis : PageBase
    {

        private static ILog log = LogManager.GetLogger(typeof(MilkAnalysis));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            {
                if (Session[ApplicationSession.Userid] != null)
                {

                    ViewState["Mode"] = "Save";
                    BindgvMilkAnalysis();
                    BindSiloId();
                }
                else
                {
                    Response.Redirect("../Default.aspx?SessionMode=Logout", false);
                }
            }
        }

        #region BindProducts
        private void BindSiloId()
        {
            ApplicationResult objResult = new ApplicationResult();
            objResult = new SiloBl().Silo_SelectAll_MilkAnalysis();

            if (objResult != null)
            {
                if (objResult.ResultDt.Rows.Count > 0)
                {
                    Controls objControls = new Controls();
                    objControls.BindDropDown_ListBox(objResult.ResultDt, ddlSiloId, "Name", "ID");
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>return alert('Please Add SILO Id First.');</script>");
                }
                ddlSiloId.Items.Insert(0, new System.Web.UI.WebControls.ListItem("- None -", "-1"));
                ddlSiloId.SelectedIndex = 1;
            }
        }
        #endregion

        #region Bind MilkAnalysis
        private void BindgvMilkAnalysis()
        {
            try
            {
                MilkAnalysisBL objMilkAnalysisBl = new MilkAnalysisBL();
                var objResult = objMilkAnalysisBl.MilkAnalysis_SelectAll();
                if (objResult != null)
                {
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        gvMilkAnalysis.DataSource = objResult.ResultDt;
                        gvMilkAnalysis.DataBind();
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
                BindgvMilkAnalysis();
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
                MilkAnalysisBO objMilkAnalysisBO = new MilkAnalysisBO();
                MilkAnalysisBL objMilkAnalysisBl = new MilkAnalysisBL();
                objMilkAnalysisBO.Date = Convert.ToDateTime(txtDate.Text);
                objMilkAnalysisBO.Time = Convert.ToDateTime(txtTime.Text);
                objMilkAnalysisBO.SiloId = Convert.ToInt32(ddlSiloId.SelectedValue);
                objMilkAnalysisBO.ProductType = txtProductType.Text.Trim();
                objMilkAnalysisBO.SampleId = txtSampleId.Text.Trim();
                objMilkAnalysisBO.FAT = float.Parse(txtFat.Text.Trim());
                objMilkAnalysisBO.SNF = float.Parse(txtSNF.Text.Trim());
                objMilkAnalysisBO.Sugar = float.Parse(txtSugar.Text.Trim());
                objMilkAnalysisBO.TS = float.Parse(txtTS.Text.Trim());
                objMilkAnalysisBO.Acidity = txtAcidity.Text.Trim();
                objMilkAnalysisBO.Temp = float.Parse(txtTemp.Text.Trim());
                objMilkAnalysisBO.OT = txtOT.Text.Trim();

              //  objMilkAnalysisBO.VehicleId = txtVehicleId.Text.Trim();
                //objMilkAnalysisBO.VehicleNo = txtVehicleNo.Text.Trim();
                //objMilkAnalysisBO.RouteNo = txtRouteNo.Text.Trim();
                //objMilkAnalysisBO.COB = txtCob.Text.Trim();
                //objMilkAnalysisBO.AlcoholNo = txtAlcohol.Text.Trim();
                //objMilkAnalysisBO.Neutralizer = txtNeutralizer.Text.Trim();
                //objMilkAnalysisBO.Urea = txtUrea.Text.Trim();
                //objMilkAnalysisBO.Salt = txtSalt.Text.Trim();
                //objMilkAnalysisBO.Starch = txtStarch.Text.Trim();
                //objMilkAnalysisBO.FPD = txtFpd.Text.Trim();

                objMilkAnalysisBO.UserId = Convert.ToInt32(Session[ApplicationSession.Userid]);
                objMilkAnalysisBO.Remark = txtRemark.Text.Trim();
                objMilkAnalysisBO.IsDeleted = 0;

                if (ViewState["Mode"].ToString() == "Save")
                {
                    objMilkAnalysisBO.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objMilkAnalysisBO.CreatedDate = DateTime.UtcNow.AddHours(5.5);
                    var objResult = objMilkAnalysisBl.MilkAnalysis_Insert(objMilkAnalysisBO);
                    if (objResult != null)
                    {

                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Saved Successfully.');</script>");
                        ClearAll();
                        BindgvMilkAnalysis();

                    }
                }
                else if (ViewState["Mode"].ToString() == "Edit")
                {
                    objMilkAnalysisBO.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objMilkAnalysisBO.LastModifiedDate = DateTime.UtcNow.AddHours(5.5);
                    objMilkAnalysisBO.Id = Convert.ToInt32(ViewState["ID"].ToString());
                    var objResult = objMilkAnalysisBl.MilkAnalysis_Update(objMilkAnalysisBO);
                    if (objResult != null)
                    {

                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Updated Successfully.');</script>");
                        ClearAll();
                        BindgvMilkAnalysis();

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


        #region gvMilkAnalysis Pre Render Event
        protected void gvCircuit_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvMilkAnalysis.Rows.Count <= 0) return;
                gvMilkAnalysis.UseAccessibleHeader = true;
                gvMilkAnalysis.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region gvMilkAnalysis Row Command Event
        protected void gvMilkAnalysis_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                MilkAnalysisBL objMilkAnalysisBL = new MilkAnalysisBL();
                if (e.CommandName == "Edit1")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["ID"] = e.CommandArgument.ToString();
                    var objResult = objMilkAnalysisBL.MilkAnalysis_Select(Convert.ToInt32(ViewState["ID"].ToString()));
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            txtDate.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_DATE].ToString();
                            txtTime.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_TIME].ToString();
                            ddlSiloId.SelectedValue = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_SILOID].ToString();
                            txtProductType.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_PRODUCTTYPE].ToString();
                            txtSampleId.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_SAMPLEID].ToString();
                            txtFat.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_FAT].ToString();
                            txtSNF.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_SNF].ToString();
                            txtSugar.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_SUGAR].ToString();
                            txtTS.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_TS].ToString();
                            txtAcidity.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_ACIDITY].ToString();
                            txtTemp.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_TEMP].ToString();
                            txtOT.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_OT].ToString();
                            txtRemark.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_REMARK].ToString();
                            //txtVehicleId.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_REMARK].ToString();
                            //txtVehicleNo.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_REMARK].ToString();
                            //txtRouteNo.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_REMARK].ToString();
                            //txtCob.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_REMARK].ToString();
                            //txtAlcohol.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_REMARK].ToString();
                            //txtNeutralizer.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_REMARK].ToString();
                            //txtUrea.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_REMARK].ToString();
                            //txtSalt.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_REMARK].ToString();
                            //txtStarch.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_REMARK].ToString();
                            //txtFpd.Text = objResult.ResultDt.Rows[0][MilkAnalysisBO.MILKANALYSIS_REMARK].ToString();

                            PanelVisibilityMode(false, true);
                        }
                    }
                }
                else if (e.CommandName == "Delete1")
                {
                    var objResult = objMilkAnalysisBL.MilkAnalysis_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid].ToString()), System.DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully.');</script>");
                        BindgvMilkAnalysis();
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
                string filename = "MilkAnalysis_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvMilkAnalysis.AllowPaging = false;
                gvMilkAnalysis.GridLines = GridLines.Both;
                gvMilkAnalysis.Columns[15].Visible = false;
                gvMilkAnalysis.Columns[16].Visible = false;
                gvMilkAnalysis.RenderControl(hw);
                string strSubTitle = "MILK ANALYSIS";


                string content = "<div align='center'><img align='left' style='height: 40px; width: 109px' src='" + Session[ApplicationSession.Logo] + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
               "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/></div>" +

               "</div><br/><div align='center' style='font-family:verdana;font-size:11px'><span style='font-size:11px;color:Maroon;'>" + strSubTitle + "</ span><br/>" +
                "<br/>" + sw.ToString() + "<br/></div>";

                string style = @"<!--mce:2-->";
                Response.Write(style);
                Response.Output.Write(content);
                gvMilkAnalysis.GridLines = GridLines.None;
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

        #region export to Word
        protected void imgbtnWord_OnClick(object sender, EventArgs e)
        {
            try
            {

                string filename = "Milk Analysis Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".doc";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Charset = "";
                Response.ContentType = "application/msword ";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvMilkAnalysis.AllowPaging = false;
                gvMilkAnalysis.GridLines = GridLines.Both;
                gvMilkAnalysis.Columns[13].Visible = false;
                gvMilkAnalysis.Columns[14].Visible = false;
                gvMilkAnalysis.RenderControl(hw);
                string content = "<div align='center' style='font-family:verdana;font-size:13px'><span style='font-size:16px;font-weight:bold;color:Maroon;'>Milk Analysis Report</ span><br/>" +
                "<span style='font-size:13px;font-weight:bold'></span><br/><span align='center' style='font-family:verdana;font-size:11px'><strong>Organisation Name :" + "Panchamrut Dairy,Taloja" + "</strong></span><br/> "
                + sw.ToString() + "<br/></div>";
                Response.Output.Write(content);
                gvMilkAnalysis.GridLines = GridLines.None;
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
                string text2 = "Milk Analysis Report";

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

                        PdfPTable pdfPTable = new PdfPTable(gvMilkAnalysis.HeaderRow.Cells.Count);

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


                        PdfPCell headerCell2 = new PdfPCell(new Phrase("Time"));
                        headerCell2.Padding = 5;
                        headerCell2.BorderWidth = 1.5f;
                        headerCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell2);

                        PdfPCell headerCell3 = new PdfPCell(new Phrase("Silo Tag"));
                        headerCell3.Padding = 5;
                        headerCell3.BorderWidth = 1.5f;
                        headerCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell3);

                        PdfPCell headerCell4 = new PdfPCell(new Phrase("Product Type"));
                        headerCell4.Padding = 5;
                        headerCell4.BorderWidth = 1.5f;
                        headerCell4.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell4.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell4);

                        PdfPCell headerCell5 = new PdfPCell(new Phrase("SampleId"));
                        headerCell5.Padding = 5;
                        headerCell5.BorderWidth = 1.5f;
                        headerCell5.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell5);

                        PdfPCell headerCell6 = new PdfPCell(new Phrase("FAT"));
                        headerCell6.Padding = 5;
                        headerCell6.BorderWidth = 1.5f;
                        headerCell6.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell6.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell6);

                        PdfPCell headerCell7 = new PdfPCell(new Phrase("SNF"));
                        headerCell7.Padding = 5;
                        headerCell7.BorderWidth = 1.5f;
                        headerCell7.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell7.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell7);

                        PdfPCell headerCell8 = new PdfPCell(new Phrase("Sugar"));
                        headerCell8.Padding = 5;
                        headerCell8.BorderWidth = 1.5f;
                        headerCell8.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell8.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell8);

                        PdfPCell headerCell9 = new PdfPCell(new Phrase("TS"));
                        headerCell9.Padding = 5;
                        headerCell9.BorderWidth = 1.5f;
                        headerCell9.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell9.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell9);

                        PdfPCell headerCell10 = new PdfPCell(new Phrase("Acidity"));
                        headerCell10.Padding = 5;
                        headerCell10.BorderWidth = 1.5f;
                        headerCell10.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell10.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell10);

                        PdfPCell headerCell11 = new PdfPCell(new Phrase("Temp"));
                        headerCell11.Padding = 5;
                        headerCell11.BorderWidth = 1.5f;
                        headerCell11.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell11.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell11);

                        PdfPCell headerCell12 = new PdfPCell(new Phrase("OT"));
                        headerCell12.Padding = 5;
                        headerCell12.BorderWidth = 1.5f;
                        headerCell12.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell12.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell12);

                        PdfPCell headerCell13 = new PdfPCell(new Phrase("User Name"));
                        headerCell13.Padding = 5;
                        headerCell13.BorderWidth = 1.5f;
                        headerCell13.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell13.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell13);

                        PdfPCell headerCell14 = new PdfPCell(new Phrase("Remarks"));
                        headerCell14.Padding = 5;
                        headerCell14.BorderWidth = 1.5f;
                        headerCell14.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell14.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell14);

                        PdfPCell headerCel15 = new PdfPCell(new Phrase("Edit"));
                        headerCel15.Padding = 5;
                        headerCel15.BorderWidth = 1.5f;
                        headerCel15.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCel15.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCel15);

                        PdfPCell headerCell16 = new PdfPCell(new Phrase("Delete"));
                        headerCell16.Padding = 5;
                        headerCell16.BorderWidth = 1.5f;
                        headerCell16.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell16.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell16);



                        float[] widthsTAS = { 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f, 300f };
                        pdfPTable.SetWidths(widthsTAS);

                        for (int i = 0; i < gvMilkAnalysis.Rows.Count; i++)
                        {
                            if (gvMilkAnalysis.Rows[i].RowType == DataControlRowType.DataRow)
                            {
                                for (int j = 0; j < gvMilkAnalysis.Columns.Count; j++)
                                {
                                    string cellText = Server.HtmlDecode(gvMilkAnalysis.Rows[i].Cells[j].Text);
                                    gvMilkAnalysis.Columns[1].Visible = false;
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

                        Response.AddHeader("content-disposition", "attachment;" + "filename=MilkAnalysisReport" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf");
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