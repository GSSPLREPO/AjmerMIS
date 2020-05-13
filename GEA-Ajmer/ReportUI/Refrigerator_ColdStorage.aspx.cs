using System;
using GEA_Ajmer.BL;
using GEA_Ajmer.Common;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using log4net;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GEA_Ajmer.ReportUI
{
    public partial class Refrigerator_ColdStorage : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger(typeof(Refrigerator_ColdStorage));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }

        #region Bind Data 
        public void RecordsBind()
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy",
               CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);
                // objResult = new MilkReceptionBL().MilkReception_SelectAll(dtFromDateTime, dtToDateTime, Convert.ToInt32(ddlShiftNo.SelectedValue), Convert.ToInt32(ddlTankerID.SelectedValue), Convert.ToDouble(ddlReceptionLineNo.SelectedValue), Convert.ToDouble(ddlSILONo.SelectedValue));

                objResult = new MilkWeighmentBl().Refrigerator_ColdStorage_SelectAll(dtFromDateTime, dtToDateTime);
                gvRef_ColdStorage.DataSource = objResult.ResutlDs.Tables[0];
                gvRef_ColdStorage.DataBind();
                //gvTotalQty.DataSource = objResult.ResutlDs.Tables[1];
                //gvTotalQty.DataBind();

                if (gvRef_ColdStorage.Rows.Count > 1)
                {
                    imgbtnPDF.Visible = imgbtnExcel.Visible = divNo.Visible = true;
                    divNo.Visible = true;
                }
                else
                {
                    imgbtnPDF.Visible = imgbtnExcel.Visible = divNo.Visible = false;
                    divNo.Visible = true;
                    gvRef_ColdStorage.DataSource = null;
                    gvRef_ColdStorage.DataBind();
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
                string filename = "Ref_ColdStorage_Report_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvRef_ColdStorage.AllowPaging = false;
                gvRef_ColdStorage.GridLines = GridLines.Both;
                gvRef_ColdStorage.RenderControl(hw);
                string Date = DateTime.UtcNow.AddHours(5.5).ToString();
                string strSubTitle = "Refrigerator-Cold Storage Report</br> as on " + Date;

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
                gvRef_ColdStorage.GridLines = GridLines.None;
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
                Response.AddHeader("content-disposition", "attachment;filename=Ref_ColdStorage_Report.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvRef_ColdStorage.AllowPaging = false;
                gvRef_ColdStorage.RenderControl(hw);
                string strTitle = "Panchamrut Dairy, Taloja, Navi-Mumbai";

                string Date = DateTime.UtcNow.AddHours(5.5).ToString();
                string strSubTitle = "Refrigerator Cold Storage Report </br> as on " + Date;
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

        #region Veify Control For check runat=server
        /* This is because when export to pdf, word, excel of gridview 
         * than it is require to check that control is placed inside runat=server. either it will through Exception */
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control); 
        }
        #endregion

        #region btnGo_Click
        protected void btnGo_Click(object sender, EventArgs e)
        {
            RecordsBind();
        }
        #endregion 
    }
}