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
    public class MaintainanceBL
    {
            #region user defined variables
            public string sSql;
            public string strStoredProcName;
            public SqlParameter[] pSqlParameter = null;
            #endregion


        #region Select All Maintainance Details
        /// <summary>
        /// To Select All data from the Maintainance table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_SelectAll(int intType)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Type", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intType;

                strStoredProcName = "usp_Maintainance_SelectAll_Routine";
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

        #region Select All Maintainance Details
        /// <summary>
        /// To Select All data from the Maintainance table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_SelectAll_ForBreakDown(int intType)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Type", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intType;

                strStoredProcName = "usp_Maintainance_SelectAll";
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

        #region Select All Maintainance For Top 5 Dashboards
        /// <summary>
        /// To Select All data from the Maintainance table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_SelectAll_forTopfive()
        {
            try
            {
                
                strStoredProcName = "usp_Maintainance_SelectAll_ForTopfive";
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

        #region Select All Maintainance For Dashboards
        /// <summary>
        /// To Select All data from the Maintainance table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_SelectAll_forDashboard()
        {
            try
            {

                strStoredProcName = "usp_Maintainance_SelectAll_ForDashboard";
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

        #region Select All Maintainance For Dashboards
        /// <summary>
        /// To Select All data from the Maintainance table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_SelectAll_forRoutineReport(DateTime strFromDate, DateTime strToDate, int intType)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.Date);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = strFromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.Date);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strToDate;

                pSqlParameter[2] = new SqlParameter("@Type", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = intType;

                strStoredProcName = "usp_Maintainance_SelectAll_forRoutineReport";
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

        #region Select Maintainance Details by
        /// <summary>
        /// Select all details of Maintainance for selected  from Maintainance table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_Select(int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_Maintainance_Select";

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

        #region Select Maintainance Details by
        /// <summary>
        /// Select all details of Maintainance for selected  from Maintainance table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_Select_Routine(int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_Maintainance_Select_Routine";

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

        #region Delete Maintainance Details by
        /// <summary>
        /// To Delete details of Maintainance for selected  from Maintainance table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_Delete(int intId, int intLastModifiedBy, string strLastModifiedDate)
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

                strStoredProcName = "usp_Maintainance_Delete";

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



        #region Insert Maintainance Details For Routine
        /// <summary>
        /// To Insert details of Maintainance in Maintainance table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name="objMaintainanceBO"></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_Insert(MaintainanceBo objMaintainanceBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[19];

                pSqlParameter[0] = new SqlParameter("@EquipmentTagNo", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMaintainanceBO.EquipmentTagNo;

                pSqlParameter[1] = new SqlParameter("@EquipmentName", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMaintainanceBO.EquipmentName;

                pSqlParameter[2] = new SqlParameter("@MaintainanceDate", SqlDbType.DateTime);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMaintainanceBO.MaintainanceDate;

                pSqlParameter[3] = new SqlParameter("@StartTime", SqlDbType.DateTime);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMaintainanceBO.StartTime;

                pSqlParameter[4] = new SqlParameter("@EndTime", SqlDbType.DateTime);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMaintainanceBO.EndTime;

                pSqlParameter[5] = new SqlParameter("@PartNo", SqlDbType.VarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMaintainanceBO.PartNo;

                pSqlParameter[6] = new SqlParameter("@PartName", SqlDbType.VarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMaintainanceBO.PartName;

                pSqlParameter[7] = new SqlParameter("@Section", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMaintainanceBO.Section;

                pSqlParameter[8] = new SqlParameter("@Area", SqlDbType.VarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMaintainanceBO.Area;

                pSqlParameter[9] = new SqlParameter("@Department", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMaintainanceBO.Department;

                pSqlParameter[10] = new SqlParameter("@ActionTaken", SqlDbType.VarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMaintainanceBO.ActionTaken;

                pSqlParameter[11] = new SqlParameter("@RectifiedBy", SqlDbType.VarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMaintainanceBO.RectifiedBy;

                pSqlParameter[12] = new SqlParameter("@Remark", SqlDbType.VarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMaintainanceBO.Remark;

              
                pSqlParameter[13] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMaintainanceBO.CreatedBy;

                pSqlParameter[14] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMaintainanceBO.CreatedDate;

                pSqlParameter[15] = new SqlParameter("@DueDate", SqlDbType.DateTime);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objMaintainanceBO.DueDate;

                pSqlParameter[16] = new SqlParameter("@NextDueDate", SqlDbType.DateTime);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objMaintainanceBO.NextDueDate;

                pSqlParameter[17] = new SqlParameter("@IsBreakDown", SqlDbType.Int);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objMaintainanceBO.IsBreackDown;

                pSqlParameter[18] = new SqlParameter("@UserId", SqlDbType.Int);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objMaintainanceBO.UserId;

                sSql = "usp_Maintainance_Insert_ForRoutine";
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
                objMaintainanceBO = null;
            }
        }
        #endregion

        #region Insert Maintainance For Breakdown
        /// <summary>
        /// To Insert details of Maintainance in Maintainance table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name="objMaintainanceBO"></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_Insert_ForBreakdown(MaintainanceBo objMaintainanceBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[19];


                pSqlParameter[0] = new SqlParameter("@EquipmentTagNo", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMaintainanceBO.EquipmentTagNo;

                pSqlParameter[1] = new SqlParameter("@EquipmentName", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMaintainanceBO.EquipmentName;

                pSqlParameter[2] = new SqlParameter("@MaintainanceDate", SqlDbType.DateTime);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMaintainanceBO.MaintainanceDate;

                pSqlParameter[3] = new SqlParameter("@StartTime", SqlDbType.DateTime);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMaintainanceBO.StartTime;

                pSqlParameter[4] = new SqlParameter("@EndTime", SqlDbType.DateTime);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMaintainanceBO.EndTime;

                pSqlParameter[5] = new SqlParameter("@PartNo", SqlDbType.VarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMaintainanceBO.PartNo;

                pSqlParameter[6] = new SqlParameter("@PartName", SqlDbType.VarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMaintainanceBO.PartName;

                pSqlParameter[7] = new SqlParameter("@Section", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMaintainanceBO.Section;

                pSqlParameter[8] = new SqlParameter("@Cause", SqlDbType.VarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMaintainanceBO.Cause;

                pSqlParameter[9] = new SqlParameter("@DetailBreakDown", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMaintainanceBO.DetailBreakDown;

                pSqlParameter[10] = new SqlParameter("@ActionTaken", SqlDbType.VarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMaintainanceBO.ActionTaken;

                pSqlParameter[11] = new SqlParameter("@RectifiedBy", SqlDbType.VarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMaintainanceBO.RectifiedBy;

                pSqlParameter[12] = new SqlParameter("@Remark", SqlDbType.VarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMaintainanceBO.Remark;

                pSqlParameter[13] = new SqlParameter("@Department", SqlDbType.VarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMaintainanceBO.Department;

                pSqlParameter[14] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMaintainanceBO.CreatedBy;

                pSqlParameter[15] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objMaintainanceBO.CreatedDate;

                pSqlParameter[16] = new SqlParameter("@Area", SqlDbType.VarChar);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objMaintainanceBO.Area;

                pSqlParameter[17] = new SqlParameter("@UserId", SqlDbType.Int);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objMaintainanceBO.UserId;

                pSqlParameter[18] = new SqlParameter("@IsBreakDown", SqlDbType.Int);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objMaintainanceBO.IsBreackDown;

                sSql = "usp_Maintainance_Insert";
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
                objMaintainanceBO = null;
            }
        }
        #endregion

        #region Update Maintainance Details
        /// <summary>
        /// To Update details of Maintainance in Maintainance table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name="objMaintainanceBO"></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_Update(MaintainanceBo objMaintainanceBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[19];


                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMaintainanceBO.Id;

                pSqlParameter[1] = new SqlParameter("@EquipmentTagNo", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMaintainanceBO.EquipmentTagNo;

                pSqlParameter[2] = new SqlParameter("@EquipmentName", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMaintainanceBO.EquipmentName;

                pSqlParameter[3] = new SqlParameter("@MaintainanceDate", SqlDbType.DateTime);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMaintainanceBO.MaintainanceDate;

                pSqlParameter[4] = new SqlParameter("@StartTime", SqlDbType.DateTime);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMaintainanceBO.StartTime;

                pSqlParameter[5] = new SqlParameter("@EndTime", SqlDbType.DateTime);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMaintainanceBO.EndTime;

                pSqlParameter[6] = new SqlParameter("@PartNo", SqlDbType.VarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMaintainanceBO.PartNo;

                pSqlParameter[7] = new SqlParameter("@PartName", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMaintainanceBO.PartName;

                pSqlParameter[8] = new SqlParameter("@Section", SqlDbType.VarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMaintainanceBO.Section;

                pSqlParameter[9] = new SqlParameter("@Area", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMaintainanceBO.Area;

                pSqlParameter[10] = new SqlParameter("@Department", SqlDbType.VarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMaintainanceBO.Department;

                pSqlParameter[11] = new SqlParameter("@ActionTaken", SqlDbType.VarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMaintainanceBO.ActionTaken;

                pSqlParameter[12] = new SqlParameter("@RectifiedBy", SqlDbType.VarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMaintainanceBO.RectifiedBy;

                pSqlParameter[13] = new SqlParameter("@Remark", SqlDbType.VarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMaintainanceBO.Remark;

                pSqlParameter[14] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMaintainanceBO.LastModifiedBy;

                pSqlParameter[15] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objMaintainanceBO.LastModifiedDate;

                pSqlParameter[16] = new SqlParameter("@NextDueDate", SqlDbType.DateTime);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objMaintainanceBO.NextDueDate;

                pSqlParameter[17] = new SqlParameter("@DueDate", SqlDbType.DateTime);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objMaintainanceBO.DueDate;

                pSqlParameter[18] = new SqlParameter("@UserId", SqlDbType.Int);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objMaintainanceBO.UserId;

                sSql = "usp_Maintainance_Update_Routine";
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
                objMaintainanceBO = null;
            }
        }
        #endregion

        #region Update Maintainance Details ForBreakDown
        /// <summary>
        /// To Update details of Maintainance in Maintainance table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name="objMaintainanceBO"></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_Update_ForBreakdown(MaintainanceBo objMaintainanceBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[19];


                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMaintainanceBO.Id;

                pSqlParameter[1] = new SqlParameter("@EquipmentTagNo", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMaintainanceBO.EquipmentTagNo;

                pSqlParameter[2] = new SqlParameter("@EquipmentName", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMaintainanceBO.EquipmentName;

                pSqlParameter[3] = new SqlParameter("@MaintainanceDate", SqlDbType.DateTime);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMaintainanceBO.MaintainanceDate;

                pSqlParameter[4] = new SqlParameter("@StartTime", SqlDbType.DateTime);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMaintainanceBO.StartTime;

                pSqlParameter[5] = new SqlParameter("@EndTime", SqlDbType.DateTime);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMaintainanceBO.EndTime;

                pSqlParameter[6] = new SqlParameter("@PartNo", SqlDbType.VarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMaintainanceBO.PartNo;

                pSqlParameter[7] = new SqlParameter("@PartName", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMaintainanceBO.PartName;

                pSqlParameter[8] = new SqlParameter("@Section", SqlDbType.VarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMaintainanceBO.Section;

                pSqlParameter[9] = new SqlParameter("@Cause", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMaintainanceBO.Cause;

                pSqlParameter[10] = new SqlParameter("@DetailBreakDown", SqlDbType.VarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMaintainanceBO.DetailBreakDown;

                pSqlParameter[11] = new SqlParameter("@ActionTaken", SqlDbType.VarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMaintainanceBO.ActionTaken;

                pSqlParameter[12] = new SqlParameter("@RectifiedBy", SqlDbType.VarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMaintainanceBO.RectifiedBy;

                pSqlParameter[13] = new SqlParameter("@Remark", SqlDbType.VarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMaintainanceBO.Remark;

                pSqlParameter[14] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMaintainanceBO.LastModifiedBy;

                pSqlParameter[15] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objMaintainanceBO.LastModifiedDate;

                pSqlParameter[16] = new SqlParameter("@Area", SqlDbType.VarChar);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objMaintainanceBO.Area;

                pSqlParameter[17] = new SqlParameter("@Department", SqlDbType.VarChar);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objMaintainanceBO.Department;

                pSqlParameter[18] = new SqlParameter("@UserId", SqlDbType.Int);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objMaintainanceBO.UserId;

                sSql = "usp_Maintainance_Update";
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
                objMaintainanceBO = null;
            }
        }
        #endregion

        #region Update Maintainance For Status Change for Routine
        /// <summary>
        /// To Update details of Maintainance in Maintainance table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name="objMaintainanceBO"></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_UpdateStatus(MaintainanceBo objMaintainanceBO,int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[17];

                pSqlParameter[0] = new SqlParameter("@EquipmentTagNo", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMaintainanceBO.EquipmentTagNo;

                pSqlParameter[1] = new SqlParameter("@EquipmentName", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMaintainanceBO.EquipmentName;

                pSqlParameter[2] = new SqlParameter("@MaintainanceDate", SqlDbType.DateTime);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMaintainanceBO.MaintainanceDate;

                pSqlParameter[3] = new SqlParameter("@StartTime", SqlDbType.DateTime);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMaintainanceBO.StartTime;

                pSqlParameter[4] = new SqlParameter("@EndTime", SqlDbType.DateTime);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMaintainanceBO.EndTime;

                pSqlParameter[5] = new SqlParameter("@PartNo", SqlDbType.VarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMaintainanceBO.PartNo;

                pSqlParameter[6] = new SqlParameter("@PartName", SqlDbType.VarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMaintainanceBO.PartName;

                pSqlParameter[7] = new SqlParameter("@Section", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMaintainanceBO.Section;

                pSqlParameter[8] = new SqlParameter("@Area", SqlDbType.VarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMaintainanceBO.Area;

                pSqlParameter[9] = new SqlParameter("@Department", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMaintainanceBO.Department;

                pSqlParameter[10] = new SqlParameter("@ActionTaken", SqlDbType.VarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMaintainanceBO.ActionTaken;

                pSqlParameter[11] = new SqlParameter("@RectifiedBy", SqlDbType.VarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMaintainanceBO.RectifiedBy;

                pSqlParameter[12] = new SqlParameter("@Remark", SqlDbType.VarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMaintainanceBO.Remark;

                pSqlParameter[13] = new SqlParameter("@Type", SqlDbType.Int);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMaintainanceBO.Type;

                pSqlParameter[14] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMaintainanceBO.CreatedBy;

                pSqlParameter[15] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objMaintainanceBO.CreatedDate;

                pSqlParameter[16] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = intId;

                strStoredProcName = "usp_Maintainance_UpdateStatus";
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

        #region Update Maintainance For Status Change for Routine
        /// <summary>
        /// To Update details of Maintainance in Maintainance table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name="objMaintainanceBO"></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_UpdateStatusForBreackDown(int intId,int intLastiModifiedBy, string strLastModifiedBy)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                pSqlParameter[1] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = intLastiModifiedBy;

                pSqlParameter[2] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = strLastModifiedBy;

                strStoredProcName = "usp_Maintainance_UpdateStatus_ForBreackDown";
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




        #region Select Maintainance Details by MaintainanceName
        /// <summary>
        /// Select all details of Maintainance for selected MaintainanceName from Maintainance table
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name="MaintainanceName"></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_Select_byMaintainanceName(string strMaintainanceName)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@MaintainanceName", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = strMaintainanceName;

                strStoredProcName = "usp_Maintainance_Select_ByMaintainance";

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


        #region ValidateName for Maintainance
        /// <summary>
        /// Function which validates whether the MaintainanceName already exits in Maintainance table.
        /// Created By : NirmalShah, 26-11-2015
        /// Modified By :
        /// </summary>
        /// <param name="strMaintainanceName"></param>
        /// <returns></returns>
        public ApplicationResult Maintainance_ValidateName(string strMaintainanceName)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@MaintainanceName", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = strMaintainanceName;

                strStoredProcName = "usp_Maintainance_Validate_MaintainanceName";

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
