using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GEA_Ajmer.BL;
using GEA_Ajmer.BO;
using GEA_Ajmer.Common;
using log4net;

namespace GEA_Ajmer.WebUI
{
    public partial class Silo : PageBase
    {
        private static ILog log = LogManager.GetLogger(typeof(Silo));

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
                    BindgvSilo();
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
        private void BindgvSilo()
        {
            try
            {
                SiloBl objReceptionBl = new SiloBl();
                var objResult = objReceptionBl.Silo_SelectAll();
                if (objResult != null)
                {
                    gvSilo.DataSource = objResult.ResultDt;
                    gvSilo.DataBind();
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
                SiloBo objSiloBo = new SiloBo();
                SiloBl objSiloBl = new SiloBl();
                objSiloBo.Name = txtName.Text.Trim();
                objSiloBo.PLCValue = Convert.ToInt32(txtPLCValue.Text);
                if (ViewState["Mode"].ToString() == "Save")
                {
                    objSiloBo.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objSiloBo.CreatedDate = DateTime.UtcNow.AddHours(5.5);
                    var objResult = objSiloBl.Silo_Insert(objSiloBo);

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
                                BindgvSilo();
                                PanelVisibilityMode(true, false);
                            }
                        }
                    }
                }
                else if (ViewState["Mode"].ToString() == "Edit")
                {
                    objSiloBo.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objSiloBo.LastModifiedDate = DateTime.UtcNow.AddHours(5.5);
                    objSiloBo.SILOID = Convert.ToInt32(ViewState["ID"].ToString());
                    var objResult = objSiloBl.Silo_Update(objSiloBo);
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
                                BindgvSilo();
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
                BindgvSilo();
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion



        #region gvSilo Pre Render Event
        protected void gvSilo_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvSilo.Rows.Count <= 0) return;
                gvSilo.UseAccessibleHeader = true;
                gvSilo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region gvSilo Row Command Event
        protected void gvSilo_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                SiloBl objSiloBL = new SiloBl();
                if (e.CommandName == "Edit1")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["ID"] = e.CommandArgument.ToString();
                    var objResult = objSiloBL.Silo_Select(Convert.ToInt32(ViewState["ID"].ToString()));
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            txtName.Text = objResult.ResultDt.Rows[0][SiloBo.SILO_NAME].ToString();
                            txtPLCValue.Text = objResult.ResultDt.Rows[0][SiloBo.SILO_PLCVALUE].ToString();
                            PanelVisibilityMode(false, true);
                        }
                    }
                }
                else if (e.CommandName == "Delete1")
                {
                    var objResult = objSiloBL.Silo_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid].ToString()), System.DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully.');</script>");
                        PanelVisibilityMode(true, false);
                        BindgvSilo();
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