using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GEA_Ajmer.BL;
using GEA_Ajmer.BL;
using GEA_Ajmer.BO;
using GEA_Ajmer.Common;
using GEA_Ajmer.ReportUI;
using log4net;

namespace GEA_Ajmer.WebUI
{
    public partial class Lab : PageBase
    {
        private static ILog log = LogManager.GetLogger(typeof(LabReport));
        private Controls objControls = new Controls();

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session[ApplicationSession.Userid] != null)
                {
                    if (IsPostBack) return;
                    ViewState["Mode"] = "Save";
                    PanelVisibilityMode(true, false);
                    getDatesofMonth();
                    txtLabDate.Attributes.Add("readonly", "readonly");
                    BindProduct();
                }
                else
                {
                    Response.Redirect("../Default.aspx?SessionMode=Logout", false);
                }
            }
            catch (Exception ex)
            {
                //log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
                //throw ex;
            }
        }
        #endregion

        #region getDatesofMonth Method

        public void getDatesofMonth()
        {
            DateTime today = DateTime.Today;
            int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime endOfMonth = new DateTime(today.Year, today.Month, daysInMonth);

            txtFromDate.Text = startOfMonth.ToString("dd/MM/yyyy").Replace("-", "/");
            txtToDate.Text = endOfMonth.ToString("dd/MM/yyyy").Replace("-", "/");

         //   BindgvLabReport(txtFromDate.Text, txtToDate.Text);
        }

        #endregion

        #region Bind GVLabReport
        private void BindgvLabReport(string strFromDt, string strToDate)
        {
            ApplicationResult objResult = new ApplicationResult();
            LabReportBl objLabReportBl = new LabReportBl();

            objResult = objLabReportBl.LabReport(strFromDt, strToDate);

            if (objResult != null)
            {
                gvLabReport.DataSource = objResult.ResultDt;
                gvLabReport.DataBind();
                PanelVisibilityMode(true, false);
            }
        }
        #endregion

        #region BindProduct

        public void BindProduct()
        {
            ApplicationResult objrResult = new ApplicationResult();
            ProductBl objProductBl = new ProductBl();

            objrResult = objProductBl.Product_SelectAll_LAB();
            if (objrResult != null)
            {
                objControls.BindDropDown_ListBox(objrResult.ResultDt, ddlProduct, "ProductName", "ProductId");
            }
            ddlProduct.Items.Insert(0, new ListItem("-Select-", "-1"));
        }

        #endregion



        #region Buttton btnSave Click Event
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (txtVehicleNo.Text == hfVehicleNo.Value)
                {

                    LabReportBo objLabReportBo = new LabReportBo();
                    ApplicationResult objResult = new ApplicationResult();
                    LabReportBl objLabReportBl = new LabReportBl();
                    objLabReportBo.LabDate = txtLabDate.Text.Trim();
                    objLabReportBo.VehicleId = Convert.ToInt32(hfVehicleId.Value);
                    objLabReportBo.VehicleCode = txtVehicleId.Text;
                    //  objLabReportBo.RouteId = Convert.ToInt32(ddlRouteNo.SelectedValue);
                    objLabReportBo.ProductId = Convert.ToInt32(ddlProduct.SelectedValue);
                    objLabReportBo.OT = (ddlOT.SelectedValue != "-1") ? Convert.ToInt32(ddlOT.SelectedValue) : -1;
                    objLabReportBo.Temp = (txtTemp.Text != "") ? Convert.ToDouble(txtTemp.Text) : 0.0;
                    objLabReportBo.Fat = (txtFat.Text != "") ? Convert.ToDouble(txtFat.Text) : 0.0;
                    objLabReportBo.SNF = (txtSNF.Text != "") ? Convert.ToDouble(txtSNF.Text) : 0.0;
                    objLabReportBo.Acidity = (txtAcidity.Text != "") ? Convert.ToDouble(txtAcidity.Text) : 0.0;
                    objLabReportBo.COB = (ddlCOB.SelectedValue != "-1") ? ddlCOB.SelectedValue : "-1";
                    objLabReportBo.AlcoholNo = txtAlcoholNo.Text;
                    objLabReportBo.Neutralizer = (ddlNeutralizer.SelectedValue != "-1") ? ddlNeutralizer.SelectedValue : "-1";
                    objLabReportBo.Urea = (ddlUrea.SelectedValue != "-1") ? ddlUrea.SelectedValue : "-1";
                    objLabReportBo.Salt = (ddlSalt.SelectedValue != "-1") ? ddlSalt.SelectedValue : "-1";
                    objLabReportBo.Startch = (ddlStartch.SelectedValue != "-1") ? ddlStartch.SelectedValue : "-1";
                    objLabReportBo.FPD = txtFPD.Text;
                    objLabReportBo.Status = Convert.ToInt32(ddlStatus.SelectedValue);

                    if (ViewState["Mode"].ToString() == "Save")
                    {
                        objLabReportBo.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objLabReportBo.CreatedDate = DateTime.UtcNow.AddHours(5.5);

                        objResult = objLabReportBl.LabReport_Insert(objLabReportBo);

                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Saved Successfully.');</script>");
                            ClearAll();
                            getDatesofMonth();
                            PanelVisibilityMode(true, false);
                        }
                    }
                    else if (ViewState["Mode"].ToString() == "Edit")
                    {
                        objLabReportBo.Id = Convert.ToInt32(ViewState["ID"].ToString());
                        objLabReportBo.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objLabReportBo.LastModifiedDate = DateTime.UtcNow.AddHours(5.5);
                        objResult = objLabReportBl.LabReport_Update(objLabReportBo);

                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Updated Successfully.');</script>");
                            ClearAll();
                            getDatesofMonth();
                            PanelVisibilityMode(true, false);
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Vehicle No is not exist.');</script>");
                }
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region Button btnAddNew Click Event
        protected void btnAddNew_OnClick(object sender, EventArgs e)
        {
            ClearAll();
            PanelVisibilityMode(false, true);
        }
        #endregion

        #region Button btnViewList Click Event
        protected void btnViewList_OnClick(object sender, EventArgs e)
        {
            ClearAll();
            PanelVisibilityMode(true, false);
            getDatesofMonth();
        }
        #endregion

        #region Go Button Click Event
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            try
            {
                BindgvLabReport(txtFromDate.Text, txtToDate.Text);
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion



        #region gvLabReport Pre Render Event
        protected void gvLabReport_OnPreRender(object sender, EventArgs e)
        {
            if (gvLabReport.Rows.Count <= 0) return;
            gvLabReport.UseAccessibleHeader = true;
            gvLabReport.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        #endregion

        #region gvLabReport Row Command Event
        protected void gvLabReport_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                LabReportBl objLabReportBl = new LabReportBl();

                if (e.CommandName == "Edit1")
                {

                    ViewState["ID"] = e.CommandArgument.ToString();
                    objResult = objLabReportBl.LabReport_Select(Convert.ToInt32(ViewState["ID"].ToString()));
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            txtLabDate.Text = objResult.ResultDt.Rows[0]["LabDate"].ToString();
                            txtVehicleNo.Text = objResult.ResultDt.Rows[0]["VehicleNumber"].ToString();
                            hfVehicleNo.Value = objResult.ResultDt.Rows[0]["VehicleNumber"].ToString();
                            hfVehicleId.Value = objResult.ResultDt.Rows[0]["VehicleId"].ToString();
                            txtVehicleId.Text = objResult.ResultDt.Rows[0]["VehicleCode"].ToString();
                            txtRouteNo.Text = objResult.ResultDt.Rows[0]["RouteNo"].ToString();
                            //ddlRouteNo.SelectedValue = objResult.ResultDt.Rows[0]["RouteId"].ToString();
                            ddlProduct.SelectedValue = objResult.ResultDt.Rows[0]["ProductId"].ToString();
                            ddlOT.SelectedValue = objResult.ResultDt.Rows[0]["OT"].ToString();
                            txtTemp.Text = objResult.ResultDt.Rows[0]["Temp"].ToString();
                            txtFat.Text = objResult.ResultDt.Rows[0]["Fat"].ToString();
                            txtSNF.Text = objResult.ResultDt.Rows[0]["SNF"].ToString();
                            txtAcidity.Text = objResult.ResultDt.Rows[0]["Acidity"].ToString();
                            ddlCOB.SelectedValue = objResult.ResultDt.Rows[0]["COB"].ToString();
                            txtAlcoholNo.Text = objResult.ResultDt.Rows[0]["AlcoholNo"].ToString();
                            ddlNeutralizer.SelectedValue = objResult.ResultDt.Rows[0]["Neutralizer"].ToString();
                            ddlUrea.SelectedValue = objResult.ResultDt.Rows[0]["Urea"].ToString();
                            ddlSalt.SelectedValue = objResult.ResultDt.Rows[0]["Salt"].ToString();
                            ddlStartch.SelectedValue = objResult.ResultDt.Rows[0]["Startch"].ToString();
                            txtFPD.Text = objResult.ResultDt.Rows[0]["FPD"].ToString();
                            ddlStatus.SelectedValue = objResult.ResultDt.Rows[0]["Status"].ToString();
                            PanelVisibilityMode(false, true);
                            ViewState["Mode"] = "Edit";
                        }
                        //ViewState["CheckRoleId"] = ViewState["RoleID"];
                    }
                }
                else if (e.CommandName == "Delete1")
                {
                    objResult = objLabReportBl.LabReport_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid].ToString()), System.DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        //log.Info("User role has been deleted.");
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully.');</script>");
                        PanelVisibilityMode(true, false);
                        getDatesofMonth();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('You can not delete this Reception because it is in used.');</script>");
                    }
                }

            }

            catch (Exception ex)
            {
                //log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
                //throw ex;
            }
        }
        #endregion



        #region PanelVisibilityMode Method
        private void PanelVisibilityMode(bool blDivGrid, bool blDivPanel)
        {
            divGrid.Visible = blDivGrid;
            divPanel.Visible = blDivPanel;
        }
        #endregion

        #region ClearAll Method
        private void ClearAll()
        {
            Controls objcontrol = new Controls();
            objcontrol.ClearForm(Master.FindControl("ContentPlaceHolder1"));
            ViewState["Mode"] = "Save";
        }
        #endregion

        #region Get Student Web Service Method
        [System.Web.Services.WebMethod]
        public static string[] GetVehicleNo(string prefixText)
        {
            VehicleBl objVehicleBl = new VehicleBl();
            ApplicationResult objResult = new ApplicationResult();
            string strSearchText = prefixText + "%";
            List<string> result = new List<string>();
            objResult = objVehicleBl.Vehicle_Search(strSearchText);
            if (objResult != null)
            {
                for (int i = 0; i < objResult.ResultDt.Rows.Count; i++)
                {
                    string strVehicleNumber = objResult.ResultDt.Rows[i]["VehicleNumber"].ToString();
                    string strVehicleId = objResult.ResultDt.Rows[i]["VehicleId"].ToString();
                    string strRouteNo = objResult.ResultDt.Rows[i]["RouteNo"].ToString();
                    result.Add(string.Format("{0}~{1}~{2}", strVehicleNumber, strVehicleId, strRouteNo));
                }
            }
            return result.ToArray();
        }

        #endregion
    }
}