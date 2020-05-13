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
    public class DryerLogBL
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
		public ApplicationResult DRYERLog_SelectAll(DateTime FromDate,DateTime ToDate)
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

                sSql = "usp_rpt_Dryer_Logger";
                DataTable dtDryer = new DataTable();
                dtDryer = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtDryer);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert PowderMoisture insert
        /// <summary>
        /// To Select All data from the Evap Log
        /// Created By : pavan, 07-07-2017
        /// Modified By :
        /// </summary>
        public ApplicationResult Insert_PowderMoisture(int Id, decimal decPowderMoisture,decimal decBagNo)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = Id;

                pSqlParameter[1] = new SqlParameter("@PowderMoisture", SqlDbType.Decimal);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = decPowderMoisture;

                pSqlParameter[2] = new SqlParameter("@BagNo", SqlDbType.Decimal);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = decBagNo;

                sSql = "usp_tbl_Dryer_Logger_Insert";

                DataTable dtDryer = new DataTable();
                dtDryer = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtDryer);
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
