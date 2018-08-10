using IntelligentAgriculture.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntelligentAgriculture.Controllers
{
    public class ResultController : Controller
    {
        private string mac;
        // 查询单个Mac地址的信息
        public ActionResult Select(string mac)
        {
            mac = Request["mac"].Trim();
            AResult result = new AResult();
            var rs = result.select(mac);
            if (rs != null)
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = 1,
                    des = "查询成功",
                    data = rs,
                }));
            }
            else
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = 0,
                    des = "查询失败",
                }));
            }
        }
    }
}