using System;

namespace GEA_Ajmer.BO
{
    public class RouteBo
    {
        #region Route Class Properties

        public const string ROUTE_TABLE = "Routes";
        public const string ROUTE_ID = "Id";
        public const string ROUTE_ROUTENO = "RouteNo";
        public const string ROUTE_ROUTENAME = "RouteName";
        public const string ROUTE_PLCVALUE = "PLCValue";
        public const string ROUTE_DESCRIPTION = "Description";
        public const string ROUTE_ISDELETED = "IsDeleted";
        public const string ROUTE_CREATEDBY = "CreatedBy";
        public const string ROUTE_CREATEDDATE = "CreatedDate";
        public const string ROUTE_LASTMODIFIEDBY = "LastModifiedBy";
        public const string ROUTE_LASTMODIFIEDDATE = "LastModifiedDate";



        private int intId = 0;
        private string intRouteNo = string.Empty;
        private string strRouteName = string.Empty;
        private string strDescription = string.Empty;
        private int intCreatedBy = 0;
        private double dblPLCValue = 0.0;
        private int intIsDeleted = 0;
        private DateTime ? dtCreatedDate;
        private int intLastModifiedBy = 0;
        private DateTime ? dtLastModifiedDate;

        #endregion

        #region ---Properties---
        public int Id
        {
            get { return intId; }
            set { intId = value; }
        }
        public string RouteNo
        {
            get { return intRouteNo; }
            set { intRouteNo = value; }
        }
        public string RouteName
        {
            get { return strRouteName; }
            set { strRouteName = value; }
        }
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }
        public int CreatedBy
        {
            get { return intCreatedBy; }
            set { intCreatedBy = value; }
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
