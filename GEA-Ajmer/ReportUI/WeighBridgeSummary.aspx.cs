using GEA_Ajmer.BL;
using GEA_Ajmer.Common;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using log4net;
using System;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GEA_Ajmer.ReportUI
{
    public partial class WeighBridgeSummary : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger(typeof(WeighBridgeSummary));

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                imgbtnPDF.Visible = imgbtnExcel.Visible = divNo.Visible = false;
                ViewState["Mode"] = "Save";
            }
        }
        #endregion

        #region WeighBridgeSummary Data Bind
        public void WeighBridgeSummaryBind()
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy",
               CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);
                // objResult = new MilkReceptionBL().MilkReception_SelectAll(dtFromDateTime, dtToDateTime, Convert.ToInt32(ddlShiftNo.SelectedValue), Convert.ToInt32(ddlTankerID.SelectedValue), Convert.ToDouble(ddlReceptionLineNo.SelectedValue), Convert.ToDouble(ddlSILONo.SelectedValue));

                objResult = new MilkWeighmentBl().WeighBridgeSummary_SelectAll(dtFromDateTime, dtToDateTime);
                //ViewState["DataTableMilkStorage"] = objResult.ResutlDs.Tables[0];
                gvWeighbridgeSummary.DataSource = objResult.ResutlDs.Tables[0];
                gvWeighbridgeSummary.DataBind();
                //gvTotalQty.DataSource = objResult.ResutlDs.Tables[1];
                //gvTotalQty.DataBind();

                if (gvWeighbridgeSummary.Rows.Count > 1)
                {
                   imgbtnPDF.Visible = imgbtnExcel.Visible = divNo.Visible = true;
                    divNo.Visible = false;
                }
                else
                {
                    imgbtnPDF.Visible = imgbtnExcel.Visible = divNo.Visible = false;
                    divNo.Visible = true;
                    gvWeighbridgeSummary.DataSource = null;
                    gvWeighbridgeSummary.DataBind();
                    // ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    //"<script>alert('No Record Found.');</script>");
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


        #region btnGo_Click
        protected void btnGo_Click(object sender, EventArgs e)
        {
            WeighBridgeSummaryBind();
        }
        #endregion

        #region imgbtnPDF_Click
        protected void imgbtnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string filename = "WeighbridgeSummaryReport_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvWeighbridgeSummary.AllowPaging = false;
                gvWeighbridgeSummary.GridLines = GridLines.Both;
                gvWeighbridgeSummary.RenderControl(hw);
                string Date = DateTime.UtcNow.AddHours(5.5).ToString();
                string strSubTitle = "Weighbridge Summary Report</br> as on " + Date;

                string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Logo1.gif";
                string content = "<div align='left' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/></div><div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                      "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/>" +
                         "<span align='center' style='font-family:verdana;font-size:13px'><strong>" + strSubTitle + "</strong></span><br/>" +
                         "<div align='center' style='font-family:verdana;font-size:12px'><strong>From Date :</strong>" +
                     DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) +
                      "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
                      DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) +
                      "</div><br/> "
                      + sw.ToString() + "<br/></div>";
                StringReader sr = new StringReader(content);
                Document pdfDoc = new Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                gvWeighbridgeSummary.GridLines = GridLines.None;
                Response.End();
            }
            catch (Exception ex)
            {
                log.Error("Button PDF", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Oops! There is some technical issue. Please Contact to your administrator.');", true);
            }
        }
        #endregion

        #region imgbtnExcel_Click
        protected void imgbtnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.AddHeader("content-disposition", "attachment;filename=WeighbridgeReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvWeighbridgeSummary.AllowPaging = false;
                gvWeighbridgeSummary.RenderControl(hw);
                string strTitle = "Panchamrut Dairy, Taloja, Navi-Mumbai";

                string Date = DateTime.UtcNow.AddHours(5.5).ToString();
                string strSubTitle = "Weighbridge Data Report </br> as on " + Date;
                string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Logo1.gif";
                string content = "<div align='left' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/></div><div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                       "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/>" +
                          "<span align='center' style='font-family:verdana;font-size:13px'><strong>" + strSubTitle + "</strong></span><br/>" +
                          "<div align='center' style='font-family:verdana;font-size:12px'><strong>From Date :</strong>" +
                      DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) +
                       "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
                       DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) +
                       "</div><br/> "
                       + sw.ToString() + "<br/></div>";
                Response.Output.Write(content);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region imgbtnWord_Click
        protected void imgbtnWord_Click(object sender, EventArgs e)
        {

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


    }
}