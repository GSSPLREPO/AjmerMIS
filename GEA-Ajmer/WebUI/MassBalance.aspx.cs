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
using System.Globalization;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;

namespace GEA_Ajmer.WebUI
{
    public partial class MassBalance : PageBase
    {
        private static ILog log = LogManager.GetLogger(typeof(MassBalance));

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) return;
                if (Session[ApplicationSession.Userid] != null)
                {
                    ViewState["Mode"] = "Save";
                    BindgvMassBalance();
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


        #region Bind MassBalance
        private void BindgvMassBalance()
        {
            try
            {
                MassBalanceBl objMassBalanceBl = new MassBalanceBl();
                var objResult = objMassBalanceBl.MassBalance_SelectAll();
                if (objResult != null)
                {
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        gvMassBalance.DataSource = objResult.ResultDt;
                        gvMassBalance.DataBind();
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

        public DataTable BindMassBalance()
        {
            try
            {
                MassBalanceBl objMassBalanceBl = new MassBalanceBl();
                var objResult = objMassBalanceBl.MassBalance_SelectAll();
                if (objResult != null)
                {
                    return objResult.ResultDt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Button btnAddNew Click Event
        protected void btnAddNew_OnClick(object sender, EventArgs e)
        {
            ClearAll();
            PanelVisibilityMode(false, true);
            btnSave.Enabled = false;
        }
        #endregion

        #region Button btnSave Click Event
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                MassBalanceBO objMassBalanceBO = new MassBalanceBO();
                //ApplicationResult objResult = new ApplicationResult();
                MassBalanceBl objMassBalanceBl = new MassBalanceBl();
                objMassBalanceBO.Date = DateTime.ParseExact(txtDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objMassBalanceBO.MilkKg = float.Parse(txtMilkKg.Text.Trim());
                objMassBalanceBO.FATMilkKg = float.Parse(txtMilkFAT.Text.Trim());
                objMassBalanceBO.SNFMilkKg = float.Parse(txtMilkSNF.Text.Trim());
                objMassBalanceBO.SugarMilkKg = float.Parse(txtMilkSugar.Text.Trim());
                objMassBalanceBO.QtyOfPowder = float.Parse(txtQtyofPowder.Text.Trim());
                objMassBalanceBO.FATQty = float.Parse(txtTSFAT.Text.Trim());
                objMassBalanceBO.SNFQty = float.Parse(txtTSSNF.Text.Trim());
                objMassBalanceBO.SugarQty = float.Parse(txtTSSugar.Text.Trim());
                objMassBalanceBO.TotalSolidKG = float.Parse(txtTotalSolid.Text.Trim());
                objMassBalanceBO.Variation = float.Parse(txtVariation.Text.Trim());
                objMassBalanceBO.UserId = Convert.ToInt32(Session[ApplicationSession.Userid]);
                switch (ViewState["Mode"].ToString())
                {
                    case "Save":
                        objMassBalanceBO.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objMassBalanceBO.CreatedDate = DateTime.UtcNow.AddHours(5.5);
                        break;
                    case "Edit":
                        objMassBalanceBO.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objMassBalanceBO.LastModifiedDate = DateTime.UtcNow.AddHours(5.5);
                        break;
                }
                if (ViewState["Mode"].ToString() == "Save")
                {
                    var objResult = objMassBalanceBl.MassBalance_Insert(objMassBalanceBO);
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Saved Successfully.');</script>");
                        ClearAll();
                        BindgvMassBalance();
                        // PanelVisibilityMode(true, false);
                    }
                }
                else if (ViewState["Mode"].ToString() == "Edit")
                {
                    objMassBalanceBO.Id = Convert.ToInt32(ViewState["MassBalanceID"].ToString());
                    var objResult = objMassBalanceBl.MassBalance_Update(objMassBalanceBO);
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Updated Successfully.');</script>");
                        ClearAll();
                        BindgvMassBalance();
                        PanelVisibilityMode(true, false);
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
                // PanelVisibilityMode(true, false);
                BindgvMassBalance();
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region Button Calculate Click Event
        protected void btnCalculate_OnClick(object sender, EventArgs e)
        {
            try
            {
                float TotalSolidKg, TotalMilkValue = 0;
                TotalMilkValue = float.Parse(txtMilkFAT.Text) + float.Parse(txtMilkSNF.Text) + float.Parse(txtMilkSugar.Text);
                TotalSolidKg = (float.Parse(txtMilkKg.Text) * TotalMilkValue) / 100;

                float variation, TotalTS = 0;
                TotalTS = float.Parse(txtTSFAT.Text) + float.Parse(txtTSSNF.Text) + float.Parse(txtTSSugar.Text);
                variation = (float.Parse(txtQtyofPowder.Text) * TotalTS) / 100;

                txtTotalSolid.Text = Convert.ToString(variation - TotalSolidKg);
                txtVariation.Text = Convert.ToString((float.Parse(txtTotalSolid.Text) / TotalSolidKg) * 100);
                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region gvMassBalance Pre Render Event
        protected void gvMassBalance_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvMassBalance.Rows.Count <= 0) return;
                gvMassBalance.UseAccessibleHeader = true;
                gvMassBalance.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region gvMassBalance Row Command Event
        protected void gvMassBalance_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                MassBalanceBl objMassBalanceBl = new MassBalanceBl();
                if (e.CommandName == "Edit1")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["MassBalanceID"] = e.CommandArgument.ToString();
                    var objResult = objMassBalanceBl.MassBalance_Select(Convert.ToInt32(ViewState["MassBalanceID"].ToString()));
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            txtDate.Text = objResult.ResultDt.Rows[0][MassBalanceBO.MASSBALANCE_DATE].ToString();
                            txtMilkKg.Text = objResult.ResultDt.Rows[0][MassBalanceBO.MASSBALANCE_MILKKG].ToString();
                            txtMilkFAT.Text = objResult.ResultDt.Rows[0][MassBalanceBO.MASSBALANCE_FATMILKKG].ToString();
                            txtMilkSNF.Text = objResult.ResultDt.Rows[0][MassBalanceBO.MASSBALANCE_SNFMILKKG].ToString();
                            txtMilkSugar.Text = objResult.ResultDt.Rows[0][MassBalanceBO.MASSBALANCE_SUGARMILKKG].ToString();
                            txtQtyofPowder.Text = objResult.ResultDt.Rows[0][MassBalanceBO.MASSBALANCE_QTYOFPOWDER].ToString();
                            txtTSFAT.Text = objResult.ResultDt.Rows[0][MassBalanceBO.MASSBALANCE_FATQTY].ToString();
                            txtTSSNF.Text = objResult.ResultDt.Rows[0][MassBalanceBO.MASSBALANCE_SNFQTY].ToString();
                            txtTSSugar.Text = objResult.ResultDt.Rows[0][MassBalanceBO.MASSBALANCE_SUGARQTY].ToString();
                            txtTotalSolid.Text = objResult.ResultDt.Rows[0][MassBalanceBO.MASSBALANCE_TOTALSOLIDKG].ToString();
                            txtVariation.Text = objResult.ResultDt.Rows[0][MassBalanceBO.MASSBALANCE_VARIATION].ToString();
                            PanelVisibilityMode(false, true);
                        }
                    }
                }
                else if (e.CommandName == "Delete1")
                {
                    var objResult = objMassBalanceBl.MassBalance_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid].ToString()), DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully.');</script>");
                        //PanelVisibilityMode(true, false);
                        BindgvMassBalance();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('You can not delete this MassBalance because it is in used.');</script>");
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
            DefaultZero();
        }
        #endregion

        #region Default Value Zero
        private void DefaultZero()
        {
            txtMilkFAT.Text = "0";
            txtMilkKg.Text = "0";
            txtMilkSNF.Text = "0";
            txtMilkSugar.Text = "0";
            txtQtyofPowder.Text = "0";
            txtTSFAT.Text = "0";
            txtTSSNF.Text = "0";
            txtTSSugar.Text = "0";
            txtVariation.Text = "0";
            txtTotalSolid.Text = "0";
        }
        #endregion


        #region VerifyRenderingInServerForm
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        #endregion


        #region Export to excel
        protected void imgbtnExcel_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string filename = "MassBalanceEntry_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvMassBalance.AllowPaging = false;
                gvMassBalance.GridLines = GridLines.Both;
              

                gvMassBalance.Columns[5].Visible = false;
                gvMassBalance.Columns[6].Visible = false;
                gvMassBalance.RenderControl(hw);
                string strSubTitle = "MASS BALANCE ENTRY";
                string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/GEAProcess_large_20122024.jpg";

                string content = "<div align='center'><img align='left' style='height: 40px; width: 109px' src='" + strPath + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
               "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/></div>" +

               "</div><br/><div align='center' style='font-family:verdana;font-size:11px'><span style='font-size:11px;color:Maroon;'>" + strSubTitle + "</ span><br/>" +
                "<br/>" + sw.ToString() + "<br/></div>";

                string style = @"<!--mce:2-->";
                Response.Write(style);
                Response.Output.Write(content);
                gvMassBalance.GridLines = GridLines.None;
                Response.Flush();
                Response.Clear();
                Response.End();
            }
            catch (Exception ex)
            {
                log.Error("Button EXCEL", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Oops! There is some technical issue. Please Contact to your administrator.');", true);
            }

            //try
            //{
            //    Response.Clear();
            //    Response.Buffer = true;
            //    Response.ContentType = "application/vnd.ms-excel";
            //    Response.ContentEncoding = System.Text.Encoding.Unicode;
            //    Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            //    string filename = "MASS_BALANCE_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
            //    Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //    StringWriter sw = new StringWriter();
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            //    gvMassBalance.AllowPaging = false;
            //    gvMassBalance.GridLines = GridLines.Both;
            //    gvMassBalance.RenderControl(hw);

            //    string strSubTitle = "MASS BALANCE REPORT";
            //    string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/GEAProcess_large_20122024.jpg";
            //    string content = "<div align='center' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
            //        "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/>" +
            //           "<span align='center' style='font-family:verdana;font-size:13px'><strong>" + strSubTitle + "</strong></span><br/><br/><br/> "
            //        + sw.ToString() + "<br/></div>";
            //    string style = @"<!--mce:2-->";
            //    Response.Write(style);
            //    Response.Output.Write(content);
            //    gvMassBalance.GridLines = GridLines.None;
            //    Response.Flush();
            //    Response.Clear();
            //    Response.End();
            //}
            //catch (Exception ex)
            //{
            //    log.Error("Button EXCEL", ex);
            //    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Oops! There is some technical issue. Please Contact to your administrator.');", true);
            //}
        }
        #endregion

        #region export to PDF
        protected void imgbtnWord_OnClick(object sender, EventArgs e)
        {
            try
            {

                string filename = "MASS_BALANCE_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".doc";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Charset = "";
                Response.ContentType = "application/msword ";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvMassBalance.AllowPaging = false;
                gvMassBalance.GridLines = GridLines.Both;
                gvMassBalance.RenderControl(hw);
                string strSubTitle = "MASS BALANCE REPORT";
                string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/logo.gif";
                string content = "<div align='center' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                    "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/>" +
                       "<span align='center' style='font-family:verdana;font-size:13px'><strong>" + strSubTitle + "</strong></span><br/><br/> "
                    + sw.ToString() + "<br/></div>";
                Response.Output.Write(content);
                gvMassBalance.GridLines = GridLines.None;
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
                log.Error("Button WORD", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Oops! There is some technical issue. Please Contact to your administrator.');", true);
            }

        }
        #endregion

        protected void imgPdfButton_Click(object sender, EventArgs e)
        {

        }
    }
}