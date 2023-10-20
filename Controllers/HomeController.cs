﻿
using Microsoft.AspNetCore.Mvc;
using S7.Net;
using S7.Net.Types;

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
                //________________ASQ_1_________________
                try
                {
                    using (var plc_asq1 = new Plc(CpuType.S71500, "10.184.159.241", 0, 1))
                    {
                        plc_asq1.Open();
                        if (plc_asq1.IsConnected)
                        {
                            MainIndexModel.ASQ_1_ROB1_Downtime_Time = ((ushort)plc_asq1.Read("DB179.DBW0.0")).ConvertToShort();
                            MainIndexModel.ASQ_1_ROB2_Downtime_Time = ((ushort)plc_asq1.Read("DB179.DBW20.0")).ConvertToShort();
                        }
                        else
                        {
                            MainIndexModel.connectionAsq1 = "Nieco sa pokazilo :(";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionAsq1 = ex.Message;
                }
                //________________ASQ_2_________________
                try
                {
                    using (var plc_asq2 = new Plc(CpuType.S71500, "10.184.159.109", 0, 1))
                    {
                        plc_asq2.Open();
                        if (plc_asq2.IsConnected)
                        {
                            MainIndexModel.ASQ_2_ROB1_Downtime_Time = ((ushort)plc_asq2.Read("DB179.DBW0.0")).ConvertToShort();
                            MainIndexModel.ASQ_2_ROB2_Downtime_Time = ((ushort)plc_asq2.Read("DB179.DBW20.0")).ConvertToShort();
                        }
                        else
                        {
                            MainIndexModel.connectionAsq2 = "Nieco sa pokazilo :(";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionAsq2 = ex.Message;
                }
                //________________ASQ_5_________________
                try
                {
                    using (var plc_asq5 = new Plc(CpuType.S71500, "10.184.159.108", 0, 1))
                    {
                        plc_asq5.Open();
                        if (plc_asq5.IsConnected)
                        {
                            MainIndexModel.ASQ_5_ROB1_Downtime_Time = ((ushort)plc_asq5.Read("DB179.DBW0.0")).ConvertToShort();
                            MainIndexModel.ASQ_5_ROB2_Downtime_Time = ((ushort)plc_asq5.Read("DB179.DBW20.0")).ConvertToShort();
                        }
                        else
                        {
                            MainIndexModel.connectionAsq5 = "Nieco sa pokazilo :(";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionAsq5 = ex.Message;
                }
                //_______________ASQ_6________________
                try
                {
                    using (var plc_asq6 = new Plc(CpuType.S71500, "10.184.159.184", 0, 1))
                    {
                        plc_asq6.Open();
                        if (plc_asq6.IsConnected)
                        {
                            MainIndexModel.ASQ_6_ROB1_Downtime_Time = ((ushort)plc_asq6.Read("DB179.DBW0.0")).ConvertToShort();
                            MainIndexModel.ASQ_6_ROB2_Downtime_Time = ((ushort)plc_asq6.Read("DB179.DBW20.0")).ConvertToShort();
                        }
                        else
                        {
                            MainIndexModel.connectionAsq6 = "Nepodarilo sa pripojiť k PLC ASQ6.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionAsq6 = ex.Message;
                }
                //________________Armrest_________________
                try
                {
                    using (var plc_OpelArmrestFd = new Plc(CpuType.S71500, "10.184.159.45", 0, 1))
                    {
                        plc_OpelArmrestFd.Open();
                        if (plc_OpelArmrestFd.IsConnected)
                        {
                            //var bytes = plc_OpelArmrestFd.ReadBytes(DataType.DataBlock, 24, 50442, 200);
                            MainIndexModel.OpelArmrestFD_actualDowntime = ((ushort)plc_OpelArmrestFd.Read("DB26.DBW0.0")).ConvertToShort();
                            //var temp = ((uint)plc_OpelArmrestFd.Read("DB24.DBD50442.0")).ConvertToFloat();

                            int udtAddress = 48040; // Adresa UDT
                            int udtSizeInBytes = 16; // Veľkosť UDT v bajtoch 39

                            byte[] udtData = plc_OpelArmrestFd.ReadBytes(DataType.DataBlock, 2, udtAddress, udtSizeInBytes);

                            // UDT obsahuje int, float a bool
                            float realValue1 = S7.Net.Types.Real.FromByteArray(udtData.Take(4).ToArray();
                            float realValue2 = S7.Net.Types.Real.FromByteArray(udtData.Skip(4).Take(4).ToArray();
                            float realValue3 = S7.Net.Types.Real.FromByteArray(udtData.Skip(8).Take(4).ToArray();
                            float realValue4 = S7.Net.Types.Real.FromByteArray(udtData.Skip(12).Take(4).ToArray();
                            Console.WriteLine(realValue1,realValue2,realValue3,realValue4);
                        }
                catch (Exception ex)
                {
                    MainIndexModel.connectionOpelArmrestFd = ex.Message;
                    
                }




                return View(MainIndexModel);
            }
        }






    }
}


