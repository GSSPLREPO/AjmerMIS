using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GEA_Ajmer.BL;
using GEA_Ajmer.BO;
using GEA_Ajmer.Common;
using log4net;

namespace GEA_Ajmer.WebUI
{
    public partial class Routes : PageBase
    {
        private static ILog log = LogManager.GetLogger(typeof(Routes));

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) return;
                if (Session[ApplicationSession.Userid] != null)
                {
                    ViewState["Mode"] = "Save";
                    BindgvRoute();
                    PanelVisibilityMode(true, false);
                }
                else
                {
                    Response.Redirect("../Default.aspx?SessionMode=Logout", false);
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



        #region Bind Route
        private void BindgvRoute()
        {
            try
            {
                RouteBl objRouteBl = new RouteBl();
                var objResult = objRouteBl.Route_SelectAll();
                if (objResult != null)
                {
                    gvRoute.DataSource = objResult.ResultDt;
                    gvRoute.DataBind();
                    PanelVisibilityMode(true, false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        #region Buttton btnSave Click Event
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                RouteBo objRouteBo = new RouteBo();
                RouteBl objRouteBl = new RouteBl();
                objRouteBo.RouteNo = (txtRouteNo.Text.Trim());
                objRouteBo.RouteName = txtRouteName.Text.Trim();
                objRouteBo.Description = txtDescription.Text.Trim();
                objRouteBo.PLCValue = Convert.ToInt32(txtPLCValue.Text);
                if (ViewState["Mode"].ToString() == "Save")
                {
                    objRouteBo.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objRouteBo.CreatedDate = DateTime.UtcNow.AddHours(5.5);
                    var objResult = objRouteBl.Route_Insert(objRouteBo);
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            int intStatus = Convert.ToInt32(objResult.ResultDt.Rows[0]["Status"].ToString());
                            if (intStatus == 0)
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Route Name or Route No is already exist.');</script>");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Saved Successfully.');</script>");
                                ClearAll();
                                BindgvRoute();
                                PanelVisibilityMode(true, false);
                            }
                        }
                    }
                }
                else if (ViewState["Mode"].ToString() == "Edit")
                {
                    objRouteBo.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objRouteBo.LastModifiedDate = DateTime.UtcNow.AddHours(5.5);
                    objRouteBo.Id = Convert.ToInt32(ViewState["RouteID"].ToString());
                    var objResult = objRouteBl.Route_Update(objRouteBo);
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            int intStatus = Convert.ToInt32(objResult.ResultDt.Rows[0]["Status"].ToString());
                            if (intStatus == 0)
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Route Name or Route No is already exist.');</script>");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Updated Successfully.');</script>");
                                ClearAll();
                                BindgvRoute();
                                PanelVisibilityMode(true, false);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region Button btnViewList Click Event
        protected void btnViewList_OnClick(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                PanelVisibilityMode(true, false);
                BindgvRoute();
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion



        #region gvRoute Pre Render Event
        protected void gvRoute_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvRoute.Rows.Count <= 0) return;
                gvRoute.UseAccessibleHeader = true;
                gvRoute.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region gvRoute Row Command Event
        protected void gvRoute_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                RouteBl objRouteBL = new RouteBl();
                if (e.CommandName == "Edit1")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["RouteID"] = e.CommandArgument.ToString();
                    var objResult = objRouteBL.Route_Select(Convert.ToInt32(ViewState["RouteID"].ToString()));
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            txtRouteName.Text = objResult.ResultDt.Rows[0][RouteBo.ROUTE_ROUTENAME].ToString();
                            txtRouteNo.Text = objResult.ResultDt.Rows[0][RouteBo.ROUTE_ROUTENO].ToString();
                            txtDescription.Text = objResult.ResultDt.Rows[0][RouteBo.ROUTE_DESCRIPTION].ToString();
                            txtPLCValue.Text = objResult.ResultDt.Rows[0][RouteBo.ROUTE_PLCVALUE].ToString();
                            PanelVisibilityMode(false, true);
                        }
                    }
                }
                else if (e.CommandName == "Delete1")
                {
                    var objResult = objRouteBL.Route_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid].ToString()), DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully.');</script>");
                        PanelVisibilityMode(true, false);
                        BindgvRoute();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('You can not delete this Route because it is in used.');</script>");
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
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
    }
}