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
    /// Class Created By : NirmalShah, 26-11-2015
	/// Summary description for Organisation.
    /// </summary>
	public class RouteBl 
	{
		#region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion
		
		
		#region Select All Route Details
        /// <summary>
        /// To Select All data from the Routes table
        /// Created By : NirmalShah, 26-11-2015
		/// Modified By :
        /// </summary>
		/// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult  Route_SelectAll()
        {
			try
            {
				sSql = "usp_Routes_SelectAll";
                DataTable dtRoute  = new DataTable();
                dtRoute = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtRoute);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
			}
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Select All Route Details for Lab
        /// <summary>
        /// To Select All data from the Routes table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult Route_SelectAll_LAB()
        {
            try
            {
                sSql = "usp_tbl_Routes_SelectAll_LabReport";
                DataTable dtRoute = new DataTable();
                dtRoute = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtRoute);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
		
		#region Select Route Details by Id
        /// <summary>
        /// Select all details of Route for selected Id from Routes table
        /// Created By : NirmalShah, 26-11-2015
		/// Modified By :
        /// </summary>
        /// <param name="intId"></param>
        /// <returns></returns>
		public ApplicationResult Route_Select(int intId)
		{
            try
            {
                pSqlParameter = new SqlParameter[1];
				
				pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

				strStoredProcName = "usp_tbl_Routes_Select";
				
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
		
		#region Delete Route Details by Id
        /// <summary>
        /// To Delete details of Route for selected Id from Routes table
        /// Created By : NirmalShah, 26-11-2015
		/// Modified By :
        /// </summary>
        /// <param name="intId"></param>
        /// <returns></returns>
        public ApplicationResult Route_Delete(int intId, int intLastModifiedBy, string strLastModifiedDate)
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

				strStoredProcName = "usp_tbl_Routes_Delete";
				
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
		
		#region Insert Route Details
		/// <summary>
        /// To Insert details of Route in Routes table
        /// Created By : NirmalShah, 26-11-2015
		/// Modified By :
        /// </summary>
        /// <param name="objRouteBO"></param>
        /// <returns></returns>
        public ApplicationResult Route_Insert(RouteBo objRouteBO)
        {
            try
            {
				pSqlParameter = new SqlParameter[6];
                
				
          		pSqlParameter[0] = new SqlParameter("@RouteNo",SqlDbType.VarChar);
				pSqlParameter[0].Direction = ParameterDirection.Input;
          		pSqlParameter[0].Value = objRouteBO.RouteNo;
 
				pSqlParameter[1] = new SqlParameter("@RouteName",SqlDbType.NVarChar);
				pSqlParameter[1].Direction = ParameterDirection.Input;
          		pSqlParameter[1].Value = objRouteBO.RouteName;
 
				pSqlParameter[2] = new SqlParameter("@PLCValue",SqlDbType.Real);
				pSqlParameter[2].Direction = ParameterDirection.Input;
          		pSqlParameter[2].Value = objRouteBO.PLCValue;
 
				pSqlParameter[3] = new SqlParameter("@Description",SqlDbType.NVarChar);
				pSqlParameter[3].Direction = ParameterDirection.Input;
          		pSqlParameter[3].Value = objRouteBO.Description;
 
				pSqlParameter[4] = new SqlParameter("@CreatedBy",SqlDbType.Int);
				pSqlParameter[4].Direction = ParameterDirection.Input;
          		pSqlParameter[4].Value = objRouteBO.CreatedBy;
 
				pSqlParameter[5] = new SqlParameter("@CreatedDate",SqlDbType.DateTime);
				pSqlParameter[5].Direction = ParameterDirection.Input;
          		pSqlParameter[5].Value = objRouteBO.CreatedDate;


                sSql = "usp_tbl_Routes_Insert";
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
                objRouteBO = null;
            }
        }
        #endregion
		
		#region Update Route Details
		/// <summary>
        /// To Update details of Route in Routes table
        /// Created By : NirmalShah, 26-11-2015
		/// Modified By :
        /// </summary>
        /// <param name="objRouteBO"></param>
        /// <returns></returns>
        public ApplicationResult Route_Update(RouteBo objRouteBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[7];
                
				
          		pSqlParameter[0] = new SqlParameter("@Id",SqlDbType.Int);
				pSqlParameter[0].Direction = ParameterDirection.Input;
          		pSqlParameter[0].Value = objRouteBO.Id;
 
				pSqlParameter[1] = new SqlParameter("@RouteNo",SqlDbType.VarChar);
				pSqlParameter[1].Direction = ParameterDirection.Input;
          		pSqlParameter[1].Value = objRouteBO.RouteNo;
 
				pSqlParameter[2] = new SqlParameter("@RouteName",SqlDbType.NVarChar);
				pSqlParameter[2].Direction = ParameterDirection.Input;
          		pSqlParameter[2].Value = objRouteBO.RouteName;
 
				pSqlParameter[3] = new SqlParameter("@PLCValue",SqlDbType.Real);
				pSqlParameter[3].Direction = ParameterDirection.Input;
          		pSqlParameter[3].Value = objRouteBO.PLCValue;
 
				pSqlParameter[4] = new SqlParameter("@Description",SqlDbType.NVarChar);
				pSqlParameter[4].Direction = ParameterDirection.Input;
          		pSqlParameter[4].Value = objRouteBO.Description;
 
				pSqlParameter[5] = new SqlParameter("@LastModifiedBy",SqlDbType.Int);
				pSqlParameter[5].Direction = ParameterDirection.Input;
          		pSqlParameter[5].Value = objRouteBO.LastModifiedBy;
 
				pSqlParameter[6] = new SqlParameter("@LastModifiedDate",SqlDbType.DateTime);
				pSqlParameter[6].Direction = ParameterDirection.Input;
          		pSqlParameter[6].Value = objRouteBO.LastModifiedDate;

		
				sSql = "usp_tbl_Routes_Update";
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
                objRouteBO = null;
            }
        }
        #endregion
		
		
		
		
		#region Select Route Details by RouteName
        /// <summary>
        /// Select all details of Route for selected RouteName from Routes table
        /// Created By : NirmalShah, 26-11-2015
		/// Modified By :
        /// </summary>
        /// <param name="RouteName"></param>
        /// <returns></returns>
		public ApplicationResult Route_Select_byRouteName(string strRouteName)
		{
            try
            {
                pSqlParameter = new SqlParameter[1];
				
				pSqlParameter[0] = new SqlParameter("@RouteName", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = strRouteName;

				strStoredProcName = "usp_Routes_Select_ByRoute";
				
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
		
		
		#region ValidateName for Route 
        /// <summary>
        /// Function which validates whether the RouteName already exits in Routes table.
        /// Created By : NirmalShah, 26-11-2015
		/// Modified By :
        /// </summary>
        /// <param name="strRouteName"></param>
        /// <returns></returns>
		public ApplicationResult Route_ValidateName(string strRouteName)
		{
            try
            {
                pSqlParameter = new SqlParameter[1];
				
				pSqlParameter[0] = new SqlParameter("@RouteName", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = strRouteName;

				strStoredProcName = "usp_Routes_Validate_RouteName";
				
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
