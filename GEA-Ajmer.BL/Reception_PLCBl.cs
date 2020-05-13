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
    public class Reception_PLCBl
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion



        #region Select All Reception_PLC Details
        /// <summary>
        /// To Select All data from the Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Reception_PLC_SelectAll(int ReceptionLineId, DateTime FromDate, DateTime ToDate)
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

                sSql = "usp_tbl_Reception_PLC_SelectAll";

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



        #region Select Reception_PLC Details by Id
        /// <summary>
        /// Select all details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Reception_PLC_Select(DateTime FromDatetime, DateTime ToDatetime, int ShiftId, int TankerId, double LineNo, double Dest)
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

                pSqlParameter[5] = new SqlParameter("@PDest", SqlDbType.Real);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = Dest;


                strStoredProcName = "usp_rpt_MilkWeighmentReport";

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



        #region Delete Reception_PLC Details by Id
        /// <summary>
        /// To Delete details of Reception_PLC for selected Id from Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Reception_PLC_Delete(int intId, int intLastModifiedBy, string strLastModifiedDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                pSqlParameter[1] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = intLastModifiedBy;

                pSqlParameter[2] = new SqlParameter("@LastModifiedDate", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = strLastModifiedDate;

                strStoredProcName = "usp_tbl_Reception_PLC_Delete";

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



        #region Insert Reception_PLC Details
        /// <summary>
        /// To Insert details of Reception_PLC in Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        //public ApplicationResult Reception_PLC_Insert(Reception_PLCBo objReception_PLCBo)
        //{
        //    try
        //    {
        //        pSqlParameter = new SqlParameter[10];


        //        pSqlParameter[0] = new SqlParameter("@DateTime", SqlDbType.DateTime);
        //        pSqlParameter[0].Direction = ParameterDirection.Input;
        //        pSqlParameter[0].Value = objReception_PLCBo.DateTime;

        //        pSqlParameter[1] = new SqlParameter("@Ch_Temp", SqlDbType.Real);
        //        pSqlParameter[1].Direction = ParameterDirection.Input;
        //        pSqlParameter[1].Value = objReception_PLCBo.Ch_Temp;

        //        pSqlParameter[2] = new SqlParameter("@DEST", SqlDbType.Real);
        //        pSqlParameter[2].Direction = ParameterDirection.Input;
        //        pSqlParameter[2].Value = objReception_PLCBo.DEST;

        //        pSqlParameter[3] = new SqlParameter("@Line_No", SqlDbType.Real);
        //        pSqlParameter[3].Direction = ParameterDirection.Input;
        //        pSqlParameter[3].Value = objReception_PLCBo.Line_No;

        //        pSqlParameter[4] = new SqlParameter("@Product_Type", SqlDbType.Real);
        //        pSqlParameter[4].Direction = ParameterDirection.Input;
        //        pSqlParameter[4].Value = objReception_PLCBo.Product_Type;

        //        pSqlParameter[5] = new SqlParameter("@SRC", SqlDbType.Real);
        //        pSqlParameter[5].Direction = ParameterDirection.Input;
        //        pSqlParameter[5].Value = objReception_PLCBo.SRC;

        //        pSqlParameter[6] = new SqlParameter("@Start_Trig", SqlDbType.Bit);
        //        pSqlParameter[6].Direction = ParameterDirection.Input;
        //        pSqlParameter[6].Value = objReception_PLCBo.Start_Trig;

        //        pSqlParameter[7] = new SqlParameter("@Tanker_ID", SqlDbType.Int);
        //        pSqlParameter[7].Direction = ParameterDirection.Input;
        //        pSqlParameter[7].Value = objReception_PLCBo.Tanker_ID;

        //        pSqlParameter[8] = new SqlParameter("@Transfer_Qty", SqlDbType.Real);
        //        pSqlParameter[8].Direction = ParameterDirection.Input;
        //        pSqlParameter[8].Value = objReception_PLCBo.Transfer_Qty;

        //        pSqlParameter[9] = new SqlParameter("@WB_Qty", SqlDbType.Real);
        //        pSqlParameter[9].Direction = ParameterDirection.Input;
        //        pSqlParameter[9].Value = objReception_PLCBo.WB_Qty;


        //        sSql = "usp_tbl_Reception_PLC_Insert";
        //        int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, sSql, pSqlParameter);

        //        if (iResult > 0)
        //        {
        //            ApplicationResult objResults = new ApplicationResult();
        //            objResults.Status = ApplicationResult.CommonStatusType.Success;
        //            return objResults;
        //        }
        //        else
        //        {
        //            ApplicationResult objResults = new ApplicationResult();
        //            objResults.Status = ApplicationResult.CommonStatusType.Failure;
        //            return objResults;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        objReception_PLCBo = null;
        //    }
        //}
        #endregion



        #region Update Reception_PLC Details
        /// <summary>
        /// To Update details of Reception_PLC in Reception_PLC table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        //public ApplicationResult Reception_PLC_Update(Reception_PLCBo objReception_PLCBo)
        //{
        //    try
        //    {
        //        pSqlParameter = new SqlParameter[11];


        //        pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
        //        pSqlParameter[0].Direction = ParameterDirection.Input;
        //        pSqlParameter[0].Value = objReception_PLCBo.Id;

        //        pSqlParameter[1] = new SqlParameter("@DateTime", SqlDbType.DateTime);
        //        pSqlParameter[1].Direction = ParameterDirection.Input;
        //        pSqlParameter[1].Value = objReception_PLCBo.DateTime;

        //        pSqlParameter[2] = new SqlParameter("@Ch_Temp", SqlDbType.Real);
        //        pSqlParameter[2].Direction = ParameterDirection.Input;
        //        pSqlParameter[2].Value = objReception_PLCBo.Ch_Temp;

        //        pSqlParameter[3] = new SqlParameter("@DEST", SqlDbType.Real);
        //        pSqlParameter[3].Direction = ParameterDirection.Input;
        //        pSqlParameter[3].Value = objReception_PLCBo.DEST;

        //        pSqlParameter[4] = new SqlParameter("@Line_No", SqlDbType.Real);
        //        pSqlParameter[4].Direction = ParameterDirection.Input;
        //        pSqlParameter[4].Value = objReception_PLCBo.Line_No;

        //        pSqlParameter[5] = new SqlParameter("@Product_Type", SqlDbType.Real);
        //        pSqlParameter[5].Direction = ParameterDirection.Input;
        //        pSqlParameter[5].Value = objReception_PLCBo.Product_Type;

        //        pSqlParameter[6] = new SqlParameter("@SRC", SqlDbType.Real);
        //        pSqlParameter[6].Direction = ParameterDirection.Input;
        //        pSqlParameter[6].Value = objReception_PLCBo.SRC;

        //        pSqlParameter[7] = new SqlParameter("@Start_Trig", SqlDbType.Bit);
        //        pSqlParameter[7].Direction = ParameterDirection.Input;
        //        pSqlParameter[7].Value = objReception_PLCBo.Start_Trig;

        //        pSqlParameter[8] = new SqlParameter("@Tanker_ID", SqlDbType.Int);
        //        pSqlParameter[8].Direction = ParameterDirection.Input;
        //        pSqlParameter[8].Value = objReception_PLCBo.Tanker_ID;

        //        pSqlParameter[9] = new SqlParameter("@Transfer_Qty", SqlDbType.Real);
        //        pSqlParameter[9].Direction = ParameterDirection.Input;
        //        pSqlParameter[9].Value = objReception_PLCBo.Transfer_Qty;

        //        pSqlParameter[10] = new SqlParameter("@WB_Qty", SqlDbType.Real);
        //        pSqlParameter[10].Direction = ParameterDirection.Input;
        //        pSqlParameter[10].Value = objReception_PLCBo.WB_Qty;


        //        sSql = "usp_tbl_Reception_PLC_Update";

        //        int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, sSql, pSqlParameter);

        //        if (iResult > 0)
        //        {
        //            ApplicationResult objResults = new ApplicationResult();
        //            objResults.Status = ApplicationResult.CommonStatusType.Success;
        //            return objResults;
        //        }
        //        else
        //        {
        //            ApplicationResult objResults = new ApplicationResult();
        //            objResults.Status = ApplicationResult.CommonStatusType.Failure;
        //            return objResults;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        objReception_PLCBo = null;
        //    }
        //}
        #endregion



        #region ValidateName for Reception_PLC
        /// <summary>
        /// Function which validates whether the Reception_PLCName already exits in Reception_PLC table.
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Reception_PLC_ValidateName(int intReception_PLCId, string strName)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@Reception_PLCId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intReception_PLCId;

                pSqlParameter[1] = new SqlParameter("@Name", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strName;

                strStoredProcName = "usp_tbl_Reception_PLC_ValidateName";

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
