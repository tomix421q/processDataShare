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

        //10.184.159.108 ASQ5

        public IActionResult Index()
        {
            Models.Asq5_model Asq5Model = new();
            {
                //Predvolené hodnoty pre PLC parametre (FAKE)
                Asq5Model.ROB1_RefValue = 0.0f;
                Asq5Model.ROB1_WeightTolMinus = 0.0f;
                Asq5Model.ROB1_WeightTolPlus = 0.0f;
                Asq5Model.ROB1_WeightActualValue = 0.0f;
                Asq5Model.ROB1_Temperature = 0.0f;
                Asq5Model.ROB1_SetTemperature = 0.0f;
                Asq5Model.ROB1_TimeDrying = 0.0f;
                Asq5Model.MixingTime = 0.0f;
                Asq5Model.ROB1_Downtime_Time = 0;
                Asq5Model.ROB1_FormNumber = 0;
                Asq5Model.ROB1_GoWeightAfter = 0;


                using (var plc = new Plc(CpuType.S71500, "10.184.159.108", 0, 1))

                {


                    try
                    {

                        plc.Open(); //Connect
                        Asq5Model.ROB1_Downtime_Time = ((ushort)plc.Read("DB179.DBW0.0")).ConvertToShort();
                        Asq5Model.ROB1_FormNumber = ((ushort)plc.Read("DB179.DBW2.0")).ConvertToShort();
                        Asq5Model.ROB1_GoWeightAfter = ((ushort)plc.Read("DB179.DBW0.0")).ConvertToShort();
                        Asq5Model.ROB1_RefValue = ((uint)plc.Read("DB179.DBD6.0")).ConvertToFloat();
                        Asq5Model.ROB1_WeightTolMinus = ((uint)plc.Read("DB179.DBD10.0")).ConvertToFloat();
                        Asq5Model.ROB1_WeightTolPlus = ((uint)plc.Read("DB179.DBD14.0")).ConvertToFloat();
                        Asq5Model.ROB1_WeightActualValue = ((uint)plc.Read("DB179.DBD18.0")).ConvertToFloat();
                        Asq5Model.ROB1_Temperature = ((uint)plc.Read("DB179.DBD22.0")).ConvertToFloat();
                        Asq5Model.ROB1_SetTemperature = ((uint)plc.Read("DB179.DBD26.0")).ConvertToFloat();
                        Asq5Model.ROB1_TimeDrying = ((uint)plc.Read("DB179.DBD30.0")).ConvertToFloat();
                        Asq5Model.MixingTime = ((uint)plc.Read("DB179.DBD34.0")).ConvertToFloat();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Chyba pri pripájaní k PLC: " + ex.Message);
                    }





                }

                //ViewBag.ROB1_Downtime_Time = ROB1_Downtime_Time;
                //ViewBag.ROB1_RefValue = ROB1_RefValue;
                //ViewBag.ROB1_WeightTolMinus = ROB1_WeightTolMinus;
                //ViewBag.ROB1_WeightTolPlus = ROB1_WeightTolPlus;
                //ViewBag.ROB1_WeightActualValue = ROB1_WeightActualValue;
                //ViewBag.ROB1_Temperature = ROB1_Temperature;
                //ViewBag.ROB1_SetTemperature = ROB1_SetTemperature;
                //ViewBag.ROB1_TimeDrying = ROB1_TimeDrying;
                //ViewBag.MixingTime = MixingTime;






                ///////////////////////////////////////////////////////////////
                //int rightPart, leftPart, actualStep;
                //short actualDowntime;

                //using (var plc = new Plc(CpuType.S71500, "10.184.159.45", 0, 1))
                //{
                //    plc.Open();

                //    rightPart = ((uint)plc.Read("DB26.DBD2.0")).ConvertToInt();
                //    leftPart = ((uint)plc.Read("DB26.DBD6.0")).ConvertToInt();
                //    actualStep = ((uint)plc.Read("DB26.DBD10.0")).ConvertToInt();
                //    actualStep = ((uint)plc.Read("DB26.DBD10.0")).ConvertToInt();
                //    actualDowntime = ((ushort)plc.Read("DB26.DBW0.0")).ConvertToShort();

                //}


                //ViewBag.pravydiel = rightPart;
                //ViewBag.lavydiel = leftPart;
                //ViewBag.aktualnyKrok = actualStep;
                //ViewBag.prestoj = actualDowntime;

                return View(Asq5Model);

            }
        }
        public IActionResult Asq5()
        {
            Models.Asq5_model Asq5Model = new();
            // Inicializácia modelu a prípadné nastavenie hodnôt
            return View(Asq5Model);
        }
    }
}


