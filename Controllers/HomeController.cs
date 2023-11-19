
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using processDataShare.Models;
using S7.Net;
using System.Reflection;

namespace processDataShare.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Models.MainIndex_model MainIndexModel = await LoadPLCData(); // nacitat data plc                    
            return View();
        }            //view

        [HttpGet]
        public async Task<JsonResult> JsonMainIndex()
        {
            Models.MainIndex_model MainIndexModel = await LoadPLCData(); // nacitat data plc (ajax)
            return Json(MainIndexModel);
        }     //json ajax

        private async Task<Models.MainIndex_model> LoadPLCData()
        {

            Models.MainIndex_model MainIndexModel = new();
            //___________________________________ASQ_____________________________________
            PlcResult asq1A_result = await ReadDowntimeFromPlcAsync("10.184.159.241", "DB179.DBW0.0");
            PlcResult asq1B_result = await ReadDowntimeFromPlcAsync("10.184.159.241", "DB179.DBW20.0");
            MainIndexModel.ASQ_1_ROB1_Downtime_Time = asq1A_result.Value;
            MainIndexModel.ASQ_1_ROB2_Downtime_Time = asq1B_result.Value;
            MainIndexModel.connectionAsq1 = asq1A_result.Connection;

            PlcResult asq2A_result = await ReadDowntimeFromPlcAsync("10.184.159.109", "DB179.DBW0.0");
            PlcResult asq2B_result = await ReadDowntimeFromPlcAsync("10.184.159.109", "DB179.DBW20.0");
            MainIndexModel.ASQ_2_ROB1_Downtime_Time = asq2A_result.Value;
            MainIndexModel.ASQ_2_ROB2_Downtime_Time = asq2B_result.Value;
            MainIndexModel.connectionAsq2 = asq2A_result.Connection;

            PlcResult asq3A_result = await ReadDowntimeFromPlcAsync("10.184.159.240", "DB179.DBW0.0");
            PlcResult asq3B_result = await ReadDowntimeFromPlcAsync("10.184.159.240", "DB179.DBW20.0");
            MainIndexModel.ASQ_3_ROB1_Downtime_Time = asq3A_result.Value;
            MainIndexModel.ASQ_3_ROB2_Downtime_Time = asq3B_result.Value;
            MainIndexModel.connectionAsq3 = asq3A_result.Connection;

            PlcResult asq4A_result = await ReadDowntimeFromPlcAsync("10.184.159.12", "DB179.DBW0.0");
            PlcResult asq4B_result = await ReadDowntimeFromPlcAsync("10.184.159.12", "DB179.DBW20.0");
            MainIndexModel.ASQ_4_ROB1_Downtime_Time = asq4A_result.Value;
            MainIndexModel.ASQ_4_ROB2_Downtime_Time = asq4B_result.Value;
            MainIndexModel.connectionAsq4 = asq4A_result.Connection;

            PlcResult asq5A_result = await ReadDowntimeFromPlcAsync("10.184.159.108", "DB179.DBW0.0");
            PlcResult asq5B_result = await ReadDowntimeFromPlcAsync("10.184.159.108", "DB179.DBW20.0");
            MainIndexModel.ASQ_5_ROB1_Downtime_Time = asq5A_result.Value;
            MainIndexModel.ASQ_5_ROB2_Downtime_Time = asq5B_result.Value;
            MainIndexModel.connectionAsq5 = asq5A_result.Connection;

            PlcResult asq6A_result = await ReadDowntimeFromPlcAsync("10.184.159.184", "DB179.DBW0.0");
            PlcResult asq6B_result = await ReadDowntimeFromPlcAsync("10.184.159.184", "DB179.DBW20.0");
            MainIndexModel.ASQ_6_ROB1_Downtime_Time = asq6A_result.Value;
            MainIndexModel.ASQ_6_ROB2_Downtime_Time = asq6B_result.Value;
            MainIndexModel.connectionAsq6 = asq6A_result.Connection;
            //________________________________OPEL____________________________________
            PlcResult opelArmrestFD_result = await ReadDowntimeFromPlcAsync("10.184.159.45", "DB26.DBW0.0");
            MainIndexModel.OpelArmrestFD_actualDowntime = opelArmrestFD_result.Value;
            MainIndexModel.connectionOpelArmrestFd = opelArmrestFD_result.Connection;

            PlcResult opelArmrestRD_result = await ReadDowntimeFromPlcAsync("10.184.159.46", "DB26.DBW0.0");
            MainIndexModel.OpelArmrestRD_actualDowntime = opelArmrestRD_result.Value;
            MainIndexModel.connectionOpelArmrestRd = opelArmrestRD_result.Connection;

            PlcResult opelInsertFD_result = await ReadDowntimeFromPlcAsync("10.184.159.48", "DB26.DBW0.0");
            MainIndexModel.OpelInsertFD_actualDowntime = opelInsertFD_result.Value;
            MainIndexModel.connectionOpelInsertFd = opelInsertFD_result.Connection;

            PlcResult opelInsertRD_result = await ReadDowntimeFromPlcAsync("10.184.159.47", "DB26.DBW0.0");
            MainIndexModel.OpelInsertRD_actualDowntime = opelInsertRD_result.Value;
            MainIndexModel.connectionOpelInsertRd = opelInsertRD_result.Connection;
            //__________________________________MFEQC___________________________________
            PlcResult MF1_result = await ReadDowntimeFromPlcAsync("10.184.159.173", "DB189.DBW0.0");
            MainIndexModel.EqcMF1_actualDownTime = MF1_result.Value;
            MainIndexModel.connectionEqcMF1 = MF1_result.Connection;

            PlcResult MF2_result = await ReadDowntimeFromPlcAsync("10.184.159.174", "DB189.DBW0.0");
            MainIndexModel.EqcMF2_actualDownTime = MF2_result.Value;
            MainIndexModel.connectionEqcMF2 = MF2_result.Connection;

            PlcResult MF3_result = await ReadDowntimeFromPlcAsync("10.184.159.175", "DB189.DBW0.0");
            MainIndexModel.EqcMF3_actualDownTime = MF3_result.Value;
            MainIndexModel.connectionEqcMF3 = MF3_result.Connection;

            PlcResult MF4_result = await ReadDowntimeFromPlcAsync("10.184.159.176", "DB189.DBW0.0");
            MainIndexModel.EqcMF4_actualDownTime = MF4_result.Value;
            MainIndexModel.connectionEqcMF4 = MF4_result.Connection;

            PlcResult MF5_result = await ReadDowntimeFromPlcAsync("10.184.159.89", "DB189.DBW0.0");
            MainIndexModel.EqcMF5_actualDownTime = MF5_result.Value;
            MainIndexModel.connectionEqcMF5 = MF5_result.Connection;

            PlcResult MF6_result = await ReadDowntimeFromPlcAsync("10.184.159.99", "DB189.DBW0.0");
            MainIndexModel.EqcMF6_actualDownTime = MF6_result.Value;
            MainIndexModel.connectionEqcMF6 = MF6_result.Connection;

            PlcResult MF7_result = await ReadDowntimeFromPlcAsync("10.184.159.171", "DB189.DBW0.0");
            MainIndexModel.EqcMF7_actualDownTime = MF7_result.Value;
            MainIndexModel.connectionEqcMF7 = MF7_result.Connection;

            PlcResult MF8_result = await ReadDowntimeFromPlcAsync("10.184.159.101", "DB189.DBW0.0");
            MainIndexModel.EqcMF8_actualDownTime = MF8_result.Value;
            MainIndexModel.connectionEqcMF8 = MF8_result.Connection;

            // ... 

            return MainIndexModel;

        }     //load data into ReadDowntimeFromPlcAsync

        public class PlcResult
        {
            public int Value { get; set; }
            public string Connection { get; set; }
        }           //template for result from ReadDowntimeFromPlcAsync

        private async Task<PlcResult> ReadDowntimeFromPlcAsync(string ipAddress, string dbAddress)
        {
            PlcResult result = new PlcResult();
            try
            {
                using (var plc = new Plc(CpuType.S71500, ipAddress, 0, 1))
                {
                    await plc.OpenAsync();
                    result.Value = ((ushort)await plc.ReadAsync(dbAddress)).ConvertToShort();
                }
            }
            catch (Exception ex)
            {
                result.Connection = ex.Message;

            }
            return result;
        }      //reusable connect for plc








    }
}

























