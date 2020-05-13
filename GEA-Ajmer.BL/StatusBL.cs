using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using GEA_Ajmer.DataAccess;
using GEA_Ajmer.BO;
using GEA_Ajmer.Common;

namespace GEA_Ajmer.BL
{
    /// <summary>
    /// Class Created By : Chintan, 06-10-2015
    /// Summary description for Organisation.
    /// </summary>
    public class StatusBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion



        #region Select All Status Details
        /// <summary>
        /// To Select All data from the Status table
        /// Created By : Chintan, 06-10-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Status_SelectAll()
        {
            try
            {
                sSql = "usp_tbl_Status_SelectAll";
                DataTable dtCuircuit = new DataTable();
                dtCuircuit = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtCuircuit);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        #region Select Status Details by Id
        /// <summary>
        /// Select all details of Cuircuit for selected Id from Status table
        /// Created By : Chintan, 06-10-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Status_Select(int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_tbl_Status_Select";

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



        #region Delete Status Details by Id
        /// <summary>
        /// To Delete details of Cuircuit for selected Id from Status table
        /// Created By : Chintan, 06-10-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Status_Delete(int intId, int intLastModifiedBy, string strLastModifiedDate)
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

                pSqlParameter[2] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = strLastModifiedDate;

                strStoredProcName = "usp_tbl_Status_Delete";

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
                //DataTable dtResult = new DataTable();
                //dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                //ApplicationResult objResults = new ApplicationResult(dtResult);
                //objResults.Status = ApplicationResult.CommonStatusType.Success;
                //return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        #region Insert Status Details
        /// <summary>
        /// To Insert details of Cuircuit in Status table
        /// Created By : Chintan, 06-10-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Status_Insert(StatusBo objCuircuitBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[5];


                pSqlParameter[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objCuircuitBo.Name;

                pSqlParameter[1] = new SqlParameter("@PLCValue", SqlDbType.Real);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objCuircuitBo.PLCValue;

                pSqlParameter[2] = new SqlParameter("@IsDeleted", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objCuircuitBo.IsDeleted;

                pSqlParameter[3] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objCuircuitBo.CreatedBy;

                pSqlParameter[4] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objCuircuitBo.CreatedDate;

                sSql = "usp_tbl_Status_Insert";

                //int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, sSql, pSqlParameter);

                //if (iResult > 0)
                //{
                //    ApplicationResult objResults = new ApplicationResult();
                //    objResults.Status = ApplicationResult.CommonStatusType.Success;
                //    return objResults;
                //}
                //else
                //{
                //    ApplicationResult objResults = new ApplicationResult();
                //    objResults.Status = ApplicationResult.CommonStatusType.Failure;
                //    return objResults;
                //}
                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objCuircuitBo = null;
            }
        }
        #endregion



        #region Update Status Details
        /// <summary>
        /// To Update details of Cuircuit in Status table
        /// Created By : Chintan, 06-10-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Status_Update(StatusBo objCuircuitBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[5];


                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objCuircuitBo.Id;

                pSqlParameter[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objCuircuitBo.Name;

                pSqlParameter[2] = new SqlParameter("@PLCValue", SqlDbType.Real);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objCuircuitBo.PLCValue;

                pSqlParameter[3] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objCuircuitBo.LastModifiedBy;

                pSqlParameter[4] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objCuircuitBo.LastModifiedDate;

                sSql = "usp_tbl_Status_Update";

                //int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, sSql, pSqlParameter);

                //if (iResult > 0)
                //{
                //    ApplicationResult objResults = new ApplicationResult();
                //    objResults.Status = ApplicationResult.CommonStatusType.Success;
                //    return objResults;
                //}
                //else
                //{
                //    ApplicationResult objResults = new ApplicationResult();
                //    objResults.Status = ApplicationResult.CommonStatusType.Failure;
                //    return objResults;
                //}
                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objCuircuitBo = null;
            }
        }
        #endregion

    }
}


