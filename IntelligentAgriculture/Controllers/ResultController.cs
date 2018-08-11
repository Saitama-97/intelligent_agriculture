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

        // 查询全部结果
        public ActionResult Showall()
        {
            AResult result = new AResult();
            var rs = result.showall();
            if(rs != null)
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

        // 按节点查看结果
        public ActionResult ShowByMac(string mac)
        {
            AResult result = new AResult();
            var rs = result.show_mac(mac);
            if(rs != null)
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

        // 按节点查询最新信息
        public ActionResult ShowLatest(string mac)
        {
            AResult result = new AResult();
            var rs = result.showlatest(mac);
            if(rs != null)
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