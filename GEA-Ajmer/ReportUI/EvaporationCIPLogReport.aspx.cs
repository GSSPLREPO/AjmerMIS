using GEA_Ajmer.BL;
using GEA_Ajmer.Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GEA_Ajmer.ReportUI
{
    public partial class EvaporationCIPLogReport : System.Web.UI.Page
    {

        #region declarations
        private static ILog log = LogManager.GetLogger(typeof(UtilityStatusReport));
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divNo.Visible = false;
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }
        #endregion

        #region export buttons
        protected void imgbtnPDF_OnClick(object sender, EventArgs e)
        {

        }

        protected void imgbtnExcel_OnClick(object sender, EventArgs e)
        {

        }

        protected void imgbtnWord_OnClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region button go click event
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            try
            {
                LogBl objBL = new LogBl();
                ApplicationResult objResult = new ApplicationResult();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                      CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);

                objResult = objBL.EvaporationCIPLog(dtFromDateTime, dtToDateTime);
                if (objResult.ResultDt.Rows.Count > 1)
                {
                    divNo.Visible = false;
                    gvEvaporationCIPLog.Visible = true;
                    gvEvaporationCIPLog.DataSource = objResult.ResultDt;
                    gvEvaporationCIPLog.DataBind();
                    ApplicationResult objRes = new ApplicationResult();
                    objRes = objBL.DeleteTempTable();
                    if (objRes.Status == ApplicationResult.CommonStatusType.Failure)
                    {
                        log.Error("Error");
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                           "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");

                    }
                }
                else
                {
                    divNo.Visible = false;
                    gvEvaporationCIPLog.Visible = true;
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

        #region gvEvaporationCIPLog_RowCreated
        protected void gvEvaporationCIPLog_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                    TableHeaderCell headerTableCell = new TableHeaderCell();

                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Sr. No.";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Start Time";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Stop Time";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "CIP Time";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 2;
                    headerTableCell.Text = "Pre-Caustic";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 2;
                    headerTableCell.Text = "Pre-Acid";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 2;
                    headerTableCell.Text = "Caustic";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 2;
                    headerTableCell.Text = "Acid";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 2;
                    headerTableCell.Text = "Intermediate Rinse";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 2;
                    headerTableCell.Text = "Final Rinse";
                    headerRow1.Controls.Add(headerTableCell);

                    TableHeaderCell headerCell1 = new TableHeaderCell();
                    TableHeaderCell headerCell2 = new TableHeaderCell();
                    TableHeaderCell headerCell3 = new TableHeaderCell();
                    TableHeaderCell headerCell4 = new TableHeaderCell();
                    TableHeaderCell headerCell5 = new TableHeaderCell();
                    TableHeaderCell headerCell6 = new TableHeaderCell();
                    TableHeaderCell headerCell7 = new TableHeaderCell();
                    TableHeaderCell headerCell8 = new TableHeaderCell();
                    TableHeaderCell headerCell9 = new TableHeaderCell();
                    TableHeaderCell headerCell10 = new TableHeaderCell();
                    TableHeaderCell headerCell11 = new TableHeaderCell();
                    TableHeaderCell headerCell12 = new TableHeaderCell();

                    headerCell1.Text = "Cond.";
                    headerCell2.Text = "Step Time";
                    headerCell3.Text = "Cond.";
                    headerCell4.Text = "Step Time";
                    headerCell5.Text = "Cond.";
                    headerCell6.Text = "Step Time";
                    headerCell7.Text = "Cond.";
                    headerCell8.Text = "Step Time";
                    headerCell9.Text = "Cond.";
                    headerCell10.Text = "Step Time";
                    headerCell11.Text = "Cond.";
                    headerCell12.Text = "Step Time";


                    headerRow2.Controls.Add(headerCell1);
                    headerRow2.Controls.Add(headerCell2);
                    headerRow2.Controls.Add(headerCell3);
                    headerRow2.Controls.Add(headerCell4);
                    headerRow2.Controls.Add(headerCell5);
                    headerRow2.Controls.Add(headerCell6);
                    headerRow2.Controls.Add(headerCell7);
                    headerRow2.Controls.Add(headerCell8);
                    headerRow2.Controls.Add(headerCell9);
                    headerRow2.Controls.Add(headerCell10);
                    headerRow2.Controls.Add(headerCell11);
                    headerRow2.Controls.Add(headerCell12);

                    gvEvaporationCIPLog.Controls[0].Controls.AddAt(0, headerRow2);
                    gvEvaporationCIPLog.Controls[0].Controls.AddAt(0, headerRow1);
                }
            }
        }
        #endregion

    }
}