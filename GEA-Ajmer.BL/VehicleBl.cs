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
    public class VehicleBl
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion



        #region Select All Vehicle Details
        /// <summary>
        /// To Select All data from the Vehicle table
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Vehicle_SelectAll()
        {
            try
            {
                sSql = "usp_tbl_Vehicle_SelectAll";
                DataTable dtVehicle = new DataTable();
                dtVehicle = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtVehicle);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        #region Select Vehicle Details by VehicleId
        /// <summary>
        /// Select all details of Vehicle for selected VehicleId from Vehicle table
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Vehicle_Select(int intVehicleId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@VehicleId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intVehicleId;

                strStoredProcName = "usp_tbl_Vehicle_Select";

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

        #region Select Vehicle Details by VehicleId for Contractor
        /// <summary>
        /// Select all details of Vehicle for selected VehicleId from Vehicle table
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Vehicle_Select_ForContractor(int intContractorId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@ContractorCode", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intContractorId;

                strStoredProcName = "usp_tbl_Vehicle_Select_ForContractor";

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

        #region Select Vehicle Details by By VehicleNumber
        /// <summary>
        /// Select all details of Vehicle for selected VehicleId from Vehicle table
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Vehicle_Select_ByVehicleNumber(string strVehicleNumber)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@VehicleNumber", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = strVehicleNumber;

                strStoredProcName = "usp_tbl_Vehicle_Select_ByVehicleNumber";

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

        #region Select Vehicle Search
        /// <summary>
        /// Select Vehicle Search
        /// Created By : Chintan, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Vehicle_Search(string strVehicleNumber)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@SearchText", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = strVehicleNumber;

                strStoredProcName = "usp_Vehicle_Search";

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

        #region Delete Vehicle Details by VehicleId
        /// <summary>
        /// To Delete details of Vehicle for selected VehicleId from Vehicle table
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Vehicle_Delete(int intVehicleId, int intLastModifiedBy, string strLastModifiedDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@VehicleId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intVehicleId;

                pSqlParameter[1] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = intLastModifiedBy;

                pSqlParameter[2] = new SqlParameter("@LastModifiedDate", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = strLastModifiedDate;

                strStoredProcName = "usp_tbl_Vehicle_Delete";

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



        #region Insert Vehicle Details
        /// <summary>
        /// To Insert details of Vehicle in Vehicle table
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Vehicle_Insert(VehicleBo objVehicleBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[13];


                pSqlParameter[0] = new SqlParameter("@VehicleNumber", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objVehicleBo.VehicleNumber;

                pSqlParameter[1] = new SqlParameter("@ContractorCode", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objVehicleBo.ContractorCode;

                pSqlParameter[2] = new SqlParameter("@VehicleType", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objVehicleBo.VehicleType;

                pSqlParameter[3] = new SqlParameter("@Capacity", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objVehicleBo.Capacity;

                pSqlParameter[4] = new SqlParameter("@DriverName", SqlDbType.VarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objVehicleBo.DriverName;

                pSqlParameter[5] = new SqlParameter("@ConductorName", SqlDbType.VarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objVehicleBo.ConductorName;

                pSqlParameter[6] = new SqlParameter("@Compartments", SqlDbType.Int);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objVehicleBo.Compartments;

                pSqlParameter[7] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objVehicleBo.Remarks;

                pSqlParameter[8] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objVehicleBo.CreatedBy;

                pSqlParameter[9] = new SqlParameter("@CreatedDate", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objVehicleBo.CreatedDate;
             
                pSqlParameter[10] = new SqlParameter("@IsDeleted", SqlDbType.Int);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objVehicleBo.IsDeleted;

                pSqlParameter[11] = new SqlParameter("@TareWeight", SqlDbType.Float);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objVehicleBo.TareWeight;

                pSqlParameter[12] = new SqlParameter("@VehicleCode", SqlDbType.Int);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objVehicleBo.VehicleCode;




                sSql = "usp_tbl_Vehicle_Insert";
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
                objVehicleBo = null;
            }
        }
        #endregion



        #region Update Vehicle Details
        /// <summary>
        /// To Update details of Vehicle in Vehicle table
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Vehicle_Update(VehicleBo objVehicleBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[14];


                pSqlParameter[0] = new SqlParameter("@VehicleId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objVehicleBo.VehicleId;

                pSqlParameter[1] = new SqlParameter("@VehicleNumber", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objVehicleBo.VehicleNumber;

                pSqlParameter[2] = new SqlParameter("@ContractorCode", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objVehicleBo.ContractorCode;

                pSqlParameter[3] = new SqlParameter("@VehicleType", SqlDbType.VarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objVehicleBo.VehicleType;

                pSqlParameter[4] = new SqlParameter("@Capacity", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objVehicleBo.Capacity;

                pSqlParameter[5] = new SqlParameter("@DriverName", SqlDbType.VarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objVehicleBo.DriverName;

                pSqlParameter[6] = new SqlParameter("@ConductorName", SqlDbType.VarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objVehicleBo.ConductorName;

                pSqlParameter[7] = new SqlParameter("@Compartments", SqlDbType.Int);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objVehicleBo.Compartments;

                pSqlParameter[8] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objVehicleBo.Remarks;

                pSqlParameter[9] = new SqlParameter("@LastModifiedBy", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objVehicleBo.LastModifiedBy;

                pSqlParameter[10] = new SqlParameter("@LastModifiedDate", SqlDbType.VarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objVehicleBo.LastModifiedDate;

                pSqlParameter[11] = new SqlParameter("@IsDeleted", SqlDbType.Int);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objVehicleBo.IsDeleted;

                pSqlParameter[12] = new SqlParameter("@TareWeight", SqlDbType.Float);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objVehicleBo.TareWeight;

                pSqlParameter[13] = new SqlParameter("@VehicleCode", SqlDbType.Int);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objVehicleBo.VehicleCode;

                sSql = "usp_tbl_Vehicle_Update";

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
                objVehicleBo = null;
            }
        }
        #endregion



        #region ValidateName for Vehicle
        /// <summary>
        /// Function which validates whether the VehicleName already exits in Vehicle table.
        /// Created By : Vishal, 11/16/2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Vehicle_ValidateName(int intVehicleId, string strName)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@VehicleId", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intVehicleId;

                pSqlParameter[1] = new SqlParameter("@VehicleNumber", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strName;

                strStoredProcName = "usp_tbl_Vehicle_ValidateName";

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
