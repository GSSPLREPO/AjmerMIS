using GEA_Ajmer.BL;
using GEA_Ajmer.Common;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GEA_Ajmer.ReportUI
{
    public partial class TotalPlantOperationLogReport : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger(typeof(TotalPlantOperationLogReport));

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            imgWordButton.Visible = imgPDFButton.Visible = imgExcelButton.Visible = divId.Visible = false;
            ViewState["Mode"] = "Save";
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }
        #endregion

        #region btnGo_Click
        protected void btnGo_Click(object sender, EventArgs e)
        {
            BindPlantOperationGrid();
        }
        #endregion 

        #region imgPDFButton_Click
        protected void imgPDFButton_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string filename = "TotalPlantOperationReport_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvPlantOperation.AllowPaging = false;
                gvPlantOperation.GridLines = GridLines.Both;
                gvPlantOperation.RenderControl(hw);
                string Date = DateTime.UtcNow.AddHours(5.5).ToString();
                string strSubTitle = "Total Plant Operation Report</br> as on " + Date;

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
                gvPlantOperation.GridLines = GridLines.None;
                Response.End();
            }
            catch (Exception ex)
            {
                log.Error("Button PDF", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Oops! There is some technical issue. Please Contact to your administrator.');", true);
            }
        }
        #endregion

        #region imgExcelButton_Click
        protected void imgExcelButton_Click(object sender, EventArgs e)
        {
            try
            {
                Response.AddHeader("content-disposition", "attachment;filename=TotalPlantOperationReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvPlantOperation.AllowPaging = false;
                gvPlantOperation.RenderControl(hw);
                string strTitle = "Panchamrut Dairy, Taloja, Navi-Mumbai";

                string Date = DateTime.UtcNow.AddHours(5.5).ToString();
                string strSubTitle = "Total Plant Operation Report </br> as on " + Date;
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

        #region imgWordButton_Click
        protected void imgWordButton_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region BindPlantOperationGrid Data Bind
        public void BindPlantOperationGrid()
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
               CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);

                objResult = new TotalPlantProductionBL().PlantProductionLogReport(dtFromDateTime, dtToDateTime);
               
                
                //ViewState["DataTableMilkStorage"] = objResult.ResutlDs.Tables[0];
                gvPlantOperation.DataSource = objResult.ResultDt;
                gvPlantOperation.DataBind();
                //gvTotalQty.DataSource = objResult.ResutlDs.Tables[1];
                //gvTotalQty.DataBind();

                if (gvPlantOperation.Rows.Count > 1)
                {

                    imgWordButton.Visible = imgPDFButton.Visible = imgExcelButton.Visible = divId.Visible = true;
                    divId.Visible = false;
                }
                else
                {
                    imgWordButton.Visible = imgPDFButton.Visible = imgExcelButton.Visible = divId.Visible = false;
                    divId.Visible = true;
                    gvPlantOperation.DataSource = null;
                    gvPlantOperation.DataBind();
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

        #region VerifyRenderingInServerForm
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        #endregion

    }
}