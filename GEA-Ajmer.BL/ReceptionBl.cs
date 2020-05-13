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
    /// Class Created By : Chintan, 05-10-2015
	/// Summary description for Organisation.
    /// </summary>
	public class ReceptionBl 
	{
		#region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion
		
		
		
		#region Select All Reception Details
        /// <summary>
        /// To Select All data from the Reception table
        /// Created By : Chintan, 05-10-2015
		/// Modified By :
        /// </summary>
		public ApplicationResult  Reception_SelectAll()
        {
			try
            {
				sSql = "usp_tbl_Reception_SelectAll";
                DataTable dtReception  = new DataTable();
                dtReception = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtReception);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
			}
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
		
		
		
		#region Select Reception Details by ReceptionId
        /// <summary>
        /// Select all details of Reception for selected ReceptionId from Reception table
        /// Created By : Chintan, 05-10-2015
		/// Modified By :
        /// </summary>
        public ApplicationResult Reception_Select(int intReceptionId)
		{
            try
            {
                pSqlParameter = new SqlParameter[1];
				
				pSqlParameter[0] = new SqlParameter("@ReceptionId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intReceptionId;

				strStoredProcName = "usp_tbl_Reception_Select";
				
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
		
		
		
		#region Delete Reception Details by ReceptionId
        /// <summary>
        /// To Delete details of Reception for selected ReceptionId from Reception table
        /// Created By : Chintan, 05-10-2015
		/// Modified By :
        /// </summary>
        public ApplicationResult Reception_Delete(int intReceptionId, int intLastModifiedBy, string strLastModifiedDate)
		{
            try
            {
                pSqlParameter = new SqlParameter[3];
				
				pSqlParameter[0] = new SqlParameter("@ReceptionId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intReceptionId;
											
				pSqlParameter[1] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = intLastModifiedBy;
				
				pSqlParameter[2] = new SqlParameter("@LastModifiedDate", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = strLastModifiedDate;

				strStoredProcName = "usp_tbl_Reception_Delete";
				
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
		
		
		
		#region Insert Reception Details
		/// <summary>
        /// To Insert details of Reception in Reception table
        /// Created By : Chintan, 05-10-2015
		/// Modified By :
        /// </summary>
        public ApplicationResult Reception_Insert(ReceptionBo objReceptionBo)
        {
            try
            {
				pSqlParameter = new SqlParameter[5];
                
				
          		pSqlParameter[0] = new SqlParameter("@Name",SqlDbType.NVarChar);
				pSqlParameter[0].Direction = ParameterDirection.Input;
          		pSqlParameter[0].Value = objReceptionBo.Name;
 
				pSqlParameter[1] = new SqlParameter("@Description",SqlDbType.NVarChar);
				pSqlParameter[1].Direction = ParameterDirection.Input;
          		pSqlParameter[1].Value = objReceptionBo.Description;
 
				pSqlParameter[2] = new SqlParameter("@PLCValue",SqlDbType.Real);
				pSqlParameter[2].Direction = ParameterDirection.Input;
          		pSqlParameter[2].Value = objReceptionBo.PLCValue;
 
				pSqlParameter[3] = new SqlParameter("@CreatedBy",SqlDbType.Int);
				pSqlParameter[3].Direction = ParameterDirection.Input;
          		pSqlParameter[3].Value = objReceptionBo.CreatedBy;
 
				pSqlParameter[4] = new SqlParameter("@CreatedDate",SqlDbType.DateTime);
				pSqlParameter[4].Direction = ParameterDirection.Input;
          		pSqlParameter[4].Value = objReceptionBo.CreatedDate;
		
				sSql = "usp_tbl_Reception_Insert";

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
                objReceptionBo = null;
            }
        }
        #endregion
		
		
		
		#region Update Reception Details
		/// <summary>
        /// To Update details of Reception in Reception table
        /// Created By : Chintan, 05-10-2015
		/// Modified By :
        /// </summary>
        public ApplicationResult Reception_Update(ReceptionBo objReceptionBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[6];
                
				
          		pSqlParameter[0] = new SqlParameter("@ReceptionId",SqlDbType.Int);
				pSqlParameter[0].Direction = ParameterDirection.Input;
          		pSqlParameter[0].Value = objReceptionBo.ReceptionId;
 
				pSqlParameter[1] = new SqlParameter("@Name",SqlDbType.NVarChar);
				pSqlParameter[1].Direction = ParameterDirection.Input;
          		pSqlParameter[1].Value = objReceptionBo.Name;
 
				pSqlParameter[2] = new SqlParameter("@Description",SqlDbType.NVarChar);
				pSqlParameter[2].Direction = ParameterDirection.Input;
          		pSqlParameter[2].Value = objReceptionBo.Description;
 
				pSqlParameter[3] = new SqlParameter("@PLCValue",SqlDbType.Real);
				pSqlParameter[3].Direction = ParameterDirection.Input;
          		pSqlParameter[3].Value = objReceptionBo.PLCValue;
 
				pSqlParameter[4] = new SqlParameter("@LastModifiedBy",SqlDbType.Int);
				pSqlParameter[4].Direction = ParameterDirection.Input;
          		pSqlParameter[4].Value = objReceptionBo.LastModifiedBy;
 
				pSqlParameter[5] = new SqlParameter("@LastModifiedDate",SqlDbType.DateTime);
				pSqlParameter[5].Direction = ParameterDirection.Input;
          		pSqlParameter[5].Value = objReceptionBo.LastModifiedDate;
		
				sSql = "usp_tbl_Reception_Update";

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
                objReceptionBo = null;
            }
        }
        #endregion
		
				
		
		#region ValidateName for Reception 
        /// <summary>
        /// Function which validates whether the ReceptionName already exits in Reception table.
        /// Created By : Chintan, 05-10-2015
		/// Modified By :
        /// </summary>
        public ApplicationResult Reception_ValidateName(int intReceptionId,string strName)
		{
            try
            {
				pSqlParameter = new SqlParameter[2];
				
				pSqlParameter[0] = new SqlParameter("@ReceptionId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intReceptionId;
				
				pSqlParameter[1] = new SqlParameter("@Name", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strName;

				strStoredProcName = "usp_tbl_Reception_ValidateName";
				
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


