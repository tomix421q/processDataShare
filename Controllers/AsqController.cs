using Microsoft.AspNetCore.Mvc;
using S7.Net;

namespace processDataShare.Controllers
{
    public class AsqController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //________________________Asq_1___________________________
        public IActionResult Asq1()
        {
            Models.Asq1_model Asq1Model = new();
            Models.MainIndex_model MainIndexModel = new();


            try
            {

                using (var plc_asq1 = new Plc(CpuType.S71500, "10.184.159.241", 0, 1))
                {
                    plc_asq1.Open();//Connect

                    if (plc_asq1.IsConnected)
                    {
                        ViewBag.connection = "Connection OK";

                        //ROB1
                        Asq1Model.ROB1_Downtime_Time = ((ushort)plc_asq1.Read("DB179.DBW0.0")).ConvertToShort();
                        Asq1Model.ROB1_FormNumber = ((ushort)plc_asq1.Read("DB179.DBW2.0")).ConvertToShort();
                        Asq1Model.ROB1_WeightActualValue = ((uint)plc_asq1.Read("DB179.DBD4.0")).ConvertToFloat();
                        Asq1Model.ROB1_Temperature = ((uint)plc_asq1.Read("DB179.DBD8.0")).ConvertToFloat();
                        Asq1Model.ROB1_SetTemperature = ((uint)plc_asq1.Read("DB179.DBD12.0")).ConvertToFloat();
                        Asq1Model.ROB1_TimeDrying = ((uint)plc_asq1.Read("DB179.DBD16.0")).ConvertToFloat();
                        //ROB2
                        Asq1Model.ROB2_Downtime_Time = ((ushort)plc_asq1.Read("DB179.DBW20.0")).ConvertToShort();
                        Asq1Model.ROB2_FormNumber = ((ushort)plc_asq1.Read("DB179.DBW22.0")).ConvertToShort();
                        Asq1Model.ROB2_WeightActualValue = ((uint)plc_asq1.Read("DB179.DBD24.0")).ConvertToFloat();
                        Asq1Model.ROB2_Temperature = ((uint)plc_asq1.Read("DB179.DBD28.0")).ConvertToFloat();
                        Asq1Model.ROB2_SetTemperature = ((uint)plc_asq1.Read("DB179.DBD32.0")).ConvertToFloat();
                        Asq1Model.ROB2_TimeDrying = ((uint)plc_asq1.Read("DB179.DBD36.0")).ConvertToFloat();
                        //Global
                        Asq1Model.Global_RefValue = ((uint)plc_asq1.Read("DB179.DBD40.0")).ConvertToFloat();
                        Asq1Model.Global_WeightTolMinus = ((uint)plc_asq1.Read("DB179.DBD44.0")).ConvertToFloat();
                        Asq1Model.Global_WeightTolPlus = ((uint)plc_asq1.Read("DB179.DBD48.0")).ConvertToFloat();
                        Asq1Model.Global_MixingTime = ((uint)plc_asq1.Read("DB179.DBD54.0")).ConvertToFloat();
                        Asq1Model.Global_GoWeightAfter = ((ushort)plc_asq1.Read("DB179.DBW0.0")).ConvertToShort();
                    }
                    else
                    {
                        ViewBag.connection = "Nieco sa pokazilo :(";
                    };
                }
            }
            catch (Exception ex)
            {
                MainIndexModel.connectionAsq1 = ex.Message;
                ViewBag.connection = MainIndexModel.connectionAsq1;
            }
            return View(Asq1Model);
        }
        //________________________Asq_2___________________________
        public IActionResult Asq2()
        {
            Models.Asq2_model Asq2Model = new();
            Models.MainIndex_model MainIndexModel = new();


            try
            {

                using (var plc_asq2 = new Plc(CpuType.S71500, "10.184.159.109", 0, 1))
                {
                    plc_asq2.Open();//Connect

                    if (plc_asq2.IsConnected)
                    {
                        ViewBag.connection = "Connection OK";

                        //ROB1
                        Asq2Model.ROB1_Downtime_Time = ((ushort)plc_asq2.Read("DB179.DBW0.0")).ConvertToShort();
                        Asq2Model.ROB1_FormNumber = ((ushort)plc_asq2.Read("DB179.DBW2.0")).ConvertToShort();
                        Asq2Model.ROB1_WeightActualValue = ((uint)plc_asq2.Read("DB179.DBD4.0")).ConvertToFloat();
                        Asq2Model.ROB1_Temperature = ((uint)plc_asq2.Read("DB179.DBD8.0")).ConvertToFloat();
                        Asq2Model.ROB1_SetTemperature = ((uint)plc_asq2.Read("DB179.DBD12.0")).ConvertToFloat();
                        Asq2Model.ROB1_TimeDrying = ((uint)plc_asq2.Read("DB179.DBD16.0")).ConvertToFloat();
                        //ROB2
                        Asq2Model.ROB2_Downtime_Time = ((ushort)plc_asq2.Read("DB179.DBW20.0")).ConvertToShort();
                        Asq2Model.ROB2_FormNumber = ((ushort)plc_asq2.Read("DB179.DBW22.0")).ConvertToShort();
                        Asq2Model.ROB2_WeightActualValue = ((uint)plc_asq2.Read("DB179.DBD24.0")).ConvertToFloat();
                        Asq2Model.ROB2_Temperature = ((uint)plc_asq2.Read("DB179.DBD28.0")).ConvertToFloat();
                        Asq2Model.ROB2_SetTemperature = ((uint)plc_asq2.Read("DB179.DBD32.0")).ConvertToFloat();
                        Asq2Model.ROB2_TimeDrying = ((uint)plc_asq2.Read("DB179.DBD36.0")).ConvertToFloat();
                        //Global
                        Asq2Model.Global_RefValue = ((uint)plc_asq2.Read("DB179.DBD40.0")).ConvertToFloat();
                        Asq2Model.Global_WeightTolMinus = ((uint)plc_asq2.Read("DB179.DBD44.0")).ConvertToFloat();
                        Asq2Model.Global_WeightTolPlus = ((uint)plc_asq2.Read("DB179.DBD48.0")).ConvertToFloat();
                        Asq2Model.Global_MixingTime = ((uint)plc_asq2.Read("DB179.DBD54.0")).ConvertToFloat();
                        Asq2Model.Global_GoWeightAfter = ((ushort)plc_asq2.Read("DB179.DBW0.0")).ConvertToShort();
                    }
                    else
                    {
                        ViewBag.connection = "Nieco sa pokazilo :(";
                    };
                }
            }
            catch (Exception ex)
            {
                MainIndexModel.connectionAsq2 = ex.Message;
                ViewBag.connection = MainIndexModel.connectionAsq2;
            }
            return View(Asq2Model);
        }

        //________________________Asq_5___________________________
        public IActionResult Asq5()
        {
            Models.Asq5_model Asq5Model = new();
            Models.MainIndex_model MainIndexModel = new();

            try
            {

                using (var plc_asq5 = new Plc(CpuType.S71500, "10.184.159.108", 0, 1))
                {
                    plc_asq5.Open();//Connect

                    if (plc_asq5.IsConnected)
                    {
                        ViewBag.connection = "Connection OK";

                        //ROB1
                        Asq5Model.ROB1_Downtime_Time = ((ushort)plc_asq5.Read("DB179.DBW0.0")).ConvertToShort();
                        Asq5Model.ROB1_FormNumber = ((ushort)plc_asq5.Read("DB179.DBW2.0")).ConvertToShort();
                        Asq5Model.ROB1_WeightActualValue = ((uint)plc_asq5.Read("DB179.DBD4.0")).ConvertToFloat();
                        Asq5Model.ROB1_Temperature = ((uint)plc_asq5.Read("DB179.DBD8.0")).ConvertToFloat();
                        Asq5Model.ROB1_SetTemperature = ((uint)plc_asq5.Read("DB179.DBD12.0")).ConvertToFloat();
                        Asq5Model.ROB1_TimeDrying = ((uint)plc_asq5.Read("DB179.DBD16.0")).ConvertToFloat();
                        //ROB2
                        Asq5Model.ROB2_Downtime_Time = ((ushort)plc_asq5.Read("DB179.DBW20.0")).ConvertToShort();
                        Asq5Model.ROB2_FormNumber = ((ushort)plc_asq5.Read("DB179.DBW22.0")).ConvertToShort();
                        Asq5Model.ROB2_WeightActualValue = ((uint)plc_asq5.Read("DB179.DBD24.0")).ConvertToFloat();
                        Asq5Model.ROB2_Temperature = ((uint)plc_asq5.Read("DB179.DBD28.0")).ConvertToFloat();
                        Asq5Model.ROB2_SetTemperature = ((uint)plc_asq5.Read("DB179.DBD32.0")).ConvertToFloat();
                        Asq5Model.ROB2_TimeDrying = ((uint)plc_asq5.Read("DB179.DBD36.0")).ConvertToFloat();
                        //Global
                        Asq5Model.Global_RefValue = ((uint)plc_asq5.Read("DB179.DBD40.0")).ConvertToFloat();
                        Asq5Model.Global_WeightTolMinus = ((uint)plc_asq5.Read("DB179.DBD44.0")).ConvertToFloat();
                        Asq5Model.Global_WeightTolPlus = ((uint)plc_asq5.Read("DB179.DBD48.0")).ConvertToFloat();
                        Asq5Model.Global_MixingTime = ((uint)plc_asq5.Read("DB179.DBD54.0")).ConvertToFloat();
                        Asq5Model.Global_GoWeightAfter = ((ushort)plc_asq5.Read("DB179.DBW0.0")).ConvertToShort();
                    }
                    else
                    {
                        ViewBag.connection = "something is bad";
                    };
                }
            }
            catch (Exception ex)
            {
                MainIndexModel.connectionAsq5 = ex.Message;
                ViewBag.connection = MainIndexModel.connectionAsq5;
            }
            return View(Asq5Model);
        }

        //________________________Asq_6___________________________
        public IActionResult Asq6()
        {
            Models.Asq6_model Asq6Model = new();
            Models.MainIndex_model MainIndexModel = new();
            try
            {
                using (var plc_asq6 = new Plc(CpuType.S71500, "10.184.159.184", 0, 1))
                {
                    plc_asq6.Open(); //Connect
                    if (plc_asq6.IsConnected)
                    {
                        ViewBag.connection = "Connection OK";

                        //ROB1
                        Asq6Model.ROB1_Downtime_Time = ((ushort)plc_asq6.Read("DB179.DBW0.0")).ConvertToShort();
                        Asq6Model.ROB1_FormNumber = ((ushort)plc_asq6.Read("DB179.DBW2.0")).ConvertToShort();
                        Asq6Model.ROB1_WeightActualValue = ((uint)plc_asq6.Read("DB179.DBD4.0")).ConvertToFloat();
                        Asq6Model.ROB1_Temperature = ((uint)plc_asq6.Read("DB179.DBD8.0")).ConvertToFloat();
                        Asq6Model.ROB1_SetTemperature = ((uint)plc_asq6.Read("DB179.DBD12.0")).ConvertToFloat();
                        Asq6Model.ROB1_TimeDrying = ((uint)plc_asq6.Read("DB179.DBD16.0")).ConvertToFloat();
                        //ROB2
                        Asq6Model.ROB2_Downtime_Time = ((ushort)plc_asq6.Read("DB179.DBW20.0")).ConvertToShort();
                        Asq6Model.ROB2_FormNumber = ((ushort)plc_asq6.Read("DB179.DBW22.0")).ConvertToShort();
                        Asq6Model.ROB2_WeightActualValue = ((uint)plc_asq6.Read("DB179.DBD24.0")).ConvertToFloat();
                        Asq6Model.ROB2_Temperature = ((uint)plc_asq6.Read("DB179.DBD28.0")).ConvertToFloat();
                        Asq6Model.ROB2_SetTemperature = ((uint)plc_asq6.Read("DB179.DBD32.0")).ConvertToFloat();
                        Asq6Model.ROB2_TimeDrying = ((uint)plc_asq6.Read("DB179.DBD36.0")).ConvertToFloat();
                        //Global
                        Asq6Model.Global_RefValue = ((uint)plc_asq6.Read("DB179.DBD40.0")).ConvertToFloat();
                        Asq6Model.Global_WeightTolMinus = ((uint)plc_asq6.Read("DB179.DBD44.0")).ConvertToFloat();
                        Asq6Model.Global_WeightTolPlus = ((uint)plc_asq6.Read("DB179.DBD48.0")).ConvertToFloat();
                        Asq6Model.Global_MixingTime = ((uint)plc_asq6.Read("DB179.DBD54.0")).ConvertToFloat();
                        Asq6Model.Global_GoWeightAfter = ((ushort)plc_asq6.Read("DB179.DBW0.0")).ConvertToShort();
                    }
                    else
                    {
                        ViewBag.connection = "Something is bad...";
                    };
                }
            }
            catch (Exception ex)
            {
                MainIndexModel.connectionAsq6 = ex.Message;
                ViewBag.connection = MainIndexModel.connectionAsq6;
            }
            return View(Asq6Model);
        }
    }
}


