using Microsoft.AspNet.SignalR;
using Sundorbon.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using DbExecutor;
using SecurityBLL;
using SecurityEntity;

namespace Sundorbon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LandingPage()
        {
            return View();
        }
        //[HttpGet]
        //public JsonResult GetCompanyAddressByCompanyId(int companyId)
        //{

        //    try
        //    {
        //       // var list = Facade.CompanyAddressBLL.GetByCompanyId(companyId);
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        error_Log error = new error_Log();
        //        error.ErrorMessage = ex.Message;
        //        error.ErrorType = ex.GetType().ToString();
        //        error.FileName = "CompanyController";
              
        //        throw;
        //    }
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }

        public string DoorLock(string cu, bool status)
        {
            string LockStatus = null;

            if (status == true)
            {
                LockStatus = "Locked";
            }
            else
            {
                LockStatus = "UnLocked";
            }

            return "Charging Unit : " + cu +"<br>"+ "Lock Status : " + LockStatus;
        }

        public string NotifyClient(string name, string message)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();           
            hubContext.Clients.All.broadcastMessage(name, message);
            return name + " Says " + message;
        }

        public string BatteryStatus(string location, string swapStation, string chargingUnit, string battery, decimal voltage, decimal amper)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            hubContext.Clients.All.broadcastBatteryStatus(location, swapStation, chargingUnit, battery, voltage, amper);
            return "Location : " + location + "<br>" + "Swap Station : " + swapStation + "<br>" + "Charging Unit : " + chargingUnit + "<br>" + "Battery : " + battery + "<br>" + "Voltage : " + voltage + "<br>" + "Amper : " + amper;
        }


        public string UserBatteryStatus(string location, string swapStation, string portName, string battery, string charging, string voltage, string ampere)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            hubContext.Clients.All.broadcastUserBatteryStatus(location, swapStation, portName, battery, charging, voltage, ampere);
            return "Done";
        }
        public string SetChargingPortError(int arduinoId, int errorId)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            hubContext.Clients.All.broadcastChargingPortError(arduinoId, errorId);
            return "Done";
        }

        // public static List<int> lockStatus = new List<int> {0,0,0,0,0,0,0,0};


        //public int SetLockerStatus(int arduinoId, int status)
        //{
        //    lockStatus.Insert(arduinoId, status);

        //    var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
        //    hubContext.Clients.All.broadcastDoorLockUnLockStatus(arduinoId, status);
        //    return lockStatus[arduinoId];
        //}

        //public int GetLockerStatus(int arduinoId)
        //{
        //    //int aurduinoId; 
        //    //if (lockStatus[arduinoId]==true)
        //    //{
        //    //    aurduinoId = 1;
        //    //}
        //    //else
        //    //{
        //    //    aurduinoId = 0;
        //    //}
        //    return lockStatus[arduinoId];
        //}

        public static List<bool> lockStatus = new List<bool> { false, false, false, false, false, false, false, false };


        public bool SetLockerStatus(int arduinoId, bool status)
        {

            lockStatus.Insert(arduinoId, status);

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            hubContext.Clients.All.broadcastDoorLockUnLockStatus(arduinoId, status);

            return lockStatus[arduinoId];

        }

        public bool GetLockerStatus(int arduinoId)
        {

            return lockStatus[arduinoId];
        }
    


    public static List<string> BatterylockStatus = new List<string> {"B","C"};

        public string SetBatteryStatusRequest(int arduinoId, string status)
        {

            BatterylockStatus.Insert(arduinoId, status);
            return BatterylockStatus[arduinoId];
        }


        public string GetBatteryStatusRequest(int arduinoId)
        {
            try
            {
                return BatterylockStatus[arduinoId];
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }
           
        }
    }
}