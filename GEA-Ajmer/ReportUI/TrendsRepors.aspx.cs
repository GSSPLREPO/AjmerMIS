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
    public partial class TrendsRepors : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger(typeof(TrendsRepors));

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

        #region btnGo_Click
        protected void btnGo_Click(object sender, EventArgs e)
        {
            BindReportData();
        }
        #endregion 

        #region Trend Data Bind
        public void BindReportData()
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                int intGraphId = Convert.ToInt32(ddlPasteuriser.SelectedValue.ToString());
                // objResult = new MilkReceptionBL().MilkReception_SelectAll(dtFromDateTime, dtToDateTime, Convert.ToInt32(ddlShiftNo.SelectedValue), Convert.ToInt32(ddlTankerID.SelectedValue), Convert.ToDouble(ddlReceptionLineNo.SelectedValue), Convert.ToDouble(ddlSILONo.SelectedValue));

                objResult = new TempratureTrendBL().GetALl_TemperatureTrendDataReport(dtFromDateTime, dtToDateTime, intGraphId);
                //ViewState["DataTableMilkStorage"] = objResult.ResutlDs.Tables[0];

                gvTrendData.DataSource = null;
                gvTrendData.DataBind();

                gvTrendData.DataSource = objResult.ResultDt;
                gvTrendData.DataBind();
                //gvTotalQty.DataSource = objResult.ResutlDs.Tables[1];
                //gvTotalQty.DataBind();

                if (gvTrendData.Rows.Count > 1)
                {
                    imgbtnPDF.Visible = imgbtnExcel.Visible = divNo.Visible = true;
                    divNo.Visible = false;

                    if (Convert.ToInt32(ddlPasteuriser.SelectedValue.ToString()) == 1)
                    {
                        lblHeader1.Text = "MPL-1 Temperature Report";
                        lblHeader2.Text = "MPL-1 Temperature Report";
                    }
                    else if (Convert.ToInt32(ddlPasteuriser.SelectedValue.ToString()) == 2)
                    {
                        lblHeader1.Text = "MPL-2 Temperature Report";
                        lblHeader2.Text = "MPL-2 Temperature Report";
                    }
                    else if (Convert.ToInt32(ddlPasteuriser.SelectedValue.ToString()) == 3)
                    {
                        lblHeader1.Text = "CPL Temperature Report";
                        lblHeader2.Text = "CPL Temperature Report";
                    }
                    else if (Convert.ToInt32(ddlPasteuriser.SelectedValue.ToString()) == 4)
                    {
                        lblHeader1.Text = "Curd Temperature Report";
                        lblHeader2.Text = "Curd Temperature Report";
                    }
                    else if (Convert.ToInt32(ddlPasteuriser.SelectedValue.ToString()) == 5)
                    {
                        lblHeader1.Text = "BM Temperature Report";
                        lblHeader2.Text = "BM Temperature Report";
                    }
                    else if (Convert.ToInt32(ddlPasteuriser.SelectedValue.ToString()) == 6)
                    {
                        lblHeader1.Text = "MPLBM Temperature Report";
                        lblHeader2.Text = "MPLBM Temperature Report";
                    }

                }
                else
                {
                    imgbtnPDF.Visible = imgbtnExcel.Visible = divNo.Visible = false;
                    divNo.Visible = true;
                    gvTrendData.DataSource = null;
                    gvTrendData.DataBind();

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
                string filename = lblHeader2.Text+"_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvTrendData.AllowPaging = false;
                gvTrendData.GridLines = GridLines.Both;
                gvTrendData.RenderControl(hw);
                string Date = DateTime.UtcNow.AddHours(5.5).ToString();
                string strSubTitle = lblHeader2 .Text+ " Report</br> as on " + Date;

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
                gvTrendData.GridLines = GridLines.None;
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
                Response.AddHeader("content-disposition", "attachment;filename="+lblHeader1.Text+".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvTrendData.AllowPaging = false;
                gvTrendData.RenderControl(hw);
                string strTitle = "Panchamrut Dairy, Taloja, Navi-Mumbai";

                string Date = DateTime.UtcNow.AddHours(5.5).ToString();
                string strSubTitle =  lblHeader2.Text+" Report </br> as on " + Date;
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

    }
}