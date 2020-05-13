using GEA_Ajmer.Common;
using GEA_Ajmer.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA_Ajmer.BL
{
    public class SugarSyrupBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region SugarSyrup insert qty
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult SugarSyrupInsert(int ID, double Qty)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = ID;

                pSqlParameter[1] = new SqlParameter("@QtySugarTaken", SqlDbType.Float);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = Qty;

                strStoredProcName = "usp_rpt_SugarSyrup_Insert";

                //DataTable dtResult = new DataTable();
                //dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                //ApplicationResult objResults = new ApplicationResult(dtResult);

                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);

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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
