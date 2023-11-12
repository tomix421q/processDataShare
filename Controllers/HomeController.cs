
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
            Models.MainIndex_model MainIndexModel = LoadPLCData(); // nacitat data plc                    
            return View(MainIndexModel);
        }

        [HttpGet]
        public JsonResult JsonMainIndex()
        {
            Models.MainIndex_model MainIndexModel = LoadPLCData(); // nacitat data plc (ajax)
            return Json(MainIndexModel);
        }

        private Models.MainIndex_model LoadPLCData()
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
                //________________ASQ_3_________________
                try
                {
                    using (var plc_asq3 = new Plc(CpuType.S71500, "10.184.159.240", 0, 1))
                    {
                        plc_asq3.Open();
                        if (plc_asq3.IsConnected)
                        {
                            MainIndexModel.ASQ_3_ROB1_Downtime_Time = ((ushort)plc_asq3.Read("DB179.DBW0.0")).ConvertToShort();
                            MainIndexModel.ASQ_3_ROB2_Downtime_Time = ((ushort)plc_asq3.Read("DB179.DBW20.0")).ConvertToShort();
                        }
                        else
                        {
                            MainIndexModel.connectionAsq3 = "Nieco sa pokazilo :(";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionAsq3 = ex.Message;
                }
                //________________ASQ_4_________________
                try
                {
                    using (var plc_asq4 = new Plc(CpuType.S71500, "10.184.159.12", 0, 1))
                    {
                        plc_asq4.Open();
                        if (plc_asq4.IsConnected)
                        {
                            MainIndexModel.ASQ_4_ROB1_Downtime_Time = ((ushort)plc_asq4.Read("DB179.DBW0.0")).ConvertToShort();
                            MainIndexModel.ASQ_4_ROB2_Downtime_Time = ((ushort)plc_asq4.Read("DB179.DBW20.0")).ConvertToShort();
                        }
                        else
                        {
                            MainIndexModel.connectionAsq4 = "Nieco sa pokazilo :(";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionAsq4 = ex.Message;
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
                //________________ASQ_6__________________
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
                //________________Opel_Armrest FD________
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
                            MainIndexModel.connectionOpelArmrestFd = "Nieco sa pokazilo...";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionOpelArmrestFd = ex.Message;

                }
                //________________Opel_Armrest RD_________
                try
                {
                    using (var plc_OpelArmrestRd = new Plc(CpuType.S71500, "10.184.159.46", 0, 1))
                    {
                        plc_OpelArmrestRd.Open();
                        if (plc_OpelArmrestRd.IsConnected)
                        {
                            MainIndexModel.OpelArmrestRD_actualDowntime = ((ushort)plc_OpelArmrestRd.Read("DB26.DBW0.0")).ConvertToShort();
                        }
                        else
                        {
                            MainIndexModel.connectionOpelArmrestRd = "Nieco sa pokazilo...";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionOpelArmrestRd = ex.Message;

                }
                //________________Opel_Insert FD__________
                try
                {
                    using (var plc_opelInsertFD = new Plc(CpuType.S71500, "10.184.159.48", 0, 1))
                    {
                        plc_opelInsertFD.Open();
                        if (plc_opelInsertFD.IsConnected)
                        {
                            MainIndexModel.OpelInsertFD_actualDowntime = ((ushort)plc_opelInsertFD.Read("DB26.DBW0.0")).ConvertToShort();
                        }
                        else
                        {
                            MainIndexModel.connectionOpelInsertFd = "Nieco sa pokazilo...";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionOpelInsertFd = ex.Message;

                }
                //________________Opel_Insert RD__________
                try
                {
                    using (var plc_opelInsertRD = new Plc(CpuType.S71500, "10.184.159.47", 0, 1))
                    {
                        plc_opelInsertRD.Open();
                        if (plc_opelInsertRD.IsConnected)
                        {
                            MainIndexModel.OpelInsertRD_actualDowntime = ((ushort)plc_opelInsertRD.Read("DB26.DBW0.0")).ConvertToShort();
                        }
                        else
                        {
                            MainIndexModel.connectionOpelInsertRd = "Nieco sa pokazilo...";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionOpelInsertRd = ex.Message;

                }
                //_________________Eqc Mf M1_______________
                try
                {
                    using (var plc_eqcMf1 = new Plc(CpuType.S71500, "10.184.159.173", 0, 1))
                    {
                        plc_eqcMf1.Open();
                        if (plc_eqcMf1.IsConnected)
                        {
                            MainIndexModel.EqcMF1_actualDownTime = ((ushort)plc_eqcMf1.Read("DB189.DBW0.0")).ConvertToShort();
                        }
                        else
                        {
                            MainIndexModel.connectionEqcMF1 = "Nieco sa pokazilo...";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionEqcMF1 = ex.Message;

                }
                //_________________Eqc Mf M2_______________
                try
                {
                    using (var plc_eqcMf2 = new Plc(CpuType.S71500, "10.184.159.174", 0, 1))
                    {
                        plc_eqcMf2.Open();
                        if (plc_eqcMf2.IsConnected)
                        {
                            MainIndexModel.EqcMF2_actualDownTime = ((ushort)plc_eqcMf2.Read("DB189.DBW0.0")).ConvertToShort();
                        }
                        else
                        {
                            MainIndexModel.connectionEqcMF2 = "Nieco sa pokazilo...";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionEqcMF2 = ex.Message;

                }
                //_________________Eqc Mf M3_______________
                try
                {
                    using (var plc_eqcMf3 = new Plc(CpuType.S71500, "10.184.159.175", 0, 1))
                    {
                        plc_eqcMf3.Open();
                        if (plc_eqcMf3.IsConnected)
                        {
                            MainIndexModel.EqcMF3_actualDownTime = ((ushort)plc_eqcMf3.Read("DB189.DBW0.0")).ConvertToShort();
                        }
                        else
                        {
                            MainIndexModel.connectionEqcMF3 = "Nieco sa pokazilo...";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionEqcMF3 = ex.Message;

                }
                //_________________Eqc Mf M4_______________
                try
                {
                    using (var plc_eqcMf4 = new Plc(CpuType.S71500, "10.184.159.176", 0, 1))
                    {
                        plc_eqcMf4.Open();
                        if (plc_eqcMf4.IsConnected)
                        {
                            MainIndexModel.EqcMF4_actualDownTime = ((ushort)plc_eqcMf4.Read("DB189.DBW0.0")).ConvertToShort();
                        }
                        else
                        {
                            MainIndexModel.connectionEqcMF4 = "Nieco sa pokazilo...";
                        }
                    }

                }
                catch (Exception ex)
                {
                    MainIndexModel.connectionEqcMF4 = ex.Message;

                }
                return MainIndexModel;
            }
















        }            //plc data loader main index
    }
}

























