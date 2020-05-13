using System;
using System.Web.UI;
using GEA_Ajmer.BL;
using GEA_Ajmer.BO;
using GEA_Ajmer.Common;
using GEA_Ajmer.ReportUI;
using log4net;

namespace GEA_Ajmer
{
    public partial class Login : Page
    {
        private static ILog log = LogManager.GetLogger(typeof(Login));

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) return;
                lblMsg.Visible = false;
                if (Session[ApplicationSession.Userid] != null)
                {
                    Response.Redirect("WebUI/Home.aspx", false);
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


        #region Button btnLogin OnClick Event
        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            try
            {
                EmployeeBl objEmployeeBl = new EmployeeBl();
                ApplicationResult objResult = new ApplicationResult();
                objResult = objEmployeeBl.Employee_Select_ForLogin(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                if (objResult.ResultDt.Rows.Count > 0)
                {
                    Session[ApplicationSession.Userid] = objResult.ResultDt.Rows[0][EmployeeBo.EMPLOYEE_ID];
                    Session[ApplicationSession.Username] = txtUserName.Text.Trim();
                    Session[ApplicationSession.Roleid] = objResult.ResultDt.Rows[0][EmployeeBo.EMPLOYEE_ROLEID];
                    Session[ApplicationSession.OrganisationName] = "The Ajmer District Co-Operative Milk";
                    Session[ApplicationSession.OrganisationAddress] = "Producers Union Ltd., MIDC Taloja, Navi Mumbai, Raigad, 410208";
                    Session[ApplicationSession.Logo] = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/GEAProcess_large_20122024.jpg";
                    // Session[ApplicationSession.Logo] = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/GEAProcess_large_20122024.jpg";
                     Session[ApplicationSession.CombinedLogo] = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/GEAProcess_large_20122024.jpg";
                    Response.Redirect("WebUI/DashBoard.aspx", false);
                }
                else
                {
                    lblMsg.Text = "Invalid Username or Password";
                    lblMsg.Visible = true;
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
    }
}