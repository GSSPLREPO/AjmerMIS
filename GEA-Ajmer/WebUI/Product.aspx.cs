using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GEA_Ajmer.BL;
using GEA_Ajmer.BO;
using GEA_Ajmer.Common;
using log4net;

namespace GEA_Ajmer.WebUI
{
    public partial class Product : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger(typeof(Product));

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) return;
                if (Session[ApplicationSession.Userid] != null)
                {
                    ViewState["Mode"] = "Save";
                    BindProduct();
                    //PanelVisibilityMode(true, false);
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

        #region Bind Product
        private void BindProduct()
        {
            try
            {
                ProductBl objProductBl = new ProductBl();
                var objResult = objProductBl.Product_SelectAll();

                if (objResult != null)
                {
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        gvProduct.DataSource = objResult.ResultDt;
                        gvProduct.DataBind();
                        PanelVisibilityMode(true, false);
                    }
                    else
                    {
                        PanelVisibilityMode(false, true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        #region btnAddNew_Click
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearAll();
            PanelVisibilityMode(false, true);
        }
        #endregion

        #region gvProduct_PreRender
        protected void gvProduct_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvProduct.Rows.Count <= 0) return;
                gvProduct.UseAccessibleHeader = true;
                gvProduct.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region gvProduct_RowCommand
        protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                ProductBl objProductBL = new ProductBl();
                if (e.CommandName == "Edit1")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["ProductID"] = e.CommandArgument.ToString();
                    var objResult = objProductBL.Product_Select(Convert.ToInt32(ViewState["ProductID"].ToString()));

                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            txtProductName.Text = objResult.ResultDt.Rows[0][ProductBo.PRODUCT_PRODUCTNAME].ToString();
                            txtIdentifierCode.Text = objResult.ResultDt.Rows[0][ProductBo.PRODUCT_IDENTIFIERCODE].ToString();
                            PanelVisibilityMode(false, true);
                        }
                    }
                }
                else if (e.CommandName == "Delete1")
                {
                    var objResult = objProductBL.Product_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid].ToString()), DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully.');</script>");
                        PanelVisibilityMode(true, false);
                        BindProduct();
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

        #region btnSave_Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blValidateName = false;
                bool blValidateCode = false;
                string strProductName = txtProductName.Text.Trim();
                string strCode = txtIdentifierCode.Text.Trim();
                if (ViewState["Mode"].ToString() == "Save")
                {
                    blValidateName = ValidateName(strProductName, -1);
                    blValidateCode = ValidateIdentifierCode(strCode, -1);
                }
                else
                {
                    blValidateName = ValidateName(strProductName, Convert.ToInt32(ViewState["ProductID"].ToString()));
                    blValidateCode = ValidateIdentifierCode(strCode, Convert.ToInt32(ViewState["ProductID"].ToString()));
                }

                if (blValidateCode == false)
                {
                    if (blValidateName == false)
                    {
                        ProductBo objProductBo = new ProductBo();
                        ProductBl objProductBl = new ProductBl();

                        objProductBo.ProductName = txtProductName.Text.Trim();
                        objProductBo.IdentifierCode = Convert.ToInt32(txtIdentifierCode.Text);

                        if (ViewState["Mode"].ToString() == "Save")
                        {
                            objProductBo.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                            objProductBo.CreatedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                            objProductBo.IsDeleted = 0;

                            var objResult = objProductBl.Product_Insert(objProductBo);
                            if (objResult != null)
                            {
                                if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                                {
                                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Saved Successfully.');</script>");
                                    ClearAll();
                                    BindProduct();
                                    PanelVisibilityMode(true, false);
                                }
                            }
                        }
                        else if (ViewState["Mode"].ToString() == "Edit")
                        {
                            objProductBo.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]).ToString();
                            objProductBo.LastModifiedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                            objProductBo.ProductId = Convert.ToInt32(ViewState["ProductID"].ToString());

                            var objResult = objProductBl.Product_Update(objProductBo);

                            if (objResult != null)
                            {
                                if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                                {
                                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Updated Successfully.');</script>");
                                    ClearAll();
                                    BindProduct();
                                    PanelVisibilityMode(true, false);
                                }
                            }
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('ProductName Already Exist.Please Check it.');</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('IdentifierCode Already Exist.Please Check it.');</script>");
                }
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region btnViewList_Click

        protected void btnViewList_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                PanelVisibilityMode(true, false);
                BindProduct();
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

        #region ValidateName For Peroduct
        public bool ValidateName(string strProductName, int intProductId)
        {
            bool blFlag = false;
            ProductBl objProductBl = new ProductBl();
            var objResult = objProductBl.Product_ValidateName(intProductId, strProductName);
            if (objResult != null)
            {
                if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                {
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        blFlag = true;
                    }
                }
            }

            return blFlag;
        }
        #endregion


        #region ValidateName For IdentifierCode
        public bool ValidateIdentifierCode(string IdentifierCode, int intProductId)
        {
            bool blFlag = false;
            ProductBl objProductBl = new ProductBl();
            var objResult = objProductBl.Product_ValidateIdentifierCode(intProductId, IdentifierCode);
            if (objResult != null)
            {
                if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                {
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        blFlag = true;
                    }
                }
            }

            return blFlag;
        }
        #endregion

    }
}