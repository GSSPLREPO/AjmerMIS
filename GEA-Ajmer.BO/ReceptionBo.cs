using System;

namespace GEA_Ajmer.BO
{
    public class ReceptionBo
    {
        #region Reception Class Properties

        public const string RECEPTION_TABLE = "Reception";
        public const string RECEPTION_RECEPTIONID = "ReceptionId";
        public const string RECEPTION_NAME = "Name";
        public const string RECEPTION_DESCRIPTION = "Description";
        public const string RECEPTION_PLCVALUE = "PLCValue";
        public const string RECEPTION_ISDELETED = "IsDeleted";
        public const string RECEPTION_CREATEDBY = "CreatedBy";
        public const string RECEPTION_CREATEDDATE = "CreatedDate";
        public const string RECEPTION_LASTMODIFIEDBY = "LastModifiedBy";
        public const string RECEPTION_LASTMODIFIEDDATE = "LastModifiedDate";



        private int intReceptionId = 0;
        private string strName = string.Empty;
        private string strDescription = string.Empty;
        private double dblPLCValue = 0.0;
        private int intIsDeleted = 0;
        private int intCreatedBy = 0;
        private DateTime ? dtCreatedDate = null;
        private int intLastModifiedBy = 0;
        private DateTime ? dtLastModifiedDate = null;

        #endregion

        #region ---Properties---
        public int ReceptionId
        {
            get { return intReceptionId; }
            set { intReceptionId = value; }
        }
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
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
