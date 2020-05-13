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
    public class EvapLogBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Select All EVAP Logs
        /// <summary>
        /// To Select All data from the Evap Log
        /// Created By : pavan, 07-07-2017
		/// Modified By :
        /// </summary>
		public ApplicationResult EVAP_SelectAll(DateTime FromDate, DateTime ToDate)
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

                sSql = "usp_rpt_Evap_Logger";
                DataTable dtEvap = new DataTable();
                dtEvap = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

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

        #region Select All EVAP Logs
        /// <summary>
        /// To Select All data from the Evap Log
        /// Created By : pavan, 07-07-2017
        /// Modified By :
        /// </summary>
        public ApplicationResult EVAP_PlantPerformance_Daily(DateTime Date)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = Date;
                
                sSql = "usp_rpt_Evap_Performance";
                DataTable dtEvap = new DataTable();
                dtEvap = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

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
