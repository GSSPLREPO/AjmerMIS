using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GEA_Ajmer.BL;
using GEA_Ajmer.BO;
using GEA_Ajmer.Common;
using log4net;

namespace GEA_Ajmer.WebUI
{
    public partial class Reception : PageBase
    {
        private static ILog log = LogManager.GetLogger(typeof(Reception));

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
                    BindgvReception();
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
        private void BindgvReception()
        {
            ReceptionBl objReceptionBl = new ReceptionBl();
            var objResult = objReceptionBl.Reception_SelectAll();
            if (objResult != null)
            {
                gvReception.DataSource = objResult.ResultDt;
                gvReception.DataBind();
                PanelVisibilityMode(true, false);
            }
        }
        #endregion



        #region Buttton btnSave Click Event
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                ReceptionBo objReceptionBo = new ReceptionBo();
                ReceptionBl objReceptionBl = new ReceptionBl();
                objReceptionBo.Name = txtRecName.Text.Trim();
                objReceptionBo.Description = txtDescription.Text.Trim();
                objReceptionBo.PLCValue = Convert.ToInt32(txtPLCValue.Text);
                if (ViewState["Mode"].ToString() == "Save")
                {
                    objReceptionBo.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objReceptionBo.CreatedDate = DateTime.UtcNow.AddHours(5.5);
                    var objResult = objReceptionBl.Reception_Insert(objReceptionBo);
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            int intStatus = Convert.ToInt32(objResult.ResultDt.Rows[0]["Status"].ToString());
                            if (intStatus == 0)
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('" + txtRecName.Text + " is already exist.');</script>");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Saved Successfully.');</script>");
                                ClearAll();
                                BindgvReception();
                                PanelVisibilityMode(true, false);
                            }
                        }
                    }
                }
                else if (ViewState["Mode"].ToString() == "Edit")
                {
                    objReceptionBo.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objReceptionBo.LastModifiedDate = DateTime.UtcNow.AddHours(5.5);
                    objReceptionBo.ReceptionId = Convert.ToInt32(ViewState["ReceptionID"].ToString());
                    var objResult = objReceptionBl.Reception_Update(objReceptionBo);
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            int intStatus = Convert.ToInt32(objResult.ResultDt.Rows[0]["Status"].ToString());
                            if (intStatus == 0)
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('" + txtRecName.Text + " is already exist.');</script>");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Updated Successfully.');</script>");
                                ClearAll();
                                BindgvReception();
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
                BindgvReception();
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion



        #region gvReception Pre Render Event
        protected void gvReception_OnPreRender(object sender, EventArgs e)
        {
            if (gvReception.Rows.Count <= 0) return;
            gvReception.UseAccessibleHeader = true;
            gvReception.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        #endregion

        #region gvReception Row Command Event
        protected void gvReception_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ReceptionBl objReceptionBL = new ReceptionBl();
                if (e.CommandName == "Edit1")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["ReceptionID"] = e.CommandArgument.ToString();
                    var objResult = objReceptionBL.Reception_Select(Convert.ToInt32(ViewState["ReceptionID"].ToString()));
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            txtRecName.Text = objResult.ResultDt.Rows[0][ReceptionBo.RECEPTION_NAME].ToString();
                            txtDescription.Text = objResult.ResultDt.Rows[0][ReceptionBo.RECEPTION_DESCRIPTION].ToString();
                            txtPLCValue.Text = objResult.ResultDt.Rows[0][ReceptionBo.RECEPTION_PLCVALUE].ToString();
                            PanelVisibilityMode(false, true);
                        }
                    }
                }
                else if (e.CommandName == "Delete1")
                {
                    var objResult = objReceptionBL.Reception_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid].ToString()), DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully.');</script>");
                        PanelVisibilityMode(true, false);
                        BindgvReception();
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