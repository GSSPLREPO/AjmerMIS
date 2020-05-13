using System;

namespace GEA_Ajmer.BO
{
    public class ProgramBo
    {
        #region PROGRAM Class Properties

        public const string PROGRAM_TABLE = "PROGRAM";
        public const string PROGRAM_ID = "Id";
        public const string PROGRAM_NAME = "Name";
        public const string PROGRAM_PLCVALUE = "PLCValue";
        public const string PROGRAM_ISDELETED = "IsDeleted";
        public const string PROGRAM_CREATEDBY = "CreatedBy";
        public const string PROGRAM_CREATEDDATE = "CreatedDate";
        public const string PROGRAM_LASTMODIFIEDBY = "LastModifiedBy";
        public const string PROGRAM_LASTMODIFIEDDATE = "LastModifiedDate";

        private int intId = 0;
        private string strName = string.Empty;
        private double dblPLCValue = 0.0;
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



