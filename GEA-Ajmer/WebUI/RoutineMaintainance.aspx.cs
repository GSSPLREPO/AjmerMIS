using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using GEA_Ajmer.BL;
using GEA_Ajmer.BO;
using GEA_Ajmer.Common;
using log4net;
using System.IO;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Drawing;
namespace GEA_Ajmer.WebUI
{
    public partial class RoutineMaintainance : PageBase
    {
        private static ILog log = LogManager.GetLogger(typeof(RoutineMaintainance));

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) return;
                if (Session[ApplicationSession.Userid] != null)
                {
                    ViewState["Mode"] = "Save";
                    BindgvRoutineMaintainance();
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



        #region Bind RoutineMaintainance
        private void BindgvRoutineMaintainance()
        {
            try
            {
            MaintainanceBL objRoutineMaintainanceBl = new MaintainanceBL();
                var objResult = objRoutineMaintainanceBl.Maintainance_SelectAll(0);
            if (objResult != null)
            {
                gvRoutineMaintainance.DataSource = objResult.ResultDt;
                gvRoutineMaintainance.DataBind();
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
                if (Page.IsValid)
                {
                    MaintainanceBo objRoutineMaintainanceBo = new MaintainanceBo();
                    MaintainanceBL objRoutineMaintainanceBl = new MaintainanceBL();
                    objRoutineMaintainanceBo.EquipmentTagNo = (txtEquipmentNo.Text.Trim());
                    objRoutineMaintainanceBo.EquipmentName = (txtEquipmentName.Text.Trim());
                    objRoutineMaintainanceBo.MaintainanceDate = DateTime.ParseExact(txtMaintainanceDate.Text.Trim(),
                        "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    objRoutineMaintainanceBo.StartTime = DateTime.ParseExact(txtStartDate.Text.Trim(), "HH:mm:ss",
                        CultureInfo.InvariantCulture);
                    objRoutineMaintainanceBo.EndTime = DateTime.ParseExact(txtEndDate.Text.Trim(), "HH:mm:ss",
                        CultureInfo.InvariantCulture);
                    objRoutineMaintainanceBo.PartNo = txtPartNo.Text.Trim();
                    objRoutineMaintainanceBo.PartName = txtPartName.Text.Trim();
                    objRoutineMaintainanceBo.Section = txtSection.Text.Trim();
                    objRoutineMaintainanceBo.DueDate = DateTime.ParseExact(txtDueDate.Text.Trim(), "dd/MM/yyyy",CultureInfo.InvariantCulture);
                    objRoutineMaintainanceBo.NextDueDate = DateTime.ParseExact(txtNextDueDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    objRoutineMaintainanceBo.Department = txtDepartment.Text.Trim();
                    objRoutineMaintainanceBo.Area = txtArea.Text.Trim();
                    //objRoutineMaintainanceBo.DueDate = DateTime.ParseExact(txtDueDate.Text.Trim(), "dd/MM/yyyy",
                    //    CultureInfo.InvariantCulture);
                    //objRoutineMaintainanceBo.NextDueDate = (txtNextDueDate.Text != "")
                    //    ? DateTime.ParseExact(txtNextDueDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    //    : DateTime.ParseExact("01/01/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //objRoutineMaintainanceBo.NextDueDate = ;
                    objRoutineMaintainanceBo.ActionTaken = txtAction.Text.Trim();
                    objRoutineMaintainanceBo.RectifiedBy = txtRectified.Text.Trim();
                    objRoutineMaintainanceBo.Remark = txtRemark.Text.Trim();
                    objRoutineMaintainanceBo.Type = 0;
                    objRoutineMaintainanceBo.UserId = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objRoutineMaintainanceBo.IsBreackDown = 0;

                    if (ViewState["Mode"].ToString() == "Save")
                    {
                        objRoutineMaintainanceBo.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objRoutineMaintainanceBo.CreatedDate = DateTime.UtcNow.AddHours(5.5);
                        var objResult = objRoutineMaintainanceBl.Maintainance_Insert(objRoutineMaintainanceBo);
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            ClientScript.RegisterStartupScript(typeof (Page), "MessagePopUp",
                                "<script>alert('Record Saved Successfully.');</script>");
                            ClearAll();
                            BindgvRoutineMaintainance();
                            PanelVisibilityMode(true, false);
                        }
                    }
                    else if (ViewState["Mode"].ToString() == "Edit")
                    {
                        objRoutineMaintainanceBo.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objRoutineMaintainanceBo.LastModifiedDate = DateTime.UtcNow.AddHours(5.5);
                        objRoutineMaintainanceBo.Id = Convert.ToInt32(ViewState["RoutineMaintainanceID"].ToString());
                        var objResult = objRoutineMaintainanceBl.Maintainance_Update(objRoutineMaintainanceBo);
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            ClientScript.RegisterStartupScript(typeof (Page), "MessagePopUp",
                                "<script>alert('Record Updated Successfully.');</script>");
                            ClearAll();
                            BindgvRoutineMaintainance();
                            PanelVisibilityMode(true, false);
                        }
                    }
                    else if (ViewState["Mode"].ToString() == "Status")
                    {
                        objRoutineMaintainanceBo.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objRoutineMaintainanceBo.CreatedDate = DateTime.UtcNow.AddHours(5.5);
                        MaintainanceBL objRoutineMaintainanceBL = new MaintainanceBL();
                        var objResult =
                            objRoutineMaintainanceBL.Maintainance_UpdateStatus(objRoutineMaintainanceBo,
                                Convert.ToInt32(ViewState["RoutineStatusID"].ToString()));
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            ClientScript.RegisterStartupScript(typeof (Page), "MessagePopUp",
                                "<script>alert('Routine Maintainance status change Successfully.');</script>");
                            PanelVisibilityMode(true, false);
                            BindgvRoutineMaintainance();
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
            BindgvRoutineMaintainance();
        }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion



        #region gvRoutineMaintainance Pre Render Event
        protected void gvRoutineMaintainance_OnPreRender(object sender, EventArgs e)
        {
            try
            {
            if (gvRoutineMaintainance.Rows.Count <= 0) return;
            gvRoutineMaintainance.UseAccessibleHeader = true;
            gvRoutineMaintainance.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region gvRoutineMaintainance Row Command Event
        protected void gvRoutineMaintainance_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                MaintainanceBL objRoutineMaintainanceBL = new MaintainanceBL();
                ClearAll();

                if (e.CommandName == "Edit1" && e.CommandArgument.ToString().Split('~')[1] != "Completed")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["RoutineMaintainanceID"] = e.CommandArgument.ToString().Split('~')[0];
                    var objResult = objRoutineMaintainanceBL.Maintainance_Select_Routine(Convert.ToInt32(ViewState["RoutineMaintainanceID"].ToString()));
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            txtEquipmentNo.Text = objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_EQUIPMENTTAGNO].ToString();
                            txtEquipmentName.Text = objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_EQUIPMENTNAME].ToString();
                            txtMaintainanceDate.Text = objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_MAINTAINANCEDATE].ToString();
                            txtStartDate.Text = objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_STARTTIME].ToString();
                            txtEndDate.Text = objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_ENDTIME].ToString();
                            txtPartNo.Text = objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_PARTNO].ToString();
                            txtPartName.Text = objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_PARTNAME].ToString();
                            txtSection.Text = objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_SECTION].ToString();
                            txtArea.Text= objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_AREA].ToString();
                            txtDepartment.Text= objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_DEPARTMENT].ToString();
                            txtDueDate.Text= objResult.ResultDt.Rows[0]["DueDate"].ToString();
                            txtNextDueDate.Text= objResult.ResultDt.Rows[0]["NextDueDate"].ToString();
                            //txtDueDate.Text = objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_DUEDATE].ToString();
                            //if (objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_NEXTDUEDATE].ToString() ==
                            //    "01/01/2015")
                            //{
                            //    txtNextDueDate.Text = "";
                            //}
                            //else
                            //{
                            //txtNextDueDate.Text = objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_NEXTDUEDATE].ToString();
                            //}
                            txtAction.Text = objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_ACTIONTAKEN].ToString();
                            txtRectified.Text = objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_RECTIFIEDBY].ToString();
                            txtRemark.Text = objResult.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_REMARK].ToString();

                            PanelVisibilityMode(false, true);
                        }
                    }
                }
                else if (e.CommandName == "Delete1" && e.CommandArgument.ToString().Split('~')[1] != "Completed")
                {
                    var objResult = objRoutineMaintainanceBL.Maintainance_Delete(Convert.ToInt32(e.CommandArgument.ToString().Split('~')[0]), Convert.ToInt32(Session[ApplicationSession.Userid].ToString()), System.DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully.');</script>");
                        PanelVisibilityMode(true, false);
                        BindgvRoutineMaintainance();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('You can not delete this RoutineMaintainance because it is in used.');</script>");
                    }
                }
                else if (e.CommandName == "Status1" && e.CommandArgument.ToString().Split('~')[1] != "Completed")
                {

                    ViewState["Mode"] = "Status";
                    ViewState["RoutineStatusID"] = e.CommandArgument.ToString().Split('~')[0];
                    rfAction.Enabled = true;
                    rfNextDueDate.Enabled = true;
                    rfRectified.Enabled = true;
                    var objResultStatus = objRoutineMaintainanceBL.Maintainance_Select_Routine(Convert.ToInt32(ViewState["RoutineStatusID"].ToString()));
                    if (objResultStatus != null)
                    {
                        if (objResultStatus.ResultDt.Rows.Count > 0)
                        {
                            txtEquipmentNo.Text = objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_EQUIPMENTTAGNO].ToString();
                            txtEquipmentName.Text = objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_EQUIPMENTNAME].ToString();
                            txtMaintainanceDate.Text = objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_MAINTAINANCEDATE].ToString();
                            txtStartDate.Text = objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_STARTTIME].ToString();
                            txtEndDate.Text = objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_ENDTIME].ToString();
                            txtPartNo.Text = objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_PARTNO].ToString();
                            txtPartName.Text = objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_PARTNAME].ToString();
                            txtSection.Text = objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_SECTION].ToString();
                            txtArea.Text = objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_AREA].ToString();
                            txtDepartment.Text = objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_DEPARTMENT].ToString();
                            txtDueDate.Text = objResultStatus.ResultDt.Rows[0]["DueDate"].ToString();
                            txtNextDueDate.Text = objResultStatus.ResultDt.Rows[0]["NextDueDate"].ToString();
                            //txtDueDate.Text = objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_DUEDATE].ToString();
                            //if (objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_NEXTDUEDATE].ToString() ==
                            //    "01/01/2015")
                            //{
                            //    txtNextDueDate.Text = "";
                            //}
                            //else
                            //{
                            //    txtNextDueDate.Text = objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_NEXTDUEDATE].ToString();
                            //}
                            txtAction.Text = objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_ACTIONTAKEN].ToString();
                            txtRectified.Text = objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_RECTIFIEDBY].ToString();
                            txtRemark.Text = objResultStatus.ResultDt.Rows[0][MaintainanceBo.MAINTAINANCE_REMARK].ToString();
                            PanelVisibilityMode(false, true);
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
            rfAction.Enabled = false;
            rfRectified.Enabled = false;
            rfNextDueDate.Enabled = false;
        }
        #endregion

        protected void imgWordButton_Click(object sender, EventArgs e)
        {

        }

        protected void imgExcelButton_Click(object sender, EventArgs e)
        {

        }

        #region imbtnPDFButton Click
        protected void imbtnPDFButton_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string filename = "RoutineMaintainance_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                gvRoutineMaintainance.Columns[gvRoutineMaintainance.Columns.Count - 1].Visible = false;
                gvRoutineMaintainance.Columns[gvRoutineMaintainance.Columns.Count - 2].Visible = false;
                gvRoutineMaintainance.Columns[gvRoutineMaintainance.Columns.Count - 3].Visible = false;
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    gvRoutineMaintainance.AllowPaging = false;
                    //   this.MilkStorageGrid();

                    gvRoutineMaintainance.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in gvRoutineMaintainance.HeaderRow.Cells)
                    {
                        cell.BackColor = gvRoutineMaintainance.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvRoutineMaintainance.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvRoutineMaintainance.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvRoutineMaintainance.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                            List<Control> controls = new List<Control>();

                            //Add controls to be removed to Generic List
                            foreach (Control control in cell.Controls)
                            {
                                controls.Add(control);
                            }

                            //Loop through the controls to be removed and replace then with Literal
                            foreach (Control control in controls)
                            {
                                switch (control.GetType().Name)
                                {
                                    case "HyperLink":
                                        cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                        break;
                                    case "TextBox":
                                        cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                        break;
                                    case "LinkButton":
                                        cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                        break;
                                    case "CheckBox":
                                        cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                        break;
                                    case "RadioButton":
                                        cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                        break;
                                }
                                cell.Controls.Remove(control);
                            }
                        }
                    }

                    // gvRoutineMaintainance.Columns[0].Visible = false;
                    gvRoutineMaintainance.RenderControl(hw);

                    string strSubTitle = "Routine Maintainance Report";
                    string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Logo1.gif";
                    //string content = "<div align='left' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/></div><div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                    string content = "<div align='left' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/></div><div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                      "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/>" +
                         "<span align='center' style='font-family:verdana;font-size:13px'><strong>" + strSubTitle + "</strong></span><br/>" +
                      "</div><br/> "
                      + sw.ToString() + "<br/></div>";
                    // string style = @"<!--mce:2-->";
                    StringReader sr = new StringReader(content);
                    Document pdfDoc = new Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
                    pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.Write(pdfDoc);
                    gvRoutineMaintainance.GridLines = GridLines.None;
                    Response.End();
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

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}