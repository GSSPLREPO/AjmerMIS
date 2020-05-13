using GEA_Ajmer.BO;
using GEA_Ajmer.Common;
using GEA_Ajmer.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GEA_Ajmer.BL
{
   public class ProductDispatchBl
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Select All ProductDispatch Details
        /// <summary>
        /// To Select All data from the ProductDispatch table
        /// Created By : pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult ProductDispatch_SelectAll()
        {
            try
            {
                sSql = "usp_tbl_ProductDispatch_SelectAll";
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


        #region Select ProductDispatch Details by Id
        /// <summary>
        /// Select all details of ProductDispatch for selected Id from ProductDispatch table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult ProductDispatch_Select(int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_tbl_ProductDispatch_Select";

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


        #region Delete ProductDispatch Details by Id
        /// <summary>
        /// To Delete details of ProductDispatch for selected Id from ProductDispatch table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult ProductDispatch_Delete(int intId, int intLastModifiedBy, string strLastModifiedDate)
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

                strStoredProcName = "usp_tbl_ProductDispatch_Delete";

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


        #region Insert ProductDispatch Details
        /// <summary>
        /// To Insert details of Fault in FaultTag table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult ProductDispatch_Insert(ProductDispatchBo objProductDispatchBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[17];

                pSqlParameter[0] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objProductDispatchBO.Date;

                pSqlParameter[1] = new SqlParameter("@DeliveryChallan", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objProductDispatchBO.DeliveryChallan;

                pSqlParameter[2] = new SqlParameter("@VehicleNo", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objProductDispatchBO.VehicleNo;

                pSqlParameter[3] = new SqlParameter("@BatchNo", SqlDbType.VarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objProductDispatchBO.BatchNo;

                pSqlParameter[4] = new SqlParameter("@BagNos", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objProductDispatchBO.BagNos;

                pSqlParameter[5] = new SqlParameter("@ProductType", SqlDbType.VarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objProductDispatchBO.ProductType;

                pSqlParameter[6] = new SqlParameter("@FAT", SqlDbType.Float);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objProductDispatchBO.FAT;

                pSqlParameter[7] = new SqlParameter("@Moisture", SqlDbType.Float);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objProductDispatchBO.Moisture;

                pSqlParameter[8] = new SqlParameter("@QualityParamter", SqlDbType.VarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objProductDispatchBO.QualityParamter;

                pSqlParameter[9] = new SqlParameter("@Acidity", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objProductDispatchBO.Acidity;

                pSqlParameter[10] = new SqlParameter("@QtyDispatch", SqlDbType.Float);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objProductDispatchBO.QtyDispatch;

                pSqlParameter[11] = new SqlParameter("@DespatchedTo", SqlDbType.VarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objProductDispatchBO.DespatchedTo;

                pSqlParameter[12] = new SqlParameter("@UserId", SqlDbType.Int);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objProductDispatchBO.UserId;

                pSqlParameter[13] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objProductDispatchBO.CreatedDate;

                pSqlParameter[14] = new SqlParameter("@IsDeleted", SqlDbType.Int);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objProductDispatchBO.IsDeleted;

                pSqlParameter[15] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objProductDispatchBO.CreatedBy;

                pSqlParameter[16] = new SqlParameter("@Time", SqlDbType.DateTime);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objProductDispatchBO.Time;

                sSql = "usp_tbl_ProductDispatch_Insert";
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
                objProductDispatchBO = null;
            }
        }
        #endregion


        #region Update ProductDispatch Details
        /// <summary>
        /// To Update details of ProductDispatch in ProductDispatch table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult ProductDispatch_Update(ProductDispatchBo objProductDispatchBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[17];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objProductDispatchBO.Id;

                pSqlParameter[1] = new SqlParameter("@DeliveryChallan", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objProductDispatchBO.DeliveryChallan;

                pSqlParameter[2] = new SqlParameter("@VehicleNo", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objProductDispatchBO.VehicleNo;

                pSqlParameter[3] = new SqlParameter("@BatchNo", SqlDbType.VarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objProductDispatchBO.BatchNo;

                pSqlParameter[4] = new SqlParameter("@BagNos", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objProductDispatchBO.BagNos;

                pSqlParameter[5] = new SqlParameter("@ProductType", SqlDbType.VarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objProductDispatchBO.ProductType;

                pSqlParameter[6] = new SqlParameter("@FAT", SqlDbType.Float);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objProductDispatchBO.FAT;

                pSqlParameter[7] = new SqlParameter("@Moisture", SqlDbType.Float);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objProductDispatchBO.Moisture;

                pSqlParameter[8] = new SqlParameter("@QualityParamter", SqlDbType.VarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objProductDispatchBO.QualityParamter;

                pSqlParameter[9] = new SqlParameter("@Acidity", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objProductDispatchBO.Acidity;

                pSqlParameter[10] = new SqlParameter("@QtyDispatch", SqlDbType.Float);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objProductDispatchBO.QtyDispatch;

                pSqlParameter[11] = new SqlParameter("@DespatchedTo", SqlDbType.VarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objProductDispatchBO.DespatchedTo;

                pSqlParameter[12] = new SqlParameter("@UserId", SqlDbType.Int);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objProductDispatchBO.UserId;

                pSqlParameter[13] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objProductDispatchBO.Date;

                pSqlParameter[14] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objProductDispatchBO.LastModifiedDate;

                pSqlParameter[15] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objProductDispatchBO.LastModifiedBy;

                pSqlParameter[16] = new SqlParameter("@Time", SqlDbType.DateTime);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objProductDispatchBO.Time;

                sSql = "usp_tbl_ProductDispatch_Update";
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
                objProductDispatchBO = null;
            }
        }
        #endregion
    }
}
