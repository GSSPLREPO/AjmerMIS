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
    /// Class Created By : Chintan, 19-12-2015
    /// Summary description for Organisation.
    /// </summary>
    public class LabReportBl
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion



        #region Select All LabReport Details
        /// <summary>
        /// To Select All data from the LabReport table
        /// Created By : Chintan, 19-12-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult LabReport_SelectAll()
        {
            try
            {
                sSql = "usp_tbl_LabReport_SelectAll";
                DataTable dtLabReport = new DataTable();
                dtLabReport = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtLabReport);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        #region Select LabReport Details by Id
        /// <summary>
        /// Select all details of LabReport for selected Id from LabReport table
        /// Created By : Chintan, 19-12-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult LabReport_Select(int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_tbl_LabReport_Select";

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


        #region LabReport
        /// <summary>
        /// Select all details of LabReport for selected Id from LabReport table
        /// Created By : Chintan, 19-12-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult LabReport(string strFromDate, string strToDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = strFromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strToDate;

                strStoredProcName = "usp_LabReport_DateWise";

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


        #region Delete LabReport Details by Id
        /// <summary>
        /// To Delete details of LabReport for selected Id from LabReport table
        /// Created By : Chintan, 19-12-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult LabReport_Delete(int intId, int intLastModifiedBy, string strLastModifiedDate)
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

                strStoredProcName = "usp_tbl_LabReport_Delete";

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



        #region Insert LabReport Details
        /// <summary>
        /// To Insert details of LabReport in LabReport table
        /// Created By : Chintan, 19-12-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult LabReport_Insert(LabReportBo objLabReportBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[21];


                pSqlParameter[0] = new SqlParameter("@LabDate", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objLabReportBo.LabDate;

                pSqlParameter[1] = new SqlParameter("@VehicleId", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objLabReportBo.VehicleId;

                pSqlParameter[2] = new SqlParameter("@VehicleCode", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objLabReportBo.VehicleCode;

                pSqlParameter[3] = new SqlParameter("@RouteId", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objLabReportBo.RouteId;

                pSqlParameter[4] = new SqlParameter("@ProductId", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objLabReportBo.ProductId;

                pSqlParameter[5] = new SqlParameter("@OT", SqlDbType.Int);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objLabReportBo.OT;

                pSqlParameter[6] = new SqlParameter("@Temp", SqlDbType.Real);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objLabReportBo.Temp;
            
                pSqlParameter[7] = new SqlParameter("@Fat", SqlDbType.Real);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objLabReportBo.Fat;

                pSqlParameter[8] = new SqlParameter("@SNF", SqlDbType.Real);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objLabReportBo.SNF;

                pSqlParameter[9] = new SqlParameter("@Acidity", SqlDbType.Real);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objLabReportBo.Acidity;

                pSqlParameter[10] = new SqlParameter("@COB", SqlDbType.VarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objLabReportBo.COB;

                pSqlParameter[11] = new SqlParameter("@AlcoholNo", SqlDbType.VarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objLabReportBo.AlcoholNo;

                pSqlParameter[12] = new SqlParameter("@Neutralizer", SqlDbType.VarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objLabReportBo.Neutralizer;

                pSqlParameter[13] = new SqlParameter("@Urea", SqlDbType.VarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objLabReportBo.Urea;

                pSqlParameter[14] = new SqlParameter("@Salt", SqlDbType.VarChar);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objLabReportBo.Salt;

                pSqlParameter[15] = new SqlParameter("@Startch", SqlDbType.VarChar);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objLabReportBo.Startch;

                pSqlParameter[16] = new SqlParameter("@FPD", SqlDbType.VarChar);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objLabReportBo.FPD;

                pSqlParameter[17] = new SqlParameter("@Status", SqlDbType.Int);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objLabReportBo.Status;

                pSqlParameter[18] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objLabReportBo.IsDeleted;

                pSqlParameter[19] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objLabReportBo.CreatedBy;

                pSqlParameter[20] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objLabReportBo.CreatedDate;

                sSql = "usp_tbl_LabReport_Insert";

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
                objLabReportBo = null;
            }
        }
        #endregion



        #region Update LabReport Details
        /// <summary>
        /// To Update details of LabReport in LabReport table
        /// Created By : Chintan, 19-12-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult LabReport_Update(LabReportBo objLabReportBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[21];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objLabReportBo.Id;

                pSqlParameter[1] = new SqlParameter("@LabDate", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objLabReportBo.LabDate;

                pSqlParameter[2] = new SqlParameter("@VehicleId", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objLabReportBo.VehicleId;

                pSqlParameter[3] = new SqlParameter("@VehicleCode", SqlDbType.VarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objLabReportBo.VehicleCode;

                pSqlParameter[4] = new SqlParameter("@RouteId", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objLabReportBo.RouteId;

                pSqlParameter[5] = new SqlParameter("@ProductId", SqlDbType.Int);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objLabReportBo.ProductId;

                pSqlParameter[6] = new SqlParameter("@OT", SqlDbType.Int);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objLabReportBo.OT;

                pSqlParameter[7] = new SqlParameter("@Temp", SqlDbType.Real);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objLabReportBo.Temp;

                pSqlParameter[8] = new SqlParameter("@Fat", SqlDbType.Real);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objLabReportBo.Fat;

                pSqlParameter[9] = new SqlParameter("@SNF", SqlDbType.Real);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objLabReportBo.SNF;

                pSqlParameter[10] = new SqlParameter("@Acidity", SqlDbType.Real);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objLabReportBo.Acidity;

                pSqlParameter[11] = new SqlParameter("@COB", SqlDbType.VarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objLabReportBo.COB;

                pSqlParameter[12] = new SqlParameter("@AlcoholNo", SqlDbType.VarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objLabReportBo.AlcoholNo;

                pSqlParameter[13] = new SqlParameter("@Neutralizer", SqlDbType.VarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objLabReportBo.Neutralizer;

                pSqlParameter[14] = new SqlParameter("@Urea", SqlDbType.VarChar);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objLabReportBo.Urea;

                pSqlParameter[15] = new SqlParameter("@Salt", SqlDbType.VarChar);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objLabReportBo.Salt;

                pSqlParameter[16] = new SqlParameter("@Startch", SqlDbType.VarChar);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objLabReportBo.Startch;

                pSqlParameter[17] = new SqlParameter("@FPD", SqlDbType.VarChar);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objLabReportBo.FPD;

                pSqlParameter[18] = new SqlParameter("@Status", SqlDbType.Int);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objLabReportBo.Status;

                pSqlParameter[19] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objLabReportBo.LastModifiedBy;

                pSqlParameter[20] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objLabReportBo.LastModifiedDate;

                sSql = "usp_tbl_LabReport_Update";

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
                objLabReportBo = null;
            }
        }
        #endregion



        #region ValidateName for LabReport
        /// <summary>
        /// Function which validates whether the LabReportName already exits in LabReport table.
        /// Created By : Chintan, 19-12-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult LabReport_ValidateName(int intLabReportId, string strName)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@LabReportId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intLabReportId;

                pSqlParameter[1] = new SqlParameter("@Name", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strName;

                strStoredProcName = "usp_tbl_LabReport_ValidateName";

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



