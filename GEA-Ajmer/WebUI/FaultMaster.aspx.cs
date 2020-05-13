using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GEA_Ajmer.BL;
using GEA_Ajmer.BO;
using GEA_Ajmer.Common;
using log4net;

namespace GEA_Ajmer.WebUI
{
    public partial class FaultMaster : PageBase
    {
        private static ILog log = LogManager.GetLogger(typeof(FaultMaster));

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) return;
                if (Session[ApplicationSession.Userid] != null)
                {
                    ViewState["Mode"] = "Save";
                    PanelVisibilityMode(true, false);
                    BindgvFault();
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



        #region Bind Reception
        private void BindgvFault()
        {
            try
            {
                FaultBl objFaultBl = new FaultBl();
                var objResult = objFaultBl.Fault_SelectAll();
                if (objResult != null)
                {
                    gvFault.DataSource = objResult.ResultDt;
                    gvFault.DataBind();
                    PanelVisibilityMode(true, false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        #region Buttton btnSave Click Event
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
                try
                {
                    FaultBo objFaultBo = new FaultBo();
                    FaultBl objFaultBl = new FaultBl();
                    objFaultBo.TagNo = txtTagNo.Text.Trim();
                    objFaultBo.Description = txtDescription.Text.Trim();
                    objFaultBo.Type = Convert.ToInt32(ddlType.SelectedValue);
                    if (ViewState["Mode"].ToString() == "Save")
                    {
                        objFaultBo.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objFaultBo.CreatedDate = DateTime.UtcNow.AddHours(5.5);
                        var objResult = objFaultBl.Fault_Insert(objFaultBo);
                        if (objResult != null)
                        {
                            if (objResult.ResultDt.Rows.Count > 0)
                            {
                                int intStatus = Convert.ToInt32(objResult.ResultDt.Rows[0]["Status"].ToString());
                                if (intStatus == 0)
                                {
                                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('" + txtTagNo.Text + " is already exist.');</script>");
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Saved Successfully.');</script>");
                                    ClearAll();
                                    BindgvFault();
                                    PanelVisibilityMode(true, false);
                                }
                            }
                        }
                    }
                    else if (ViewState["Mode"].ToString() == "Edit")
                    {
                        objFaultBo.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objFaultBo.LastModifiedDate = DateTime.UtcNow.AddHours(5.5);
                        objFaultBo.Id = Convert.ToInt32(ViewState["ID"].ToString());
                        var objResult = objFaultBl.Fault_Update(objFaultBo);
                        if (objResult != null)
                        {
                            if (objResult.ResultDt.Rows.Count > 0)
                            {
                                int intStatus = Convert.ToInt32(objResult.ResultDt.Rows[0]["Status"].ToString());
                                if (intStatus == 0)
                                {
                                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('" + txtTagNo.Text + " is already exist.');</script>");
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Updated Successfully.');</script>");
                                    ClearAll();
                                    BindgvFault();
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
            try
            {
                ClearAll();
                PanelVisibilityMode(true, false);
                BindgvFault();
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion



        #region gvCircuit Pre Render Event
        protected void gvCircuit_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvFault.Rows.Count <= 0) return;
                gvFault.UseAccessibleHeader = true;
                gvFault.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region gvCircuit Row Command Event
        protected void gvCircuit_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                FaultBl objFaultBl = new FaultBl();
                if (e.CommandName == "Edit1")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["ID"] = e.CommandArgument.ToString();
                    var objResult = objFaultBl.Fault_Select(Convert.ToInt32(ViewState["ID"].ToString()));
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            txtTagNo.Text = objResult.ResultDt.Rows[0][FaultBo.FAULT_TAGNO].ToString();
                            txtDescription.Text = objResult.ResultDt.Rows[0][FaultBo.FAULT_DESCRIPTION].ToString();
                            ddlType.Text = objResult.ResultDt.Rows[0][FaultBo.FAULT_TYPE].ToString();
                            PanelVisibilityMode(false, true);
                        }
                    }
                }
                else if (e.CommandName == "Delete1")
                {
                    var objResult = objFaultBl.Fault_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid].ToString()), DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully.');</script>");
                        PanelVisibilityMode(true, false);
                        BindgvFault();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('You can not delete this Reception because it is in used.');</script>");
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