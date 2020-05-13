using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using GEA_Ajmer.BL;
using GEA_Ajmer.Common;
using log4net;
//using Word = Microsoft.Office.Interop.Word;

namespace GEA_Ajmer.ReportUI
{
    public partial class LabReport : PageBase
    {
        private static ILog log = LogManager.GetLogger(typeof(LabReport));
        private Controls objControls = new Controls();
        //private Word.Application wordApp;
        //Word.Document aDoc = null;

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session[ApplicationSession.Userid] != null)
                {
                    if (IsPostBack) return;
                    PanelVisibilityMode(true, false);
                    getDatesofMonth();
                    divExport.Visible = false;
                    divNo.Visible = false;
                }
                else
                {
                    Response.Redirect("../Default.aspx?SessionMode=Logout", false);
                }
            }
            catch (Exception ex)
            {
                //log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
                //throw ex;
            }
        }
        #endregion



        #region getDatesofMonth Method

        public void getDatesofMonth()
        {
            DateTime today = DateTime.Today;
            int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime endOfMonth = new DateTime(today.Year, today.Month, daysInMonth);

            //txtFromDate.Text = startOfMonth.ToString("dd/MM/yyyy").Replace("-", "/");
            //txtToDate.Text = endOfMonth.ToString("dd/MM/yyyy").Replace("-", "/");

           // BindgvLabReport(txtFromDate.Text, txtToDate.Text);
        }

        #endregion

        #region Bind gvLabReport
        private void BindgvLabReport(string strFromDt, string strToDate)
        {
            ApplicationResult objResult = new ApplicationResult();
            LabReportBl objLabReportBl = new LabReportBl();

            objResult = objLabReportBl.LabReport(strFromDt, strToDate);

            gvLabReport.DataSource = objResult.ResultDt;
            gvLabReport.DataBind();
            PanelVisibilityMode(true, false);
            if (gvLabReport.Rows.Count > 0)
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
        #endregion



        #region Go Button Click Event
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            try
            {
                BindgvLabReport(txtFromDate.Text, txtToDate.Text);
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
                string strDate = DateTime.UtcNow.AddHours(5.5).ToString().Replace("/", "-").Replace(" ", "-").Replace(":", "-");
                object filename = "LabReport.docx";
                object saveAs = "LabReport" + strDate + ".docx";
                string strType = "word";
                //CreateWordDocument(filename, saveAs, strType);
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
            try
            {
                Response.AddHeader("content-disposition", "attachment;filename=LabReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvLabReport.AllowPaging = false;
                gvLabReport.RenderControl(hw);
                string strTitle = "Banaskantha District Co-Operative Milk Producers Union LTD, Palanpur";

                string Date = DateTime.UtcNow.AddHours(5.5).ToString();
                string strSubTitle = "Lob Report </br> as on " + Date;
                //string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/GCMMF-297x300.jpg";
                string content =
                    "<div align='center'>" +
                    "<div>" +
                    "<div style='align:left;font-size:20px;font-weight:bold;color:Maroon'></td>" + strTitle +
                    "</div><br/><span style='font-size:20px;'>" + strSubTitle + "</span><br/>" +
                    "<div><div align='left' style='font-family:verdana;font-size:13px;border-style: solid; border-width: thin;'>" +
                    sw.ToString() + "</div> </div>";
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
                string strDate = DateTime.UtcNow.AddHours(5.5).ToString().Replace("/", "-").Replace(" ", "-").Replace(":", "-");
                object filename = "LabReport.docx";
                object saveAs = "LabReport" + strDate + ".pdf";
                string strType = "pdf";
                //CreateWordDocument(filename, saveAs, strType);
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
        //            if (gvLabReport.Rows.Count > 0)
        //            {
        //                foreach (var d in inttablecounts)
        //                {
        //                    Word.Table objTable = aDoc.Tables[d];

        //                    for (int i = 1; i < gvLabReport.Rows.Count; i++)
        //                    {
        //                        objTable.Rows.Add(objTable.Rows[i + 2]);
        //                        for (int j = 1; j <= objTable.Columns.Count; j++)
        //                        {
        //                            objTable.Cell(i + 2, j).Range.Text = gvLabReport.Rows[i - 1].Cells[j - 1].Text.Replace("&nbsp;", "");
        //                        }
        //                    }
        //                    for (int i = 1; i <= objTable.Columns.Count; i++)
        //                    {
        //                        objTable.Cell(gvLabReport.Rows.Count + 2, i).Range.Text = gvLabReport.Rows[gvLabReport.Rows.Count - 1].Cells[i - 1].Text.Replace("&nbsp;", "");
        //                    }
        //                    FindAndReplace(wordApp, "<lblMultiResults>", "");
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

        #region Get Vehicle Number
        [System.Web.Services.WebMethod]
        public static string[] GetVehicleNo(string prefixText)
        {
            VehicleBl objVehicleBl = new VehicleBl();
            ApplicationResult objResult = new ApplicationResult();
            string strSearchText = prefixText + "%";
            List<string> result = new List<string>();
            objResult = objVehicleBl.Vehicle_Search(strSearchText);
            if (objResult != null)
            {
                for (int i = 0; i < objResult.ResultDt.Rows.Count; i++)
                {
                    string strVehicleNumber = objResult.ResultDt.Rows[i]["VehicleNumber"].ToString();
                    string strVehicleId = objResult.ResultDt.Rows[i]["VehicleId"].ToString();
                    result.Add(string.Format("{0}~{1}", strVehicleNumber, strVehicleId));
                }
            }
            return result.ToArray();
        }

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

        #region PanelVisibilityMode Method
        private void PanelVisibilityMode(bool blDivGrid, bool blDivPanel)
        {
            //divGrid.Visible = blDivGrid;
            //divPanel.Visible = blDivPanel;
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
    }
}