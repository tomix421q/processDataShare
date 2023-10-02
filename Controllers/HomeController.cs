using Microsoft.AspNetCore.Mvc;
//using myFirstApp.Models;
using S7.Net;
using System.Data;
using System.Diagnostics;


namespace myFirstApp.Controllers
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
            {
                //10.184.159.108 ASQ5
                float ROB1_RefValue, ROB1_WeightTolMinus, ROB1_WeightTolPlus, ROB1_WeightActualValue, ROB1_Temperature, ROB1_SetTemperature, ROB1_TimeDrying, MixingTime;

                int ROB1_Downtime_Time, ROB1_FormNumber, ROB1_GoWeightAfter;

                using (var plc = new Plc(CpuType.S71500, "10.184.159.108", 0, 1))
                {
                    plc.Open(); //Connect?

                    ROB1_Downtime_Time = ((ushort)plc.Read("DB179.DBW0.0")).ConvertToShort();
                    ROB1_FormNumber = ((ushort)plc.Read("DB179.DBW2.0")).ConvertToShort();
                    ROB1_GoWeightAfter = ((ushort)plc.Read("DB179.DBW0.0")).ConvertToShort();

                    ROB1_RefValue = ((uint)plc.Read("DB179.DBD6.0")).ConvertToFloat();
                    ROB1_WeightTolMinus = ((uint)plc.Read("DB179.DBD10.0")).ConvertToFloat();
                    ROB1_WeightTolPlus = ((uint)plc.Read("DB179.DBD14.0")).ConvertToFloat();
                    ROB1_WeightActualValue = ((uint)plc.Read("DB179.DBD18.0")).ConvertToFloat();
                    ROB1_Temperature = ((uint)plc.Read("DB179.DBD22.0")).ConvertToFloat();
                    ROB1_SetTemperature = ((uint)plc.Read("DB179.DBD26.0")).ConvertToFloat();
                    ROB1_TimeDrying = ((uint)plc.Read("DB179.DBD30.0")).ConvertToFloat();
                    MixingTime = ((uint)plc.Read("DB179.DBD34.0")).ConvertToFloat();


                }

                ViewBag.ROB1_Downtime_Time = ROB1_Downtime_Time;
                ViewBag.ROB1_RefValue = ROB1_RefValue;
                ViewBag.ROB1_WeightTolMinus = ROB1_WeightTolMinus;
                ViewBag.ROB1_WeightTolPlus = ROB1_WeightTolPlus;
                ViewBag.ROB1_WeightActualValue = ROB1_WeightActualValue;
                ViewBag.ROB1_Temperature = ROB1_Temperature;
                ViewBag.ROB1_SetTemperature = ROB1_SetTemperature;
                ViewBag.ROB1_TimeDrying = ROB1_TimeDrying;
                ViewBag.MixingTime = MixingTime;






                ///////////////////////////////////////////////////////////////
                int rightPart, leftPart, actualStep;
                short actualDowntime;

                using (var plc = new Plc(CpuType.S71500, "10.184.159.45", 0, 1))
                {
                    plc.Open();

                    rightPart = ((uint)plc.Read("DB26.DBD2.0")).ConvertToInt();
                    leftPart = ((uint)plc.Read("DB26.DBD6.0")).ConvertToInt();
                    actualStep = ((uint)plc.Read("DB26.DBD10.0")).ConvertToInt();
                    actualStep = ((uint)plc.Read("DB26.DBD10.0")).ConvertToInt();
                    actualDowntime = ((ushort)plc.Read("DB26.DBW0.0")).ConvertToShort();

                }


                ViewBag.pravydiel = rightPart;
                ViewBag.lavydiel = leftPart;
                ViewBag.aktualnyKrok = actualStep;
                ViewBag.prestoj = actualDowntime;

                return View();

            }
        }
    }
}
