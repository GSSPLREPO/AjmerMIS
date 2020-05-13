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
    public class LabReportSMPBl
    {

        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Select All LabReportSMP Details
        /// <summary>
        /// To Select All data from the LabReportSMP table
        /// Created By : pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult LabReportSMP_SelectAll()
        {
            try
            {
                sSql = "usp_tbl_LabReportSMP_SelectAll";
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


        #region Select LabReportSMP Details by Id
        /// <summary>
        /// Select all details of LabReportSMP for selected Id from LabReportSMP table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult LabReportSMP_Select(int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_tbl_LabReportSMP_Select";

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


        #region Delete LabReportSMP Details by Id
        /// <summary>
        /// To Delete details of LabReportSMP for selected Id from LabReportSMP table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult LabReportSMP_Delete(int intId, int intLastModifiedBy, string strLastModifiedDate)
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

                strStoredProcName = "usp_tbl_LabReportSMP_Delete";

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


        #region Insert LabReportSMP Insert
        /// <summary>
        /// To Insert details of Fault in FaultTag table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult LabReportSMP_Insert(LabReportSMPBo objLabReportSMPBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[25];

                pSqlParameter[0] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objLabReportSMPBO.Date;

                pSqlParameter[1] = new SqlParameter("@TypeOfPowder", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objLabReportSMPBO.TypeOfPowder;

                pSqlParameter[2] = new SqlParameter("@Time", SqlDbType.DateTime);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objLabReportSMPBO.Time;

                pSqlParameter[3] = new SqlParameter("@BatchNo", SqlDbType.VarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objLabReportSMPBO.BatchNo;

                pSqlParameter[4] = new SqlParameter("@BagNo", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objLabReportSMPBO.BagNos;

                pSqlParameter[5] = new SqlParameter("@Weight", SqlDbType.Float);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objLabReportSMPBO.Weight;

                pSqlParameter[6] = new SqlParameter("@Appearance", SqlDbType.VarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objLabReportSMPBO.Appearance;

                pSqlParameter[7] = new SqlParameter("@Moisture", SqlDbType.Float);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objLabReportSMPBO.Moisture;

                pSqlParameter[8] = new SqlParameter("@TotalSolid", SqlDbType.Float);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objLabReportSMPBO.TotalSolid;

                pSqlParameter[9] = new SqlParameter("@BulkDensity", SqlDbType.Float);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objLabReportSMPBO.BulkDensity;

                pSqlParameter[10] = new SqlParameter("@MilkFat", SqlDbType.Float);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objLabReportSMPBO.MilkFat;

                pSqlParameter[11] = new SqlParameter("@Acidity", SqlDbType.VarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objLabReportSMPBO.Acidity;

                pSqlParameter[12] = new SqlParameter("@Wettability", SqlDbType.VarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objLabReportSMPBO.Wettability;
            
                pSqlParameter[13] = new SqlParameter("@ScorchedParticle", SqlDbType.VarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objLabReportSMPBO.ScorchedParticle;

                pSqlParameter[14] = new SqlParameter("@SolIndex", SqlDbType.VarChar);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objLabReportSMPBO.SolIndex;

                pSqlParameter[15] = new SqlParameter("@CoffeTest", SqlDbType.VarChar);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objLabReportSMPBO.CoffeTest;

                pSqlParameter[16] = new SqlParameter("@Flavour", SqlDbType.VarChar);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objLabReportSMPBO.Flavour;

                pSqlParameter[17] = new SqlParameter("@Protein", SqlDbType.Float);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objLabReportSMPBO.Protein;

                pSqlParameter[18] = new SqlParameter("@ASH", SqlDbType.Float);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objLabReportSMPBO.ASH;

                pSqlParameter[19] = new SqlParameter("@Lumpiness", SqlDbType.VarChar);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objLabReportSMPBO.Lumpiness;

                pSqlParameter[20] = new SqlParameter("@Adultration", SqlDbType.VarChar);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objLabReportSMPBO.Adultration;

                pSqlParameter[21] = new SqlParameter("@UserId", SqlDbType.Int);
                pSqlParameter[21].Direction = ParameterDirection.Input;
                pSqlParameter[21].Value = objLabReportSMPBO.UserId;

                pSqlParameter[22] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[22].Direction = ParameterDirection.Input;
                pSqlParameter[22].Value = objLabReportSMPBO.CreatedDate;

                pSqlParameter[23] = new SqlParameter("@IsDeleted", SqlDbType.Int);
                pSqlParameter[23].Direction = ParameterDirection.Input;
                pSqlParameter[23].Value = objLabReportSMPBO.IsDeleted;

                pSqlParameter[24] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[24].Direction = ParameterDirection.Input;
                pSqlParameter[24].Value = objLabReportSMPBO.CreatedBy;

                sSql = "usp_tbl_LabReportSMP_Insert";
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
                objLabReportSMPBO = null;
            }
        }
        #endregion


        #region Update LabReportSMP Update
        /// <summary>
        /// To Update details of LabReportSMP in LabReportSMP table
        /// Created By : Pavan, 08/07/2017
        /// Modified By :
        /// </summary>
        public ApplicationResult LabReportSMP_Update(LabReportSMPBo objLabReportSMPBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[25];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objLabReportSMPBO.Id;

                pSqlParameter[1] = new SqlParameter("@TypeOfPowder", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objLabReportSMPBO.TypeOfPowder;

                pSqlParameter[2] = new SqlParameter("@Time", SqlDbType.DateTime);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objLabReportSMPBO.Time;

                pSqlParameter[3] = new SqlParameter("@BatchNo", SqlDbType.VarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objLabReportSMPBO.BatchNo;

                pSqlParameter[4] = new SqlParameter("@BagNo", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objLabReportSMPBO.BagNos;

                pSqlParameter[5] = new SqlParameter("@Weight", SqlDbType.Float);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objLabReportSMPBO.Weight;

                pSqlParameter[6] = new SqlParameter("@Appearance", SqlDbType.VarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objLabReportSMPBO.Appearance;

                pSqlParameter[7] = new SqlParameter("@Moisture", SqlDbType.Float);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objLabReportSMPBO.Moisture;

                pSqlParameter[8] = new SqlParameter("@TotalSolid", SqlDbType.Float);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objLabReportSMPBO.TotalSolid;

                pSqlParameter[9] = new SqlParameter("@BulkDensity", SqlDbType.Float);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objLabReportSMPBO.BulkDensity;

                pSqlParameter[10] = new SqlParameter("@MilkFat", SqlDbType.Float);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objLabReportSMPBO.MilkFat;

                pSqlParameter[11] = new SqlParameter("@Acidity", SqlDbType.VarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objLabReportSMPBO.Acidity;

                pSqlParameter[12] = new SqlParameter("@Wettability", SqlDbType.VarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objLabReportSMPBO.Wettability;

                pSqlParameter[13] = new SqlParameter("@ScorchedParticle", SqlDbType.VarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objLabReportSMPBO.ScorchedParticle;

                pSqlParameter[14] = new SqlParameter("@SolIndex", SqlDbType.VarChar);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objLabReportSMPBO.SolIndex;

                pSqlParameter[15] = new SqlParameter("@CoffeTest", SqlDbType.VarChar);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objLabReportSMPBO.CoffeTest;

                pSqlParameter[16] = new SqlParameter("@Flavour", SqlDbType.VarChar);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objLabReportSMPBO.Flavour;

                pSqlParameter[17] = new SqlParameter("@Protein", SqlDbType.Float);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objLabReportSMPBO.Protein;

                pSqlParameter[18] = new SqlParameter("@ASH", SqlDbType.Float);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objLabReportSMPBO.ASH;

                pSqlParameter[19] = new SqlParameter("@Lumpiness", SqlDbType.VarChar);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objLabReportSMPBO.Lumpiness;

                pSqlParameter[20] = new SqlParameter("@Adultration", SqlDbType.VarChar);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objLabReportSMPBO.Adultration;

                pSqlParameter[21] = new SqlParameter("@UserId", SqlDbType.Int);
                pSqlParameter[21].Direction = ParameterDirection.Input;
                pSqlParameter[21].Value = objLabReportSMPBO.UserId;

                pSqlParameter[22] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[22].Direction = ParameterDirection.Input;
                pSqlParameter[22].Value = objLabReportSMPBO.Date;

                pSqlParameter[23] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[23].Direction = ParameterDirection.Input;
                pSqlParameter[23].Value = objLabReportSMPBO.LastModifiedDate;

                pSqlParameter[24] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[24].Direction = ParameterDirection.Input;
                pSqlParameter[24].Value = objLabReportSMPBO.LastModifiedBy;

                sSql = "usp_tbl_LabReportSMP_Update";
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
                objLabReportSMPBO = null;
            }
        }
        #endregion
    }
}
