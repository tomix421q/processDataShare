using Microsoft.AspNetCore.Mvc;
using processDataShare.Models;
using S7.Net;

namespace processDataShare.Controllers
{

    public class AsqController : Controller
    {
        //________________________Asq_1___________________________
        public IActionResult Asq1()
        {
            Models.Asq1_model Asq1Model = LoadPLCData_Asq1(); // nacitat data plc (ajax)
            return View(Asq1Model);
        } //create view

        [HttpGet]
        public JsonResult JsonAsq1()
        {
            Models.Asq1_model Asq1Model = LoadPLCData_Asq1(); // nacitat data plc (ajax)
            return Json(Asq1Model);
        } //json get

        private Models.Asq1_model LoadPLCData_Asq1()
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
                        Asq1Model.connection = "Connection OK";

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
                        
                    }
                    else
                    {
                        Asq1Model.connection = "Error please reload page...";
                    };
                }
            }
            catch (Exception ex)
            {
                Asq1Model.connection = ex.Message;
            }
            return Asq1Model;
        } //connect to plc 

        //________________________Asq_2___________________________
        public IActionResult Asq2()
        {
            Models.Asq2_model Asq2Model = LoadPLCData_Asq2(); // nacitat data plc (ajax)            
            return View(Asq2Model);
        }

        [HttpGet]
        public JsonResult JsonAsq2()
        {
            Models.Asq2_model Asq2Model = LoadPLCData_Asq2(); // nacitat data plc (ajax)
            return Json(Asq2Model);
        }

        private Models.Asq2_model LoadPLCData_Asq2() {
            Models.Asq2_model Asq2Model = new();

            try
            {
                using (var plc_asq2 = new Plc(CpuType.S71500, "10.184.159.109", 0, 1))
                {
                    plc_asq2.Open();//Connect

                    if (plc_asq2.IsConnected)
                    {
                        Asq2Model.connection = "Connection OK";

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
                        Asq2Model.connection = "Error please reload page...";
                    };
                }
            }
            catch (Exception ex)
            {
                Asq2Model.connection = ex.Message;
            }
            return Asq2Model;
        }

        //________________________Asq_3___________________________
        public IActionResult Asq3()
        {
            Models.Asq3_model Asq3Model = LoadPLCData_Asq3(); // nacitat data plc (ajax)
            return View(Asq3Model);
        }

        [HttpGet]
        public JsonResult JsonAsq3()
        {
            Models.Asq3_model Asq3Model = LoadPLCData_Asq3(); // nacitat data plc (ajax)
            return Json(Asq3Model);
        }

        private Models.Asq3_model LoadPLCData_Asq3(){
            Models.Asq3_model Asq3Model = new();
            try
            {

                using (var plc_asq3 = new Plc(CpuType.S71500, "10.184.159.240", 0, 1))
                {
                    plc_asq3.Open();//Connect

                    if (plc_asq3.IsConnected)
                    {
                        Asq3Model.connection = "Connection OK";

                        //ROB1
                        Asq3Model.ROB1_Downtime_Time = ((ushort)plc_asq3.Read("DB179.DBW0.0")).ConvertToShort();
                        Asq3Model.ROB1_FormNumber = ((ushort)plc_asq3.Read("DB179.DBW2.0")).ConvertToShort();
                        Asq3Model.ROB1_WeightActualValue = ((uint)plc_asq3.Read("DB179.DBD4.0")).ConvertToFloat();
                        Asq3Model.ROB1_Temperature = ((uint)plc_asq3.Read("DB179.DBD8.0")).ConvertToFloat();
                        Asq3Model.ROB1_SetTemperature = ((uint)plc_asq3.Read("DB179.DBD12.0")).ConvertToFloat();
                        Asq3Model.ROB1_TimeDrying = ((uint)plc_asq3.Read("DB179.DBD16.0")).ConvertToFloat();
                        //ROB2
                        Asq3Model.ROB2_Downtime_Time = ((ushort)plc_asq3.Read("DB179.DBW20.0")).ConvertToShort();
                        Asq3Model.ROB2_FormNumber = ((ushort)plc_asq3.Read("DB179.DBW22.0")).ConvertToShort();
                        Asq3Model.ROB2_WeightActualValue = ((uint)plc_asq3.Read("DB179.DBD24.0")).ConvertToFloat();
                        Asq3Model.ROB2_Temperature = ((uint)plc_asq3.Read("DB179.DBD28.0")).ConvertToFloat();
                        Asq3Model.ROB2_SetTemperature = ((uint)plc_asq3.Read("DB179.DBD32.0")).ConvertToFloat();
                        Asq3Model.ROB2_TimeDrying = ((uint)plc_asq3.Read("DB179.DBD36.0")).ConvertToFloat();
                        //Global
                        Asq3Model.Global_RefValue = ((uint)plc_asq3.Read("DB179.DBD40.0")).ConvertToFloat();
                        Asq3Model.Global_WeightTolMinus = ((uint)plc_asq3.Read("DB179.DBD44.0")).ConvertToFloat();
                        Asq3Model.Global_WeightTolPlus = ((uint)plc_asq3.Read("DB179.DBD48.0")).ConvertToFloat();
                        Asq3Model.Global_MixingTime = ((uint)plc_asq3.Read("DB179.DBD54.0")).ConvertToFloat();
                        Asq3Model.Global_GoWeightAfter = ((ushort)plc_asq3.Read("DB179.DBW0.0")).ConvertToShort();
                    }
                    else
                    {
                        Asq3Model.connection = "Error please reload page...";
                    };
                }
            }
            catch (Exception ex)
            {
                Asq3Model.connection = ex.Message;
            }
            return Asq3Model;
        }

        //________________________Asq_4___________________________
        public IActionResult Asq4()
        {
            Models.Asq4_model Asq4Model = LoadPLCData_Asq4(); // nacitat data plc (ajax)
            return View(Asq4Model);
        }

        [HttpGet]
        public JsonResult JsonAsq4()
        {
            Models.Asq4_model Asq4Model = LoadPLCData_Asq4(); // nacitat data plc (ajax)
            return Json(Asq4Model);
        }

        private Models.Asq4_model LoadPLCData_Asq4(){
            Models.Asq4_model Asq4Model = new();
            try
            {
                using (var plc_asq4 = new Plc(CpuType.S71500, "10.184.159.12", 0, 1))
                {
                    plc_asq4.Open();//Connect

                    if (plc_asq4.IsConnected)
                    {
                        Asq4Model.connection = "Connection OK";

                        //ROB1
                        Asq4Model.ROB1_Downtime_Time = ((ushort)plc_asq4.Read("DB179.DBW0.0")).ConvertToShort();
                        Asq4Model.ROB1_FormNumber = ((ushort)plc_asq4.Read("DB179.DBW2.0")).ConvertToShort();
                        Asq4Model.ROB1_WeightActualValue = ((uint)plc_asq4.Read("DB179.DBD4.0")).ConvertToFloat();
                        Asq4Model.ROB1_Temperature = ((uint)plc_asq4.Read("DB179.DBD8.0")).ConvertToFloat();
                        Asq4Model.ROB1_SetTemperature = ((uint)plc_asq4.Read("DB179.DBD12.0")).ConvertToFloat();
                        Asq4Model.ROB1_TimeDrying = ((uint)plc_asq4.Read("DB179.DBD16.0")).ConvertToFloat();
                        //ROB2
                        Asq4Model.ROB2_Downtime_Time = ((ushort)plc_asq4.Read("DB179.DBW20.0")).ConvertToShort();
                        Asq4Model.ROB2_FormNumber = ((ushort)plc_asq4.Read("DB179.DBW22.0")).ConvertToShort();
                        Asq4Model.ROB2_WeightActualValue = ((uint)plc_asq4.Read("DB179.DBD24.0")).ConvertToFloat();
                        Asq4Model.ROB2_Temperature = ((uint)plc_asq4.Read("DB179.DBD28.0")).ConvertToFloat();
                        Asq4Model.ROB2_SetTemperature = ((uint)plc_asq4.Read("DB179.DBD32.0")).ConvertToFloat();
                        Asq4Model.ROB2_TimeDrying = ((uint)plc_asq4.Read("DB179.DBD36.0")).ConvertToFloat();
                        //Global
                        Asq4Model.Global_RefValue = ((uint)plc_asq4.Read("DB179.DBD40.0")).ConvertToFloat();
                        Asq4Model.Global_WeightTolMinus = ((uint)plc_asq4.Read("DB179.DBD44.0")).ConvertToFloat();
                        Asq4Model.Global_WeightTolPlus = ((uint)plc_asq4.Read("DB179.DBD48.0")).ConvertToFloat();
                        Asq4Model.Global_MixingTime = ((uint)plc_asq4.Read("DB179.DBD54.0")).ConvertToFloat();
                        Asq4Model.Global_GoWeightAfter = ((ushort)plc_asq4.Read("DB179.DBW0.0")).ConvertToShort();
                    }
                    else
                    {
                        Asq4Model.connection = "Error please reload page...";
                    };
                }
            }
            catch (Exception ex)
            {
                Asq4Model.connection = ex.Message;
            }
            return Asq4Model;
        }

        //________________________Asq_5___________________________
        public IActionResult Asq5()
        {
            Models.Asq5_model Asq5Model = LoadPLCData_Asq5(); // nacitat data plc (ajax)
            return View(Asq5Model);
        }

        [HttpGet]
        public JsonResult JsonAsq5()
        {
            Models.Asq5_model Asq5Model = LoadPLCData_Asq5(); // nacitat data plc (ajax)
            return Json(Asq5Model);
        }

        private Models.Asq5_model LoadPLCData_Asq5(){
            Models.Asq5_model Asq5Model = new();
            try
            {

                using (var plc_asq5 = new Plc(CpuType.S71500, "10.184.159.108", 0, 1))
                {
                    plc_asq5.Open();//Connect

                    if (plc_asq5.IsConnected)
                    {
                        Asq5Model.connection = "Connection OK";

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
                        Asq5Model.connection = "Error please reload page...";
                    };
                }
            }
            catch (Exception ex)
            {
                Asq5Model.connection = ex.Message;
            }
            return Asq5Model;
        }

        //________________________Asq_6___________________________
        public IActionResult Asq6()
        {
            Models.Asq6_model Asq6Model = LoadPLCData_Asq6(); // nacitat data plc (ajax)
            return View(Asq6Model);
        }

        [HttpGet]
        public JsonResult JsonAsq6()
        {
            Models.Asq6_model Asq6Model = LoadPLCData_Asq6(); // nacitat data plc (ajax)
            return Json(Asq6Model);
        }

        private Models.Asq6_model LoadPLCData_Asq6() 
{
            Models.Asq6_model Asq6Model = new();
            try
            {
                using (var plc_asq6 = new Plc(CpuType.S71500, "10.184.159.184", 0, 1))
                {
                    plc_asq6.Open(); //Connect
                    if (plc_asq6.IsConnected)
                    {
                        Asq6Model.connection = "Connection OK";

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
                        Asq6Model.connection = "Something is bad...";
                    };
                }
            }
            catch (Exception ex)
            {
                Asq6Model.connection = ex.Message;
            }
            return Asq6Model;
        }















    }
}


