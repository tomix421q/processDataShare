using Microsoft.AspNetCore.Mvc;
using S7.Net;
using System.Security.Cryptography.X509Certificates;

namespace processDataShare.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //10.184.159.108 ASQ5

        public IActionResult Index()
        {
            Models.Asq5_model Asq5Model = new();
            Models.OpelArmrestFront_model OpelArmrestFDmodel = new();
            Models.MainIndex_model MainIndexModel = new();
            {
                /////////////FAKE////////////////////////
                //Asq5Model.ROB1_RefValue = 0.0f;
                //Asq5Model.ROB1_WeightTolMinus = 0.0f;
                //Asq5Model.ROB1_WeightTolPlus = 0.0f;
                //Asq5Model.ROB1_WeightActualValue = 0.0f;
                //Asq5Model.ROB1_Temperature = 0.0f;
                //Asq5Model.ROB1_SetTemperature = 0.0f;
                //Asq5Model.ROB1_TimeDrying = 0.0f;
                //Asq5Model.MixingTime = 0.0f;
                //Asq5Model.ROB1_Downtime_Time = 0;
                //Asq5Model.ROB1_FormNumber = 0;
                //Asq5Model.ROB1_GoWeightAfter = 0;


                /////////////////ASQ_5/////////////////////
                using (var plc = new Plc(CpuType.S71500, "10.184.159.108", 0, 1))
                {
                        plc.Open(); 
                   
                        MainIndexModel.ASQ_5_ROB1_Downtime_Time = ((ushort)plc.Read("DB179.DBW0.0")).ConvertToShort();
                        MainIndexModel.ASQ_5_ROB2_Downtime_Time = ((ushort)plc.Read("DB179.DBW20.0")).ConvertToShort();

                }

                /////////////////ASQ_6/////////////////////
                using (var plc = new Plc(CpuType.S71500, "10.184.159.184", 0, 1))
                {
                    plc.Open();
                    MainIndexModel.ASQ_6_ROB1_Downtime_Time = ((ushort)plc.Read("DB179.DBW0.0")).ConvertToShort();
                    MainIndexModel.ASQ_6_ROB2_Downtime_Time = ((ushort)plc.Read("DB179.DBW20.0")).ConvertToShort();

                }

                ///////////////Armrest//////////////////////

                using (var plc = new Plc(CpuType.S71500, "10.184.159.45", 0, 1))
                {
                    plc.Open();
                    MainIndexModel.OpelArmrestFD_actualDowntime = ((ushort)plc.Read("DB26.DBW0.0")).ConvertToShort();
                }
                return View(MainIndexModel);

              

            }
        }


        public IActionResult Asq5()
        {
            Models.Asq5_model Asq5Model = new();
            // Inicializácia modelu a prípadné nastavenie hodnôt
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


