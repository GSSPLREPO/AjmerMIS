using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web.UI;
using GEA_Ajmer.BL;
using log4net;
//using Word = Microsoft.Office.Interop.Word;

namespace GEA_Ajmer.ReportUI
{
    public partial class BreakDownMaintainanceReport : System.Web.UI.Page
    {
        //private Word.Application wordApp;
        //Word.Document aDoc = null;
        private static ILog log = LogManager.GetLogger(typeof(UtilityStatusReport));

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            Breakdown();
            divExport.Visible = true;
            divNo.Visible = false;
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }
        #endregion



        #region Button Go Click Event
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            try
            {
                MaintainanceBL objMaintainanceBl = new MaintainanceBL();
                DateTime dtFromDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);
                DateTime dtToDate = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);

                var objResult = objMaintainanceBl.Maintainance_SelectAll_forRoutineReport(dtFromDate, dtToDate, 1);
                gvBreakdown.DataSource = objResult.ResultDt;
                gvBreakdown.DataBind();
                if (gvBreakdown.Rows.Count > 0)
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
                string strDate = DateTime.UtcNow.AddHours(5.5).ToString().Replace("/", "-").Replace(" ", "-").Replace(":", "-");
                object filename = "BreakDown.docx";
                object saveAs = "BreakDown" + strDate + ".docx";
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
                Response.AddHeader("content-disposition", "attachment;filename=BreakdownMaintainanceReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvBreakdown.AllowPaging = false;
                gvBreakdown.RenderControl(hw);
                string strTitle = "Banaskantha District Co-Operative Milk Producers Union LTD, Palanpur";

                string Date = DateTime.UtcNow.AddHours(5.5).ToString();
                string strSubTitle = "Breakdown Maintainance Report </br> as on " + Date;
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
                object filename = "BreakDown.docx";
                object saveAs = "BreakDown" + strDate + ".pdf";
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
        //            if (gvBreakdown.Rows.Count > 0)
        //            {
        //                foreach (var d in inttablecounts)
        //                {
        //                    Word.Table objTable = aDoc.Tables[d];

        //                    for (int i = 1; i < gvBreakdown.Rows.Count; i++)
        //                    {
        //                        objTable.Rows.Add(objTable.Rows[i + 2]);
        //                        for (int j = 1; j <= objTable.Columns.Count; j++)
        //                        {
        //                            objTable.Cell(i + 2, j).Range.Text = gvBreakdown.Rows[i - 1].Cells[j - 1].Text.Replace("&nbsp;", "");
        //                        }
        //                    }
        //                    for (int i = 1; i <= objTable.Columns.Count; i++)
        //                    {
        //                        objTable.Cell(gvBreakdown.Rows.Count + 2, i).Range.Text = gvBreakdown.Rows[gvBreakdown.Rows.Count - 1].Cells[i - 1].Text.Replace("&nbsp;", "");
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


        public void Breakdown()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("StartTime", typeof(string));
            dt.Columns.Add("EndTime", typeof(string));
            dt.Columns.Add("EquipmentTagNo", typeof(string));
            dt.Columns.Add("EquipmentName", typeof(string));
            dt.Columns.Add("PartNo", typeof(string));
            dt.Columns.Add("PartName", typeof(string));
            dt.Columns.Add("Area", typeof(string));
            dt.Columns.Add("Dept", typeof(string));
            dt.Columns.Add("Section", typeof(string));
            dt.Columns.Add("Cause", typeof(string));
            dt.Columns.Add("DetailsofBreakdown", typeof(string));
            dt.Columns.Add("ActionTaken", typeof(string));
            dt.Columns.Add("RectifiedBy", typeof(string));
            dt.Columns.Add("Remark", typeof(string));
            dt.Columns.Add("UserId", typeof(string));

            DataRow dr1 = dt.NewRow();
            dr1["Date"] = "12/12/2015";
            dr1["StartTime"] = "12:35 PM";
            dr1["EndTime"] = "1:35 PM";
            dr1["EquipmentTagNo"] = "1234";
            dr1["EquipmentName"] = "abc";
            dr1["PartNo"] = "123";
            dr1["PartName"] = "xyz";
            dr1["Area"] = "Vadodara";
            dr1["Dept"] = "abc";
            dr1["Section"] = "1";
            dr1["Cause"] = "No.";
            dr1["DetailsofBreakdown"] = "anc";
            dr1["ActionTaken"] = "No Action";
            dr1["RectifiedBy"] = "Company";
            dr1["Remark"] = "No Remark";
            dr1["UserId"] = "xyz";
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["Date"] = "12/12/2015";
            dr2["StartTime"] = "12:35 PM";
            dr2["EndTime"] = "1:35 PM";
            dr2["EquipmentTagNo"] = "1234";
            dr2["EquipmentName"] = "abc";
            dr2["PartNo"] = "123";
            dr2["PartName"] = "xyz";
            dr2["Area"] = "Vadodara";
            dr2["Dept"] = "abc";
            dr2["Section"] = "1";
            dr2["Cause"] = "No.";
            dr2["DetailsofBreakdown"] = "anc";
            dr2["ActionTaken"] = "No Action";
            dr2["RectifiedBy"] = "Company";
            dr2["Remark"] = "No Remark";
            dr2["UserId"] = "abc";
            dt.Rows.Add(dr2);


            DataRow dr3 = dt.NewRow();
            dr3["Date"] = "12/12/2015";
            dr3["StartTime"] = "12:35 PM";
            dr3["EndTime"] = "1:35 PM";
            dr3["EquipmentTagNo"] = "1234";
            dr3["EquipmentName"] = "abc";
            dr3["PartNo"] = "123";
            dr3["PartName"] = "xyz";
            dr3["Area"] = "Vadodara";
            dr3["Dept"] = "abc";
            dr3["Section"] = "1";
            dr3["Cause"] = "No.";
            dr3["DetailsofBreakdown"] = "anc";
            dr3["ActionTaken"] = "No Action";
            dr3["RectifiedBy"] = "Company";
            dr3["Remark"] = "No Remark";
            dr3["UserId"] = "pqr";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["Date"] = "12/12/2015";
            dr4["StartTime"] = "12:35 PM";
            dr4["EndTime"] = "1:35 PM";
            dr4["EquipmentTagNo"] = "1234";
            dr4["EquipmentName"] = "abc";
            dr4["PartNo"] = "123";
            dr4["PartName"] = "xyz";
            dr4["Area"] = "Vadodara";
            dr4["Dept"] = "abc";
            dr4["Section"] = "1";
            dr4["Cause"] = "No.";
            dr4["DetailsofBreakdown"] = "anc";
            dr4["ActionTaken"] = "No Action";
            dr4["RectifiedBy"] = "Company";
            dr4["Remark"] = "No Remark";
            dr4["UserId"] = "mno";
            dt.Rows.Add(dr4);

            gvBreakdown.DataSource = dt;
            gvBreakdown.DataBind();
        }
    }
}