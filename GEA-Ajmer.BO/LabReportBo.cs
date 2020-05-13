using System;

namespace GEA_Ajmer.BO
{
    public class LabReportBo
    {
        #region LabReport Class Properties

        public const string LABREPORT_TABLE = "LabReport";
        public const string LABREPORT_ID = "Id";
        public const string LABREPORT_LABDATE = "LabDate";
        public const string LABREPORT_VEHICLECODE = "VehicleCode";
        public const string LABREPORT_VEHICLEID = "VehicleId";
        public const string LABREPORT_ROUTEID = "RouteId";
        public const string LABREPORT_PRODUCTID = "ProductId";
        public const string LABREPORT_OT = "OT";
        public const string LABREPORT_TEMP = "Temp";
        public const string LABREPORT_FAT = "Fat";
        public const string LABREPORT_SNF = "SNF";
        public const string LABREPORT_ACIDITY = "Acidity";
        public const string LABREPORT_COB = "COB";
        public const string LABREPORT_ALCOHOLNO = "AlcoholNo";
        public const string LABREPORT_NEUTRALIZER = "Neutralizer";
        public const string LABREPORT_UREA = "Urea";
        public const string LABREPORT_SALT = "Salt";
        public const string LABREPORT_STARTCH = "Startch";
        public const string LABREPORT_FPD = "FPD";
        public const string LABREPORT_STATUS = "Status";
        public const string LABREPORT_ISDELETED = "IsDeleted";
        public const string LABREPORT_CREATEDBY = "CreatedBy";
        public const string LABREPORT_CREATEDDATE = "CreatedDate";
        public const string LABREPORT_LASTMODIFIEDBY = "LastModifiedBy";
        public const string LABREPORT_LASTMODIFIEDDATE = "LastModifiedDate";



        private int intId = 0;
        private int intVehicleId = 0;
        private string strVehicleCode = string.Empty;
        private string strLabDate = string.Empty;
        private int intRouteId = 0;
        private int intProductId = 0;
        private int intOT = 0;
        private double dbTemp = 0.0;
        private double dbFat = 0.0;
        private double dbSNF = 0.0;
        private double dbAcidity = 0.0;
        private string strCOB = string.Empty;
        private string strAlcoholNo = string.Empty;
        private string strNeutralizer = string.Empty;
        private string strUrea = string.Empty;
        private string strSalt = string.Empty;
        private string strStartch = string.Empty;
        private string strFPD = string.Empty;
        private int intStatus = 0;
        public int intIsDeleted = 0;
        private int intCreatedBy = 0;
        private DateTime dtCreatedDate;
        private int intLastModifiedBy = 0;
        private DateTime dtLastModifiedDate;

        #endregion

        #region ---Properties---
        public int Id
        {
            get { return intId; }
            set { intId = value; }
        }

        public int VehicleId
        {
            get { return intVehicleId; }
            set { intVehicleId = value; }
        }
        public string VehicleCode
        {
            get { return strVehicleCode; }
            set { strVehicleCode = value; }
        }
        public string LabDate
        {
            get { return strLabDate; }
            set { strLabDate = value; }
        }
        public int RouteId
        {
            get { return intRouteId; }
            set { intRouteId = value; }
        }
        public int ProductId
        {
            get { return intProductId; }
            set { intProductId = value; }
        }
        public int OT
        {
            get { return intOT; }
            set { intOT = value; }
        }
        public double Temp
        {
            get { return dbTemp; }
            set { dbTemp = value; }
        }
        public double Fat
        {
            get { return dbFat; }
            set { dbFat = value; }
        }
        public double SNF
        {
            get { return dbSNF; }
            set { dbSNF = value; }
        }
        public double Acidity
        {
            get { return dbAcidity; }
            set { dbAcidity = value; }
        }
        public string COB
        {
            get { return strCOB; }
            set { strCOB = value; }
        }
        public string AlcoholNo
        {
            get { return strAlcoholNo; }
            set { strAlcoholNo = value; }
        }
        public string Neutralizer
        {
            get { return strNeutralizer; }
            set { strNeutralizer = value; }
        }
        public string Urea
        {
            get { return strUrea; }
            set { strUrea = value; }
        }
        public string Salt
        {
            get { return strSalt; }
            set { strSalt = value; }
        }
        public string Startch
        {
            get { return strStartch; }
            set { strStartch = value; }
        }
        public string FPD
        {
            get { return strFPD; }
            set { strFPD = value; }
        }
        public int Status
        {
            get { return intStatus; }
            set { intStatus = value; }
        }
        public int IsDeleted
        {
            get { return intIsDeleted; }
            set { intIsDeleted = value; }
        }
        public int CreatedBy
        {
            get { return intCreatedBy; }
            set { intCreatedBy = value; }
        }
        public DateTime CreatedDate
        {
            get { return dtCreatedDate; }
            set { dtCreatedDate = value; }
        }
        public int LastModifiedBy
        {
            get { return intLastModifiedBy; }
            set { intLastModifiedBy = value; }
        }
        public DateTime LastModifiedDate
        {
            get { return dtLastModifiedDate; }
            set { dtLastModifiedDate = value; }
        }

        #endregion
    }
}
