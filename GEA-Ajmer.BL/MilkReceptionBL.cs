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
    public class MilkReceptionBL
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
        public ApplicationResult MilkReception_SelectAll(DateTime FromDatetime, DateTime ToDatetime, int ShiftId, string TankerId, double LineNo, double Dest)
        {
            try
            {
                pSqlParameter = new SqlParameter[6];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDatetime;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDatetime;

                pSqlParameter[2] = new SqlParameter("@ShiftId", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = ShiftId;

                pSqlParameter[3] = new SqlParameter("@PTankerId", SqlDbType.VarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = TankerId;

                pSqlParameter[4] = new SqlParameter("@LineNo", SqlDbType.Real);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = LineNo;

                pSqlParameter[5] = new SqlParameter("@PDest", SqlDbType.Real);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = Dest;

                //sSql = "usp_rpt_MilkReception";
                sSql = "usp_rpt_MilkReception_Taloja";
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
