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
    public class TempratureTrendBL
    {

        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Select Data Of MPL1 Temperature Trend
        /// <summary>
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult GetALl_TemperatureTrendData(DateTime dtFromDate,DateTime dtToDate,string strGraph)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = dtFromDate;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = dtToDate;

                pSqlParameter[2] = new SqlParameter("@Graph", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = strGraph;

                sSql = "usp_TemperatureTrend_GetData";

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

        #region Select Data Of MPL1 Temperature Trend
        /// <summary>
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult GetALl_TemperatureTrendDataReport(DateTime dtFromDate, DateTime dtToDate, int GraphId)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = dtFromDate;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = dtToDate;

                pSqlParameter[2] = new SqlParameter("@GraphId", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = GraphId;

                sSql = "usp_TemperatureTrend_GetData_Report";

                DataTable dtAnnouncement = new DataTable();
                dtAnnouncement = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

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

    }
}
