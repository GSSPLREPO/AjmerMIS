using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GEA_Ajmer.BO;
using GEA_Ajmer.Common;
using GEA_Ajmer.DataAccess;

namespace GEA_Ajmer.BL
{
    public class FaultBl
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion



        #region Select All Fault Details
        /// <summary>
        /// To Select All data from the FaultTag table
        /// Created By : VIshal, 11/21/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Fault_SelectAll()
        {
            try
            {
                sSql = "usp_tbl_FaultTag_SelectAll";
                DataTable dtFault = new DataTable();
                dtFault = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtFault);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        #region Select Fault Details by Id
        /// <summary>
        /// Select all details of Fault for selected Id from FaultTag table
        /// Created By : VIshal, 11/21/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Fault_Select(int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_tbl_FaultTag_Select";

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



        #region Delete Fault Details by Id
        /// <summary>
        /// To Delete details of Fault for selected Id from FaultTag table
        /// Created By : VIshal, 11/21/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Fault_Delete(int intId, int intLastModifiedBy, string strLastModifiedDate)
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

                strStoredProcName = "usp_tbl_FaultTag_Delete";

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



        #region Insert Fault Details
        /// <summary>
        /// To Insert details of Fault in FaultTag table
        /// Created By : VIshal, 11/21/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Fault_Insert(FaultBo objFaultBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[5];


                pSqlParameter[0] = new SqlParameter("@TagNo", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objFaultBo.TagNo;

                pSqlParameter[1] = new SqlParameter("@Description", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objFaultBo.Description;

                pSqlParameter[2] = new SqlParameter("@Type", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objFaultBo.Type;

                pSqlParameter[3] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objFaultBo.CreatedBy;

                pSqlParameter[4] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objFaultBo.CreatedDate;


                sSql = "usp_tbl_FaultTag_Insert";
                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objFaultBo = null;
            }
        }
        #endregion



        #region Update Fault Details
        /// <summary>
        /// To Update details of Fault in FaultTag table
        /// Created By : VIshal, 11/21/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Fault_Update(FaultBo objFaultBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[6];


                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objFaultBo.Id;

                pSqlParameter[1] = new SqlParameter("@TagNo", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objFaultBo.TagNo;

                pSqlParameter[2] = new SqlParameter("@Description", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objFaultBo.Description;

                pSqlParameter[3] = new SqlParameter("@Type", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objFaultBo.Type;

                pSqlParameter[4] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objFaultBo.LastModifiedBy;

                pSqlParameter[5] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objFaultBo.LastModifiedDate;


                sSql = "usp_tbl_FaultTag_Update";
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
                objFaultBo = null;
            }
        }
        #endregion



        #region ValidateName for Fault
        /// <summary>
        /// Function which validates whether the FaultName already exits in FaultTag table.
        /// Created By : VIshal, 11/21/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Fault_ValidateName(int intFaultId, string strName)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FaultId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intFaultId;

                pSqlParameter[1] = new SqlParameter("@Name", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strName;

                strStoredProcName = "usp_tbl_FaultTag_ValidateName";

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
