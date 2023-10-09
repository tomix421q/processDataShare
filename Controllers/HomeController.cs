using Microsoft.AspNetCore.Mvc;
using S7.Net;

namespace processDataShare.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            Models.MainIndex_model MainIndexModel = new();
            {

                /////////////////ASQ_5///////////////////// 
                ///

                try
                {
                    using (var plc_asq5 = new Plc(CpuType.S71500, "10.184.159.108", 0, 1))

                    {
                        plc_asq5.Open();
                        if (plc_asq5.IsConnected)
                        {
                            MainIndexModel.connectionAsq5 = "Nepodarilo sa pripojiť k PLC ASQ5.";
                        }
                        else
                        {
                            MainIndexModel.ASQ_5_ROB1_Downtime_Time = ((ushort)plc_asq5.Read("DB179.DBW0.0")).ConvertToShort();
                            MainIndexModel.ASQ_5_ROB2_Downtime_Time = ((ushort)plc_asq5.Read("DB179.DBW20.0")).ConvertToShort();
                        }
                    }
                }
                catch (Exception ex)
                {

                    MainIndexModel.connectionAsq5 = "Nastala chyba pri komunikácii s PLC ASQ5: " + ex.Message;
                }

                /////////////////ASQ_6/////////////////////
                try
                {
                    using (var plc_asq6 = new Plc(CpuType.S71500, "10.184.159.184", 0, 1))

                    {
                        plc_asq6.Open();
                        if (plc_asq6.IsConnected)
                        {
                            MainIndexModel.connectionAsq6 = "Nepodarilo sa pripojiť k PLC ASQ6.";
                        }
                        else
                        {
                            MainIndexModel.ASQ_6_ROB1_Downtime_Time = ((ushort)plc_asq6.Read("DB179.DBW0.0")).ConvertToShort();
                            MainIndexModel.ASQ_6_ROB2_Downtime_Time = ((ushort)plc_asq6.Read("DB179.DBW20.0")).ConvertToShort();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionAsq6 = "Nastala chyba pri komunikácii s PLC ASQ6: " + ex.Message;
                }


                ///////////////Armrest//////////////////////
                try
                {
                    using (var plc_OpelArmrestFd = new Plc(CpuType.S71500, "10.184.159.45", 0, 1))
                    {
                        plc_OpelArmrestFd.Open();
                        if (plc_OpelArmrestFd.IsConnected)
                        {
                            MainIndexModel.OpelArmrestFD_actualDowntime = ((ushort)plc_OpelArmrestFd.Read("DB26.DBW0.0")).ConvertToShort();
                        }
                        else
                        {
                            MainIndexModel.connectionOpelArmrestFd = "Nepodarilo sa pripojiť k PLC opel armrest fd.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionOpelArmrestFd = "Nastala chyba pri komunikácii s PLC opel armrest fd: " + ex.Message;

                }

                return View(MainIndexModel);

            }
        }

        public IActionResult Asq5()
        {
            Models.Asq5_model Asq5Model = new();
            Models.MainIndex_model MainIndexModel = new();
            using (var plc = new Plc(CpuType.S71500, "10.184.159.108", 0, 1))
            {
                plc.Open(); //Connect
                //ROB1
                Asq5Model.ROB1_Downtime_Time = ((ushort)plc.Read("DB179.DBW0.0")).ConvertToShort();
                Asq5Model.ROB1_FormNumber = ((ushort)plc.Read("DB179.DBW2.0")).ConvertToShort();
                Asq5Model.ROB1_WeightActualValue = ((uint)plc.Read("DB179.DBD4.0")).ConvertToFloat();
                Asq5Model.ROB1_Temperature = ((uint)plc.Read("DB179.DBD8.0")).ConvertToFloat();
                Asq5Model.ROB1_SetTemperature = ((uint)plc.Read("DB179.DBD12.0")).ConvertToFloat();
                Asq5Model.ROB1_TimeDrying = ((uint)plc.Read("DB179.DBD16.0")).ConvertToFloat();
                //ROB2
                Asq5Model.ROB2_Downtime_Time = ((ushort)plc.Read("DB179.DBW20.0")).ConvertToShort();
                Asq5Model.ROB2_FormNumber = ((ushort)plc.Read("DB179.DBW22.0")).ConvertToShort();
                Asq5Model.ROB2_WeightActualValue = ((uint)plc.Read("DB179.DBD24.0")).ConvertToFloat();
                Asq5Model.ROB2_Temperature = ((uint)plc.Read("DB179.DBD28.0")).ConvertToFloat();
                Asq5Model.ROB2_SetTemperature = ((uint)plc.Read("DB179.DBD32.0")).ConvertToFloat();
                Asq5Model.ROB2_TimeDrying = ((uint)plc.Read("DB179.DBD36.0")).ConvertToFloat();
                //Global
                Asq5Model.Global_RefValue = ((uint)plc.Read("DB179.DBD40.0")).ConvertToFloat();
                Asq5Model.Global_WeightTolMinus = ((uint)plc.Read("DB179.DBD44.0")).ConvertToFloat();
                Asq5Model.Global_WeightTolPlus = ((uint)plc.Read("DB179.DBD48.0")).ConvertToFloat();
                Asq5Model.Global_MixingTime = ((uint)plc.Read("DB179.DBD54.0")).ConvertToFloat();
                Asq5Model.Global_GoWeightAfter = ((ushort)plc.Read("DB179.DBW0.0")).ConvertToShort();
            }
            return View(Asq5Model);
        }

        public IActionResult OpelArmrestFD()
        {
            Models.OpelArmrestFront_model OpelArmrestFDmodel = new();
            Models.MainIndex_model MainIndexModel = new();
            using (var plc = new Plc(CpuType.S71500, "10.184.159.45", 0, 1))
            {
                plc.Open();

                OpelArmrestFDmodel.rightPart = ((uint)plc.Read("DB26.DBD2.0")).ConvertToInt();
                OpelArmrestFDmodel.leftPart = ((uint)plc.Read("DB26.DBD6.0")).ConvertToInt();
                OpelArmrestFDmodel.actualStep = ((uint)plc.Read("DB26.DBD10.0")).ConvertToInt();
                OpelArmrestFDmodel.actualDowntime = ((ushort)plc.Read("DB26.DBW0.0")).ConvertToShort();
            }
            return View(OpelArmrestFDmodel);
        }


    }
}


