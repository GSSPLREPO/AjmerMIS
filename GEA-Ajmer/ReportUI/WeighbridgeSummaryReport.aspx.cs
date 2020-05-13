using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GEA_Ajmer.BL;
using GEA_Ajmer.Common;
using log4net;
using System.Globalization;
using System.IO;

namespace GEA_Ajmer.ReportUI
{
    public partial class WeighbridgeSummaryReport : System.Web.UI.Page
    {

        private static ILog log = LogManager.GetLogger(typeof(WeighbridgeSummaryReport));

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                imgbtnWord.Visible = imgbtnPDF.Visible = imgbtnExcel.Visible = divExport.Visible = false;
                ViewState["Mode"] = "Save";
            }
        }
        #endregion

        #region WeighBridgeSummary Data Bind
        public void WeighBridgeSummaryBind()
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy",
               CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);
                // objResult = new MilkReceptionBL().MilkReception_SelectAll(dtFromDateTime, dtToDateTime, Convert.ToInt32(ddlShiftNo.SelectedValue), Convert.ToInt32(ddlTankerID.SelectedValue), Convert.ToDouble(ddlReceptionLineNo.SelectedValue), Convert.ToDouble(ddlSILONo.SelectedValue));

                objResult = new MilkWeighmentBl().WeighBridgeSummary_SelectAll(dtFromDateTime, dtToDateTime);
                //ViewState["DataTableMilkStorage"] = objResult.ResutlDs.Tables[0];
                gvWeighbridgeSummary.DataSource = objResult.ResutlDs.Tables[0];
                gvWeighbridgeSummary.DataBind();
                //gvTotalQty.DataSource = objResult.ResutlDs.Tables[1];
                //gvTotalQty.DataBind();

                if (gvWeighbridgeSummary.Rows.Count > 1)
                {
                    imgbtnWord.Visible = imgbtnPDF.Visible = imgbtnExcel.Visible = divExport.Visible = true;
                    divExport.Visible = true;
                }
                else
                {
                    imgbtnWord.Visible = imgbtnPDF.Visible = imgbtnExcel.Visible = divExport.Visible = true;
                    divExport.Visible = true;
                    gvWeighbridgeSummary.DataSource = null;
                    gvWeighbridgeSummary.DataBind();
                    // ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    //"<script>alert('No Record Found.');</script>");
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

        #region imgbtnPDF_Click
        protected void imgbtnPDF_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region imgbtnExcel_Click
        protected void imgbtnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.AddHeader("content-disposition", "attachment;filename=BreakdownMaintainanceReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvWeighbridgeSummary.AllowPaging = false;
                gvWeighbridgeSummary.RenderControl(hw);
                string strTitle = "Banaskantha District Co-Operative Milk Producers Union LTD, Palanpur";

                string Date = DateTime.UtcNow.AddHours(5.5).ToString();
                string strSubTitle = "Breakdown Maintainance Report </br> as on " + Date;
                //string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/GCMMF-297x300.jpg";
                string content =
                    "<div align='center'>" +
                    "<div>" +
                    "<div style='align:left;font-size:20px;font-weight:bold;color:Maroon'></td>" + strTitle +
                    "</div><br/><span style='font-size:20px;'>" + strSubTitle + "</span><br/>" +
                    "<div><div align='left' style='font-family:verdana;font-size:13px;border-style: solid; border-width: thin;'>" +
                    sw.ToString() + "</div> </div>";
                Response.Output.Write(content);
                Response.Flush();
                Response.End();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region imgbtnWord_Click
        protected void imgbtnWord_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region btnGo_Click
        protected void btnGo_Click(object sender, EventArgs e)
        {
            WeighBridgeSummaryBind();
        }
        #endregion

        protected void gvWeighbridgeSummary_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                    TableHeaderCell headerTableCell = new TableHeaderCell();

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "VehicleNumber";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "VehicleCode";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "ChallanNo";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "DriverName";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "TankerSourceLocation";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "ProductName";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "Purpose";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "GrossWeight (kg)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "TareWeight (kg)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "NetWeight (kg)";
                    headerRow1.Controls.Add(headerTableCell);


                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "InTime";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "OutTime";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "Supplied Qty. (kg)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "Wt.Difference (kg)";
                    headerRow1.Controls.Add(headerTableCell);

                   
                    TableHeaderCell headerCell1;
                    TableHeaderCell headerCell2;
                    TableHeaderCell headerCell3;
                    TableHeaderCell headerCell4;
                    TableHeaderCell headerCell5;
                    TableHeaderCell headerCell6;
                    TableHeaderCell headerCell7;
                    TableHeaderCell headerCell8;
                    TableHeaderCell headerCell9;
                    TableHeaderCell headerCell10;
                    TableHeaderCell headerCell11;
                     TableHeaderCell headerCell12;
                    TableHeaderCell headerCell13;
                    TableHeaderCell headerCell14;
                  


                    //headerCell1 = new TableHeaderCell();
                    //headerCell2 = new TableHeaderCell();
                    //headerCell3 = new TableHeaderCell();
                    //headerCell4 = new TableHeaderCell();
                    //headerCell5 = new TableHeaderCell();
                    //headerCell6 = new TableHeaderCell();
                    //headerCell7 = new TableHeaderCell();
                    //headerCell8 = new TableHeaderCell();
                    //headerCell9 = new TableHeaderCell();
                    //headerCell10 = new TableHeaderCell();
                    //headerCell11 = new TableHeaderCell();
                    //headerCell12 = new TableHeaderCell();
                    //headerCell13 = new TableHeaderCell();
                    //headerCell14 = new TableHeaderCell();

                    //headerCell1.Text = "Step Time (sec)";
                    //headerCell2.Text = "Temp SP (Deg C)";
                    //headerCell3.Text = "Return Temp (Deg C)";
                    //headerCell4.Text = "LYE SP( ms/cm)";
                    //headerCell5.Text = "Return Cond. (ms/cm)";
                    //headerCell6.Text = "Step Time (sec)";
                    //headerCell7.Text = "Temp SP (Deg C)";
                    //headerCell8.Text = "Return Temp (Deg C)";
                    //headerCell9.Text = "Acid SP (ms/cm)";
                    //headerCell10.Text = "Return Cond. (ms/cm)";
                    //headerCell11.Text = "Step Time (sec)";
                    //headerCell12.Text = "Temp SP";
                    //headerCell13.Text = "Return Temp (Deg C)";
                    //headerCell14.Text = "Cond SP (Deg C)";
                   


                    //headerRow2.Controls.Add(headerCell1);
                    //headerRow2.Controls.Add(headerCell2);
                    //headerRow2.Controls.Add(headerCell3);
                    //headerRow2.Controls.Add(headerCell4);
                    //headerRow2.Controls.Add(headerCell5);
                    //headerRow2.Controls.Add(headerCell6);
                    //headerRow2.Controls.Add(headerCell7);
                    //headerRow2.Controls.Add(headerCell8);
                    //headerRow2.Controls.Add(headerCell9);
                    //headerRow2.Controls.Add(headerCell10);
                    //headerRow2.Controls.Add(headerCell11);
                    ////headerRow2.Controls.Add(headerCell12);
                    //headerRow2.Controls.Add(headerCell13);
                    //headerRow2.Controls.Add(headerCell14);
                    //headerRow2.Controls.Add(headerCell15);
                    //headerRow2.Controls.Add(headerCell16);
                    //// headerRow2.Controls.Add(headerCell17);
                    //headerRow2.Controls.Add(headerCell18);
                    //headerRow2.Controls.Add(headerCell19);
                    //headerRow2.Controls.Add(headerCell20);
                    //headerRow2.Controls.Add(headerCell21);
                    //headerRow2.Controls.Add(headerCell21);
                    //headerRow2.Controls.Add(headerCell22);
                    //headerRow2.Controls.Add(headerCell23);
                    //headerRow2.Controls.Add(headerCell24);


                    //gvPCIPLogReport.Controls[0].Controls.AddAt(0, headerRow2);
                    gvWeighbridgeSummary.Controls[0].Controls.AddAt(0, headerRow1);
                }
            }

        }
    }
}