using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEA_Ajmer.BO;
using GEA_Ajmer.Common;
using GEA_Ajmer.DataAccess;

namespace GEA_Ajmer.BL
{
    /// <summary>
    /// Class Created By : Vishal, 11/16/2015
    /// Summary description for Organisation.
    /// </summary>
    public class ProductBl
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion



        #region Select All Product Details
        /// <summary>
        /// To Select All data from the Product table
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Product_SelectAll()
        {
            try
            {
                sSql = "usp_tbl_Product_SelectAll";
                DataTable dtProduct = new DataTable();
                dtProduct = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtProduct);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select All Product Details for Lab Report
        /// <summary>
        /// To Select All data from the Product table
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Product_SelectAll_LAB()
        {
            try
            {
                sSql = "usp_tbl_Product_SelectAll_LabReport";
                DataTable dtProduct = new DataTable();
                dtProduct = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtProduct);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select All Product Details ProductGroupId
        /// <summary>
        /// To Select All data from the Product table
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Product_SelectAll_ByProductGroupId(int intProductGroupId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@ProductGroupId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intProductGroupId;

                sSql = "usp_tbl_Product_SelectAll_ByProductGroupId";
                DataTable dtProduct = new DataTable();
                dtProduct = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtProduct);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Select Product Details by ProductId
        /// <summary>
        /// Select all details of Product for selected ProductId from Product table
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Product_Select(int intProductId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@ProductId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intProductId;

                strStoredProcName = "usp_tbl_Product_Select";

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



        #region Delete Product Details by ProductId
        /// <summary>
        /// To Delete details of Product for selected ProductId from Product table
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Product_Delete(int intProductId, int intLastModifiedBy, string strLastModifiedDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@ProductId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intProductId;

                pSqlParameter[1] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = intLastModifiedBy;

                pSqlParameter[2] = new SqlParameter("@LastModifiedDate", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = strLastModifiedDate;

                strStoredProcName = "usp_tbl_Product_Delete";

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



        #region Insert Product Details
        /// <summary>
        /// To Insert details of Product in Product table
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Product_Insert(ProductBo objProductBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[5];

                pSqlParameter[0] = new SqlParameter("@ProductName", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objProductBo.ProductName;

                pSqlParameter[1] = new SqlParameter("@IdentifierCode", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objProductBo.IdentifierCode;

                pSqlParameter[2] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objProductBo.CreatedBy;

                pSqlParameter[3] = new SqlParameter("@CreatedDate", SqlDbType.VarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objProductBo.CreatedDate;

                pSqlParameter[4] = new SqlParameter("@IsDeleted", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objProductBo.IsDeleted;


                sSql = "usp_tbl_Product_Insert";
                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, sSql, pSqlParameter);

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
            finally
            {
                objProductBo = null;
            }
        }
        #endregion



        #region Update Product Details
        /// <summary>
        /// To Update details of Product in Product table
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Product_Update(ProductBo objProductBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[6];


                pSqlParameter[0] = new SqlParameter("@ProductId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objProductBo.ProductId;

                pSqlParameter[1] = new SqlParameter("@ProductName", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objProductBo.ProductName;

                pSqlParameter[2] = new SqlParameter("@IdentifierCode", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objProductBo.IdentifierCode;

                pSqlParameter[3] = new SqlParameter("@LastModifiedBy", SqlDbType.VarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objProductBo.LastModifiedBy;

                pSqlParameter[4] = new SqlParameter("@LastModifiedDate", SqlDbType.VarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objProductBo.LastModifiedDate;

                pSqlParameter[5] = new SqlParameter("@IsDeleted", SqlDbType.Int);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objProductBo.IsDeleted;


                sSql = "usp_tbl_Product_Update";

                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, sSql, pSqlParameter);

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
            finally
            {
                objProductBo = null;
            }
        }
        #endregion



        #region ValidateName for Product
        /// <summary>
        /// Function which validates whether the ProductName already exits in Product table.
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Product_ValidateName(int intProductId, string strName)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@ProductId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intProductId;

                pSqlParameter[1] = new SqlParameter("@ProductName", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strName;

                strStoredProcName = "usp_tbl_Product_ValidateName";

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

        #region ValidateName for IdentifierCode
        /// <summary>
        /// Function which validates whether the ProductName already exits in Product table.
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Product_ValidateIdentifierCode(int intProductId, string strName)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@ProductId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intProductId;

                pSqlParameter[1] = new SqlParameter("@IdentifierCode", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strName;

                strStoredProcName = "usp_tbl_Product_ValidateIdentifierCode";

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
