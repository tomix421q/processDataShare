
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
                //________________ASQ_6__________________
                try
                {
                    using (var plc_asq6 = new Plc(CpuType.S71500, "10.184.159.184", 0, 1))
                    {
                        plc_asq6.Open();
                        if (plc_asq6.IsConnected)
                        {
                            MainIndexModel.ASQ_6_ROB1_Downtime_Time = ((ushort)plc_asq6.Read("DB179.DBW0.0")).ConvertToShort() ;
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












                return View(MainIndexModel);
            }
        }






    }
}


