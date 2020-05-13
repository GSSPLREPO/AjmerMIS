using System;

namespace GEA_Ajmer.BO
{
   public class Reception_PLCBo
    {
        #region Reception_PLC Class Properties

        public const string RECEPTION_PLC_TABLE = "Reception_PLC";
        public const string RECEPTION_PLC_ID = "Id";
        public const string RECEPTION_PLC_DATETIME = "DateTime";
        public const string RECEPTION_PLC_CH_TEMP = "Ch_Temp";
        public const string RECEPTION_PLC_DEST = "DEST";
        public const string RECEPTION_PLC_LINE_NO = "Line_No";
        public const string RECEPTION_PLC_PRODUCT_TYPE = "Product_Type";
        public const string RECEPTION_PLC_SRC = "SRC";
        public const string RECEPTION_PLC_START_TRIG = "Start_Trig";
        public const string RECEPTION_PLC_TANKER_ID = "Tanker_ID";
        public const string RECEPTION_PLC_TRANSFER_QTY = "Transfer_Qty";
        public const string RECEPTION_PLC_WB_QTY = "WB_Qty";



        private int intId = 0;
        private DateTime dtDateTime;
        private int intTanker_ID = 0;

        #endregion

        #region ---Properties---
        public int Id
        {
            get { return intId; }
            set { intId = value; }
        }
        public DateTime DateTime
        {
            get { return dtDateTime; }
            set { dtDateTime = value; }
        }
        public int Tanker_ID
        {
            get { return intTanker_ID; }
            set { intTanker_ID = value; }
        }

        #endregion
    }
}
