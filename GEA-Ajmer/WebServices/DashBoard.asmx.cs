using GEA_Ajmer.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using GEA_Ajmer.BL;
using System.Xml;
using Newtonsoft.Json;

namespace GEA_Ajmer.WebServices
{
    /// <summary>
    /// Summary description for DashBoard
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DashBoard : System.Web.Services.WebService
    {
        #region GraphDetail Milk Volume
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public string datatable(string DateTime)
        {
            DataSet table = new DataSet();
            ApplicationResult objResult = new ApplicationResult();
            ReportBL objReportBL = new ReportBL();
            objResult = objReportBL.GetAllData(DateTime);
            if (objResult != null)
            {
                if (objResult.ResutlDs.Tables.Count > 0)
                {
                    table = objResult.ResutlDs;
                }
            }
            string strJsonResult = JsonConvert.SerializeObject(table, Newtonsoft.Json.Formatting.Indented);
            return strJsonResult;
        }
        #endregion

        #region MPL1 Charts
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)] 
        //public List<RevenueEntities> MPL1Data(string Fromdate, string Fromtime, string Todate, string Totime)
        public string MPL1Data(string strGraph,string Fromdate, string Fromtime, string Todate, string Totime)
        {
            DataTable table = new DataTable();
            ApplicationResult objResult = new ApplicationResult();
            TempratureTrendBL objTempTrendBL = new TempratureTrendBL();


            DateTime dtFromDateTime = DateTime.ParseExact(Fromdate + " " + Fromtime, "dd/MM/yyyy HH:mm:ss",
                 System.Globalization.CultureInfo.InvariantCulture);
            DateTime dtToDateTime = DateTime.ParseExact(Todate + " " + Totime, "dd/MM/yyyy HH:mm:ss",
                System.Globalization.CultureInfo.InvariantCulture);

            //DateTime dtFromDateTime = Convert.ToDateTime("28/10/2018 12:10:20");
            //DateTime dtToDateTime = Convert.ToDateTime("30/10/2018 12:10:20");
            objResult = objTempTrendBL.GetALl_TemperatureTrendData(dtFromDateTime, dtToDateTime,strGraph);
            if (objResult != null)
            {
                if (objResult.ResutlDs.Tables.Count > 0)
                {
                    table = objResult.ResutlDs.Tables[0];
                }
            }
            string strJsonResult = JsonConvert.SerializeObject(table, Newtonsoft.Json.Formatting.Indented);
            //return JsonConvert.SerializeObject(objResult.ResutlDs.Tables[0]);
            string j=JsonConvert.SerializeObject(objResult.ResutlDs.Tables[0]);
            return j;


        }

        #endregion


       
    }
}
