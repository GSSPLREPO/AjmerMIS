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
    public class PlantPerformanceBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion


        #region Insert PowderMoisture insert
        /// <summary>
        /// To Select All data from the Evap Log
        /// Created By : pavan, 07-07-2017
        /// Modified By :
        /// </summary>
        public ApplicationResult Insert_EvaporationPlantPerformanceReport(int Id, string BreakdownHours, string IdleHours, string Remarks,DateTime ModifiedDate,int ModifiedId)
        {
            try
            {
                pSqlParameter = new SqlParameter[6];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = Id;

                pSqlParameter[1] = new SqlParameter("@BreakdownHours", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = BreakdownHours;

                pSqlParameter[2] = new SqlParameter("@IdleHours", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = IdleHours;

                pSqlParameter[3] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = Remarks;

                pSqlParameter[4] = new SqlParameter("@ModifiedDate", SqlDbType.DateTime);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = ModifiedDate; 

                pSqlParameter[5] = new SqlParameter("@ModifiedId", SqlDbType.Int);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = ModifiedId;

                sSql = "usp_tbl_Evaporation_Plant_Performance_Insert";

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
        public ApplicationResult Insert_EvaporationPlantPerformanceMonthlyReport(int Id, string BreakdownHours, string IdleHours, string Remarks, DateTime ModifiedDate, int ModifiedId, string TotalHours,string Date,string OprationHours,string CIPHours,string percentegg)
        {
            try
            {
                pSqlParameter = new SqlParameter[11];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = Id;

                pSqlParameter[1] = new SqlParameter("@BreakdownHours", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = BreakdownHours;

                pSqlParameter[2] = new SqlParameter("@IdleHours", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = IdleHours;

                pSqlParameter[3] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = Remarks;

                pSqlParameter[4] = new SqlParameter("@ModifiedDate", SqlDbType.DateTime);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = ModifiedDate;

                pSqlParameter[5] = new SqlParameter("@ModifiedId", SqlDbType.Int);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = ModifiedId;

                pSqlParameter[6] = new SqlParameter("@Totalhours", SqlDbType.VarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = TotalHours;

                pSqlParameter[7] = new SqlParameter("@Date", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = Date;

                pSqlParameter[8] = new SqlParameter("@OprationHours", SqlDbType.VarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = OprationHours;

                pSqlParameter[9] = new SqlParameter("@CIPHours", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = CIPHours;
               
                pSqlParameter[10] = new SqlParameter("@PercentageEggDB", SqlDbType.VarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = percentegg;

                sSql = "usp_tbl_Evaporation_Plant_Performance_Monthly_Insert";

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
