using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GEA_Ajmer.BO
{
    public class ProductDispatchBo
    {
        #region PRODUCTDISPATCH Class Properties

        public const string PRODUCTDISPATCH_TABLE = "ProductDispatch";
        public const string PRODUCTDISPATCH_ID = "Id";
        public const string PRODUCTDISPATCH_DATE= "Date";
        public const string PRODUCTDISPATCH_TIME = "Time";
        public const string PRODUCTDISPATCH_DELIVERYCHALLAN = "DeliveryChallan";
        public const string PRODUCTDISPATCH_VEHICLENO = "VehicleNo";
        public const string PRODUCTDISPATCH_BATCHNO = "BatchNo";
        public const string PRODUCTDISPATCH_BAGNOS = "BagNos";
        public const string PRODUCTDISPATCH_PRODUCTTYPE = "ProductType";
        public const string PRODUCTDISPATCH_FAT = "FAT";
        public const string PRODUCTDISPATCH_MOISTURE = "Moisture";
        public const string PRODUCTDISPATCH_ACIDITY = "Acidity";
        public const string PRODUCTDISPATCH_QUALITYPARAMETER = "QualityParamter";
        public const string PRODUCTDISPATCH_QTYDISPATCH = "QtyDispatch";
        public const string PRODUCTDISPATCH_DESPATCHEDTO = "DespatchedTo";
        public const string PRODUCTDISPATCH_USERID = "UserId";
        public const string PRODUCTDISPATCH_ISDELETED = "IsDeleted";
        public const string PRODUCTDISPATCH_CREATEDBY = "CreatedBy";
        public const string PRODUCTDISPATCH_CREATEDDATE = "CreatedDate";
        public const string PRODUCTDISPATCH_LASTMODIFIEDBY = "LastModifiedBy";
        public const string PRODUCTDISPATCH_LASTMODIFIEDDATE = "LastModifiedDate";


        private int intId = 0;
        private DateTime dtDate;
        private DateTime dtTime;
        private string strDeliveryChallan = string.Empty;
        private string strVehicleNo = string.Empty;
        private string strBatchNo = string.Empty;
        private int intBagNos = 0;
        private string strProductType = string.Empty;
        private float ftFAT = 0;
        private float ftMoisture = 0;
        private string strAcidity = string.Empty;
        private string strQualityParamter = string.Empty;
        private string strQtyDispatch = string.Empty;
        private string strDespatchedTo = string.Empty;
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
            set { dtDate= value; }
        }

        public DateTime Time
        {
            get { return dtTime; }
            set { dtTime = value; }
        }
        public string DeliveryChallan
        {
            get { return strDeliveryChallan; }
            set { strDeliveryChallan = value; }
        }
        public string VehicleNo
        {
            get { return strVehicleNo; }
            set { strVehicleNo = value; }
        }
        public string BatchNo
        {
            get { return strBatchNo; }
            set { strBatchNo = value; }
        }
        public string ProductType
        {
            get { return strProductType; }
            set { strProductType = value; }
        }
        public int BagNos
        {
            get { return intBagNos; }
            set { intBagNos = value; }
        }
        public float FAT
        {
            get { return ftFAT; }
            set { ftFAT = value; }
        }
        public float Moisture
        {
            get { return ftMoisture; }
            set { ftMoisture = value; }
        }
        public string Acidity
        {
            get { return strAcidity; }
            set { strAcidity = value; }
        }
        public string QualityParamter
        {
            get { return strQualityParamter; }
            set { strQualityParamter = value; }
        }

        public string QtyDispatch
        {
            get { return strQtyDispatch; }
            set { strQtyDispatch = value; }
        }
        public string DespatchedTo
        {
            get { return strDespatchedTo; }
            set { strDespatchedTo = value; }
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
