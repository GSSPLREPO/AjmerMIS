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

namespace GEA_Ajmer.ReportUI
{
    public partial class ProductDispatchReport : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger(typeof(UtilityStatusReport));
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductDispatch();
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
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
        }
        public void ProductDispatch()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SrNo", typeof(int));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Time", typeof(string));
            dt.Columns.Add("DeliveryChallanNo", typeof(string));
            dt.Columns.Add("VehicleNo", typeof(string));
            dt.Columns.Add("BatchNo", typeof(string));
            dt.Columns.Add("BagNo", typeof(string));
            dt.Columns.Add("ProductType", typeof(string));
            dt.Columns.Add("FAT", typeof(string));
            dt.Columns.Add("Moisture", typeof(string));
            dt.Columns.Add("Acidity", typeof(string));
            dt.Columns.Add("QualityParameter", typeof(string));
            dt.Columns.Add("QtyDispatched", typeof(string));
            dt.Columns.Add("DespatchedTo", typeof(string));
            dt.Columns.Add("UserId", typeof(string));
            DataRow dr1 = dt.NewRow();


            dr1["SrNo"] = 1;
            dr1["Date"] = "11/10/2015";
            dr1["Time"] = "8:30 AM";
            dr1["DeliveryChallanNo"] = "1234";
            dr1["VehicleNo"] = "GJ 6HI 5303";
            dr1["BatchNo"] = "1000";
            dr1["BagNo"] = "54";
            dr1["ProductType"] = "New";
            dr1["FAT"] = "5";
            dr1["Moisture"] = "15";
            dr1["Acidity"] = "120";
            dr1["QualityParameter"] = "OK";
            dr1["QtyDispatched"] = "150";
            dr1["DespatchedTo"] = "Vadodara";
            dr1["UserId"] = "abc";
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["SrNo"] = 2;
            dr2["Date"] = "04/08/2016";
            dr2["Time"] = "5:30 PM";
            dr2["DeliveryChallanNo"] = "1234";
            dr2["VehicleNo"] = "GJ 5AK 1475";
            dr2["BatchNo"] = "1500";
            dr2["BagNo"] = "54";
            dr2["ProductType"] = "New";
            dr2["FAT"] = "5";
            dr2["Moisture"] = "05";
            dr2["Acidity"] = "138";
            dr2["QualityParameter"] = "OK";
            dr2["QtyDispatched"] = "200";
            dr2["DespatchedTo"] = "Ahmedabad";
            dr2["UserId"] = "pqrs";
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["SrNo"] = 2;
            dr3["Date"] = "04/08/2016";
            dr3["Time"] = "5:30 PM";
            dr3["DeliveryChallanNo"] = "1234";
            dr3["VehicleNo"] = "GJ 5AK 1475";
            dr3["BatchNo"] = "1500";
            dr3["BagNo"] = "54";
            dr3["ProductType"] = "New";
            dr3["FAT"] = "5";
            dr3["Moisture"] = "05";
            dr3["Acidity"] = "138";
            dr3["QualityParameter"] = "OK";
            dr3["QtyDispatched"] = "200";
            dr3["DespatchedTo"] = "Ahmedabad";
            dr3["UserId"] = "pqrs";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["SrNo"] = 2;
            dr4["Date"] = "04/08/2016";
            dr4["Time"] = "5:30 PM";
            dr4["DeliveryChallanNo"] = "1234";
            dr4["VehicleNo"] = "GJ 5AK 1475";
            dr4["BatchNo"] = "1500";
            dr4["BagNo"] = "54";
            dr4["ProductType"] = "New";
            dr4["FAT"] = "5";
            dr4["Moisture"] = "05";
            dr4["Acidity"] = "138";
            dr4["QualityParameter"] = "OK";
            dr4["QtyDispatched"] = "200";
            dr4["DespatchedTo"] = "Ahmedabad";
            dr4["UserId"] = "pqrs";
            dt.Rows.Add(dr4);

            gvProductDispatch.DataSource = dt;
            gvProductDispatch.DataBind();
        }

        protected void gvProductDispatch_OnPreRender(object sender, EventArgs e)
        {

        }

        protected void gvProductDispatch_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvProductDispatch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtDate = (TextBox)e.Row.FindControl("txtDate");
                txtDate.Text = System.DateTime.UtcNow.AddHours(5.5).Date.ToString("dd/MM/yyyy");
                txtDate.ReadOnly = true;
                TextBox txtTime = (TextBox)e.Row.FindControl("txtTime");
                txtTime.Text = System.DateTime.UtcNow.AddHours(5.5).ToString("hh:mm:ss") ;
                txtTime.ReadOnly = true;
                 
            }
        }
    }
}