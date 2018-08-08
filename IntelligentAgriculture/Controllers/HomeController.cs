using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntelligentAgriculture.Controllers
{
    public class HomeController : Controller
    {

        private string timeStamp;
        private string authenticator;

        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult BGQuery()
        {
            try
            {

                timeStamp = Request["timeStamp"].Trim();
                authenticator = Request["authenticator"].Trim();
             
                    return Content(JsonConvert.SerializeObject(new
                    {
                        code = 0,
                        des = "OK",

                    }));

                
            }
            catch (Exception error)
            {
                // 登录失败会抛出登录异常
                return Content(JsonConvert.SerializeObject(new
                {
                    code = -1,
                    err = error.Message
                }));
            }

        }
    }
}