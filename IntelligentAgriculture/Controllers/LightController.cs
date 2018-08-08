using IntelligentAgriculture.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntelligentAgriculture.Controllers
{
    public class LightController : Controller
    {
        private int id;
        // GET: Light
        public ActionResult select(int id)
        {
            id = Convert.ToInt32(Request["id"].Trim());
            ALight lightAciton = new ALight();
            light result=lightAciton.select(id);
            if (result != null)
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = 0,
                    des = "成功",
                    light = result.Light1
                }));

            }
            else {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = -1,
                    des = "失败",
                   
                }));
            }
           
        }
    }
}