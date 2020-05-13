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
    public class MilkStorageBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Select All MilkStorage Logs
        /// <summary>
        /// To Select All data from the Evap Log
        /// Created By : pavan, 07-07-2017
		/// Modified By :
        /// </summary>
		public ApplicationResult MilkStorage_SelectAll(DateTime FromDate,DateTime ToDate)
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

                sSql = "usp_rpt_MilkStorage";
                DataSet dtEvap = new DataSet();
                dtEvap = Database.ExecuteDataSet(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtEvap);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select All MilkStorage Unload Logs
        /// <summary>
        /// To Select All data from the Evap Log
        /// Created By : pavan, 07-07-2017
		/// Modified By :
        /// </summary>
		public ApplicationResult MilkStorageUnload_SelectAll(DateTime FromDate, DateTime ToDate)
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

                sSql = "usp_rpt_MilkStorage_Unload";
                DataSet dtEvap = new DataSet();
                dtEvap = Database.ExecuteDataSet(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtEvap);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Milk Storage Insert
        /// <summary>
        /// To Select All data from the Evap Log
        /// Created By : pavan, 07-07-2017
        /// Modified By :
        /// </summary>
        public ApplicationResult MilkStorage_Insert(int Id, string strBatchId,decimal dcSNF,decimal dcFAT,decimal dcTS)
        {
            try
            {
                pSqlParameter = new SqlParameter[5];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = Id;

                pSqlParameter[1] = new SqlParameter("@BatchId", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strBatchId;

                pSqlParameter[2] = new SqlParameter("@SNF", SqlDbType.Decimal);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = dcSNF;

                pSqlParameter[3] = new SqlParameter("@FAT", SqlDbType.Decimal);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = dcFAT;

                pSqlParameter[4] = new SqlParameter("@TS", SqlDbType.Decimal);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = dcTS;

                sSql = "usp_tbl_MilkStorage_Insert";

                DataSet dtEvap = new DataSet();
                dtEvap = Database.ExecuteDataSet(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtEvap);
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
