using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GEA_Ajmer.BL;
using GEA_Ajmer.BO;
using GEA_Ajmer.Common;
using log4net;

namespace GEA_Ajmer.WebUI
{
    public partial class Program : PageBase
    {
        private static ILog log = LogManager.GetLogger(typeof(Program));

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
                    BindgvProgram();
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
        private void BindgvProgram()
        {
            try
            {
                ProgramBl objReceptionBl = new ProgramBl();
                var objResult = objReceptionBl.Program_SelectAll();
                if (objResult != null)
                {
                    gvProgram.DataSource = objResult.ResultDt;
                    gvProgram.DataBind();
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
                ProgramBo objProgramBo = new ProgramBo();
                ProgramBl objProgramBl = new ProgramBl();
                objProgramBo.Name = txtName.Text.Trim();
                objProgramBo.PLCValue = Convert.ToInt32(txtPLCValue.Text);
                if (ViewState["Mode"].ToString() == "Save")
                {
                    objProgramBo.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objProgramBo.CreatedDate = DateTime.UtcNow.AddHours(5.5);
                    var objResult = objProgramBl.Program_Insert(objProgramBo);
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
                                BindgvProgram();
                                PanelVisibilityMode(true, false);
                            }
                        }
                    }
                }
                else if (ViewState["Mode"].ToString() == "Edit")
                {
                    objProgramBo.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objProgramBo.LastModifiedDate = DateTime.UtcNow.AddHours(5.5);
                    objProgramBo.Id = Convert.ToInt32(ViewState["ID"].ToString());
                    var objResult = objProgramBl.Program_Update(objProgramBo);
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
                                BindgvProgram();
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
                BindgvProgram();
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion



        #region gvProgram Pre Render Event
        protected void gvProgram_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvProgram.Rows.Count <= 0) return;
                gvProgram.UseAccessibleHeader = true;
                gvProgram.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region gvProgram Row Command Event
        protected void gvProgram_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ProgramBl objProgramBL = new ProgramBl();
                if (e.CommandName == "Edit1")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["ID"] = e.CommandArgument.ToString();
                    var objResult = objProgramBL.Program_Select(Convert.ToInt32(ViewState["ID"].ToString()));
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            txtName.Text = objResult.ResultDt.Rows[0][ProgramBo.PROGRAM_NAME].ToString();
                            txtPLCValue.Text = objResult.ResultDt.Rows[0][ProgramBo.PROGRAM_PLCVALUE].ToString();
                            PanelVisibilityMode(false, true);
                        }
                    }
                }
                else if (e.CommandName == "Delete1")
                {
                    var objResult = objProgramBL.Program_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid].ToString()), System.DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully.');</script>");
                        PanelVisibilityMode(true, false);
                        BindgvProgram();
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