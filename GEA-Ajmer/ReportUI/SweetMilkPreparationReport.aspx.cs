using System;
using System.Data;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GEA_Ajmer.BL;
using log4net;

namespace AMULFED.ReportUI
{
    public partial class SweetMilkPreparationReport : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger(typeof(SweetMilkPreparationReport));
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                btnGo_OnClick(sender,e);
            }
        }

        protected void imgbtnPDF_OnClick(object sender, EventArgs e)
        {

        }

        protected void imgbtnExcel_OnClick(object sender, EventArgs e)
        {

        }
        protected void imgbtnWord_OnClick(object sender, EventArgs e)
        {

        }
        public void SweetMilkReport()
        {
        }

        protected void gvSweetMilk_OnPreRender(object sender, EventArgs e)
        {

        }
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            try
            {
                LogBl objLogBl = new LogBl();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //var objResult = objLogBl.SugarsyrpReport(dtFromDateTime, dtToDateTime);
                var objResult = objLogBl.SweetMilkReport(dtFromDateTime, dtToDateTime);
                if (objResult.ResultDt.Rows.Count > 0)
                {
                    gvSweetMilk.DataSource = objResult.ResultDt;
                    gvSweetMilk.DataBind();
                    divExport.Visible = divExport.Visible = true;
                    gvSweetMilk.Visible = false;
                    for (int i = 0; i < gvSweetMilk.Rows.Count; i++)
                    {
                        TextBox txt = (TextBox)gvSweetMilk.Rows[i].FindControl("txtQtySugar");
                        txt.Text = objResult.ResultDt.Rows[i]["QtyOfSugarSyrup"].ToString();
                    }
                }
                else
                {
                    divExport.Visible =  false;
                    //divRecord.Visible = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        protected void gvSweetMilk_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}