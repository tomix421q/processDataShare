using Microsoft.AspNetCore.Mvc;
using S7.Net;

namespace processDataShare.Controllers
{
    public class OpelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //______________________OpelArmrestFD_________________________
        public IActionResult OpelArmrestFD()
        {
            Models.OpelArmrestFront_model OpelArmrestFDmodel = new();
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
                    }
                    else
                    {
                        ViewBag.connection = "Something is bad..." + MainIndexModel.connectionOpelArmrestFd;
                    };
                }
            }
            catch (Exception ex)
            {
                MainIndexModel.connectionAsq5 = ex.Message;
                ViewBag.connection = MainIndexModel.connectionOpelArmrestFd;
            }
            return View(OpelArmrestFDmodel);
        }
    }
}
