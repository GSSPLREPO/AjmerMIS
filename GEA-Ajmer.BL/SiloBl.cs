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
    public class SiloBl
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion



        #region Select All SILO Details
        /// <summary>
        /// To Select All data from the SILO table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Silo_SelectAll()
        {
            try
            {
                sSql = "usp_tbl_SILO_SelectAll";
                DataTable dtSILO = new DataTable();
                dtSILO = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtSILO);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select All SILO Details
        /// <summary>
        /// To Select All data from the SILO table
        /// Created By : Vishal, 9/24/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Silo_SelectAll_MilkAnalysis()
        {
            try
            {
                sSql = "usp_tbl_SILO_SelectAll_MilkAnalysis";
                DataTable dtSILO = new DataTable();
                dtSILO = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtSILO);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        #region Select SILO Details by SILOID
        /// <summary>
        /// Select all details of SILO for selected SILOID from SILO table
        /// Created By : Chintan, 06-10-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Silo_Select(int intSILOID)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@SILOID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intSILOID;

                strStoredProcName = "usp_tbl_SILO_Select";

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



        #region Delete SILO Details by SILOID
        /// <summary>
        /// To Delete details of SILO for selected SILOID from SILO table
        /// Created By : Chintan, 06-10-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Silo_Delete(int intSILOID, int intLastModifiedBy, string strLastModifiedDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@SILOID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intSILOID;

                pSqlParameter[1] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = intLastModifiedBy;

                pSqlParameter[2] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = strLastModifiedDate;

                strStoredProcName = "usp_tbl_SILO_Delete";

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



        #region Insert SILO Details
        /// <summary>
        /// To Insert details of SILO in SILO table
        /// Created By : Chintan, 06-10-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Silo_Insert(SiloBo objSILOBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[5];


                pSqlParameter[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objSILOBo.Name;

                pSqlParameter[1] = new SqlParameter("@PLCValue", SqlDbType.Real);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objSILOBo.PLCValue;

                pSqlParameter[2] = new SqlParameter("@IsDeleted", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objSILOBo.IsDeleted;

                pSqlParameter[3] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objSILOBo.CreatedBy;

                pSqlParameter[4] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objSILOBo.CreatedDate;

                sSql = "usp_tbl_SILO_Insert";
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
                objSILOBo = null;
            }
        }
        #endregion



        #region Update SILO Details
        /// <summary>
        /// To Update details of SILO in SILO table
        /// Created By : Chintan, 06-10-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Silo_Update(SiloBo objSILOBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[5];


                pSqlParameter[0] = new SqlParameter("@SILOID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objSILOBo.SILOID;

                pSqlParameter[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objSILOBo.Name;

                pSqlParameter[2] = new SqlParameter("@PLCValue", SqlDbType.Real);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objSILOBo.PLCValue;

                pSqlParameter[3] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objSILOBo.LastModifiedBy;

                pSqlParameter[4] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objSILOBo.LastModifiedDate;
                
                sSql = "usp_tbl_SILO_Update";

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
                objSILOBo = null;
            }
        }
        #endregion
		
    }
}
