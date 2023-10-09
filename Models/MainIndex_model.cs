namespace processDataShare.Models
{
    public class MainIndex_model
    {

        public int ASQ_5_ROB1_Downtime_Time { get; set; }
        public int ASQ_5_ROB2_Downtime_Time { get; set; }
        public int ASQ_6_ROB1_Downtime_Time { get; set; }
        public int ASQ_6_ROB2_Downtime_Time { get; set; }
        public int OpelArmrestFD_actualDowntime { get; set; }


        //connections 
        public string connectionAsq5 { get; set; }
        public string connectionAsq6 { get; set; }
        public string connectionOpelArmrestFd { get; set; }

    }
}
