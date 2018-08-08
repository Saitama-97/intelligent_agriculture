using IntelligentAgriculture.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntelligentAgriculture.Controllers
{
    public class ControlController : Controller
    {
        // 显示全部控制点
        public ActionResult ShowAll()
        {
            AControl control = new AControl();
            var rs = control.select_all();
            if(rs != null)
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = 1,
                    des = "显示成功",
                    data = rs,
                }));
            }
            else
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = 0,
                    des = "显示失败",
                }));
            }
        }

        // 修改某个控制点
        public ActionResult Update(controllable_equipment controllable)
        {
            AControl control = new AControl();
            var rs = control.select(controllable.MAC);
            // 该节点存在
            if (rs != null)
            {
                //if (control.select(controllable.MAC) != rs)
                //{
                //    control.update(controllable);
                //    return Content(JsonConvert.SerializeObject(new
                //    {
                //        code = 1,
                //        des = "修改成功",
                //    }));
                //}
                //else
                //{
                //    return Content(JsonConvert.SerializeObject(new
                //    {
                //        code = 0,
                //        des = "修改失败",
                //    }));
                //}
                control.update(controllable);
                return Content(JsonConvert.SerializeObject(new
                {
                    code = 1,
                    des = "修改成功",
                }));
            }
            else
            // 该节点不存在
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = -1,
                    des = "该节点不存在",
                }));
            }
        }
    }
}