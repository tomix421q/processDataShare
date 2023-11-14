using Microsoft.AspNetCore.Mvc;
using processDataShare.Models;
using processDataShare.Models.eqcMfModels;
using S7.Net;
using S7.Net.Types;

namespace processDataShare.Controllers
{
    public class MFeqcController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //______________________MF1__________________________
        public IActionResult EqcMF1()
        {
            Models.eqcMfModels.EqcMf1_model EqcMf1model = LoadPLCData_MF1(); // nacitat data plc  
            return View(EqcMf1model);
        }

        [HttpGet]
        public JsonResult JsonMF1()
        {
            Models.eqcMfModels.EqcMf1_model EqcMf1model = LoadPLCData_MF1(); // nacitat data plc (ajax)
            return Json(EqcMf1model);
        }

        private Models.eqcMfModels.EqcMf1_model LoadPLCData_MF1(){
            Models.eqcMfModels.EqcMf1_model EqcMf1model = new();
            try
            {

                using (var plc_eqcMf1 = new Plc(CpuType.S71500, "10.184.159.173", 0, 1))
                {
                    plc_eqcMf1.Open();//Connect

                    if (plc_eqcMf1.IsConnected)
                    {
                        EqcMf1model.connection = "Connection OK";

                        EqcMf1model.actualDowntime = ((ushort)plc_eqcMf1.Read("DB189.DBW0.0")).ConvertToShort();

                        EqcMf1model.ActualToolName = plc_eqcMf1.Read(DataType.DataBlock, 189, 2, VarType.String, 20).ToString();


                        int startAdress = 258; // Adresa UDT
                        int sizeInBytes = 78; // Veľkosť UDT v bajtoch
                        int numberDB = 189; // Cislo DB blocku v plc

                        //Scan multiply
                        var udtData = plc_eqcMf1.ReadBytes(DataType.DataBlock, numberDB, startAdress, sizeInBytes);
                        //basic info
                        EqcMf1model.MachineAuto = udtData[0].SelectBit(0);
                        EqcMf1model.ConveyorOK = udtData[0].SelectBit(1);
                        EqcMf1model.MainStepNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(2).Take(2).ToArray());
                        EqcMf1model.CycleTime = S7.Net.Types.DInt.FromByteArray(udtData.Skip(4).Take(4).ToArray()) / 10;
                        EqcMf1model.ProductionCurrentNum = S7.Net.Types.DInt.FromByteArray(udtData.Skip(8).Take(4).ToArray());
                        //tool
                        EqcMf1model.ToolHome = udtData[12].SelectBit(0);
                        EqcMf1model.HeaterOk = udtData[12].SelectBit(1);
                        EqcMf1model.ToolNumber = S7.Net.Types.Word.FromByteArray(udtData.Skip(14).Take(2).ToArray());
                        //bluemelt gluestation
                        EqcMf1model.BluemeltOk = udtData[17].SelectBit(0);
                        EqcMf1model.ActualPressure = S7.Net.Types.Real.FromByteArray(udtData.Skip(18).Take(4).ToArray());

                        EqcMf1model.SetAirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(22).Take(4).ToArray());
                        EqcMf1model.SetAirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(26).Take(4).ToArray());
                        EqcMf1model.SetpumpSpeed1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(30).Take(4).ToArray());

                        EqcMf1model.SetAirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(34).Take(4).ToArray());
                        EqcMf1model.SetAirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(38).Take(4).ToArray());
                        EqcMf1model.SetpumpSpeed2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(42).Take(4).ToArray());

                        EqcMf1model.SetAirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(46).Take(4).ToArray());
                        EqcMf1model.SetpumpSpeed3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(50).Take(4).ToArray());

                        EqcMf1model.Actual_AirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(54).Take(4).ToArray());
                        EqcMf1model.Actual_AirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(58).Take(4).ToArray());
                        EqcMf1model.Actual_AirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(62).Take(4).ToArray());
                        EqcMf1model.Actual_AirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(66).Take(4).ToArray());
                        EqcMf1model.Actual_AirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(70).Take(4).ToArray());
                        //Robot
                        EqcMf1model.RobotAutomaticMode = udtData[74].SelectBit(0);
                        EqcMf1model.RobotRunning = udtData[74].SelectBit(1);
                        EqcMf1model.RobotHome = udtData[74].SelectBit(2);
                        EqcMf1model.RobotConnectedGripper = udtData[74].SelectBit(3);
                        EqcMf1model.RobotToolNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(76).Take(2).ToArray());



                    }
                    else
                    {
                        EqcMf1model.connection = "Error please reload page...";
                    };
                }
            }
            catch (Exception ex)
            {
                EqcMf1model.connection = ex.Message;
            }
            return EqcMf1model;
        }

        //______________________MF2__________________________
        public IActionResult EqcMF2()
        {
            Models.eqcMfModels.EqcMf2_model EqcMf2model = LoadPLCData_MF2(); // nacitat data plc  
            return View(EqcMf2model);
        }

        [HttpGet]
        public JsonResult JsonMF2()
        {
            Models.eqcMfModels.EqcMf2_model EqcMf2model = LoadPLCData_MF2(); // nacitat data plc (ajax)
            return Json(EqcMf2model);
        }

        private Models.eqcMfModels.EqcMf2_model LoadPLCData_MF2(){
            Models.eqcMfModels.EqcMf2_model EqcMf2model = new();
            try
            {

                using (var plc_eqcMf2 = new Plc(CpuType.S71500, "10.184.159.174", 0, 1))
                {
                    plc_eqcMf2.Open();//Connect

                    if (plc_eqcMf2.IsConnected)
                    {
                        EqcMf2model.connection = "Connection OK";

                        EqcMf2model.actualDowntime = ((ushort)plc_eqcMf2.Read("DB189.DBW0.0")).ConvertToShort();

                        EqcMf2model.ActualToolName = plc_eqcMf2.Read(DataType.DataBlock, 189, 2, VarType.String, 20).ToString();


                        int startAdress = 258; // Adresa UDT
                        int sizeInBytes = 78; // Veľkosť UDT v bajtoch
                        int numberDB = 189; // Cislo DB blocku v plc

                        //Scan multiply
                        var udtData = plc_eqcMf2.ReadBytes(DataType.DataBlock, numberDB, startAdress, sizeInBytes);
                        //basic info
                        EqcMf2model.MachineAuto = udtData[0].SelectBit(0);
                        EqcMf2model.ConveyorOK = udtData[0].SelectBit(1);
                        EqcMf2model.MainStepNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(2).Take(2).ToArray());
                        EqcMf2model.CycleTime = S7.Net.Types.DInt.FromByteArray(udtData.Skip(4).Take(4).ToArray()) / 10;
                        EqcMf2model.ProductionCurrentNum = S7.Net.Types.DInt.FromByteArray(udtData.Skip(8).Take(4).ToArray());
                        //tool
                        EqcMf2model.ToolHome = udtData[12].SelectBit(0);
                        EqcMf2model.HeaterOk = udtData[12].SelectBit(1);
                        EqcMf2model.ToolNumber = S7.Net.Types.Word.FromByteArray(udtData.Skip(14).Take(2).ToArray());
                        //bluemelt gluestation
                        EqcMf2model.BluemeltOk = udtData[17].SelectBit(0);
                        EqcMf2model.ActualPressure = S7.Net.Types.Real.FromByteArray(udtData.Skip(18).Take(4).ToArray());

                        EqcMf2model.SetAirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(22).Take(4).ToArray());
                        EqcMf2model.SetAirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(26).Take(4).ToArray());
                        EqcMf2model.SetpumpSpeed1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(30).Take(4).ToArray());

                        EqcMf2model.SetAirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(34).Take(4).ToArray());
                        EqcMf2model.SetAirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(38).Take(4).ToArray());
                        EqcMf2model.SetpumpSpeed2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(42).Take(4).ToArray());

                        EqcMf2model.SetAirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(46).Take(4).ToArray());
                        EqcMf2model.SetpumpSpeed3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(50).Take(4).ToArray());

                        EqcMf2model.Actual_AirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(54).Take(4).ToArray());
                        EqcMf2model.Actual_AirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(58).Take(4).ToArray());
                        EqcMf2model.Actual_AirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(62).Take(4).ToArray());
                        EqcMf2model.Actual_AirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(66).Take(4).ToArray());
                        EqcMf2model.Actual_AirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(70).Take(4).ToArray());
                        //Robot
                        EqcMf2model.RobotAutomaticMode = udtData[74].SelectBit(0);
                        EqcMf2model.RobotRunning = udtData[74].SelectBit(1);
                        EqcMf2model.RobotHome = udtData[74].SelectBit(2);
                        EqcMf2model.RobotConnectedGripper = udtData[74].SelectBit(3);
                        EqcMf2model.RobotToolNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(76).Take(2).ToArray());

                    }
                    else
                    {
                        EqcMf2model.connection = "Error please reload page...";
                    };
                }
            }
            catch (Exception ex)
            {
                EqcMf2model.connection = ex.Message;
            }
            return EqcMf2model;
        }

        //______________________MF3__________________________
        public IActionResult EqcMF3()
        {
            Models.eqcMfModels.EqcMf3_model EqcMf3model = LoadPLCData_MF3(); // nacitat data plc (ajax)
            return View(EqcMf3model);
        }

        [HttpGet]
        public JsonResult JsonMF3()
        {
            Models.eqcMfModels.EqcMf3_model EqcMf3model = LoadPLCData_MF3(); // nacitat data plc (ajax)
            return Json(EqcMf3model);
        }

        private Models.eqcMfModels.EqcMf3_model LoadPLCData_MF3(){
            Models.eqcMfModels.EqcMf3_model EqcMf3model = new();
            try
            {

                using (var plc_eqcMf3 = new Plc(CpuType.S71500, "10.184.159.175", 0, 1))
                {
                    plc_eqcMf3.Open();//Connect

                    if (plc_eqcMf3.IsConnected)
                    {
                        EqcMf3model.connection = "Connection OK";

                        EqcMf3model.actualDowntime = ((ushort)plc_eqcMf3.Read("DB189.DBW0.0")).ConvertToShort();

                        EqcMf3model.ActualToolName = plc_eqcMf3.Read(DataType.DataBlock, 189, 2, VarType.String, 20).ToString();


                        int startAdress = 258; // Adresa UDT
                        int sizeInBytes = 78; // Veľkosť UDT v bajtoch
                        int numberDB = 189; // Cislo DB blocku v plc

                        //Scan multiply
                        var udtData = plc_eqcMf3.ReadBytes(DataType.DataBlock, numberDB, startAdress, sizeInBytes);
                        //basic info
                        EqcMf3model.MachineAuto = udtData[0].SelectBit(0);
                        EqcMf3model.ConveyorOK = udtData[0].SelectBit(1);
                        EqcMf3model.MainStepNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(2).Take(2).ToArray());
                        EqcMf3model.CycleTime = S7.Net.Types.DInt.FromByteArray(udtData.Skip(4).Take(4).ToArray()) / 10;
                        EqcMf3model.ProductionCurrentNum = S7.Net.Types.DInt.FromByteArray(udtData.Skip(8).Take(4).ToArray());
                        //tool
                        EqcMf3model.ToolHome = udtData[12].SelectBit(0);
                        EqcMf3model.HeaterOk = udtData[12].SelectBit(1);
                        EqcMf3model.ToolNumber = S7.Net.Types.Word.FromByteArray(udtData.Skip(14).Take(2).ToArray());
                        //bluemelt gluestation
                        EqcMf3model.BluemeltOk = udtData[17].SelectBit(0);
                        EqcMf3model.ActualPressure = S7.Net.Types.Real.FromByteArray(udtData.Skip(18).Take(4).ToArray());

                        EqcMf3model.SetAirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(22).Take(4).ToArray());
                        EqcMf3model.SetAirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(26).Take(4).ToArray());
                        EqcMf3model.SetpumpSpeed1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(30).Take(4).ToArray());

                        EqcMf3model.SetAirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(34).Take(4).ToArray());
                        EqcMf3model.SetAirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(38).Take(4).ToArray());
                        EqcMf3model.SetpumpSpeed2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(42).Take(4).ToArray());

                        EqcMf3model.SetAirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(46).Take(4).ToArray());
                        EqcMf3model.SetpumpSpeed3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(50).Take(4).ToArray());

                        EqcMf3model.Actual_AirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(54).Take(4).ToArray());
                        EqcMf3model.Actual_AirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(58).Take(4).ToArray());
                        EqcMf3model.Actual_AirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(62).Take(4).ToArray());
                        EqcMf3model.Actual_AirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(66).Take(4).ToArray());
                        EqcMf3model.Actual_AirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(70).Take(4).ToArray());
                        //Robot
                        EqcMf3model.RobotAutomaticMode = udtData[74].SelectBit(0);
                        EqcMf3model.RobotRunning = udtData[74].SelectBit(1);
                        EqcMf3model.RobotHome = udtData[74].SelectBit(2);
                        EqcMf3model.RobotConnectedGripper = udtData[74].SelectBit(3);
                        EqcMf3model.RobotToolNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(76).Take(2).ToArray());

                    }
                    else
                    {
                        EqcMf3model.connection = "Error please reload page...";
                    };
                }
            }
            catch (Exception ex)
            {
                EqcMf3model.connection = ex.Message;
            }
return EqcMf3model;
        }

        //______________________MF4__________________________
        public IActionResult EqcMF4()
        {
            Models.eqcMfModels.EqcMf4_model EqcMf4model = LoadPLCData_MF4(); // nacitat data plc 
            return View(EqcMf4model);
        }

        [HttpGet]
        public JsonResult JsonMF4()
        {
            Models.eqcMfModels.EqcMf4_model EqcMf4model = LoadPLCData_MF4(); // nacitat data plc (ajax)
            return Json(EqcMf4model);
        }

        private Models.eqcMfModels.EqcMf4_model LoadPLCData_MF4(){
            Models.eqcMfModels.EqcMf4_model EqcMf4model = new();
            try
            {

                using (var plc_eqcMf4 = new Plc(CpuType.S71500, "10.184.159.176", 0, 1))
                {
                    plc_eqcMf4.Open();//Connect

                    if (plc_eqcMf4.IsConnected)
                    {
                        EqcMf4model.connection = "Connection OK";

                        EqcMf4model.actualDowntime = ((ushort)plc_eqcMf4.Read("DB189.DBW0.0")).ConvertToShort();

                        EqcMf4model.ActualToolName = plc_eqcMf4.Read(DataType.DataBlock, 189, 2, VarType.String, 20).ToString();


                        int startAdress = 258; // Adresa UDT
                        int sizeInBytes = 78; // Veľkosť UDT v bajtoch
                        int numberDB = 189; // Cislo DB blocku v plc

                        //Scan multiply
                        var udtData = plc_eqcMf4.ReadBytes(DataType.DataBlock, numberDB, startAdress, sizeInBytes);
                        //basic info
                        EqcMf4model.MachineAuto = udtData[0].SelectBit(0);
                        EqcMf4model.ConveyorOK = udtData[0].SelectBit(1);
                        EqcMf4model.MainStepNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(2).Take(2).ToArray());
                        EqcMf4model.CycleTime = S7.Net.Types.DInt.FromByteArray(udtData.Skip(4).Take(4).ToArray()) / 10;
                        EqcMf4model.ProductionCurrentNum = S7.Net.Types.DInt.FromByteArray(udtData.Skip(8).Take(4).ToArray());
                        //tool
                        EqcMf4model.ToolHome = udtData[12].SelectBit(0);
                        EqcMf4model.HeaterOk = udtData[12].SelectBit(1);
                        EqcMf4model.ToolNumber = S7.Net.Types.Word.FromByteArray(udtData.Skip(14).Take(2).ToArray());
                        //bluemelt gluestation
                        EqcMf4model.BluemeltOk = udtData[17].SelectBit(0);
                        EqcMf4model.ActualPressure = S7.Net.Types.Real.FromByteArray(udtData.Skip(18).Take(4).ToArray());

                        EqcMf4model.SetAirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(22).Take(4).ToArray());
                        EqcMf4model.SetAirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(26).Take(4).ToArray());
                        EqcMf4model.SetpumpSpeed1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(30).Take(4).ToArray());

                        EqcMf4model.SetAirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(34).Take(4).ToArray());
                        EqcMf4model.SetAirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(38).Take(4).ToArray());
                        EqcMf4model.SetpumpSpeed2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(42).Take(4).ToArray());

                        EqcMf4model.SetAirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(46).Take(4).ToArray());
                        EqcMf4model.SetpumpSpeed3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(50).Take(4).ToArray());

                        EqcMf4model.Actual_AirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(54).Take(4).ToArray());
                        EqcMf4model.Actual_AirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(58).Take(4).ToArray());
                        EqcMf4model.Actual_AirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(62).Take(4).ToArray());
                        EqcMf4model.Actual_AirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(66).Take(4).ToArray());
                        EqcMf4model.Actual_AirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(70).Take(4).ToArray());
                        //Robot
                        EqcMf4model.RobotAutomaticMode = udtData[74].SelectBit(0);
                        EqcMf4model.RobotRunning = udtData[74].SelectBit(1);
                        EqcMf4model.RobotHome = udtData[74].SelectBit(2);
                        EqcMf4model.RobotConnectedGripper = udtData[74].SelectBit(3);
                        EqcMf4model.RobotToolNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(76).Take(2).ToArray());

                    }
                    else
                    {
                        EqcMf4model.connection = "Error please reload page...";
                    };
                }
            }
            catch (Exception ex)
            {
                EqcMf4model.connection = ex.Message;
            }
            return EqcMf4model;
        }

        //______________________MF5__________________________
        public IActionResult EqcMF5()
        {
            Models.eqcMfModels.EqcMf5_model EqcMf5model = LoadPLCData_MF5(); // nacitat data plc 
            return View(EqcMf5model);
        }

        [HttpGet]
        public JsonResult JsonMF5()
        {
            Models.eqcMfModels.EqcMf5_model EqcMf5model = LoadPLCData_MF5(); // nacitat data plc (ajax)
            return Json(EqcMf5model);
        }

        private Models.eqcMfModels.EqcMf5_model LoadPLCData_MF5()
        {
            Models.eqcMfModels.EqcMf5_model EqcMf5model = new();
            try
            {

                using (var plc_eqcMf5 = new Plc(CpuType.S71500, "10.184.159.89", 0, 1))
                {
                    plc_eqcMf5.Open();//Connect

                    if (plc_eqcMf5.IsConnected)
                    {
                        EqcMf5model.connection = "Connection OK";

                        EqcMf5model.actualDowntime = ((ushort)plc_eqcMf5.Read("DB189.DBW0.0")).ConvertToShort();

                        EqcMf5model.ActualToolName = plc_eqcMf5.Read(DataType.DataBlock, 189, 2, VarType.String, 20).ToString();


                        int startAdress = 258; // Adresa UDT
                        int sizeInBytes = 78; // Veľkosť UDT v bajtoch
                        int numberDB = 189; // Cislo DB blocku v plc

                        //Scan multiply
                        var udtData = plc_eqcMf5.ReadBytes(DataType.DataBlock, numberDB, startAdress, sizeInBytes);
                        //basic info
                        EqcMf5model.MachineAuto = udtData[0].SelectBit(0);
                        EqcMf5model.ConveyorOK = udtData[0].SelectBit(1);
                        EqcMf5model.MainStepNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(2).Take(2).ToArray());
                        EqcMf5model.CycleTime = S7.Net.Types.DInt.FromByteArray(udtData.Skip(4).Take(4).ToArray()) / 10;
                        EqcMf5model.ProductionCurrentNum = S7.Net.Types.DInt.FromByteArray(udtData.Skip(8).Take(4).ToArray());
                        //tool
                        EqcMf5model.ToolHome = udtData[12].SelectBit(0);
                        EqcMf5model.HeaterOk = udtData[12].SelectBit(1);
                        EqcMf5model.ToolNumber = S7.Net.Types.Word.FromByteArray(udtData.Skip(14).Take(2).ToArray());
                        //bluemelt gluestation
                        EqcMf5model.BluemeltOk = udtData[17].SelectBit(0);
                        EqcMf5model.ActualPressure = S7.Net.Types.Real.FromByteArray(udtData.Skip(18).Take(4).ToArray());

                        EqcMf5model.SetAirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(22).Take(4).ToArray());
                        EqcMf5model.SetAirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(26).Take(4).ToArray());
                        EqcMf5model.SetpumpSpeed1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(30).Take(4).ToArray());

                        EqcMf5model.SetAirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(34).Take(4).ToArray());
                        EqcMf5model.SetAirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(38).Take(4).ToArray());
                        EqcMf5model.SetpumpSpeed2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(42).Take(4).ToArray());

                        EqcMf5model.SetAirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(46).Take(4).ToArray());
                        EqcMf5model.SetpumpSpeed3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(50).Take(4).ToArray());

                        EqcMf5model.Actual_AirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(54).Take(4).ToArray());
                        EqcMf5model.Actual_AirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(58).Take(4).ToArray());
                        EqcMf5model.Actual_AirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(62).Take(4).ToArray());
                        EqcMf5model.Actual_AirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(66).Take(4).ToArray());
                        EqcMf5model.Actual_AirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(70).Take(4).ToArray());
                        //Robot
                        EqcMf5model.RobotAutomaticMode = udtData[74].SelectBit(0);
                        EqcMf5model.RobotRunning = udtData[74].SelectBit(1);
                        EqcMf5model.RobotHome = udtData[74].SelectBit(2);
                        EqcMf5model.RobotConnectedGripper = udtData[74].SelectBit(3);
                        EqcMf5model.RobotToolNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(76).Take(2).ToArray());

                    }
                    else
                    {
                        EqcMf5model.connection = "Error please reload page...";
                    };
                }
            }
            catch (Exception ex)
            {
                EqcMf5model.connection = ex.Message;
            }
            return EqcMf5model;
        }

        //______________________MF6__________________________
        public IActionResult EqcMF6()
        {
            Models.eqcMfModels.EqcMf6_model EqcMf6model = LoadPLCData_MF6(); // nacitat data plc 
            return View(EqcMf6model);
        }

        [HttpGet]
        public JsonResult JsonMF6()
        {
            Models.eqcMfModels.EqcMf6_model EqcMf6model = LoadPLCData_MF6(); // nacitat data plc (ajax)
            return Json(EqcMf6model);
        }

        private Models.eqcMfModels.EqcMf6_model LoadPLCData_MF6()
        {
            Models.eqcMfModels.EqcMf6_model EqcMf6model = new();
            try
            {

                using (var plc_eqcMf6 = new Plc(CpuType.S71500, "10.184.159.99", 0, 1))
                {
                    plc_eqcMf6.Open();//Connect

                    if (plc_eqcMf6.IsConnected)
                    {
                        EqcMf6model.connection = "Connection OK";

                        EqcMf6model.actualDowntime = ((ushort)plc_eqcMf6.Read("DB189.DBW0.0")).ConvertToShort();

                        EqcMf6model.ActualToolName = plc_eqcMf6.Read(DataType.DataBlock, 189, 2, VarType.String, 20).ToString();


                        int startAdress = 258; // Adresa UDT
                        int sizeInBytes = 78; // Veľkosť UDT v bajtoch
                        int numberDB = 189; // Cislo DB blocku v plc

                        //Scan multiply
                        var udtData = plc_eqcMf6.ReadBytes(DataType.DataBlock, numberDB, startAdress, sizeInBytes);
                        //basic info
                        EqcMf6model.MachineAuto = udtData[0].SelectBit(0);
                        EqcMf6model.ConveyorOK = udtData[0].SelectBit(1);
                        EqcMf6model.MainStepNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(2).Take(2).ToArray());
                        EqcMf6model.CycleTime = S7.Net.Types.DInt.FromByteArray(udtData.Skip(4).Take(4).ToArray()) / 10;
                        EqcMf6model.ProductionCurrentNum = S7.Net.Types.DInt.FromByteArray(udtData.Skip(8).Take(4).ToArray());
                        //tool
                        EqcMf6model.ToolHome = udtData[12].SelectBit(0);
                        EqcMf6model.HeaterOk = udtData[12].SelectBit(1);
                        EqcMf6model.ToolNumber = S7.Net.Types.Word.FromByteArray(udtData.Skip(14).Take(2).ToArray());
                        //bluemelt gluestation
                        EqcMf6model.BluemeltOk = udtData[17].SelectBit(0);
                        EqcMf6model.ActualPressure = S7.Net.Types.Real.FromByteArray(udtData.Skip(18).Take(4).ToArray());

                        EqcMf6model.SetAirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(22).Take(4).ToArray());
                        EqcMf6model.SetAirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(26).Take(4).ToArray());
                        EqcMf6model.SetpumpSpeed1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(30).Take(4).ToArray());

                        EqcMf6model.SetAirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(34).Take(4).ToArray());
                        EqcMf6model.SetAirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(38).Take(4).ToArray());
                        EqcMf6model.SetpumpSpeed2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(42).Take(4).ToArray());

                        EqcMf6model.SetAirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(46).Take(4).ToArray());
                        EqcMf6model.SetpumpSpeed3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(50).Take(4).ToArray());

                        EqcMf6model.Actual_AirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(54).Take(4).ToArray());
                        EqcMf6model.Actual_AirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(58).Take(4).ToArray());
                        EqcMf6model.Actual_AirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(62).Take(4).ToArray());
                        EqcMf6model.Actual_AirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(66).Take(4).ToArray());
                        EqcMf6model.Actual_AirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(70).Take(4).ToArray());
                        //Robot
                        EqcMf6model.RobotAutomaticMode = udtData[74].SelectBit(0);
                        EqcMf6model.RobotRunning = udtData[74].SelectBit(1);
                        EqcMf6model.RobotHome = udtData[74].SelectBit(2);
                        EqcMf6model.RobotConnectedGripper = udtData[74].SelectBit(3);
                        EqcMf6model.RobotToolNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(76).Take(2).ToArray());

                    }
                    else
                    {
                        EqcMf6model.connection = "Error please reload page...";
                    };
                }
            }
            catch (Exception ex)
            {
                EqcMf6model.connection = ex.Message;
            }
            return EqcMf6model;
        }

        //______________________MF7__________________________
        public IActionResult EqcMF7()
        {
            Models.eqcMfModels.EqcMf7_model EqcMf7model = LoadPLCData_MF7(); // nacitat data plc 
            return View(EqcMf7model);
        }

        [HttpGet]
        public JsonResult JsonMF7()
        {
            Models.eqcMfModels.EqcMf7_model EqcMf7model = LoadPLCData_MF7(); // nacitat data plc (ajax)
            return Json(EqcMf7model);
        }

        private Models.eqcMfModels.EqcMf7_model LoadPLCData_MF7()
        {
            Models.eqcMfModels.EqcMf7_model EqcMf7model = new();
            try
            {

                using (var plc_eqcMf7 = new Plc(CpuType.S71500, "10.184.159.171", 0, 1))
                {
                    plc_eqcMf7.Open();//Connect

                    if (plc_eqcMf7.IsConnected)
                    {
                        EqcMf7model.connection = "Connection OK";

                        EqcMf7model.actualDowntime = ((ushort)plc_eqcMf7.Read("DB189.DBW0.0")).ConvertToShort();

                        EqcMf7model.ActualToolName = plc_eqcMf7.Read(DataType.DataBlock, 189, 2, VarType.String, 20).ToString();


                        int startAdress = 258; // Adresa UDT
                        int sizeInBytes = 78; // Veľkosť UDT v bajtoch
                        int numberDB = 189; // Cislo DB blocku v plc

                        //Scan multiply
                        var udtData = plc_eqcMf7.ReadBytes(DataType.DataBlock, numberDB, startAdress, sizeInBytes);
                        //basic info
                        EqcMf7model.MachineAuto = udtData[0].SelectBit(0);
                        EqcMf7model.ConveyorOK = udtData[0].SelectBit(1);
                        EqcMf7model.MainStepNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(2).Take(2).ToArray());
                        EqcMf7model.CycleTime = S7.Net.Types.DInt.FromByteArray(udtData.Skip(4).Take(4).ToArray()) / 10;
                        EqcMf7model.ProductionCurrentNum = S7.Net.Types.DInt.FromByteArray(udtData.Skip(8).Take(4).ToArray());
                        //tool
                        EqcMf7model.ToolHome = udtData[12].SelectBit(0);
                        EqcMf7model.HeaterOk = udtData[12].SelectBit(1);
                        EqcMf7model.ToolNumber = S7.Net.Types.Word.FromByteArray(udtData.Skip(14).Take(2).ToArray());
                        //bluemelt gluestation
                        EqcMf7model.BluemeltOk = udtData[17].SelectBit(0);
                        EqcMf7model.ActualPressure = S7.Net.Types.Real.FromByteArray(udtData.Skip(18).Take(4).ToArray());

                        EqcMf7model.SetAirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(22).Take(4).ToArray());
                        EqcMf7model.SetAirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(26).Take(4).ToArray());
                        EqcMf7model.SetpumpSpeed1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(30).Take(4).ToArray());

                        EqcMf7model.SetAirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(34).Take(4).ToArray());
                        EqcMf7model.SetAirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(38).Take(4).ToArray());
                        EqcMf7model.SetpumpSpeed2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(42).Take(4).ToArray());

                        EqcMf7model.SetAirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(46).Take(4).ToArray());
                        EqcMf7model.SetpumpSpeed3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(50).Take(4).ToArray());

                        EqcMf7model.Actual_AirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(54).Take(4).ToArray());
                        EqcMf7model.Actual_AirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(58).Take(4).ToArray());
                        EqcMf7model.Actual_AirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(62).Take(4).ToArray());
                        EqcMf7model.Actual_AirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(66).Take(4).ToArray());
                        EqcMf7model.Actual_AirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(70).Take(4).ToArray());
                        //Robot
                        EqcMf7model.RobotAutomaticMode = udtData[74].SelectBit(0);
                        EqcMf7model.RobotRunning = udtData[74].SelectBit(1);
                        EqcMf7model.RobotHome = udtData[74].SelectBit(2);
                        EqcMf7model.RobotConnectedGripper = udtData[74].SelectBit(3);
                        EqcMf7model.RobotToolNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(76).Take(2).ToArray());

                    }
                    else
                    {
                        EqcMf7model.connection = "Error please reload page...";
                    };
                }
            }
            catch (Exception ex)
            {
                EqcMf7model.connection = ex.Message;
            }
            return EqcMf7model;
        }

        //______________________MF8__________________________
        public IActionResult EqcMF8()
        {
            Models.eqcMfModels.EqcMf8_model EqcMf8model = LoadPLCData_MF8(); // nacitat data plc 
            return View(EqcMf8model);
        }

        [HttpGet]
        public JsonResult JsonMF8()
        {
            Models.eqcMfModels.EqcMf8_model EqcMf8model = LoadPLCData_MF8(); // nacitat data plc (ajax)
            return Json(EqcMf8model);
        }

        private Models.eqcMfModels.EqcMf8_model LoadPLCData_MF8()
        {
            Models.eqcMfModels.EqcMf8_model EqcMf8model = new();
            try
            {

                using (var plc_eqcMf8 = new Plc(CpuType.S71500, "10.184.159.101", 0, 1))
                {
                    plc_eqcMf8.Open();//Connect

                    if (plc_eqcMf8.IsConnected)
                    {
                        EqcMf8model.connection = "Connection OK";

                        EqcMf8model.actualDowntime = ((ushort)plc_eqcMf8.Read("DB189.DBW0.0")).ConvertToShort();

                        EqcMf8model.ActualToolName = plc_eqcMf8.Read(DataType.DataBlock, 189, 2, VarType.String, 20).ToString();


                        int startAdress = 258; // Adresa UDT
                        int sizeInBytes = 78; // Veľkosť UDT v bajtoch
                        int numberDB = 189; // Cislo DB blocku v plc

                        //Scan multiply
                        var udtData = plc_eqcMf8.ReadBytes(DataType.DataBlock, numberDB, startAdress, sizeInBytes);
                        //basic info
                        EqcMf8model.MachineAuto = udtData[0].SelectBit(0);
                        EqcMf8model.ConveyorOK = udtData[0].SelectBit(1);
                        EqcMf8model.MainStepNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(2).Take(2).ToArray());
                        EqcMf8model.CycleTime = S7.Net.Types.DInt.FromByteArray(udtData.Skip(4).Take(4).ToArray()) / 10;
                        EqcMf8model.ProductionCurrentNum = S7.Net.Types.DInt.FromByteArray(udtData.Skip(8).Take(4).ToArray());
                        //tool
                        EqcMf8model.ToolHome = udtData[12].SelectBit(0);
                        EqcMf8model.HeaterOk = udtData[12].SelectBit(1);
                        EqcMf8model.ToolNumber = S7.Net.Types.Word.FromByteArray(udtData.Skip(14).Take(2).ToArray());
                        //bluemelt gluestation
                        EqcMf8model.BluemeltOk = udtData[17].SelectBit(0);
                        EqcMf8model.ActualPressure = S7.Net.Types.Real.FromByteArray(udtData.Skip(18).Take(4).ToArray());

                        EqcMf8model.SetAirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(22).Take(4).ToArray());
                        EqcMf8model.SetAirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(26).Take(4).ToArray());
                        EqcMf8model.SetpumpSpeed1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(30).Take(4).ToArray());

                        EqcMf8model.SetAirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(34).Take(4).ToArray());
                        EqcMf8model.SetAirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(38).Take(4).ToArray());
                        EqcMf8model.SetpumpSpeed2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(42).Take(4).ToArray());

                        EqcMf8model.SetAirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(46).Take(4).ToArray());
                        EqcMf8model.SetpumpSpeed3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(50).Take(4).ToArray());

                        EqcMf8model.Actual_AirInside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(54).Take(4).ToArray());
                        EqcMf8model.Actual_AirOutside1 = S7.Net.Types.Real.FromByteArray(udtData.Skip(58).Take(4).ToArray());
                        EqcMf8model.Actual_AirInside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(62).Take(4).ToArray());
                        EqcMf8model.Actual_AirOutside2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(66).Take(4).ToArray());
                        EqcMf8model.Actual_AirInside3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(70).Take(4).ToArray());
                        //Robot
                        EqcMf8model.RobotAutomaticMode = udtData[74].SelectBit(0);
                        EqcMf8model.RobotRunning = udtData[74].SelectBit(1);
                        EqcMf8model.RobotHome = udtData[74].SelectBit(2);
                        EqcMf8model.RobotConnectedGripper = udtData[74].SelectBit(3);
                        EqcMf8model.RobotToolNumber = S7.Net.Types.Int.FromByteArray(udtData.Skip(76).Take(2).ToArray());

                    }
                    else
                    {
                        EqcMf8model.connection = "Error please reload page...";
                    };
                }
            }
            catch (Exception ex)
            {
                EqcMf8model.connection = ex.Message;
            }
            return EqcMf8model;
        }





































    }
}
