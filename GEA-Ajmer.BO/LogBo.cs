using System;

namespace GEA_Ajmer.BO
{
    public class LogBo
    {
        #region  Class Properties

        public const string TABLE = "LogReport";
        public const string ID = "Id";
        public const string DATETIME = "DateTime";
        public const string CIRCUIT_NO = "Circuit_No";
        public const string FLOW_SP = "Flow_SP";
        public const string RECIPE_NO = "Recipe_No";
        public const string ROUTE_NO = "Route_No";
        public const string START_TRIG = "Start_Trig";
        public const string STATUS = "Status";
        public const string TANKER_ID = "Tanker_ID";
        public const string ACID_CONC_SP = "Acid_Conc_SP";
        public const string ACID_RETURN_CT = "Acid_Return_CT";
        public const string ACID_RETURN_TEMP = "Acid_Return_Temp";
        public const string ACID_STEP_TIME_SP = "Acid_Step_Time_SP";
        public const string ACID_TEMP_SP = "Acid_Temp_SP";
        public const string ACID_TRIG = "Acid_Trig";
        public const string FINAL_ACID_CONC_SP = "Final_Acid_Conc_SP";
        public const string FINAL_RETURN_CT = "Final_Return_CT";
        public const string FINAL_RETURN_TEMP = "Final_Return_Temp";
        public const string FINAL_STEP_TIME_SP = "Final_Step_Time_SP";
        public const string FINAL_TEMP_SP = "Final_Temp_SP";
        public const string FINAL_TRIG = "Final_Trig";
        public const string INTERMEDIATE_LYE_CONC_SP = "Intermediate_Lye_Conc_SP";
        public const string INTERMEDIATE_RETURN_CT = "Intermediate_Return_CT";
        public const string INTERMEDIATE_RETURN_TEMP = "Intermediate_Return_Temp";
        public const string INTERMEDIATE_STEP_TIME_SP = "Intermediate_Step_Time_SP";
        public const string INTERMEDIATE_TEMP_SP = "Intermediate_Temp_SP";
        public const string INTERMEDIATE_TRIG = "Intermediate_Trig";
        public const string LYE_CONC_SP = "Lye_Conc_SP";
        public const string LYE_RETURN_CT = "Lye_Return_CT";
        public const string LYE_RETURN_TEMP = "Lye_Return_Temp";
        public const string LYE_STEP_TIME_SP = "Lye_Step_Time_SP";
        public const string LYE_TEMP_SP = "Lye_Temp_SP";
        public const string LYE_TRIG = "Lye_Trig";
        public const string STERILISATION_LYE_CONC_SP = "Sterilisation_Lye_Conc_SP";
        public const string STERILISATION_RETURN_CT = "Sterilisation_Return_CT";
        public const string STERILISATION_RETURN_TEMP = "Sterilisation_Return_Temp";
        public const string STERILISATION_STEP_TIME_SP = "Sterilisation_Step_Time_SP";
        public const string STERILISATION_TEMP_SP = "Sterilisation_Temp_SP";
        public const string STERILISATION_TRIG = "Sterilisation_Trig";
        
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



