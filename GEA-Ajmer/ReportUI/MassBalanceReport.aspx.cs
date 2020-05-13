using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI;
using GEA_Ajmer.BL;
using GEA_Ajmer.Common;
using log4net;
using System.Web.UI.WebControls;
using System.Web;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


namespace GEA_Ajmer.ReportUI
{
    public partial class MassBalanceReport : PageBase
    {
        private static ILog log = LogManager.GetLogger(typeof(MassBalanceReport));

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            divExport.Visible = false;
            divNo.Visible = false;
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }
        #endregion



        #region Go button Click Event
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            try
            {
                LogBl objLogBl = new LogBl();
                ReportBL objReportBl = new ReportBL();
                //DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                //    CultureInfo.InvariantCulture);
                var objResult = objReportBl.DailyMassBalanceReport(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text), Convert.ToInt32(ddlReport.SelectedValue));
                gvMassBalanceReport.DataSource = objResult.ResultDt;
                gvMassBalanceReport.DataBind();
                if (gvMassBalanceReport.Rows.Count > 0)
                {
                    divExport.Visible = true;
                    divNo.Visible = false;
                }
                else
                {
                    divExport.Visible = false;
                    divNo.Visible = true;
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

        #region Export to Word Button Click
        //protected void imgbtnDoc_OnClick(object sender, EventArgs e)
        //{
        //    string filename = "MassBalance_Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".doc";
        //    Response.AddHeader("content-disposition", "attachment;filename=" + filename);
        //    Response.Charset = "";
        //    Response.ContentType = "application/msword ";

        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    gvMassBalanceReport.AllowPaging = false;
        //    gvMassBalanceReport.GridLines = GridLines.Both;
        //    foreach (TableCell cell in gvMassBalanceReport.HeaderRow.Cells)
        //    {
        //        cell.BackColor = gvMassBalanceReport.HeaderStyle.BackColor;
        //    }
        //    foreach (GridViewRow row in gvMassBalanceReport.Rows)
        //    {
        //        row.BackColor = Color.White;
        //        foreach (TableCell cell in row.Cells)
        //        {
        //            if (row.RowIndex % 2 == 0)
        //            {
        //                cell.BackColor = gvMassBalanceReport.AlternatingRowStyle.BackColor;
        //            }
        //            else
        //            {
        //                cell.BackColor = gvMassBalanceReport.RowStyle.BackColor;
        //            }
        //            cell.CssClass = "textmode";
        //            List<Control> controls = new List<Control>();

        //            //Add controls to be removed to Generic List
        //            foreach (Control control in cell.Controls)
        //            {
        //                controls.Add(control);
        //            }

        //            //Loop through the controls to be removed and replace then with Literal
        //            foreach (Control control in controls)
        //            {
        //                switch (control.GetType().Name)
        //                {
        //                    case "HyperLink":
        //                        cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
        //                        break;
        //                    case "TextBox":
        //                        cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
        //                        break;
        //                    case "LinkButton":
        //                        cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
        //                        break;
        //                    case "CheckBox":
        //                        cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
        //                        break;
        //                    case "RadioButton":
        //                        cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
        //                        break;
        //                }
        //                cell.Controls.Remove(control);
        //            }
        //        }
        //    }
        //    // gvMassBalanceReport.Columns[0].Visible = false;
        //    gvMassBalanceReport.RenderControl(hw);

        //    string strSubTitle = "PCIP LOG REPORT";
        //    //string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Logo1.gif";
        //    //string content = "<div align='left' style='font-family:verdana;font-size:16px'><img src='" + strPath + "'/></div><div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
        //    string content = "<div align='center'><img align='left' style='height: 40px; width: 109px' src='" + Session[ApplicationSession.Logo] + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
        //    "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/></div>" +
        //       "<div align='center' style='font-family:verdana;font-size:11px'><strong>From Date :</strong>" +
        //   DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
        //    "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
        //    DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) +
        //    "</div><br/><div align='center' style='font-family:verdana;font-size:11px'><span style='font-size:11px;color:Maroon;'>" + strSubTitle + "</ span><br/>" +
        //     "<br/>" + sw.ToString() + "<br/></div>";
        //    Response.Output.Write(content);
        //    Response.Flush();
        //    Response.End();
        //}
        #endregion

        #region Export to Excel Button Click
        protected void imgbtnExcel_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string filename = "MassBalanceReport" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvMassBalanceReport.AllowPaging = false;
                gvMassBalanceReport.GridLines = GridLines.Both;
                foreach (TableCell cell in gvMassBalanceReport.HeaderRow.Cells)
                {
                    cell.BackColor = gvMassBalanceReport.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvMassBalanceReport.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvMassBalanceReport.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvMassBalanceReport.RowStyle.BackColor;
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

                gvMassBalanceReport.RenderControl(hw);
                string strSubTitle = "MASS BALANCE REPORT";

                string content = "<div align='center'><img align='left' style='height: 40px; width: 109px' src='" + Session[ApplicationSession.Logo] + "'/><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/></div>" +
                  "<div align='center' style='font-family:verdana;font-size:11px'><strong>From Date :</strong>" +
                (DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToShortDateString() +
                 "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
                 (DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToShortDateString() +
                "</div><br/><div align='center' style='font-family:verdana;font-size:11px'><span style='font-size:11px;color:Maroon;'>" + strSubTitle + "</ span><br/>" +
                 "<br/>" + sw.ToString() + "<br/></div>";

                string style = @"<!--mce:2-->";
                Response.Write(style);
                Response.Output.Write(content);
                Response.Flush();
                Response.Clear();
                Response.End();

            }
            catch (Exception ex)
            {
                log.Error("Button EXCEL", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Oops! There is some technical issue. Please Contact to your administrator.');", true);
            }
        }
        #endregion

        #region Export to PDF Button Click
        protected void imgbtnPDF_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string filename = "Mass Balance Report" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //gvMilkStorage.Columns[gvMilkStorage.Columns.Count - 1].Visible = false;
                //gvMilkStorage.Columns[gvMilkStorage.Columns.Count - 2].Visible = false;
                //gvMilkStorage.Columns[gvMilkStorage.Columns.Count - 3].Visible = false;


                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    gvMassBalanceReport.AllowPaging = false;
                    //   this.MilkStorageGrid();

                    gvMassBalanceReport.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in gvMassBalanceReport.HeaderRow.Cells)
                    {
                        cell.BackColor = gvMassBalanceReport.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in gvMassBalanceReport.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvMassBalanceReport.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvMassBalanceReport.RowStyle.BackColor;
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
                    //gvPCIPLogReport.Columns[0].Visible = false;
                    gvMassBalanceReport.RenderControl(hw);

                    string strSubTitle = "Milk Storage Report";
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
                    gvMassBalanceReport.GridLines = GridLines.None;
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

        #region VerifyRenderingInServerForm
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }



        #endregion

        #region gvMassBalanceReport_RowCreated
        protected void gvMassBalanceReport_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {

                    GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    GridViewRow headerRow3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    GridViewRow headerRow4 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                    TableHeaderCell headerTableCell = new TableHeaderCell();

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 3;
                    headerTableCell.ColumnSpan = 1;
                    headerTableCell.CssClass = "rowstyle1";
                    headerTableCell.Text = "Sr.No. ";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 3;
                    headerTableCell.ColumnSpan = 1;
                    headerTableCell.CssClass = "rowstyle1";
                    headerTableCell.Text = "Date.";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 4;
                    headerTableCell.CssClass = "rowstyle1";
                    headerTableCell.Text = "Input A";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 4;
                    headerTableCell.CssClass = "rowstyle1";
                    headerTableCell.Text = "Output B";
                    headerRow1.Controls.Add(headerTableCell);


                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 3;
                    headerTableCell.ColumnSpan = 1;
                    headerTableCell.CssClass = "rowstyle1";
                    headerTableCell.Text = "Difference of Total solids in Kg C = B - A";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 3;
                    headerTableCell.ColumnSpan = 1;
                    headerTableCell.CssClass = "rowstyle1";
                    headerTableCell.Text = "% variation    D = C / A %";
                    headerRow1.Controls.Add(headerTableCell);


                    TableHeaderCell headerCell_2_1;
                    TableHeaderCell headerCell_2_2;
                    TableHeaderCell headerCell_2_3;
                    TableHeaderCell headerCell_2_4;
                    TableHeaderCell headerCell_2_5;


                    TableHeaderCell headerCell_3_1;
                    TableHeaderCell headerCell_3_2;
                    TableHeaderCell headerCell_3_3;
                    TableHeaderCell headerCell_3_4;
                    TableHeaderCell headerCell_3_5;
                    TableHeaderCell headerCell_3_6;

                    headerCell_2_1 = new TableHeaderCell();
                    headerCell_2_2 = new TableHeaderCell();
                    headerCell_2_3 = new TableHeaderCell();
                    headerCell_2_4 = new TableHeaderCell();
                    headerCell_2_5 = new TableHeaderCell();

                    headerCell_3_1 = new TableHeaderCell();
                    headerCell_3_2 = new TableHeaderCell();
                    headerCell_3_3 = new TableHeaderCell();
                    headerCell_3_4 = new TableHeaderCell();
                    headerCell_3_5 = new TableHeaderCell();
                    headerCell_3_6 = new TableHeaderCell();

                    headerCell_2_1.Text = "Milk  In Kg";
                    headerCell_2_1.RowSpan = 2;
                    headerCell_2_2.Text = "Milk TS In Kg";
                    headerCell_2_2.RowSpan = 1;
                    headerCell_2_2.ColumnSpan = 3;
                    headerCell_2_3.Text = "Qty of Powder In Kg";
                    headerCell_2_3.RowSpan = 2;
                    headerCell_2_4.Text = "TS Qty in Powder In Kg";
                    headerCell_2_4.RowSpan = 1;
                    headerCell_2_4.ColumnSpan = 3;

                    headerCell_3_1.Text = "FAT";
                    headerCell_3_1.RowSpan = 1;
                    headerCell_3_2.Text = "SNF";
                    headerCell_3_2.RowSpan = 1;
                    headerCell_3_3.Text = "SUGAR";
                    headerCell_3_3.ColumnSpan = 1;
                    headerCell_3_3.RowSpan = 1;
                    headerCell_3_4.Text = "FAT";
                    headerCell_3_4.RowSpan = 1;
                    headerCell_3_4.ColumnSpan = 1;
                    headerCell_3_5.Text = "SNF";
                    headerCell_3_5.RowSpan = 1;
                    headerCell_3_5.ColumnSpan = 1;
                    headerCell_3_6.Text = "SUGAR";
                    headerCell_3_6.RowSpan = 1;
                    headerCell_3_6.ColumnSpan = 1;

                    headerRow2.Controls.Add(headerCell_2_1);
                    headerRow2.Controls.Add(headerCell_2_2);
                    headerRow3.Controls.Add(headerCell_3_1);
                    headerRow3.Controls.Add(headerCell_3_2);
                    headerRow3.Controls.Add(headerCell_3_3);
                    headerRow2.Controls.Add(headerCell_2_3);
                    headerRow2.Controls.Add(headerCell_2_4);
                   
                    headerRow3.Controls.Add(headerCell_3_4);              
                    headerRow3.Controls.Add(headerCell_3_5);
                    headerRow3.Controls.Add(headerCell_3_6);               
                    headerRow2.Controls.Add(headerCell_2_5);

                   // gvMassBalanceReport.Controls[0].Controls.AddAt(0, headerRow4);
                    gvMassBalanceReport.Controls[0].Controls.AddAt(0, headerRow3);
                    gvMassBalanceReport.Controls[0].Controls.AddAt(0, headerRow2);
                    gvMassBalanceReport.Controls[0].Controls.AddAt(0, headerRow1);
                }
            }
            for (int b = 0; b < gvMassBalanceReport.Rows.Count; b++)
            {
                if (gvMassBalanceReport.Rows[b].RowType == DataControlRowType.DataRow)
                {
                    for (int bb = 0; bb < gvMassBalanceReport.Rows[b].Cells.Count; bb++)
                    {
                        gvMassBalanceReport.Rows[b].Cells[bb].HorizontalAlign = HorizontalAlign.Center;
                    }
                  
                }
            }
        }
        #endregion
    }
}