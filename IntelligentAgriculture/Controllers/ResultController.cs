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
            var rs1 = result.show_mac(mac);
            if(rs1 != null)
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = 1,
                    des = "查询成功",
                    data = rs1,
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

        // 按节点查询Type
        public ActionResult ShowTypeByMac(string mac)
        {
            ADevice device = new ADevice();
            var rs = device.returnType(mac);
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
        public ActionResult ShowLatestByMac(string mac)
        {
            AResult result = new AResult();
            var rs = result.showlatestByMac(mac);
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

        // 查询所有节点的最新信息
        public ActionResult ShowLatest()
        {
            AResult result = new AResult();
            var rs = result.showlatest();
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