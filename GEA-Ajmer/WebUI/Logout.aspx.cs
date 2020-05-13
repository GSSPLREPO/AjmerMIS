using System;
using GEA_Ajmer.Common;

namespace GEA_Ajmer.WebUI
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[ApplicationSession.Username] != null)
                {
                    Session.Abandon();
                }
                Response.Redirect("Logout.aspx", false);
            }
        }
    }
}