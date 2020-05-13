using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI;
using GEA_Ajmer.BL;
using GEA_Ajmer.Common;
using log4net;
using System.Web.UI.WebControls;
using System.Web;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System.Collections;
using System.Data;
using System.Web.Services;

namespace GEA_Ajmer.ReportUI
{
    public partial class DryerPerformanceReport : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger(typeof(DryerPerformanceReport));
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
           
            divExport.Visible = false;
            divNo.Visible = false;
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
            try
            {
                ReportBL objBL = new ReportBL();
                ApplicationResult objResult = new ApplicationResult();


                objResult = objBL.DryerPerformanceReport(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text), Convert.ToInt32(ddlReport.SelectedValue));
                if (ddlReport.SelectedValue == "1")
                {
                    if (objResult.ResultDt.Rows.Count >= 1)
                    {
                        divNo.Visible = false;
                        gvPlantPerformance.Columns[0].Visible = false;
                        gvPlantPerformance.Columns[1].Visible = true;
                        gvPlantPerformance.Columns[3].Visible = true;
                        gvPlantPerformance.Columns[2].Visible = false;
                        gvPlantPerformance.Columns[9].Visible = false;
                        gvPlantPerformance.Columns[10].Visible = true;
                        gvPlantPerformance.Columns[11].Visible = true;
                        gvPlantPerformance.Visible = true;
                        gvPlantPerformance.DataSource = objResult.ResultDt;
                        gvPlantPerformance.DataBind();
                        for (int i = 0; i < gvPlantPerformance.Rows.Count; i++)
                        {
                            gvPlantPerformance.Columns[0].Visible = false;
                            TextBox txtBreakdownHours = (TextBox)gvPlantPerformance.Rows[i].Cells[6].FindControl("txtBreakdownHours");
                            TextBox txtIdleHours = (TextBox)gvPlantPerformance.Rows[i].Cells[7].FindControl("txtIdleHours");
                            TextBox txtRemarks = (TextBox)gvPlantPerformance.Rows[i].Cells[9].FindControl("txtRemarks");
                            txtBreakdownHours.Text = objResult.ResultDt.Rows[i]["BreakdownHours"].ToString();
                            txtIdleHours.Text = objResult.ResultDt.Rows[i]["IdleHours"].ToString();
                            txtRemarks.Text = objResult.ResultDt.Rows[i]["Remarks"].ToString();
                            btnSave.Enabled = true;
                        }
                    }
                    else
                    {
                        divNo.Visible = true;
                        gvPlantPerformance.Visible = false;
                    }
                }
                else
                {
                    objResult = objBL.DryerPerformanceReportMonthly(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text), Convert.ToInt32(ddlReport.SelectedValue));
                    if (objResult.ResultDt.Rows.Count >= 1)
                    {
                        divNo.Visible = false;
                        gvPlantPerformance.Columns[0].Visible = false;
                        gvPlantPerformance.Columns[1].Visible = false;
                        gvPlantPerformance.Columns[3].Visible = false;
                        gvPlantPerformance.Columns[2].Visible = true;
                        gvPlantPerformance.Columns[9].Visible = true;
                        gvPlantPerformance.Columns[10].Visible = true;
                        gvPlantPerformance.Columns[11].Visible = false;
                        gvPlantPerformance.Visible = true;
                        gvPlantPerformance.DataSource = objResult.ResultDt;
                        gvPlantPerformance.DataBind();
                        for (int i = 0; i < gvPlantPerformance.Rows.Count; i++)
                        {
                            gvPlantPerformance.Columns[0].Visible = false;
                            var id = gvPlantPerformance.Rows[i].Cells[0].Text;
                            TextBox txtBreakdownHours = (TextBox)gvPlantPerformance.Rows[i].Cells[6].FindControl("txtBreakdownHours");
                            TextBox txtIdleHours = (TextBox)gvPlantPerformance.Rows[i].Cells[7].FindControl("txtIdleHours");
                            TextBox txtRemarks = (TextBox)gvPlantPerformance.Rows[i].Cells[9].FindControl("txtRemarks");
                            txtBreakdownHours.Text = objResult.ResultDt.Rows[i]["BreakdownHours"].ToString();
                            txtIdleHours.Text = objResult.ResultDt.Rows[i]["IdleHours"].ToString();
                            txtRemarks.Text = objResult.ResultDt.Rows[i]["Remarks"].ToString();
                            btnSave.Enabled = true;
                        }
                    }
                    else
                    {
                        divNo.Visible = true;
                        gvPlantPerformance.Visible = false;
                    }
                    
                    BindGraph();

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

        #region btnSave_Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlReport.SelectedValue == "1")
            {
                try
                {
                    DryerPerformanceBL ObjBL = new DryerPerformanceBL();
                    //int Count = 0;
                    foreach (GridViewRow row in gvPlantPerformance.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            string strBreakdownHours = ((TextBox)row.FindControl("txtBreakdownHours")).Text;
                            string strIdleHours = ((TextBox)row.FindControl("txtIdleHours")).Text;
                            string strRemarks = ((TextBox)row.FindControl("txtRemarks")).Text;
                            int IntId = Convert.ToInt32(row.Cells[0].Text);
                            string strPlantName = row.Cells[1].Text;
                            int ModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                            DateTime ModifiedDate = DateTime.UtcNow.AddHours(5.5);

                            ApplicationResult objResult = new ApplicationResult();
                            objResult = ObjBL.Insert_DryerPerformanceReport(IntId, strBreakdownHours, strIdleHours, strRemarks, ModifiedDate, ModifiedBy);

                            if (objResult != null)
                            {
                                if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                                {
                                    // Count = Count + 1;
                                    // ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Data Saved Successfully.');</script>");
                                }
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    //DatabaseTransaction.RollbackTransation();
                    log.Error("Error", ex);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                }
            }
            else
            {
                try
                {
                    DryerPerformanceBL ObjBL = new DryerPerformanceBL();
                    //int Count = 0;
                    foreach (GridViewRow row in gvPlantPerformance.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            string strBreakdownHours = ((TextBox)row.FindControl("txtBreakdownHours")).Text;
                            string strIdleHours = ((TextBox)row.FindControl("txtIdleHours")).Text;
                            string strRemarks = ((TextBox)row.FindControl("txtRemarks")).Text;
                            int IntId = Convert.ToInt32(row.Cells[0].Text);
                            string strdate = row.Cells[2].Text;
                            string strPlantName = row.Cells[1].Text;
                            string strTotalHours = row.Cells[8].Text;
                            string strOprationHours = row.Cells[4].Text;
                            string strCIPHours = row.Cells[5].Text;
                            string strpecentEgg = row.Cells[9].Text;
                            int ModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                            DateTime ModifiedDate = DateTime.UtcNow.AddHours(5.5);

                            ApplicationResult objResult = new ApplicationResult();
                            objResult = ObjBL.Insert_DryerPerformanceMonthlyReport(IntId, strBreakdownHours, strIdleHours, strRemarks, ModifiedDate, ModifiedBy, strTotalHours, strdate, strOprationHours, strCIPHours, strpecentEgg);

                            if (objResult != null)
                            {
                                if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                                {
                                    // Count = Count + 1;
                                    // ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Data Saved Successfully.');</script>");
                                }
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    //DatabaseTransaction.RollbackTransation();
                    log.Error("Error", ex);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                }

            }
        }
        #endregion

        #region Trend Graph
        [WebMethod]
        public void BindGraph()
        {
            try
            {
                ReportBL objBL = new ReportBL();
                ApplicationResult objResult = new ApplicationResult();
                
                objResult = objBL.DryerPerformanceReportMonthlyGraph(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text));
                                
                List<String> dateyearArr = new List<String>();

                // datatable column to array
                for (int a = 0; a < objResult.ResultDt.Rows.Count; a++)
                {
                    dateyearArr.Add(objResult.ResultDt.Rows[a]["Date/Year"].ToString());
                }
                    
                List<String> PercentageEnggBDArr = new List<String>();

                // datatable column to array
                for (int a = 0; a < objResult.ResultDt.Rows.Count; a++)
                {
                    PercentageEnggBDArr.Add(objResult.ResultDt.Rows[a]["PercentageEnggBD"].ToString());
                }
                //  var stringArr = objResult.ResultDt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                   "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        protected void imgExcelButton_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string filename = "DryerPerformanceReport" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvPlantPerformance.AllowPaging = false;
                gvPlantPerformance.GridLines = GridLines.Both;
                foreach (TableCell cell in gvPlantPerformance.HeaderRow.Cells)
                {
                    cell.BackColor = gvPlantPerformance.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvPlantPerformance.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvPlantPerformance.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvPlantPerformance.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                        List<Control> controls = new List<Control>();

                        //Add controls to be removed to Generic List
                        foreach (Control control in cell.Controls)
                        {
                            controls.Add(control);
                        }

                        //Loop through the controls to be removed and replace then with Literal
                        foreach (Control control in controls)
                        {
                            switch (control.GetType().Name)
                            {
                                case "HyperLink":
                                    cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                    break;
                                case "TextBox":
                                    cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                    break;
                                case "LinkButton":
                                    cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                    break;
                                case "CheckBox":
                                    cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                    break;
                                case "RadioButton":
                                    cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                    break;
                            }
                            cell.Controls.Remove(control);
                        }
                    }
                }

                gvPlantPerformance.RenderControl(hw);
                string strSubTitle = "DRYER PERFORMANCE REPORT";

                string content = "<div align='center'><img align='left' style='height: 40px; width: 109px' src='" + Session[ApplicationSession.Logo] + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/></div>" +
                  "<div align='center' style='font-family:verdana;font-size:11px'><strong>From Date :</strong>" +
                (DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToShortDateString() +
                 "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
                 (DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToShortDateString() +
                "</div><br/><div align='center' style='font-family:verdana;font-size:11px'><span style='font-size:11px;color:Maroon;'>" + strSubTitle + "</ span><br/>" +
                 "<br/>" + sw.ToString() + "<br/></div>";

                string style = @"<!--mce:2-->";
                Response.Write(style);
                Response.Output.Write(content);
                Response.Flush();
                Response.Clear();
                Response.End();

            }
            catch (Exception ex)
            {
                log.Error("Button EXCEL", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Oops! There is some technical issue. Please Contact to your administrator.');", true);
            }
        }

        protected void imgbtnPDF_OnClick(object sender, EventArgs e)
        {

        }
    }
}