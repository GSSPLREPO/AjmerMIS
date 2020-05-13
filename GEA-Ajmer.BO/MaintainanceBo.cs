using System;

namespace GEA_Ajmer.BO
{
    public class MaintainanceBo
    {
        #region Maintainance Class Properties

        public const string MAINTAINANCE_TABLE = "Maintainance";
        public const string MAINTAINANCE_ID = "Id";
        public const string MAINTAINANCE_EQUIPMENTTAGNO = "EquipmentTagNo";
        public const string MAINTAINANCE_EQUIPMENTNAME = "EquipmentName";
        public const string MAINTAINANCE_MAINTAINANCEDATE = "MaintainanceDate";
        public const string MAINTAINANCE_STARTTIME = "StartTime";
        public const string MAINTAINANCE_ENDTIME = "EndTime";
        public const string MAINTAINANCE_PARTNO = "PartNo";
        public const string MAINTAINANCE_PARTNAME = "PartName";
        public const string MAINTAINANCE_SECTION = "Section";
        public const string MAINTAINANCE_ACTIONTAKEN = "ActionTaken";
        public const string MAINTAINANCE_RECTIFIEDBY = "RectifiedBy";
        public const string MAINTAINANCE_REMARK = "Remark";
        public const string MAINTAINANCE_STATUS = "Status";
        public const string MAINTAINANCE_CAUSE = "Cause";
        public const string MAINTAINANCE_DEPARTMENT = "Department";
        public const string MAINTAINANCE_AREA = "Area";
        public const string MAINTAINANCE_DETAILBREAKDOWN = "DetailBreakdown";
        public const string MAINTAINANCE_APPROVEDBY = "ApprovedBy";
        public const string MAINTAINANCE_ISDELETED = "IsDeleted";
        public const string MAINTAINANCE_USERID = "UserId";
        public const string MAINTAINANCE_CREATEDBY = "CreatedBy";
        public const string MAINTAINANCE_CREATEDDATE = "CreatedDate";
        public const string MAINTAINANCE_LASTMODIFIEDBY = "LastModifiedBy";
        public const string MAINTAINANCE_LASTMODIFIEDDATE = "LastModifiedDate";
        public const string MAINTAINANCE_ISBREAKDOWN = "IsBreackDown";
        public const string MAINTAINANCE_DUEDDATE = "DueDate";
        public const string MAINTAINANCE_NEXTDUEDATE = "NextDueDate";



        private int intId = 0;
        private string strEquipmentTagNo = string.Empty;
        private string strEquipmentName = string.Empty;
        private DateTime? dtMaintainanceDate;
        private DateTime? dtStartTime;
        private DateTime? dtEndTime;
        private string strPartNo = string.Empty;
        private string strPartName = string.Empty;
        private string strSection = string.Empty;
        private string strActionTaken = string.Empty;
        private string strRectifiedBy = string.Empty;
        private string strRemark = string.Empty;
        private string strStatus = string.Empty;
        private string strCause = string.Empty;
        private string strArea = string.Empty;
        private string strDepartment = string.Empty;
        private string strDetailBreakDown = string.Empty;
        private int intType = 0;
        private int intUserId = 0;
        private int intApprovedBy = 0;
        private int intIsDeleted = 0;
        private int intCreatedBy = 0;
        private DateTime? dtCreatedDate;
        private int intLastModifiedBy = 0;
        private DateTime? dtLastModifiedDate;
        private int intIsBreakDown;
        private DateTime? dtDueDate;
        private DateTime? dtNextDueDate;

        #endregion

        #region ---Properties---
        public int Id
        {
            get { return intId; }
            set { intId = value; }
        }
        public string EquipmentTagNo
        {
            get { return strEquipmentTagNo; }
            set { strEquipmentTagNo = value; }
        }
        public string EquipmentName
        {
            get { return strEquipmentName; }
            set { strEquipmentName = value; }
        }
        public DateTime MaintainanceDate
        {
            get { return (DateTime)dtMaintainanceDate; }
            set { dtMaintainanceDate = value; }
        }
        public DateTime StartTime
        {
            get { return (DateTime)dtStartTime; }
            set { dtStartTime = value; }
        }
        public DateTime EndTime
        {
            get { return (DateTime)dtEndTime; }
            set { dtEndTime = value; }
        }
        public string PartNo
        {
            get { return strPartNo; }
            set { strPartNo = value; }
        }
        public string PartName
        {
            get { return strPartName; }
            set { strPartName = value; }
        }
        public string Section
        {
            get { return strSection; }
            set { strSection = value; }
        }
        public string ActionTaken
        {
            get { return strActionTaken; }
            set { strActionTaken = value; }
        }
        public string RectifiedBy
        {
            get { return strRectifiedBy; }
            set { strRectifiedBy = value; }
        }
        public string Remark
        {
            get { return strRemark; }
            set { strRemark = value; }
        }
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }
        public string Cause
        {
            get { return strCause; }
            set { strCause = value; }
        }
        public string Area
        {
            get { return strArea; }
            set { strArea = value; }
        }
        public string Department
        {
            get { return strDepartment; }
            set { strDepartment = value; }
        }
        public string DetailBreakDown
        {
            get { return strDetailBreakDown; }
            set { strDetailBreakDown = value; }
        }
        public int UserId
        {
            get { return intUserId; }
            set { intUserId = value; }
        }
        public int Type
        {
            get { return intType; }
            set { intType = value; }
        }
        public int ApprovedBy
        {
            get { return intApprovedBy; }
            set { intApprovedBy = value; }
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

        public int IsBreackDown
        {
            get { return intIsBreakDown; }
            set { intIsBreakDown = value; }
        }

        public DateTime DueDate
        {
            get { return (DateTime)dtDueDate; }
            set { dtDueDate = value; }
        }
        public DateTime NextDueDate
        {
            get { return (DateTime)dtNextDueDate; }
            set { dtNextDueDate = value; }
        }
        #endregion
    }
}
