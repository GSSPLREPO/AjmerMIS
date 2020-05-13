using System;

namespace GEA_Ajmer.BO
{
    public class SiloBo
    {
        #region SILO Class Properties

        public const string SILO_TABLE = "SILO";
        public const string SILO_SILOID = "SILOID";
        public const string SILO_NAME = "Name";
        public const string SILO_PLCVALUE = "PLCValue";
        public const string SILO_ISDELETED = "IsDeleted";
        public const string SILO_CREATEDBY = "CreatedBy";
        public const string SILO_CREATEDDATE = "CreatedDate";
        public const string SILO_LASTMODIFIEDBY = "LastModifiedBy";
        public const string SILO_LASTMODIFIEDDATE = "LastModifiedDate";

        private int intSILOID = 0;
        private string strName = string.Empty;
        private double dblPLCValue = 0.0;
        private int intIsDeleted = 0;
        private int intCreatedBy = 0;
        private int intLastModifiedBy = 0;
        private DateTime? dtLastModifiedDate = null;
        private DateTime? dtCreatedDate = null;

        #endregion

        #region ---Properties---
        public int SILOID
        {
            get { return intSILOID; }
            set { intSILOID = value; }
        }
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }
        public double PLCValue
        {
            get { return dblPLCValue; }
            set { dblPLCValue = value; }
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
        public DateTime CreatedDate
        {
            get { return (DateTime)dtCreatedDate; }
            set { dtCreatedDate = value; }
        }

        #endregion
    }
}
