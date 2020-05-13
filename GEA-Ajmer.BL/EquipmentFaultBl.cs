using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GEA_Ajmer.Common;
using GEA_Ajmer.DataAccess;
using GEA_Ajmer.BO;

namespace GEA_Ajmer.BL
{
    public class EquipmentFaultBl
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Select All Tags Name
        /// <summary>
        /// Report Equipment Fault Summary Report
        /// Created By : Chintan, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Tag_SelectAll()
        {
            try
            {
                strStoredProcName = "usp_Tag_SelectAll";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, null);
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

        #region Report Equipment Fault Summary Report
        /// <summary>
        /// Report Equipment Fault Summary Report
        /// Created By : Chintan, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult EquipmentFaultSummaryReport(string strFromDate, string strToDate, string strTagNo)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = strFromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strToDate;

                pSqlParameter[2] = new SqlParameter("@TagNo", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = strTagNo;

                strStoredProcName = "usp_rpt_EquipmentFaultSummaryReport";

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

        #region Report Equipment Fault Count Report
        /// <summary>
        /// Report Equipment Fault Count Report
        /// Created By : Chintan, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult EquipmentFaultCountReport(string strFromDate, string strToDate, string strTagNo)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = strFromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strToDate;

                pSqlParameter[2] = new SqlParameter("@TagNo", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = strTagNo;

                strStoredProcName = "usp_rpt_EquipmentFaultCountReport";

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
    }
}
