using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using GEA_Ajmer.BL;
using GEA_Ajmer.Common;

namespace GEA_Ajmer
{
    public partial class MainMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            if (Session[ApplicationSession.Userid] != null)
            {
                lblUserName.Text = Session[ApplicationSession.Username].ToString();
                #region Manage Role Rights

                string sPath = Page.Page.AppRelativeVirtualPath;
                string sRet = sPath.Substring(sPath.LastIndexOf('/') + 1);

                RoleRightsBl objRoleRightsBL = new RoleRightsBl();
                ApplicationResult objResults = new ApplicationResult();

                int flagMaster = 0;
                int flagReport = 0;
                int flagUser = 0;
                int flag = 0;

                objResults = objRoleRightsBL.RoleRights_SelectAll_ForAuthorization(Convert.ToInt32(Session[ApplicationSession.Roleid].ToString()));
                if (objResults != null)
                {
                    for (int i = 0; i < objResults.ResultDt.Rows.Count; i++)
                    {
                        #region Menu Hide
                        Control MyList = FindControl("cssmenu");
                        foreach (Control MyControl in MyList.Controls)
                        {
                            if (MyControl is HtmlGenericControl)
                            {
                                HtmlGenericControl li = MyControl as HtmlGenericControl;

                                if (li.ID == objResults.ResultDt.Rows[i]["DisplayName"].ToString())
                                {
                                    li.Visible = true;
                                    break;
                                }
                            }
                        }

                        if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Shift")
                            flagMaster = 1;
                        if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "MilkAnalysis")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "PowderProduction")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Program")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Status")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Silo")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "ProductDispatch")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Product")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Routes")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "RoutineMaintainance")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "BreakDownMaintainance")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Role")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Employee")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "RoleRights")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Lab")
                            flagMaster = 1;

                        if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "MilkReceptionReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "TransferReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "DispatchReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "PCIPLogReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "TCIPLogReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "UtilityStatusReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "UtilityConsumptionReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "EquipmentFaultSummaryReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "EquipmentFaultCountReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "LabReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "BreakdownReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "RoutineReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "LabReportSMP")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "LabReportWMP")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "LabReportDW")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "MilkReceptionReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "MilkStorageUnloadReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "SugarSyrupPreparationReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "MPLTempratureTrend")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "MPLTemperatureTrend2")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "CPLTemperatureTrend")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "CurdTemperatureTrend")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "BMTemperatureTrend")
                            flagReport = 1;

                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "UtilityHotWaterStatusReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "UtilityChilledWaterStatusReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "UtilityRowWaterStatusReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "UtilitySoftWaterReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "UtilityAirStatusReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "UtilityAirStatusReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "WeighBridgeSummary")
                            flagReport = 1;

                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "CIPLogReport")
                        //    flagReport = 1;
                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "EvaporatorLogSheetReport")
                        //    flagReport = 1;
                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "DryerLogSheetReport")
                        //    flagReport = 1;

                        #endregion
                    }
                    if (sRet != "NotAuthorized.aspx")
                    {
                        for (int j = 0; j < objResults.ResultDt.Rows.Count; j++)
                        {
                            #region Not Authorized

                            if (sRet == "Home.aspx")
                            {
                                flag = 0;
                                break;
                            }
                            if (sRet=="WebUI/AboutSoftware.aspx")
                            {
                                flag = 0;
                                break;
                            }
                            if (objResults.ResultDt.Rows[j]["ScreenName"].ToString() == sRet)
                            {
                                flag = 0;
                                break;
                            }
                            flag = 1;
                            #endregion
                        }
                    }
                    //if (flagMaster == 1)
                    //{
                    //    liMaster.Visible = true;
                    //}
                    //else
                    //{
                    //    liMaster.Visible = false;
                    //}
                    //if (flagReport == 1)
                    //{
                    //    liReport.Visible = true;
                    //}
                    //else
                    //{
                    //    liReport.Visible = false;
                    //}
                    if (flag == 1)
                    {
                        Response.Redirect("../WebUI/NotAuthorized.aspx", false);
                    }
                }
                #endregion
            }
            else
            {
                Response.Redirect("../Login.aspx", false);
            }
        }
    }
}
