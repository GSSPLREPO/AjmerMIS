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
    public class TransferDispatchBl
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Select Silo for Transfer and Dispatch Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Silo_Select(int intParam)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Param", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intParam;

                strStoredProcName = "usp_Silo_Selection";

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

        #region Transfer Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Transfer_Report(DateTime FromDatetime, DateTime ToDatetime, int ShiftId, double LineNo, double SRC, double Dest)
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

                pSqlParameter[3] = new SqlParameter("@LineNo", SqlDbType.Real);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = LineNo;

                pSqlParameter[4] = new SqlParameter("@PSRC", SqlDbType.Real);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = SRC;

                pSqlParameter[5] = new SqlParameter("@PDEST", SqlDbType.Real);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = Dest;


                strStoredProcName = "usp_rpt_TransferReport";

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

        #region Select Reception_PLC Details by Id
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Dispatch_Report(DateTime FromDatetime, DateTime ToDatetime, int ShiftId, int TankerId, double LineNo, double SRC)
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

                pSqlParameter[3] = new SqlParameter("@PTankerId", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = TankerId;

                pSqlParameter[4] = new SqlParameter("@LineNo", SqlDbType.Real);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = LineNo;

                pSqlParameter[5] = new SqlParameter("@PSRC", SqlDbType.Real);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = SRC;


                strStoredProcName = "usp_rpt_DispatchReport";

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

        #region Select All Transfer_Dispatch_PLC Details
        /// <summary>
        /// To Select All data from the Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Transfer_Dispatch_PLC_SelectAll()
        {
            try
            {
                sSql = "usp_tbl_Transfer_Dispatch_PLC_SelectAll_1";
                DataTable dtReception_PLC = new DataTable();
                dtReception_PLC = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtReception_PLC);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select All Transfer 
        /// <summary>
        /// To Select All data from the Evap Log
        /// Created By : pavan, 07-07-2017
        /// Modified By :
        /// </summary>
        public ApplicationResult Transfer_SelectAll(DateTime FromDate, DateTime ToDate,int Source,int Destination)
        {
            try
            {
                pSqlParameter = new SqlParameter[4];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDate;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDate;

                pSqlParameter[2] = new SqlParameter("@Source", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = Source;

                pSqlParameter[3] = new SqlParameter("@Destination", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = Destination;

                sSql = "usp_rpt_TransferReport_Taloja";
                DataTable dtMilkReception = new DataTable();
                dtMilkReception = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtMilkReception);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select Reception_PLC Details by Id
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Dispatch_SelectAll(DateTime FromDatetime, DateTime ToDatetime,int intSiloId)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDatetime;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDatetime;

                pSqlParameter[2] = new SqlParameter("@SiloId", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = intSiloId;

                strStoredProcName = "usp_rpt_DispatchReport_Taloja";

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

        #region Select All Transfer_Dispatch_PLC Details
        /// <summary>
        /// To Select All data from the Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Transfer_Dispatch_PLC_SelectAll(int ReceptionLineId, DateTime FromDate, DateTime ToDate)
        {
            try
            {

                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@ReceptionLineId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = ReceptionLineId;

                pSqlParameter[1] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = FromDate;

                pSqlParameter[2] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = ToDate;

                sSql = "usp_tbl_Transfer_Dispatch_PLC_SelectAll_1";
                DataTable dtReception_PLC = new DataTable();
                dtReception_PLC = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtReception_PLC);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select Silo for Transfer and Dispatch Report
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Silo_Select_Dispatch(int intParam)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@LineNo", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intParam;

                strStoredProcName = "usp_tbl_Silo_Selection_Dispatch";

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

        #region Select Reception_PLC Details by Id
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Dispatch_SelectAll(DateTime FromDatetime, DateTime ToDatetime, int ShiftId, int TankerId, double LineNo, double Dest)
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

                pSqlParameter[3] = new SqlParameter("@PTankerId", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = TankerId;

                pSqlParameter[4] = new SqlParameter("@LineNo", SqlDbType.Real);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = LineNo;

                pSqlParameter[5] = new SqlParameter("@PSRC", SqlDbType.Real);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = Dest;

                strStoredProcName = "usp_rpt_DispatchReport_Taloja";

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

        #region Bind Transfer Silo
        public ApplicationResult TransferSilo()
        {
            try
            {
                strStoredProcName = "uap_tbl_Transfer_Select_Source_and_Destination";
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
