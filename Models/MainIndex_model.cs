namespace processDataShare.Models
{
    public class MainIndex_model
    {
        //_______________ASQ_MODELS________________
        public int ASQ_1_ROB1_Downtime_Time { get; set; }
        public int ASQ_1_ROB2_Downtime_Time { get; set; }
        public int ASQ_2_ROB1_Downtime_Time { get; set; }
        public int ASQ_2_ROB2_Downtime_Time { get; set; }
        public int ASQ_3_ROB1_Downtime_Time { get; set; }
        public int ASQ_3_ROB2_Downtime_Time { get; set; }
        public int ASQ_4_ROB1_Downtime_Time { get; set; }
        public int ASQ_4_ROB2_Downtime_Time { get; set; }
        public int ASQ_5_ROB1_Downtime_Time { get; set; }
        public int ASQ_5_ROB2_Downtime_Time { get; set; }
        public int ASQ_6_ROB1_Downtime_Time { get; set; }
        public int ASQ_6_ROB2_Downtime_Time { get; set; }
        //connections 
        public string connectionAsq1 { get; set; }
        public string connectionAsq2 { get; set; }
        public string connectionAsq3 { get; set; }
        public string connectionAsq4 { get; set; }
        public string connectionAsq5 { get; set; }
        public string connectionAsq6 { get; set; }

        //_____________Opel_Armrest______________
        public int OpelArmrestFD_actualDowntime { get; set; }


        //connections
        public string connectionOpelArmrestFd { get; set; }
    }
}
