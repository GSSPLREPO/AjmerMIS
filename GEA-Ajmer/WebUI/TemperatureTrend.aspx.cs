using System;
using log4net;

namespace GEA_Ajmer.WebUI
{
    public partial class TemperatureTrend : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger(typeof(TemperatureTrend));

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { }
        }
        #endregion

        protected void btnGo_Click(object sender, EventArgs e)
        {

        }
    }
}