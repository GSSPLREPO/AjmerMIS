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
    public class MassBalanceBl
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion
            
        #region Select All MassBalance Details
        /// <summary>
        /// To Select All data from the MassBalance table
        /// Created By : pavan, 12-07-2017
        /// Modified By :
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult MassBalance_SelectAll()
        {
            try
            {
                
                strStoredProcName = "usp_tbl_MassBalance_SelectAll";
                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, null);
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

        #region Select MassBalance Details by
        /// <summary>
        /// Select all details of MassBalance for selected  from MassBalance table
        /// Created By : pavan, 12-07-2017
        /// Modified By :
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult MassBalance_Select(int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_tbl_MassBalance_Select";

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

        #region Delete MassBalance Details by
        /// <summary>
        /// To Delete details of MassBalance for selected  from MassBalance table
        /// Created By : pavan, 12-07-2017
        /// Modified By :
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult MassBalance_Delete(int intId, int intLastModifiedBy, string strLastModifiedDate)
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

                strStoredProcName = "usp_tbl_MassBalance_Delete";

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



        #region Insert MassBalance Details
        /// <summary>
        /// To Insert details of MassBalance in MassBalance table
        /// Created By : pavan, 12-07-2017
        /// Modified By :
        /// </summary>
        /// <param name="objMassBalanceBO"></param>
        /// <returns></returns>
        public ApplicationResult MassBalance_Insert(MassBalanceBO objMassBalanceBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[14];

                pSqlParameter[0] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMassBalanceBO.Date;
                    
                pSqlParameter[1] = new SqlParameter("@MilkKg", SqlDbType.Float);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMassBalanceBO.MilkKg;

                pSqlParameter[2] = new SqlParameter("@FATMilkKg", SqlDbType.Float);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMassBalanceBO.FATMilkKg;

                pSqlParameter[3] = new SqlParameter("@SNFMilkKg", SqlDbType.Float);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMassBalanceBO.SNFMilkKg;

                pSqlParameter[4] = new SqlParameter("@SugarMilkKg", SqlDbType.Float);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMassBalanceBO.SugarMilkKg;

                pSqlParameter[5] = new SqlParameter("@QtyOfPowder", SqlDbType.Float);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMassBalanceBO.QtyOfPowder;

                pSqlParameter[6] = new SqlParameter("@FATQty", SqlDbType.Float);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMassBalanceBO.FATQty;

                pSqlParameter[7] = new SqlParameter("@SNFQty", SqlDbType.Float);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMassBalanceBO.SNFQty;

                pSqlParameter[8] = new SqlParameter("@SugarQty", SqlDbType.Float);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMassBalanceBO.SugarQty;

                pSqlParameter[9] = new SqlParameter("@UserId", SqlDbType.Int);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMassBalanceBO.UserId;
                
                pSqlParameter[10] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMassBalanceBO.CreatedBy;

                pSqlParameter[11] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMassBalanceBO.CreatedDate;

                pSqlParameter[12] = new SqlParameter("@TotalSolidKG", SqlDbType.Float);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMassBalanceBO.TotalSolidKG;

                pSqlParameter[13] = new SqlParameter("@Variation", SqlDbType.Float);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMassBalanceBO.Variation;

                sSql = "usp_tbl_MassBalance_Insert";
                //DataTable dtResult = new DataTable();
                //dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);
                //ApplicationResult objResults = new ApplicationResult(dtResult);
                //objResults.Status = ApplicationResult.CommonStatusType.Success;
                //return objResults;
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
                objMassBalanceBO = null;
            }
        }
        #endregion

        #region Update MassBalance Details
        /// <summary>
        /// To Update details of MassBalance in MassBalance table
        /// Created By : pavan, 12-07-2017
        /// Modified By :
        /// </summary>
        /// <param name="objMassBalanceBO"></param>
        /// <returns></returns>
        public ApplicationResult MassBalance_Update(MassBalanceBO objMassBalanceBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[15];


                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMassBalanceBO.Id;

                pSqlParameter[1] = new SqlParameter("@MilkKg", SqlDbType.Float);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMassBalanceBO.MilkKg;

                pSqlParameter[2] = new SqlParameter("@FATMilkKg", SqlDbType.Float);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMassBalanceBO.FATMilkKg;

                pSqlParameter[3] = new SqlParameter("@SNFMilkKg", SqlDbType.Float);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMassBalanceBO.SNFMilkKg;

                pSqlParameter[4] = new SqlParameter("@SugarMilkKg", SqlDbType.Float);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMassBalanceBO.SugarMilkKg;

                pSqlParameter[5] = new SqlParameter("@QtyOfPowder", SqlDbType.Float);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMassBalanceBO.QtyOfPowder;

                pSqlParameter[6] = new SqlParameter("@FATQty", SqlDbType.Float);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMassBalanceBO.FATQty;

                pSqlParameter[7] = new SqlParameter("@SNFQty", SqlDbType.Float);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMassBalanceBO.SNFQty;

                pSqlParameter[8] = new SqlParameter("@SugarQty", SqlDbType.Float);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMassBalanceBO.SugarQty;

                pSqlParameter[9] = new SqlParameter("@UserId", SqlDbType.Int);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMassBalanceBO.UserId;

                pSqlParameter[10] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMassBalanceBO.Date;

                pSqlParameter[11] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMassBalanceBO.LastModifiedBy;

                pSqlParameter[12] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMassBalanceBO.LastModifiedDate;

                pSqlParameter[13] = new SqlParameter("@TotalSolidKG", SqlDbType.Float);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMassBalanceBO.TotalSolidKG;

                pSqlParameter[14] = new SqlParameter("@Variation", SqlDbType.Float);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMassBalanceBO.Variation;

                sSql = "usp_tbl_MassBalance_Update";
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
                objMassBalanceBO = null;
            }
        }
        #endregion

    }
}
