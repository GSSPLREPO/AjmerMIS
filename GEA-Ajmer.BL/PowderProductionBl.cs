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
    public class PowderProductionBl
    {

        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Select All PowderProduction Details
        /// <summary>
        /// To Select All data from the PowderProduction table
        /// Created By : pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult PowderProduction_SelectAll()
        {
            try
            {
                sSql = "usp_tbl_PowderProduction_SelectAll";
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


        #region Select PowderProduction Details by Id
        /// <summary>
        /// Select all details of PowderProduction for selected Id from PowderProduction table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult PowderProduction_Select(int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_tbl_PowderProduction_Select";

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


        #region Delete PowderProduction Details by Id
        /// <summary>
        /// To Delete details of PowderProduction for selected Id from PowderProduction table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult PowderProduction_Delete(int intId, int intLastModifiedBy, string strLastModifiedDate)
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

                strStoredProcName = "usp_tbl_PowderProduction_Delete";

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


        #region Insert PowderProduction Details
        /// <summary>
        /// To Insert details of Fault in FaultTag table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult PowderProduction_Insert(PowderProductionBo objPowderProductionBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[12];

                pSqlParameter[0] = new SqlParameter("@Date", SqlDbType.Date);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objPowderProductionBO.Date;

                pSqlParameter[1] = new SqlParameter("@ProductType", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objPowderProductionBO.ProductType;

                pSqlParameter[2] = new SqlParameter("@BatchNo", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objPowderProductionBO.BatchNo;

                pSqlParameter[3] = new SqlParameter("@ProductionTime", SqlDbType.DateTime);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objPowderProductionBO.ProductionTime;

                pSqlParameter[4] = new SqlParameter("@PackQuantity", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objPowderProductionBO.PackQuantity;

                pSqlParameter[5] = new SqlParameter("@TypeOfPacking", SqlDbType.VarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objPowderProductionBO.TypePacking;

                pSqlParameter[6] = new SqlParameter("@NoOfUnits", SqlDbType.Int);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objPowderProductionBO.NoOfUnits;

                pSqlParameter[7] = new SqlParameter("@QualityParameter", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objPowderProductionBO.QualityParameter;

                pSqlParameter[8] = new SqlParameter("@UserId", SqlDbType.Int);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objPowderProductionBO.UserId;

                pSqlParameter[9] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objPowderProductionBO.Remark;

                pSqlParameter[10] = new SqlParameter("@CreatedDate", SqlDbType.Int);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objPowderProductionBO.IsDeleted;

                pSqlParameter[11] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objPowderProductionBO.CreatedBy;

                sSql = "usp_tbl_PowderProduction_Insert";

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
                objPowderProductionBO = null;
            }
        }
        #endregion


        #region Update PowderProduction Details
        /// <summary>
        /// To Update details of PowderProduction in PowderProduction table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult PowderProduction_Update(PowderProductionBo objPowderProductionBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[13];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objPowderProductionBO.Id;

                pSqlParameter[1] = new SqlParameter("@ProductType", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objPowderProductionBO.ProductType;

                pSqlParameter[2] = new SqlParameter("@BatchNo", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objPowderProductionBO.BatchNo;

                pSqlParameter[3] = new SqlParameter("@ProductionTime", SqlDbType.DateTime);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objPowderProductionBO.ProductionTime;

                pSqlParameter[4] = new SqlParameter("@PackQuantity", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objPowderProductionBO.PackQuantity;

                pSqlParameter[5] = new SqlParameter("@TypeOfpacking", SqlDbType.VarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objPowderProductionBO.TypePacking;

                pSqlParameter[6] = new SqlParameter("@NoOfUnits", SqlDbType.Int);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objPowderProductionBO.NoOfUnits;

                pSqlParameter[7] = new SqlParameter("@QualityParameter", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objPowderProductionBO.QualityParameter;

                pSqlParameter[8] = new SqlParameter("@UserId", SqlDbType.Int);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objPowderProductionBO.UserId;

                pSqlParameter[9] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objPowderProductionBO.Remark;

                pSqlParameter[10] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objPowderProductionBO.Date;

                pSqlParameter[11] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objPowderProductionBO.LastModifiedBy;

                pSqlParameter[12] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objPowderProductionBO.LastModifiedDate;

                sSql = "usp_tbl_PowderProduction_Update";
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
                objPowderProductionBO = null;
            }
        }
        #endregion
    }
}
