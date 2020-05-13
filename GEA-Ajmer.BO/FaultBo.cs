using System;

namespace GEA_Ajmer.BO
{
    public class FaultBo
    {
        #region Fault Class Properties

        public const string FAULT_TABLE = "FaultTag";
        public const string FAULT_ID = "Id";
        public const string FAULT_TAGNO = "TagNo";
        public const string FAULT_DESCRIPTION = "Description";
        public const string FAULT_TYPE = "Type";
        public const string FAULT_ISDELETED = "IsDeleted";
        public const string FAULT_CREATEDBY = "CreatedBy";
        public const string FAULT_CREATEDDATE = "CreatedDate";
        public const string FAULT_LASTMODIFIEDBY = "LastModifiedBy";
        public const string FAULT_LASTMODIFIEDDATE = "LastModifiedDate";



        private int intId = 0;
        private string strTagNo = string.Empty;
        private string strDescription = string.Empty;
        private int intType = 0;
        private bool boolIsDeleted = false;
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
        public string TagNo
        {
            get { return strTagNo; }
            set { strTagNo = value; }
        }
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }
        public int Type
        {
            get { return intType; }
            set { intType = value; }
        }

        public bool IsDeleted
        {
            get { return boolIsDeleted; }
            set { boolIsDeleted = value; }
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
