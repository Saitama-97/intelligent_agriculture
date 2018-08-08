using IntelligentAgriculture.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntelligentAgriculture.Controllers
{
    public class DeviceController : Controller
    {
        private string MAC;

        public ActionResult select()
        {
            MAC = Request["MAC"].Trim();
            ADevice deviceAciton = new ADevice();
            var result = deviceAciton.select(MAC);
            if (result != null)
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = 0,
                    des = "成功",
                    data = result
                }));

            }
            else
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = -1,
                    des = "失败",

                }));
            }

        }
    }
}