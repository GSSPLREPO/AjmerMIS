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
    public class MilkAnalysisBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Select All MilkAnalysis Details
        /// <summary>
        /// To Select All data from the MilkAnalysis table
        /// Created By : pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult MilkAnalysis_SelectAll()
        {
            try
            {
                
                sSql = "usp_tbl_MilkAnalysis_SelectAll";
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

        public ApplicationResult MilkAnalysisReport_SelectAll(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDate;

                sSql = "usp_tbl_MilkAnalysisReport_SelectAll";
                DataTable dtFault = new DataTable();
                dtFault = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

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

        #region Select All MilkAnalysis Details
        /// <summary>
        /// To Select All data from the MilkAnalysis table
        /// Created By : pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult MilkAnalysis_SelectAll_DateWise(DateTime dtFromDate,DateTime dtToDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.Date);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = dtFromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.Date);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = dtToDate;

                sSql = "usp_tbl_MilkAnalysis_SelectAll_DateWise";
                DataTable dtFault = new DataTable();
                dtFault = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

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


        #region Select MilkAnalysis Details by Id
        /// <summary>
        /// Select all details of MilkAnalysis for selected Id from MilkAnalysis table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult MilkAnalysis_Select(int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_tbl_MilkAnalysis_Select";

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


        #region Delete MilkAnalysis Details by Id
        /// <summary>
        /// To Delete details of MilkAnalysis for selected Id from MilkAnalysis table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult MilkAnalysis_Delete(int intId, int intLastModifiedBy, string strLastModifiedDate)
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

                strStoredProcName = "usp_tbl_MilkAnalysis_Delete";

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


        #region Insert MilkAnalysis Details
        /// <summary>
        /// To Insert details of Fault in FaultTag table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult MilkAnalysis_Insert(MilkAnalysisBO objMilkAnalysisBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[27];

                pSqlParameter[0] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMilkAnalysisBO.Date;

                pSqlParameter[1] = new SqlParameter("@Time", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMilkAnalysisBO.Time;

                pSqlParameter[2] = new SqlParameter("@SiloId", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMilkAnalysisBO.SiloId;

                pSqlParameter[3] = new SqlParameter("@ProductType", SqlDbType.VarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMilkAnalysisBO.ProductType;

                pSqlParameter[4] = new SqlParameter("@SampleId", SqlDbType.VarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMilkAnalysisBO.SampleId;

                pSqlParameter[5] = new SqlParameter("@FAT", SqlDbType.Float);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMilkAnalysisBO.FAT;

                pSqlParameter[6] = new SqlParameter("@SNF", SqlDbType.Float);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMilkAnalysisBO.SNF;

                pSqlParameter[7] = new SqlParameter("@Sugar", SqlDbType.Float);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMilkAnalysisBO.Sugar;

                pSqlParameter[8] = new SqlParameter("@TS", SqlDbType.Float);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMilkAnalysisBO.TS;

                pSqlParameter[9] = new SqlParameter("@Acidity", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMilkAnalysisBO.Acidity;

                pSqlParameter[10] = new SqlParameter("@Temp", SqlDbType.Float);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMilkAnalysisBO.Temp;

                pSqlParameter[11] = new SqlParameter("@OT", SqlDbType.VarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMilkAnalysisBO.OT;

                pSqlParameter[12] = new SqlParameter("@UserId", SqlDbType.Int);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMilkAnalysisBO.UserId;

                pSqlParameter[13] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMilkAnalysisBO.Remark;

                pSqlParameter[14] = new SqlParameter("@IsDeleted", SqlDbType.Int);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMilkAnalysisBO.IsDeleted;

                pSqlParameter[15] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objMilkAnalysisBO.CreatedBy;

                pSqlParameter[16] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objMilkAnalysisBO.CreatedDate;

                pSqlParameter[17] = new SqlParameter("@VehicleId", SqlDbType.VarChar);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objMilkAnalysisBO.VehicleId;

                pSqlParameter[18] = new SqlParameter("@VehicleNo", SqlDbType.VarChar);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objMilkAnalysisBO.VehicleNo;

                pSqlParameter[19] = new SqlParameter("@RouteNo", SqlDbType.VarChar);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objMilkAnalysisBO.RouteNo;

                pSqlParameter[20] = new SqlParameter("@COB", SqlDbType.VarChar);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objMilkAnalysisBO.COB;

                pSqlParameter[21] = new SqlParameter("@AlcoholNo", SqlDbType.VarChar);
                pSqlParameter[21].Direction = ParameterDirection.Input;
                pSqlParameter[21].Value = objMilkAnalysisBO.AlcoholNo;

                pSqlParameter[22] = new SqlParameter("@Neutralizer", SqlDbType.VarChar);
                pSqlParameter[22].Direction = ParameterDirection.Input;
                pSqlParameter[22].Value = objMilkAnalysisBO.Neutralizer;

                pSqlParameter[23] = new SqlParameter("@Urea", SqlDbType.VarChar);
                pSqlParameter[23].Direction = ParameterDirection.Input;
                pSqlParameter[23].Value = objMilkAnalysisBO.Urea;

                pSqlParameter[24] = new SqlParameter("@Salt", SqlDbType.VarChar);
                pSqlParameter[24].Direction = ParameterDirection.Input;
                pSqlParameter[24].Value = objMilkAnalysisBO.Salt;

                pSqlParameter[25] = new SqlParameter("@Starch", SqlDbType.VarChar);
                pSqlParameter[25].Direction = ParameterDirection.Input;
                pSqlParameter[25].Value = objMilkAnalysisBO.Starch;

                pSqlParameter[26] = new SqlParameter("@FPD", SqlDbType.VarChar);
                pSqlParameter[26].Direction = ParameterDirection.Input;
                pSqlParameter[26].Value = objMilkAnalysisBO.FPD;



                sSql = "usp_tbl_MilkAnalysis_Insert";
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
                objMilkAnalysisBO = null;
            }
        }
        #endregion


        #region Update MilkAnalysis Details
        /// <summary>
        /// To Update details of MilkAnalysis in MilkAnalysis table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult MilkAnalysis_Update(MilkAnalysisBO objMilkAnalysisBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[27];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMilkAnalysisBO.Id;

                pSqlParameter[1] = new SqlParameter("@Time", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMilkAnalysisBO.Time;

                pSqlParameter[2] = new SqlParameter("@SiloId", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMilkAnalysisBO.SiloId;

                pSqlParameter[3] = new SqlParameter("@ProductType", SqlDbType.VarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMilkAnalysisBO.ProductType;

                pSqlParameter[4] = new SqlParameter("@SampleId", SqlDbType.VarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMilkAnalysisBO.SampleId;

                pSqlParameter[5] = new SqlParameter("@FAT", SqlDbType.Float);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMilkAnalysisBO.FAT;

                pSqlParameter[6] = new SqlParameter("@SNF", SqlDbType.Float);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMilkAnalysisBO.SNF;

                pSqlParameter[7] = new SqlParameter("@Sugar", SqlDbType.Float);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMilkAnalysisBO.Sugar;

                pSqlParameter[8] = new SqlParameter("@TS", SqlDbType.Float);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMilkAnalysisBO.TS;

                pSqlParameter[9] = new SqlParameter("@Acidity", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMilkAnalysisBO.Acidity;

                pSqlParameter[10] = new SqlParameter("@Temp", SqlDbType.Float);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMilkAnalysisBO.Temp;

                pSqlParameter[11] = new SqlParameter("@OT", SqlDbType.VarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMilkAnalysisBO.OT;

                pSqlParameter[12] = new SqlParameter("@UserId", SqlDbType.Int);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMilkAnalysisBO.UserId;

                pSqlParameter[13] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMilkAnalysisBO.Remark;

                pSqlParameter[14] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMilkAnalysisBO.Date;

                pSqlParameter[15] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objMilkAnalysisBO.LastModifiedBy;

                pSqlParameter[16] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objMilkAnalysisBO.LastModifiedDate;

                pSqlParameter[17] = new SqlParameter("@VehicleId", SqlDbType.VarChar);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objMilkAnalysisBO.VehicleId;

                pSqlParameter[18] = new SqlParameter("@VehicleNo", SqlDbType.VarChar);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objMilkAnalysisBO.VehicleNo;

                pSqlParameter[19] = new SqlParameter("@RouteNo", SqlDbType.VarChar);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objMilkAnalysisBO.RouteNo;

                pSqlParameter[20] = new SqlParameter("@COB", SqlDbType.VarChar);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objMilkAnalysisBO.COB;

                pSqlParameter[21] = new SqlParameter("@AlcoholNo", SqlDbType.VarChar);
                pSqlParameter[21].Direction = ParameterDirection.Input;
                pSqlParameter[21].Value = objMilkAnalysisBO.AlcoholNo;

                pSqlParameter[22] = new SqlParameter("@Neutralizer", SqlDbType.VarChar);
                pSqlParameter[22].Direction = ParameterDirection.Input;
                pSqlParameter[22].Value = objMilkAnalysisBO.Neutralizer;

                pSqlParameter[23] = new SqlParameter("@Urea", SqlDbType.VarChar);
                pSqlParameter[23].Direction = ParameterDirection.Input;
                pSqlParameter[23].Value = objMilkAnalysisBO.Urea;

                pSqlParameter[24] = new SqlParameter("@Salt", SqlDbType.VarChar);
                pSqlParameter[24].Direction = ParameterDirection.Input;
                pSqlParameter[24].Value = objMilkAnalysisBO.Salt;

                pSqlParameter[25] = new SqlParameter("@Starch", SqlDbType.VarChar);
                pSqlParameter[25].Direction = ParameterDirection.Input;
                pSqlParameter[25].Value = objMilkAnalysisBO.Starch;

                pSqlParameter[26] = new SqlParameter("@FPD", SqlDbType.VarChar);
                pSqlParameter[26].Direction = ParameterDirection.Input;
                pSqlParameter[26].Value = objMilkAnalysisBO.FPD;

                sSql = "usp_tbl_MilkAnalysis_Update";
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
                objMilkAnalysisBO = null;
            }
        }
        #endregion
    }
}
