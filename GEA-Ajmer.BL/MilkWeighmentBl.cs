using GEA_Ajmer.Common;
using GEA_Ajmer.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GEA_Ajmer.BL
{
    public class MilkWeighmentBl
    {

        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Select All MilkReception 
        /// <summary>
        /// To Select All data from the Evap Log
        /// Created By : pavan, 07-07-2017
        /// Modified By :
        /// </summary>
        public ApplicationResult WeighBridgeSummary_SelectAll(DateTime FromDatetime, DateTime ToDatetime)
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

                //sSql = "usp_rpt_MilkReception";
                sSql = "usp_rpt_WeighBridgeSummary_Taloja";
                DataTable dtMilkReception = new DataTable();
                DataSet dsResult = new DataSet();
                dsResult = Database.ExecuteDataSet(CommandType.StoredProcedure, sSql, pSqlParameter);

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

        #region Refrigerator_ColdStorage_SelectAll
        public ApplicationResult Refrigerator_ColdStorage_SelectAll(DateTime FromDatetime, DateTime ToDatetime)
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

                //sSql = "usp_rpt_MilkReception";
                sSql = "usp_rpt_Ref_ColdStorage_Taloja";
                DataTable dtMilkReception = new DataTable();
                DataSet dsResult = new DataSet();
                dsResult = Database.ExecuteDataSet(CommandType.StoredProcedure, sSql, pSqlParameter);

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


        #region Refrigerator_ChilledWater_SelectAll
        public ApplicationResult Refrigerator_ChilledWater_SelectAll(DateTime FromDatetime, DateTime ToDatetime)
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

                //sSql = "usp_rpt_MilkReception";
                sSql = "usp_rpt_Ref_ChilledWater_Taloja";
                DataTable dtMilkReception = new DataTable();
                DataSet dsResult = new DataSet();
                dsResult = Database.ExecuteDataSet(CommandType.StoredProcedure, sSql, pSqlParameter);

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

        #region Boiler-1 Data 
        public ApplicationResult Boiler1_SelectAll(DateTime FromDatetime, DateTime ToDatetime)
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

                //sSql = "usp_rpt_MilkReception";
                sSql = "usp_rpt_Boiler1_Taloja";
                DataTable dtMilkReception = new DataTable();
                DataSet dsResult = new DataSet();
                dsResult = Database.ExecuteDataSet(CommandType.StoredProcedure, sSql, pSqlParameter);

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

        #region Boiler-2 Data 
        public ApplicationResult Boiler2_SelectAll(DateTime FromDatetime, DateTime ToDatetime)
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

                //sSql = "usp_rpt_MilkReception";
                sSql = "usp_rpt_Boiler2_Taloja";
                DataTable dtMilkReception = new DataTable();
                DataSet dsResult = new DataSet();
                dsResult = Database.ExecuteDataSet(CommandType.StoredProcedure, sSql, pSqlParameter);

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

        #region  WTP Data 
        public ApplicationResult WTP_SelectAll(DateTime FromDatetime, DateTime ToDatetime)
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

                //sSql = "usp_rpt_MilkReception";
                sSql = "usp_rpt_WTP_Taloja";
                DataTable dtMilkReception = new DataTable();
                DataSet dsResult = new DataSet();
                dsResult = Database.ExecuteDataSet(CommandType.StoredProcedure, sSql, pSqlParameter);

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

        #region Compressor Data 
        public ApplicationResult Compressor_SelectAll(DateTime FromDatetime, DateTime ToDatetime)
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

                //sSql = "usp_rpt_MilkReception";
                sSql = "usp_rpt_Comprassor_Taloja";
                DataTable dtMilkReception = new DataTable();
                DataSet dsResult = new DataSet();
                dsResult = Database.ExecuteDataSet(CommandType.StoredProcedure, sSql, pSqlParameter);

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

    }
}
