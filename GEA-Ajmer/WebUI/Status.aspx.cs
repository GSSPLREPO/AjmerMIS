using GEA_Ajmer.Common;
using GEA_Ajmer.BL;
using GEA_Ajmer.BO;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GEA_Ajmer.WebUI
{
    public partial class Status : PageBase
    {
        private static ILog log = LogManager.GetLogger(typeof(Status));

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) return;
                if (Session[ApplicationSession.Userid] != null)
                {
                    ViewState["Mode"] = "Save";
                    PanelVisibilityMode(true, false);
                    BindgvStatus();
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
        private void BindgvStatus()
        {
            try
            {
                StatusBL objReceptionBl = new StatusBL();
                var objResult = objReceptionBl.Status_SelectAll();
                if (objResult != null)
                {
                    gvStatus.DataSource = objResult.ResultDt;
                    gvStatus.DataBind();
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
                StatusBo objStatusBo = new StatusBo();
                StatusBL objStatusBl = new StatusBL();
                objStatusBo.Name = txtName.Text.Trim();
                objStatusBo.PLCValue = Convert.ToInt32(txtPLCValue.Text);
                if (ViewState["Mode"].ToString() == "Save")
                {
                    objStatusBo.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objStatusBo.CreatedDate = DateTime.UtcNow.AddHours(5.5);
                    var objResult = objStatusBl.Status_Insert(objStatusBo);
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            int intStatus = Convert.ToInt32(objResult.ResultDt.Rows[0]["Status"].ToString());
                            if (intStatus == 0)
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('" + txtName.Text + " is already exist.');</script>");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Saved Successfully.');</script>");
                                ClearAll();
                                BindgvStatus();
                                PanelVisibilityMode(true, false);
                            }
                        }
                    }
                }
                else if (ViewState["Mode"].ToString() == "Edit")
                {
                    objStatusBo.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objStatusBo.LastModifiedDate = DateTime.UtcNow.AddHours(5.5);
                    objStatusBo.Id = Convert.ToInt32(ViewState["ID"].ToString());
                    var objResult = objStatusBl.Status_Update(objStatusBo);
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            int intStatus = Convert.ToInt32(objResult.ResultDt.Rows[0]["Status"].ToString());
                            if (intStatus == 0)
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('" + txtName.Text + " is already exist.');</script>");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Updated Successfully.');</script>");
                                ClearAll();
                                BindgvStatus();
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
                BindgvStatus();
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion



        #region gvStatus Pre Render Event
        protected void gvStatus_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvStatus.Rows.Count <= 0) return;
                gvStatus.UseAccessibleHeader = true;
                gvStatus.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region gvStatus Row Command Event
        protected void gvStatus_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                StatusBL objStatusBL = new StatusBL();
                if (e.CommandName == "Edit1")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["ID"] = e.CommandArgument.ToString();
                    var objResult = objStatusBL.Status_Select(Convert.ToInt32(ViewState["ID"].ToString()));
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            txtName.Text = objResult.ResultDt.Rows[0][StatusBo.STATUS_NAME].ToString();
                            txtPLCValue.Text = objResult.ResultDt.Rows[0][StatusBo.STATUS_PLCVALUE].ToString();
                            PanelVisibilityMode(false, true);
                        }
                    }
                }
                else if (e.CommandName == "Delete1")
                {
                    var objResult = objStatusBL.Status_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid].ToString()), System.DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully.');</script>");
                        PanelVisibilityMode(true, false);
                        BindgvStatus();
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