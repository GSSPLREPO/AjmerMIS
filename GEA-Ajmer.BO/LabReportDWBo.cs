using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GEA_Ajmer.BO
{
    public class LabReportDWBo
    {
        #region LABREPORTDW Class Properties

        public const string LABREPORTDW_TABLE = "LABREPORTDW";
        public const string LABREPORTDW_ID = "Id";
        public const string LABREPORTDW_DATE = "Date";
        public const string LABREPORTDW_TYPEOFPOWDER = "TypeOfPowder";
        public const string LABREPORTDW_TIME = "Time";
        public const string LABREPORTDW_BATCHNO = "BatchNo";
        public const string LABREPORTDW_BAGNOS = "BagNo";
        public const string LABREPORTDW_WEIGHT = "Weight";
        public const string LABREPORTDW_APPEARANCE = "Appearance";
        public const string LABREPORTDW_MOISTURE = "Moisture";
        public const string LABREPORTDW_SUGAR = "Sugar";
        public const string LABREPORTDW_ACIDITY = "Acidity";
        public const string LABREPORTDW_TOTALSOLID = "TotalSolid";
        public const string LABREPORTDW_BULKDENSITY = "BulkDensity";
        public const string LABREPORTDW_MILKFAT = "MilkFat";
        public const string LABREPORTDW_WETTABILITY = "Wettability";
        public const string LABREPORTDW_SCORCHEDPARTICLE = "ScorchedParticle";
        public const string LABREPORTDW_SOLINDEX = "SolIndex";
        public const string LABREPORTDW_COFFETEST = "CoffeTest";
        public const string LABREPORTDW_FLAVOUR = "Flavour";
        public const string LABREPORTDW_PROTEIN = "Protein";
        public const string LABREPORTDW_ASH = "ASH";
        public const string LABREPORTDW_LUMPINESS = "Lumpiness";
        public const string LABREPORTDW_ADULTRATION = "Adultration";
        public const string LABREPORTDW_USERID = "UserId";
        public const string LABREPORTDW_ISDELETED = "IsDeleted";
        public const string LABREPORTDW_CREATEDBY = "CreatedBy";
        public const string LABREPORTDW_CREATEDDATE = "CreatedDate";
        public const string LABREPORTDW_LASTMODIFIEDBY = "LastModifiedBy";
        public const string LABREPORTDW_LASTMODIFIEDDATE = "LastModifiedDate";


        private int intId = 0;
        private DateTime dtDate;
        private string strTypeOfPowder = string.Empty;
        private DateTime dtTime;
        private string strBatchNo = string.Empty;
        private int intBagNos = 0;
        private float ftWeight = 0;
        private string strAppearance = string.Empty;
        private float ftMoisture = 0;
        private float ftTotalSolid = 0;
        private float ftBulkDensity = 0;
        private float ftMilkFat = 0;
        private float ftSugar= 0;
        private string strAcidity = string.Empty;
        private string strWettability = string.Empty;
        private string strScorchedParticle = string.Empty;
        private string strSolIndex = string.Empty;
        private string strCoffeTest = string.Empty;
        private string strFlavour = string.Empty;
        private float ftProtein = 0;
        private float ftASH = 0;
        private string strLumpiness = string.Empty;
        private string strAdultration = string.Empty;
        private int intUserId = 0;
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
        public string TypeOfPowder
        {
            get { return strTypeOfPowder; }
            set { strTypeOfPowder = value; }
        }
        public DateTime Time
        {
            get { return dtTime; }
            set { dtTime = value; }
        }
        public string BatchNo
        {
            get { return strBatchNo; }
            set { strBatchNo = value; }
        }
        public int BagNos
        {
            get { return intBagNos; }
            set { intBagNos = value; }
        }
        public float Weight
        {
            get { return ftWeight; }
            set { ftWeight = value; }
        }
        public string Appearance
        {
            get { return strAppearance; }
            set { strAppearance = value; }
        }
        public float TotalSolid
        {
            get { return ftTotalSolid; }
            set { ftTotalSolid = value; }
        }
        public float Moisture
        {
            get { return ftMoisture; }
            set { ftMoisture = value; }
        }
        public float BulkDensity
        {
            get { return ftBulkDensity; }
            set { ftBulkDensity = value; }
        }
        public float MilkFat
        {
            get { return ftMoisture; }
            set { ftMoisture = value; }
        }
        public float Sugar
        {
            get { return ftSugar; }
            set { ftSugar = value; }
        }
        public string Acidity
        {
            get { return strAcidity; }
            set { strAcidity = value; }
        }
        public string Wettability
        {
            get { return strWettability; }
            set { strWettability = value; }
        }
        public string ScorchedParticle
        {
            get { return strScorchedParticle; }
            set { strScorchedParticle = value; }
        }
        public string SolIndex
        {
            get { return strSolIndex; }
            set { strSolIndex = value; }
        }
        public string CoffeTest
        {
            get { return strCoffeTest; }
            set { strCoffeTest = value; }
        }
        public string Flavour
        {
            get { return strFlavour; }
            set { strFlavour = value; }
        }
        public float Protein
        {
            get { return ftProtein; }
            set { ftProtein = value; }
        }
        public float ASH
        {
            get { return ftASH; }
            set { ftASH = value; }
        }
        public string Lumpiness
        {
            get { return strLumpiness; }
            set { strLumpiness = value; }
        }
        public string Adultration
        {
            get { return strAdultration; }
            set { strAdultration = value; }
        }
        public int UserId
        {
            get { return intUserId; }
            set { intUserId = value; }
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
