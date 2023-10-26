﻿using Microsoft.AspNetCore.Mvc;
using S7.Net;
using S7.Net.Types;

namespace processDataShare.Controllers
{
    public class OpelController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        //______________________OpelArmrest_FD_________________________
        public IActionResult OpelArmrestFD()
        {
            Models.OpelArmrestFront_model OpelArmrestFDmodel = new();
            Models.OpelArmrestData UDTopelArmrestFDmodel = new();
            Models.MainIndex_model MainIndexModel = new();
            try
            {

                using (var plc_opelArmrestFD = new Plc(CpuType.S71500, "10.184.159.45", 0, 1))
                {
                    plc_opelArmrestFD.Open();//Connect

                    if (plc_opelArmrestFD.IsConnected)
                    {
                        ViewBag.connection = "Connection OK";

                        OpelArmrestFDmodel.rightPart = ((uint)plc_opelArmrestFD.Read("DB26.DBD2.0")).ConvertToInt();
                        OpelArmrestFDmodel.leftPart = ((uint)plc_opelArmrestFD.Read("DB26.DBD6.0")).ConvertToInt();
                        OpelArmrestFDmodel.actualStep = ((uint)plc_opelArmrestFD.Read("DB26.DBD10.0")).ConvertToInt();
                        OpelArmrestFDmodel.actualDowntime = ((ushort)plc_opelArmrestFD.Read("DB26.DBW0.0")).ConvertToShort();

                        int startAdress = 14; // Adresa UDT
                        int sizeInBytes = 39; // Veľkosť UDT v bajtoch 39
                        int numberDB = 26; // Cislo DB blocku v plc

                        //Scan UDT
                        var udtData = plc_opelArmrestFD.ReadBytes(DataType.DataBlock, numberDB, startAdress, sizeInBytes);
                        // UDT
                        OpelArmrestFDmodel.tempLeftUp = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(0).Take(4).ToArray()));
                        OpelArmrestFDmodel.tempRightUp = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(4).Take(4).ToArray()));
                        OpelArmrestFDmodel.tempLeftDown = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(8).Take(4).ToArray()));                      
                        OpelArmrestFDmodel.tempRightDown = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(12).Take(4).ToArray()));
                        OpelArmrestFDmodel.heatingTime = S7.Net.Types.Int.FromByteArray(udtData.Skip(16).Take(2).ToArray())/10;
                        OpelArmrestFDmodel.heatingSetPointMax = S7.Net.Types.Int.FromByteArray(udtData.Skip(18).Take(2).ToArray())/10;
                        OpelArmrestFDmodel.foldingTime = S7.Net.Types.Int.FromByteArray(udtData.Skip(20).Take(2).ToArray())/10;
                        OpelArmrestFDmodel.foldingSetPointMax = S7.Net.Types.Int.FromByteArray(udtData.Skip(22).Take(2).ToArray()) / 10;
                        OpelArmrestFDmodel.cycleTime = S7.Net.Types.Int.FromByteArray(udtData.Skip(24).Take(2).ToArray()) / 10;
                        OpelArmrestFDmodel.shotDateTime = S7.Net.Types.DateTime.FromByteArray(udtData.Skip(26).Take(8).ToArray());
                        OpelArmrestFDmodel.mouldNumber = S7.Net.Types.Word.FromByteArray(udtData.Skip(34).Take(2).ToArray());
                        OpelArmrestFDmodel.recipe = S7.Net.Types.Int.FromByteArray(udtData.Skip(36).Take(2).ToArray());
                        OpelArmrestFDmodel.pyroIndicatorOnOff = udtData[38].SelectBit(0);

                        //if (OpelArmrestFDmodel.actualStep == 2)
                        //{
                        //    var opelData = new OpelArmrestData
                        //    {

                        //        // Nastavte vlastnosti objektu OpelArmrestData z OpelArmrestFDmodel
                        //        tempLeftUp = OpelArmrestFDmodel.tempLeftUp,
                        //        tempRightUp = OpelArmrestFDmodel.tempRightUp,
                        //        tempRightDown = OpelArmrestFDmodel.tempRightDown,
                        //        tempLeftDown = OpelArmrestFDmodel.tempLeftDown,
                        //        heatingTime = OpelArmrestFDmodel.heatingTime,
                        //        heatingSetPointMax = OpelArmrestFDmodel.heatingSetPointMax,
                        //        foldingTime = OpelArmrestFDmodel.foldingTime,
                        //        foldingSetPointMax = OpelArmrestFDmodel.foldingSetPointMax,
                        //        cycleTime = OpelArmrestFDmodel.cycleTime,
                        //        shotDateTime = OpelArmrestFDmodel.shotDateTime,
                        //        mouldNumber = OpelArmrestFDmodel.mouldNumber,
                        //        recipe = OpelArmrestFDmodel.recipe,
                        //        pyroIndicatorOnOff = OpelArmrestFDmodel.pyroIndicatorOnOff
                        //    };

                        //    _context.OpelArmrestData.Add(opelData);
                        //    _context.SaveChanges();
                        //}

                    }
                    else
                    {
                        ViewBag.connection = "Something is bad..." + MainIndexModel.connectionOpelArmrestFd;
                    };
                }
            }
            catch (Exception ex)
            {
                MainIndexModel.connectionOpelArmrestFd = ex.Message;
                ViewBag.connection = MainIndexModel.connectionOpelArmrestFd;
            }
            return View(OpelArmrestFDmodel);
        }
        //______________________OpelArmrest_RD_________________________
        public IActionResult OpelArmrestRD()
        {
            Models.OpelArmrestRear_model OpelArmrestRDmodel = new();
            
            Models.MainIndex_model MainIndexModel = new();
            try
            {

                using (var plc_opelArmrestRD = new Plc(CpuType.S71500, "10.184.159.46", 0, 1))
                {
                    plc_opelArmrestRD.Open();//Connect

                    if (plc_opelArmrestRD.IsConnected)
                    {
                        ViewBag.connection = "Connection OK";

                        OpelArmrestRDmodel.rightPart = ((uint)plc_opelArmrestRD.Read("DB26.DBD2.0")).ConvertToInt();
                        OpelArmrestRDmodel.leftPart = ((uint)plc_opelArmrestRD.Read("DB26.DBD6.0")).ConvertToInt();
                        OpelArmrestRDmodel.actualStep = ((uint)plc_opelArmrestRD.Read("DB26.DBD10.0")).ConvertToInt();
                        OpelArmrestRDmodel.actualDowntime = ((ushort)plc_opelArmrestRD.Read("DB26.DBW0.0")).ConvertToShort();

                        int startAdress = 14; // Adresa UDT
                        int sizeInBytes = 39; // Veľkosť UDT v bajtoch 39
                        int numberDB = 26; // Cislo DB blocku v plc

                        //Scan UDT
                        var udtData = plc_opelArmrestRD.ReadBytes(DataType.DataBlock, numberDB, startAdress, sizeInBytes);
                        // UDT
                        OpelArmrestRDmodel.tempLeftUp = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(0).Take(4).ToArray()));
                        OpelArmrestRDmodel.tempRightUp = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(4).Take(4).ToArray()));
                        OpelArmrestRDmodel.tempLeftDown = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(8).Take(4).ToArray()));
                        OpelArmrestRDmodel.tempRightDown = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(12).Take(4).ToArray()));
                        OpelArmrestRDmodel.heatingTime = S7.Net.Types.Int.FromByteArray(udtData.Skip(16).Take(2).ToArray()) / 10;
                        OpelArmrestRDmodel.heatingSetPointMax = S7.Net.Types.Int.FromByteArray(udtData.Skip(18).Take(2).ToArray()) / 10;
                        OpelArmrestRDmodel.foldingTime = S7.Net.Types.Int.FromByteArray(udtData.Skip(20).Take(2).ToArray()) / 10;
                        OpelArmrestRDmodel.foldingSetPointMax = S7.Net.Types.Int.FromByteArray(udtData.Skip(22).Take(2).ToArray()) / 10;
                        OpelArmrestRDmodel.cycleTime = S7.Net.Types.Int.FromByteArray(udtData.Skip(24).Take(2).ToArray()) / 10;
                        OpelArmrestRDmodel.shotDateTime = S7.Net.Types.DateTime.FromByteArray(udtData.Skip(26).Take(8).ToArray());
                        OpelArmrestRDmodel.mouldNumber = S7.Net.Types.Word.FromByteArray(udtData.Skip(34).Take(2).ToArray());
                        OpelArmrestRDmodel.recipe = S7.Net.Types.Int.FromByteArray(udtData.Skip(36).Take(2).ToArray());
                        OpelArmrestRDmodel.pyroIndicatorOnOff = udtData[38].SelectBit(0);

                        //if (OpelArmrestFDmodel.actualStep == 2)
                        //{
                        //    var opelData = new OpelArmrestData
                        //    {

                        //        // Nastavte vlastnosti objektu OpelArmrestData z OpelArmrestFDmodel
                        //        tempLeftUp = OpelArmrestFDmodel.tempLeftUp,
                        //        tempRightUp = OpelArmrestFDmodel.tempRightUp,
                        //        tempRightDown = OpelArmrestFDmodel.tempRightDown,
                        //        tempLeftDown = OpelArmrestFDmodel.tempLeftDown,
                        //        heatingTime = OpelArmrestFDmodel.heatingTime,
                        //        heatingSetPointMax = OpelArmrestFDmodel.heatingSetPointMax,
                        //        foldingTime = OpelArmrestFDmodel.foldingTime,
                        //        foldingSetPointMax = OpelArmrestFDmodel.foldingSetPointMax,
                        //        cycleTime = OpelArmrestFDmodel.cycleTime,
                        //        shotDateTime = OpelArmrestFDmodel.shotDateTime,
                        //        mouldNumber = OpelArmrestFDmodel.mouldNumber,
                        //        recipe = OpelArmrestFDmodel.recipe,
                        //        pyroIndicatorOnOff = OpelArmrestFDmodel.pyroIndicatorOnOff
                        //    };

                        //    _context.OpelArmrestData.Add(opelData);
                        //    _context.SaveChanges();
                        //}

                    }
                    else
                    {
                        ViewBag.connection = "Something is bad..." + MainIndexModel.connectionOpelArmrestRd;
                    };
                }
            }
            catch (Exception ex)
            {
                MainIndexModel.connectionOpelArmrestRd = ex.Message;
                ViewBag.connection = MainIndexModel.connectionOpelArmrestRd;
            }
            return View(OpelArmrestRDmodel);
        }
        //______________________OpelInsert_FD__________________________
        public IActionResult OpelInsertFD()
        {
            Models.OpelInsertFront_model OpelInsertFDmodel = new();
            Models.MainIndex_model MainIndexModel = new();
            try
            {

                using (var plc_opelInsertFD = new Plc(CpuType.S71500, "10.184.159.48", 0, 1))
                {
                    plc_opelInsertFD.Open();//Connect

                    if (plc_opelInsertFD.IsConnected)
                    {
                        ViewBag.connection = "Connection OK";

                        OpelInsertFDmodel.rightPart = ((uint)plc_opelInsertFD.Read("DB26.DBD2.0")).ConvertToInt();
                        OpelInsertFDmodel.leftPart = ((uint)plc_opelInsertFD.Read("DB26.DBD6.0")).ConvertToInt();
                        OpelInsertFDmodel.actualStep = ((uint)plc_opelInsertFD.Read("DB26.DBD10.0")).ConvertToInt();
                        OpelInsertFDmodel.actualDowntime = ((ushort)plc_opelInsertFD.Read("DB26.DBW0.0")).ConvertToShort();

                        int startAdress = 14; // Adresa UDT
                        int sizeInBytes = 41; // Veľkosť UDT v bajtoch 39
                        int numberDB = 26; // Cislo DB blocku v plc

                        //Scan UDT
                        var udtData = plc_opelInsertFD.ReadBytes(DataType.DataBlock, numberDB, startAdress, sizeInBytes);
                        // UDT
                        OpelInsertFDmodel.tempLeftUp = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(0).Take(4).ToArray()));
                        OpelInsertFDmodel.tempRightUp = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(4).Take(4).ToArray()));
                        OpelInsertFDmodel.tempLeftDown = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(8).Take(4).ToArray()));
                        OpelInsertFDmodel.tempRightDown = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(12).Take(4).ToArray()));
                        OpelInsertFDmodel.heatingTime = S7.Net.Types.Int.FromByteArray(udtData.Skip(16).Take(2).ToArray()) / 10;
                        OpelInsertFDmodel.heatingSetPointMax = S7.Net.Types.Int.FromByteArray(udtData.Skip(18).Take(2).ToArray()) / 10;
                        OpelInsertFDmodel.foldingTime = S7.Net.Types.Int.FromByteArray(udtData.Skip(20).Take(2).ToArray()) / 10;
                        OpelInsertFDmodel.foldingSetPointMax = S7.Net.Types.Int.FromByteArray(udtData.Skip(22).Take(2).ToArray()) / 10;
                        OpelInsertFDmodel.cycleTime = S7.Net.Types.Int.FromByteArray(udtData.Skip(24).Take(2).ToArray()) / 10;
                        OpelInsertFDmodel.shotDateTime = S7.Net.Types.DateTime.FromByteArray(udtData.Skip(26).Take(8).ToArray());
                        OpelInsertFDmodel.mouldNumber = S7.Net.Types.Word.FromByteArray(udtData.Skip(34).Take(2).ToArray());
                        OpelInsertFDmodel.recipe = S7.Net.Types.Int.FromByteArray(udtData.Skip(36).Take(2).ToArray());
                        OpelInsertFDmodel.partRecipe = S7.Net.Types.Int.FromByteArray(udtData.Skip(38).Take(2).ToArray());
                        OpelInsertFDmodel.pyroIndicatorOnOff = udtData[40].SelectBit(0);
                        OpelInsertFDmodel.Workside_A = udtData[40].SelectBit(1);
                        Console.WriteLine(OpelInsertFDmodel.Workside_A);
                        OpelInsertFDmodel.Workside_B = udtData[40].SelectBit(2);
                        Console.WriteLine(OpelInsertFDmodel.Workside_B);
                    }
                    else
                    {
                        ViewBag.connection = "Something is bad..." + MainIndexModel.connectionOpelInsertFd;
                    };
                }
            }
            catch (Exception ex)
            {
                MainIndexModel.connectionOpelInsertFd = ex.Message;
                ViewBag.connection = MainIndexModel.connectionOpelInsertFd;
            }
            return View(OpelInsertFDmodel);
        }
        //______________________OpelInsert_RD__________________________
        public IActionResult OpelInsertRD()
        {
            Models.OpelInsertRear_model OpelInsertRDmodel = new();
            Models.MainIndex_model MainIndexModel = new();
            try
            {

                using (var plc_opelInsertRD = new Plc(CpuType.S71500, "10.184.159.47", 0, 1))
                {
                    plc_opelInsertRD.Open();//Connect

                    if (plc_opelInsertRD.IsConnected)
                    {
                        ViewBag.connection = "Connection OK";

                        OpelInsertRDmodel.rightPart = ((uint)plc_opelInsertRD.Read("DB26.DBD2.0")).ConvertToInt();
                        OpelInsertRDmodel.leftPart = ((uint)plc_opelInsertRD.Read("DB26.DBD6.0")).ConvertToInt();
                        OpelInsertRDmodel.actualStep = ((uint)plc_opelInsertRD.Read("DB26.DBD10.0")).ConvertToInt();
                        OpelInsertRDmodel.actualDowntime = ((ushort)plc_opelInsertRD.Read("DB26.DBW0.0")).ConvertToShort();

                        int startAdress = 14; // Adresa UDT
                        int sizeInBytes = 41; // Veľkosť UDT v bajtoch 39
                        int numberDB = 26; // Cislo DB blocku v plc

                        //Scan UDT
                        var udtData = plc_opelInsertRD.ReadBytes(DataType.DataBlock, numberDB, startAdress, sizeInBytes);
                        // UDT
                        OpelInsertRDmodel.tempLeftUp = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(0).Take(4).ToArray()));
                        OpelInsertRDmodel.tempRightUp = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(4).Take(4).ToArray()));
                        OpelInsertRDmodel.tempLeftDown = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(8).Take(4).ToArray()));
                        OpelInsertRDmodel.tempRightDown = (int)Math.Round(S7.Net.Types.Real.FromByteArray(udtData.Skip(12).Take(4).ToArray()));
                        OpelInsertRDmodel.heatingTime = S7.Net.Types.Int.FromByteArray(udtData.Skip(16).Take(2).ToArray()) / 10;
                        OpelInsertRDmodel.heatingSetPointMax = S7.Net.Types.Int.FromByteArray(udtData.Skip(18).Take(2).ToArray()) / 10;
                        OpelInsertRDmodel.foldingTime = S7.Net.Types.Int.FromByteArray(udtData.Skip(20).Take(2).ToArray()) / 10;
                        OpelInsertRDmodel.foldingSetPointMax = S7.Net.Types.Int.FromByteArray(udtData.Skip(22).Take(2).ToArray()) / 10;
                        OpelInsertRDmodel.cycleTime = S7.Net.Types.Int.FromByteArray(udtData.Skip(24).Take(2).ToArray()) / 10;
                        OpelInsertRDmodel.shotDateTime = S7.Net.Types.DateTime.FromByteArray(udtData.Skip(26).Take(8).ToArray());
                        OpelInsertRDmodel.mouldNumber = S7.Net.Types.Word.FromByteArray(udtData.Skip(34).Take(2).ToArray());
                        OpelInsertRDmodel.recipe = S7.Net.Types.Int.FromByteArray(udtData.Skip(36).Take(2).ToArray());
                        OpelInsertRDmodel.partRecipe = S7.Net.Types.Int.FromByteArray(udtData.Skip(38).Take(2).ToArray());
                        OpelInsertRDmodel.pyroIndicatorOnOff = udtData[40].SelectBit(0);
                        OpelInsertRDmodel.Workside_A = udtData[40].SelectBit(1);
                        Console.WriteLine(OpelInsertRDmodel.Workside_A);
                        OpelInsertRDmodel.Workside_B = udtData[40].SelectBit(2);
                        Console.WriteLine(OpelInsertRDmodel.Workside_B);
                    }
                    else
                    {
                        ViewBag.connection = "Something is bad..." + MainIndexModel.connectionOpelInsertRd;
                    };
                }
            }
            catch (Exception ex)
            {
                MainIndexModel.connectionOpelInsertRd = ex.Message;
                ViewBag.connection = MainIndexModel.connectionOpelInsertRd;
            }
            return View(OpelInsertRDmodel);
        }

    }
}
