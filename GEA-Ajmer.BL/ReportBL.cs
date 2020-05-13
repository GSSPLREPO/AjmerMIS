using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEA_Ajmer.Common;
using GEA_Ajmer.DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace GEA_Ajmer.BL
{
    public class ReportBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region MilkStorage Report Insert
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Pavan, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult MilkStorageReport_Load_Insert(string SiloName, string BatchID, float SNF, float FAT, DateTime StartTime, DateTime EndTime, int ModifiedBy, DateTime ModifiedDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[8];

                pSqlParameter[0] = new SqlParameter("@SiloName", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = SiloName;

                pSqlParameter[1] = new SqlParameter("@SNF", SqlDbType.Float);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = SNF;

                pSqlParameter[2] = new SqlParameter("@FAT", SqlDbType.Float);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = FAT;

                pSqlParameter[3] = new SqlParameter("@StartTime", SqlDbType.DateTime);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = StartTime;

                pSqlParameter[4] = new SqlParameter("@EndTime", SqlDbType.DateTime);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = EndTime;

                pSqlParameter[5] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = ModifiedBy;

                pSqlParameter[6] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = ModifiedDate;

                pSqlParameter[7] = new SqlParameter("@BatchID", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = BatchID;

                strStoredProcName = "usp_rpt_MilkStorageLoadReport_Insert";

                // DataTable dtResult = new DataTable();
                ApplicationResult objResults = new ApplicationResult();
                int i = Database.ExecuteNonQuery(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                if (i > 0)
                {
                    //ApplicationResult objResults = new ApplicationResult(dtResult);
                    objResults.Status = ApplicationResult.CommonStatusType.Success;
                    return objResults;
                }
                else
                {
                    //ApplicationResult objResults = new ApplicationResult(dtResult);
                    objResults.Status = ApplicationResult.CommonStatusType.Failure;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region MilkStorage Unload Report Insert
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Pavan, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult MilkStorageReport_UnLoad_Insert(string SiloName, string BatchID, float SNF, float FAT, DateTime StartTime, DateTime EndTime, int ModifiedBy, DateTime ModifiedDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[8];

                pSqlParameter[0] = new SqlParameter("@SiloName", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = SiloName;

                pSqlParameter[1] = new SqlParameter("@SNF", SqlDbType.Float);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = SNF;

                pSqlParameter[2] = new SqlParameter("@FAT", SqlDbType.Float);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = FAT;

                pSqlParameter[3] = new SqlParameter("@StartTime", SqlDbType.DateTime);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = StartTime;

                pSqlParameter[4] = new SqlParameter("@EndTime", SqlDbType.DateTime);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = EndTime;

                pSqlParameter[5] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = ModifiedBy;

                pSqlParameter[6] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = ModifiedDate;

                pSqlParameter[7] = new SqlParameter("@BatchID", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = BatchID;

                strStoredProcName = "usp_rpt_MilkStorageUnLoadReport_Insert";

                // DataTable dtResult = new DataTable();
                ApplicationResult objResults = new ApplicationResult();
                int i = Database.ExecuteNonQuery(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                if (i > 0)
                {
                    //ApplicationResult objResults = new ApplicationResult(dtResult);
                    objResults.Status = ApplicationResult.CommonStatusType.Success;
                    return objResults;
                }
                else
                {
                    //ApplicationResult objResults = new ApplicationResult(dtResult);
                    objResults.Status = ApplicationResult.CommonStatusType.Failure;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Sugar Syrup Report Insert
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Pavan, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult SugarSyrup_Insert(string SiloName, string VatNo, DateTime StartTime, DateTime EndTime, int ModifiedBy, DateTime ModifiedDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[6];

                pSqlParameter[0] = new SqlParameter("@SiloName", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = SiloName;

                pSqlParameter[1] = new SqlParameter("@VatNo", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = VatNo;

                pSqlParameter[2] = new SqlParameter("@StartTime", SqlDbType.DateTime);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = StartTime;

                pSqlParameter[3] = new SqlParameter("@EndTime", SqlDbType.DateTime);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = EndTime;

                pSqlParameter[4] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = ModifiedBy;

                pSqlParameter[5] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = ModifiedDate;

                strStoredProcName = "usp_rpt_SugarSyrupReport_Insert";

                // DataTable dtResult = new DataTable();
                ApplicationResult objResults = new ApplicationResult();
                int i = Database.ExecuteNonQuery(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                if (i > 0)
                {
                    //ApplicationResult objResults = new ApplicationResult(dtResult);
                    objResults.Status = ApplicationResult.CommonStatusType.Success;
                    return objResults;
                }
                else
                {
                    //ApplicationResult objResults = new ApplicationResult(dtResult);
                    objResults.Status = ApplicationResult.CommonStatusType.Failure;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Sweet Milk Syrup Report Insert
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Pavan, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult SweetMilk_Insert(string SiloName, float Ts, DateTime datetime, int ModifiedBy, DateTime ModifiedDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[5];

                pSqlParameter[0] = new SqlParameter("@SiloName", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = SiloName;

                pSqlParameter[1] = new SqlParameter("@TS", SqlDbType.Float);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = Ts;

                pSqlParameter[2] = new SqlParameter("@StartTime", SqlDbType.DateTime);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = datetime;

                pSqlParameter[3] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = ModifiedBy;

                pSqlParameter[4] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = ModifiedDate;

                strStoredProcName = "usp_rpt_SweetMilkReport_Insert";

                // DataTable dtResult = new DataTable();
                ApplicationResult objResults = new ApplicationResult();
                int i = Database.ExecuteNonQuery(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                if (i > 0)
                {
                    //ApplicationResult objResults = new ApplicationResult(dtResult);
                    objResults.Status = ApplicationResult.CommonStatusType.Success;
                    return objResults;
                }
                else
                {
                    //ApplicationResult objResults = new ApplicationResult(dtResult);
                    objResults.Status = ApplicationResult.CommonStatusType.Failure;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Evap Plant Performance Shift DayWise Insert
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Pavan, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult EvapPlantPerformance_DailyShift_Insert(string BDHrs, string IDLEHrs, string TotalHrs, string Remark, DateTime datetime, string ShiftName, int ModifiedBy, DateTime ModifiedDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[10];

                pSqlParameter[0] = new SqlParameter("@BDHrs", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = BDHrs;

                pSqlParameter[1] = new SqlParameter("@IDLEHrs", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = IDLEHrs;

                pSqlParameter[2] = new SqlParameter("@Remark", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = Remark;

                pSqlParameter[3] = new SqlParameter("@datetime", SqlDbType.DateTime);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = datetime;

                pSqlParameter[4] = new SqlParameter("@ShiftName", SqlDbType.VarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = ShiftName;

                pSqlParameter[5] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = ModifiedDate;

                pSqlParameter[6] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = ModifiedBy;

                pSqlParameter[7] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = ModifiedDate;

                pSqlParameter[8] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = ModifiedBy;

                pSqlParameter[9] = new SqlParameter("@TotalHrs", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = TotalHrs;

                strStoredProcName = "usp_rpt_EvapPlantPerformance_Insert";

                // DataTable dtResult = new DataTable();
                ApplicationResult objResults = new ApplicationResult();
                int i = Database.ExecuteNonQuery(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                if (i > 0)
                {
                    //ApplicationResult objResults = new ApplicationResult(dtResult);
                    objResults.Status = ApplicationResult.CommonStatusType.Success;
                    return objResults;
                }
                else
                {
                    //ApplicationResult objResults = new ApplicationResult(dtResult);
                    objResults.Status = ApplicationResult.CommonStatusType.Failure;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Select EvapPerformance Chart Year
        /// <summary>
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult GetAllData(string FromDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDate;

                //sSql = "usp_tbl_ClientWise_BMCGetID";
                sSql = "usp_rpt_EVAP_Performance_Year";

                DataSet dtAnnouncement = new DataSet();
                dtAnnouncement = Database.ExecuteDataSet(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtAnnouncement);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DailyMassBalanceReport
        public ApplicationResult DailyMassBalanceReport(DateTime FromDate, DateTime ToDate,int IsDaily)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDate;

                pSqlParameter[2] = new SqlParameter("@IsDaily", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = IsDaily;

                sSql = "usp_rpt_MassBalance_Report";

                DataTable DtResult = new DataTable();
                DtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(DtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Evaporation Plant Performance Report
        public ApplicationResult EvaporationPlantPerformanceReport(DateTime FromDate, DateTime ToDate, int IsDaily)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDate;

                pSqlParameter[2] = new SqlParameter("@IsDaily", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = IsDaily;

                sSql = "usp_rpt_EvaporationPlantPerformance_Report";

                DataTable DtResult = new DataTable();
                DtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(DtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Evaporation Plant Performance Monthly Report
        public ApplicationResult EvaporationPlantPerformanceReportMonthly(DateTime FromDate, DateTime ToDate, int IsDaily)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDate;

                pSqlParameter[2] = new SqlParameter("@IsDaily", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = IsDaily;

                sSql = "usp_rpt_EvaporationPlantPerformance_Report";

                DataTable DtResult = new DataTable();
                DtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(DtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Dryer Performance Report
        public ApplicationResult DryerPerformanceReport(DateTime FromDate, DateTime ToDate, int IsDaily)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDate;

                pSqlParameter[2] = new SqlParameter("@IsDaily", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = IsDaily;

                sSql = "usp_rpt_DryerPerformance_Report";

                DataTable DtResult = new DataTable();
                DtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(DtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Dryer Performance Report Graph
        public ApplicationResult DryerPerformanceReportMonthlyGraph(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDate;

              

                sSql = "usp_rpt_DryerPerformanceGraph_Report";

                DataTable DtResult = new DataTable();
                DtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(DtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        #region Dryer Performance Monthly Report
        public ApplicationResult DryerPerformanceReportMonthly(DateTime FromDate, DateTime ToDate, int IsDaily)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDate;

                pSqlParameter[2] = new SqlParameter("@IsDaily", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = IsDaily;

                sSql = "usp_rpt_DryerPerformance_Report";

                DataTable DtResult = new DataTable();
                DtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(DtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
