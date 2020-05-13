using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA_Ajmer.BO
{
    public class ProductBo
    {

        #region Product Class Properties

        public const string PRODUCT_TABLE = "Product";
        public const string PRODUCT_PRODUCTID = "ProductId";
        public const string PRODUCT_PRODUCTNAME = "ProductName";
        public const string PRODUCT_PRODUCTTYPE = "ProductType";
        public const string PRODUCT_PRODUCTUNIT = "ProductUnit";
        public const string PRODUCT_PRODUCTPERUNIT = "ProductPerUnit";
        public const string PRODUCT_IDENTIFIERCODE = "IdentifierCode";
        public const string PRODUCT_PRODUCTGROUPID = "ProductGroupId";
        public const string PRODUCT_CATEGORYNAME = "CategoryName";
        public const string PRODUCT_ALIASCODE = "AliasCode";
        public const string PRODUCT_CREATEDBY = "CreatedBy";
        public const string PRODUCT_CREATEDDATE = "CreatedDate";
        public const string PRODUCT_LASTMODIFIEDBY = "LastModifiedBy";
        public const string PRODUCT_LASTMODIFIEDDATE = "LastModifiedDate";
        public const string PRODUCT_ISDELETED = "IsDeleted";




        private int intProductId = 0;
        private string strProductName = string.Empty;
        private string strProductType = string.Empty;
        private string strProductUnit = string.Empty;
        private int intProductPerUnit = 0;
        private int intIdentifierCode = 0;
        private int intProductGroupId = 0;
        private string strCategoryName = string.Empty;
        private int intAliasCode = 0;
        private int intCreatedBy = 0;
        private string strCreatedDate = string.Empty;
        private string strLastModifiedBy = string.Empty;
        private string strLastModifiedDate = string.Empty;
        private int intIsDeleted = 0;

        #endregion

        #region ---Properties---
        public int ProductId
        {
            get { return intProductId; }
            set { intProductId = value; }
        }
        public string ProductName
        {
            get { return strProductName; }
            set { strProductName = value; }
        }
        public string ProductType
        {
            get { return strProductType; }
            set { strProductType = value; }
        }
        public string ProductUnit
        {
            get { return strProductUnit; }
            set { strProductUnit = value; }
        }
        public int ProductPerUnit
        {
            get { return intProductPerUnit; }
            set { intProductPerUnit = value; }
        }
        public int IdentifierCode
        {
            get { return intIdentifierCode; }
            set { intIdentifierCode = value; }
        }
        public int ProductGroupId
        {
            get { return intProductGroupId; }
            set { intProductGroupId = value; }
        }
        public string CategoryName
        {
            get { return strCategoryName; }
            set { strCategoryName = value; }
        }
        public int AliasCode
        {
            get { return intAliasCode; }
            set { intAliasCode = value; }
        }
        public int CreatedBy
        {
            get { return intCreatedBy; }
            set { intCreatedBy = value; }
        }
        public string CreatedDate
        {
            get { return strCreatedDate; }
            set { strCreatedDate = value; }
        }
        public string LastModifiedBy
        {
            get { return strLastModifiedBy; }
            set { strLastModifiedBy = value; }
        }
        public string LastModifiedDate
        {
            get { return strLastModifiedDate; }
            set { strLastModifiedDate = value; }
        }
        public int IsDeleted
        {
            get { return intIsDeleted; }
            set { intIsDeleted = value; }
        }

        #endregion
        
    }
}
