using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GEA_Ajmer.BO
{
    public class MassBalanceBO
    {
        #region MASSBALANCE Class Properties

        public const string MASSBALANCE_TABLE = "MASSBALANCE";
        public const string MASSBALANCE_ID = "Id";
        public const string MASSBALANCE_DATE = "Date";
        public const string MASSBALANCE_MILKKG = "MilkKg";
        public const string MASSBALANCE_FATMILKKG = "FATMilkKg";
        public const string MASSBALANCE_SNFMILKKG = "SNFMilkKg";
        public const string MASSBALANCE_SUGARMILKKG = "SugarMilkKg";
        public const string MASSBALANCE_QTYOFPOWDER = "QtyOfPowder";
        public const string MASSBALANCE_FATQTY = "FATQty";
        public const string MASSBALANCE_SNFQTY = "SNFQty";
        public const string MASSBALANCE_SUGARQTY = "SugarQty";
        public const string MASSBALANCE_TOTALSOLIDKG = "TotalSolidKG";
        public const string MASSBALANCE_VARIATION = "Variation";
        public const string MASSBALANCE_USERID = "UserId";
        public const string MASSBALANCE_ISDELETED = "IsDeleted";
        public const string MASSBALANCE_CREATEDBY = "CreatedBy";
        public const string MASSBALANCE_CREATEDDATE = "CreatedDate";
        public const string MASSBALANCE_LASTMODIFIEDBY = "LastModifiedBy";
        public const string MASSBALANCE_LASTMODIFIEDDATE = "LastModifiedDate";
      


        private int intId = 0;
        private DateTime? dtDate;
        private float ftMilkKg = 0;
        private float ftFATMilkKg = 0;
        private float ftSNFMilkKg = 0;
        private float ftSugarMilkKg = 0;
        private float ftQtyOfPowder = 0;
        private float ftFATQty = 0;
        private float ftSNFQty = 0;
        private float ftSugarQty = 0;
        private float ftTotalSolidKG = 0;
        private float ftVariation = 0;
        private int intUserID = 0;
        private int intIsDeleted = 0;
        private int intCreatedBy = 0;
        private DateTime? dtCreatedDate;
        private int intLastModifiedBy = 0;
        private DateTime? dtLastModifiedDate;

        #endregion

        #region ---Properties---
        public int Id
        {
            get { return intId; }
            set { intId = value; }
        }
        public DateTime Date
        {
            get { return (DateTime)dtDate; }
            set { dtDate = value; }
        }
        public float MilkKg
        {
            get { return ftMilkKg; }
            set { ftMilkKg = value; }
        }
        public float FATMilkKg
        {
            get { return ftFATMilkKg; }
            set { ftFATMilkKg = value; }
        }
        public float SNFMilkKg
        {
            get { return ftSNFMilkKg; }
            set { ftSNFMilkKg = value; }
        }
        public float SugarMilkKg
        {
            get { return ftSugarMilkKg; }
            set { ftSugarMilkKg = value; }
        }
        public float QtyOfPowder
        {
            get { return ftQtyOfPowder; }
            set { ftQtyOfPowder = value; }
        }
        public float FATQty
        {
            get { return ftFATQty; }
            set { ftFATQty = value; }
        }
        public float SNFQty
        {
            get { return ftSNFQty; }
            set { ftSNFQty = value; }
        }
        public float SugarQty
        {
            get { return ftSugarQty; }
            set { ftSugarQty = value; }
        }
        public float TotalSolidKG
        {
            get { return ftTotalSolidKG; }
            set { ftTotalSolidKG = value; }
        }
        public float Variation
        {
            get { return ftVariation; }
            set { ftVariation = value; }
        }
        public int UserId
        {
            get { return intUserID; }
            set { intUserID = value; }
        }
        public int CreatedBy
        {
            get { return intCreatedBy; }
            set { intCreatedBy = value; }
        }
        public DateTime CreatedDate
        {
            get { return (DateTime)dtCreatedDate; }
            set { dtCreatedDate = value; }
        }
        public int LastModifiedBy
        {
            get { return intLastModifiedBy; }
            set { intLastModifiedBy = value; }
        }
        public DateTime LastModifiedDate
        {
            get { return (DateTime)dtLastModifiedDate; }
            set { dtLastModifiedDate = value; }
        }

        #endregion
    }
}
