using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GEA_Ajmer.Common;
using GEA_Ajmer.DataAccess;

namespace GEA_Ajmer.BL
{
    public class LogBl
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region PCIP Log Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult PCIPLogReport(DateTime FromDatetime, DateTime ToDatetime)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDatetime;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDatetime;

                strStoredProcName = "usp_rpt_PCIPLOGReport";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region TCIP Log Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult TCIPLogReport(DateTime FromDatetime, DateTime ToDatetime)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDatetime;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDatetime;

                strStoredProcName = "usp_rpt_TCIPLOGReport";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Utility Status Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult UtilityStatusReport(DateTime FromDatetime, DateTime ToDatetime)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDatetime;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDatetime;

                strStoredProcName = "usp_rpt_UtilityStatusReport_Taloja";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Utility Consumption Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult UtilityConsumptionReport(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDate;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDate;

                strStoredProcName = "usp_rpt_UtilityConsumptionReport_Taloja";

                DataTable dtResult = new DataTable();
               // DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Sugarsyrp Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult SugarsyrpReport(DateTime FromDate, DateTime ToDate)
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

                strStoredProcName = "usp_rpt_SugarSyrup";

                DataSet dsResult = new DataSet();
                dsResult = Database.ExecuteDataSet(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dsResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Sweet Milk Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult SweetMilkReport(DateTime FromDate, DateTime ToDate)
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

                strStoredProcName = "usp_rpt_SweetMilk";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Sugarsyrp Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult PowderProductionLog(DateTime FromDate, DateTime ToDate)
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

                strStoredProcName = "usp_rpt_PowderProduction";

                DataSet dtResult = new DataSet();
                dtResult = Database.ExecuteDataSet(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region PCIP Log Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult FCIPLogReport(DateTime FromDatetime, DateTime ToDatetime)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDatetime;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDatetime;

                strStoredProcName = "usp_rpt_FCIPLOGReport";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Utility Hot Water Status Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult UtilityHotWaterStatusReport(DateTime FromDatetime, DateTime ToDatetime)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDatetime;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDatetime;

                strStoredProcName = "usp_rpt_UtilityHotWaterStatusReport_Taloja";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Utility Chilled Water Status Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult UtilityChilledWaterStatusReport(DateTime FromDatetime, DateTime ToDatetime)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDatetime;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDatetime;

                strStoredProcName = "usp_rpt_UtilityChilledWaterStatusReport_Taloja";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Utility Raw Water Status Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult UtilityRawaterStatusReport(DateTime FromDatetime, DateTime ToDatetime)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDatetime;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDatetime;

                strStoredProcName = "usp_rpt_UtilityRowWaterStatusReport_Taloja";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Utility Raw Water Status Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult UtilityRawaterStatusReport_DayWise(DateTime FromDatetime, DateTime ToDatetime)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDatetime;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDatetime;

                strStoredProcName = "usp_rpt_UtilityRawWaterStatusReport_DayWise_Taloja";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Utility Soft Water Status Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult UtilitySoftWaterStatusReport(DateTime FromDatetime, DateTime ToDatetime)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDatetime;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDatetime;

                strStoredProcName = "usp_rpt_UtilitySoftWaterStatusReport_Taloja";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Utility Soft Water Status Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult UtilitySoftWaterStatusReport_DayWise(DateTime FromDatetime, DateTime ToDatetime)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDatetime;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDatetime;

                strStoredProcName = "usp_rpt_UtilitySoftWaterStatusReport_DayWise_Taloja";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Utility Air Water Status Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult UtilityAirStatusReport(DateTime FromDatetime, DateTime ToDatetime)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDatetime;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDatetime;

                strStoredProcName = "usp_rpt_UtilityAirStatusReport_Taloja";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Chemical Consumption Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult ChemicalConsumptionReport(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.Date);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDate;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.Date);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDate;

                strStoredProcName = "usp_rpt_ChemicalConsumptionReport_Taloja";

                DataSet dtResult = new DataSet();
                // DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataSet(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region MilkStorage_Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult MilkStorageReport(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.Date);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDate;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.Date);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDate;

                strStoredProcName = "Usp_rpt_MilkStorageReport";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Sugarsyrp Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult SugarsyrpReport(DateTime FromDate, DateTime ToDate, int LineNo)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.Date);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.Date);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDate;

                pSqlParameter[2] = new SqlParameter("@LineNo", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = LineNo;

                strStoredProcName = "usp_rpt_SugarSyrup";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select Evaporator Log_SelectAll
        /// <summary>
        /// To Select All data from the Evap Log
        /// Created By : pavan, 07-07-2017
        /// Modified By :
        /// </summary>
        public ApplicationResult EvaporatorLog_SelectAll(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDate;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDate;

                sSql = "usp_rpt_Evaporator_Logger";

                DataTable dtEvaporator = new DataTable();
                dtEvaporator = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtEvaporator);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        //#region Mass Balance Report
        ///// <summary>
        ///// Select all details of Mass Balance Report between dates
        ///// Created By : Vishal, 9/24/2015
        ///// Modified By :
        ///// </summary>
        //public ApplicationResult MassBalanceReport(DateTime FromDatetime, DateTime ToDatetime)
        //{
        //    try
        //    {
        //        pSqlParameter = new SqlParameter[2];

        //        pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
        //        pSqlParameter[0].Direction = ParameterDirection.Input;
        //        pSqlParameter[0].Value = FromDatetime;

        //        pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
        //        pSqlParameter[1].Direction = ParameterDirection.Input;
        //        pSqlParameter[1].Value = ToDatetime;

        //        strStoredProcName = "usp_rpt_PCIPLOGReport";

        //        DataTable dtResult = new DataTable();
        //        dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
        //        ApplicationResult objResults = new ApplicationResult(dtResult);
        //        objResults.Status = ApplicationResult.CommonStatusType.Success;
        //        return objResults;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //#endregion

        #region Evaporation Production Log Report
        public ApplicationResult EvaporationProductionLog(DateTime fromDate, DateTime toDate)
        {
            try
            {

                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = fromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = toDate;

                sSql = "usp_rpt_Evaporation_Production_Log";

                DataTable dtEvaporator = new DataTable();
                dtEvaporator = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtEvaporator);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Drying Production Log Report
        public ApplicationResult DryingProductionLog(DateTime fromDate, DateTime toDate)
        {
            try
            {

                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = fromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = toDate;

                sSql = "usp_rpt_Dryer_Production_Log";

                DataTable dtEvaporator = new DataTable();
                dtEvaporator = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtEvaporator);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Evaporation CIP Log Report
        public ApplicationResult EvaporationCIPLog(DateTime fromDate, DateTime toDate)
        {
            try
            {

                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = fromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = toDate;

                sSql = "usp_rpt_Evaporation_CIP_Log_2";

                DataTable dtEvaporator = new DataTable();
                dtEvaporator = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtEvaporator);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region delete temp evap cip log report
        public ApplicationResult DeleteTempTable()
        {
            try
            {
                strStoredProcName = "usp_rpt_Temp_Evap_CIP_Log";

                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, strStoredProcName, null);

                if (iResult > 0)
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.Status = ApplicationResult.CommonStatusType.Success;
                    return objResults;
                }
                else
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.Status = ApplicationResult.CommonStatusType.Failure;
                    return objResults;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
