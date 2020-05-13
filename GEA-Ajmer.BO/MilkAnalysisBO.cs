using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GEA_Ajmer.BO
{
    public class MilkAnalysisBO
    {
        #region MilkAnalysis Class Properties

        public const string MILKANALYSIS_TABLE = "MILKANALYSIS";
        public const string MILKANALYSIS_ID = "Id";
        public const string MILKANALYSIS_DATE = "Date";
        public const string MILKANALYSIS_TIME = "Time";
        public const string MILKANALYSIS_SILOID = "SiloId";
        public const string MILKANALYSIS_PRODUCTTYPE = "ProductType";
        public const string MILKANALYSIS_SAMPLEID = "SampleId";
        public const string MILKANALYSIS_FAT = "FAT";
        public const string MILKANALYSIS_SNF = "SNF";
        public const string MILKANALYSIS_SUGAR = "Sugar";
        public const string MILKANALYSIS_TS = "TS";
        public const string MILKANALYSIS_ACIDITY = "Acidity";
        public const string MILKANALYSIS_TEMP = "Temp";
        public const string MILKANALYSIS_OT = "OT";

        public const string MILKANALYSIS_VehicleId = "VehicleId";
        public const string MILKANALYSIS_VehicleNo = "VehicleNo";
        public const string MILKANALYSIS_COB = "RoutNo";
        public const string MILKANALYSIS_Route = "COB";
        public const string MILKANALYSIS_Alcohol = "AlcoholNo";
        public const string MILKANALYSIS_Neutralizer = "Neutralizer";
        public const string MILKANALYSIS_Urea = "Urea";
        public const string MILKANALYSIS_Salt = "Salt";
        public const string MILKANALYSIS_Starch = "Starch";
        public const string MILKANALYSIS_FPD = "FPD";


        public const string MILKANALYSIS_USERID = "UserId";
        public const string MILKANALYSIS_REMARK = "Remark";
        public const string MILKANALYSIS_ISDELETED = "IsDeleted";
        public const string MILKANALYSIS_CREATEDBY = "CreatedBy";
        public const string MILKANALYSIS_CREATEDDATE = "CreatedDate";
        public const string MILKANALYSIS_LASTMODIFIEDBY = "LastModifiedBy";
        public const string MILKANALYSIS_LASTMODIFIEDDATE = "LastModifiedDate";


        private int intId = 0;
        private DateTime dtDate;
        private DateTime dtTime;
        private int intSiloId = 0;
        private string strProductType = string.Empty;
        private string strSampleId = string.Empty;
        private float ftFAT = 0;
        private float ftSNF = 0;
        private float ftSugar = 0;
        private float ftTS = 0;
        private string strAcidity = string.Empty;
        private float ftTemp = 0;
        private string strOT = string.Empty;

        private string strVehicleId = string.Empty;
        private string strVehicleNo = string.Empty;
        private string strRouteNo = string.Empty;
        private string strCob = string.Empty;
        private string strAlcoholNo = string.Empty;
        private string strNeutralizer = string.Empty;
        private string strUrea = string.Empty;
        private string strSalt = string.Empty;
        private string strStarch = string.Empty;
        private string strFPD = string.Empty;
        

        private int intUserId = 0;
        private string strRemark = string.Empty;
        private int intCreatedBy = 0;
        private DateTime dtCreatedDate;
        private int intLastModifiedBy = 0;
        private DateTime dtLastModifiedDate;
        private int intIsDeleted = 0;
        #endregion

        #region ---Properties---
        public int Id
        {
            get { return intId; }
            set { intId = value; }
        }
        public DateTime Date
        {
            get { return dtDate; }
            set { dtDate = value; }
        }
        public DateTime Time
        {
            get { return dtTime; }
            set { dtTime = value; }
        }
        public int SiloId
        {
            get { return intSiloId; }
            set { intSiloId = value; }
        }
        public string ProductType
        {
            get { return strProductType; }
            set { strProductType = value; }
        }
        public string SampleId
        {
            get { return strSampleId; }
            set { strSampleId = value; }
        }
        public float FAT
        {
            get { return ftFAT; }
            set { ftFAT = value; }
        }
        public float SNF
        {
            get { return ftSNF; }
            set { ftSNF = value; }
        }
        public float Sugar
        {
            get { return ftSugar; }
            set { ftSugar = value; }
        }
        public float TS
        {
            get { return ftTS; }
            set { ftTS = value; }
        }
        public string Acidity
        {
            get { return strAcidity; }
            set { strAcidity = value; }
        }
        public float Temp
        {
            get { return ftTemp; }
            set { ftTemp = value; }
        }
        public string OT
        {
            get { return strOT; }
            set { strOT = value; }
        }



        public string VehicleId
        {
            get { return strVehicleId; }
            set { strVehicleId = value; }
        }

        public string VehicleNo
        {
            get { return strVehicleNo; }
            set { strVehicleNo = value; }
        }
        public string RouteNo
        {
            get { return strRouteNo; }
            set { strRouteNo = value; }
        }

        public string COB
        {
            get { return strCob; }
            set { strCob = value; }
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

        public string Starch
        {
            get { return strStarch; }
            set { strStarch = value; }
        }

        public string FPD
        {
            get { return strFPD; }
            set { strFPD = value; }
        }


        public int UserId
        {
            get { return intUserId; }
            set { intUserId = value; }
        }
        public string Remark
        {
            get { return strRemark; }
            set { strRemark = value; }
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
