using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using GEA_Ajmer.BL;
using GEA_Ajmer.BO;
using GEA_Ajmer.Common;
using System.Globalization;
using log4net;
//using Word = Microsoft.Office.Interop.Word;

namespace GEA_Ajmer.ReportUI
{
    public partial class MilkWeighmentReport : PageBase
    {
        //private Word.Application wordApp;
        //Word.Document aDoc = null;
        private static ILog log = LogManager.GetLogger(typeof(MilkWeighmentReport));

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) return;
                BindShiftNo();
                //BindTankerId();
                BindSILO();
                BindReceptionLineNo();
                divExport.Visible = false;
                divNo.Visible = false;
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion



        #region Bind Shift No
        protected void BindShiftNo()
        {
            Controls objControls = new Controls();
            ShiftBl objShiftBl = new ShiftBl();
            var objResult = objShiftBl.Shift_SelectAll();
            if (objResult != null)
            {
                if (objResult.ResultDt.Rows.Count > 0)
                {
                    objControls.BindDropDown_ListBox(objResult.ResultDt, ddlShiftNo, "Name", "ShiftId");
                }
                ddlShiftNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select All--", "-1"));
            }
        }
        #endregion

        //#region Bind Tanker Id
        //protected void BindTankerId()
        //{
        //    Controls objControls = new Controls();
        //    Reception_PLCBl objReceptionPlcBl = new Reception_PLCBl();
        //    var objResult = objReceptionPlcBl.Reception_PLC_SelectAll();
        //    if (objResult != null)
        //    {
        //        if (objResult.ResultDt.Rows.Count > 0)
        //        {
        //            objControls.BindDropDown_ListBox(objResult.ResultDt, ddlTankerID, "Tanker_ID", "Tanker_ID");
        //        }
        //        ddlTankerID.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select All--", "-1"));
        //    }
        //}
        //#endregion

        #region Bind Reception Line NO
        protected void BindReceptionLineNo()
        {
            Controls objControls = new Controls();
            ReceptionBl objReceptionBl = new ReceptionBl();
            var objResult = objReceptionBl.Reception_SelectAll();
            if (objResult != null)
            {
                if (objResult.ResultDt.Rows.Count > 0)
                {
                    objControls.BindDropDown_ListBox(objResult.ResultDt, ddlReceptionLineNo, "Name", "PLCValue");
                }
                ddlReceptionLineNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select All--", "-1"));
            }
        }
        #endregion

        #region Bind SILO
        protected void BindSILO()
        {
            Controls objControls = new Controls();
            SiloBl objSiloBl = new SiloBl();
            var objResult = objSiloBl.Silo_SelectAll();
            if (objResult != null)
            {
                if (objResult.ResultDt.Rows.Count > 0)
                {
                    objControls.BindDropDown_ListBox(objResult.ResultDt, ddlSILONo, "Name", "PLCValue");
                }
                ddlSILONo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select All--", "-1"));
            }
        }
        #endregion



        #region Button Go Click Event
        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                Reception_PLCBl objReceptionPlcBl = new Reception_PLCBl();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                var objResult = objReceptionPlcBl.Reception_PLC_Select(dtFromDateTime, dtToDateTime, Convert.ToInt32(ddlShiftNo.SelectedValue), Convert.ToInt32(ddlTankerID.SelectedValue), Convert.ToDouble(ddlReceptionLineNo.SelectedValue), Convert.ToDouble(ddlSILONo.SelectedValue));
                gvReport1.DataSource = objResult.ResultDt;
                gvReport1.DataBind();
                if (gvReport1.Rows.Count > 0)
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

        #region Export to Excel Button Click
        protected void imgbtnExcel_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.AddHeader("content-disposition", "attachment;filename=MilkWeighment.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvReport1.AllowPaging = false;
                gvReport1.RenderControl(hw);
                string strTitle = "Banaskantha District Co-Operative Milk Producers Union LTD, Palanpur";

                string Date = DateTime.UtcNow.AddHours(5.5).ToString();
                string strSubTitle = "Milk Weighment Report </br> as on " + Date;
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
                object filename = "MilkWeighmentReport.docx";
                object saveAs = "MilkWeighmentReport" + strDate + ".pdf";
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

        #region Export to Word button click
        protected void imgbtnWord_OnClick(object sender, EventArgs e)
        {
            try
            {
                string strDate = DateTime.UtcNow.AddHours(5.5).ToString().Replace("/", "-").Replace(" ", "-").Replace(":", "-");
                object filename = "MilkWeighmentReport.docx";
                object saveAs = "MilkWeighmentReport" + strDate + ".docx";
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

        //            aDoc = wordApp.Documents.Open(ref fileName, ref missing,
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

        //            if (gvReport1.Rows.Count > 0)
        //            {
        //                foreach (var d in inttablecounts)
        //                {
        //                    Word.Table objTable = aDoc.Tables[d];

        //                    for (int i = 1; i < gvReport1.Rows.Count; i++)
        //                    {
        //                        objTable.Rows.Add(objTable.Rows[i + 2]);
        //                        for (int j = 1; j <= objTable.Columns.Count; j++)
        //                        {
        //                            objTable.Cell(i + 2, j).Range.Text = gvReport1.Rows[i - 1].Cells[j - 1].Text.Replace("&nbsp;", "");
        //                        }
        //                    }
        //                    for (int i = 1; i <= objTable.Columns.Count; i++)
        //                    {
        //                        objTable.Cell(gvReport1.Rows.Count + 2, i).Range.Text = gvReport1.Rows[gvReport1.Rows.Count - 1].Cells[i - 1].Text.Replace("&nbsp;", "");
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

        //        aDoc.SaveAs(ref outputFileName, ref fileFormat, ref missing, ref missing,
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
        //        throw;
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
    }
}