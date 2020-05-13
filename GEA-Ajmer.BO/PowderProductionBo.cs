using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GEA_Ajmer.BO
{
    public class PowderProductionBo
    {
        #region POWDERPRODUCTION Class Properties

        public const string POWDERPRODUCTION_TABLE = "POWDERPRODUCTION";
        public const string POWDERPRODUCTION_ID = "Id";
        public const string POWDERPRODUCTION_DATE = "Date";
        public const string POWDERPRODUCTION_PRODUCTTYPE = "ProductType";
        public const string POWDERPRODUCTION_BATCHNO = "BatchNo";
        public const string POWDERPRODUCTION_PRODUCTIONTIME = "ProductionTime";
        public const string POWDERPRODUCTION_PACKQUANTITY = "PackQuantity";
        public const string POWDERPRODUCTION_TYPEPACKING = "TypeOfPacking";
        public const string POWDERPRODUCTION_NOOFUNITS = "NoOfUnit";
        public const string POWDERPRODUCTION_QUALITYPARAMETER = "QualityParameters";
        public const string POWDERPRODUCTION_REMARK = "Remark";
        public const string MILKANALYSIS_USERID = "UserId";
        public const string POWDERPRODUCTION_ISDELETED = "IsDeleted";
        public const string POWDERPRODUCTION_CREATEDBY = "CreatedBy";
        public const string POWDERPRODUCTION_CREATEDDATE = "CreatedDate";
        public const string POWDERPRODUCTION_LASTMODIFIEDBY = "LastModifiedBy";
        public const string POWDERPRODUCTION_LASTMODIFIEDDATE = "LastModifiedDate";

        private int intId = 0;
        private DateTime dtDate;
        private DateTime dtProductType;
        private string strBatchNo = string.Empty;
        private DateTime dtProductionTime;
        private int intPackQuantity = 0;
        private string strTypePacking = string.Empty;
        private int intNoOfUnits = 0;
        private string strQualityParameter = string.Empty;
        private string strRemark = string.Empty;
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
        public DateTime ProductType
        {
            get { return dtProductType; }
            set { dtProductType = value; }
        }
        public string BatchNo
        {
            get { return strBatchNo; }
            set { strBatchNo = value; }
        }
        public DateTime ProductionTime
        {
            get { return dtProductionTime; }
            set { dtProductionTime = value; }
        }
        public int PackQuantity
        {
            get { return intPackQuantity; }
            set { intPackQuantity = value; }
        }
        public string TypePacking
        {
            get { return strTypePacking; }
            set { strTypePacking = value; }
        }
        public int NoOfUnits
        {
            get { return intNoOfUnits; }
            set { intNoOfUnits = value; }
        }
        public string QualityParameter
        {
            get { return strQualityParameter; }
            set { strQualityParameter = value; }
        }
        public string Remark
        {
            get { return strRemark; }
            set { strRemark = value; }
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
