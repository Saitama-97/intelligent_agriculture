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
        // 显示全部节点配置
        public ActionResult ShowAll()
        {
            ADevice device = new ADevice();
            var rs = device.select_all();
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

        // 添加节点配置信息
        public ActionResult Add(equipment_information node)
        {
            ADevice device = new ADevice();
            var rs = device.select(node.MAC);
            // 本来没有该节点
            if (rs == null)
            {
                device.insert(node);
                if (device.select(node.MAC) != null)
                {
                    return Content(JsonConvert.SerializeObject(new
                    {
                        code = 1,
                        des = "添加成功",
                    }));
                }
                else
                {
                    return Content(JsonConvert.SerializeObject(new
                    {
                        code = 0,
                        des = "添加失败，未添加到数据库"
                    }));
                }
            }
            else
            // 本来有该节点
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = -1,
                    des = "添加失败，系统已有该节点",
                }));
            }
        }

        // 修改节点配置信息
        public ActionResult Update(equipment_information node)
        {
            ADevice device = new ADevice();
            device.update(node);
            return Content(JsonConvert.SerializeObject(new
            {
                code = 1,
                des = "修改成功"
            }));

        }

        // 删除节点配置信息
        public ActionResult Delete(string Mac)
        {
            ADevice device = new ADevice();
            var rs = device.select(Mac);
            if(rs != null)
            {
                device.delete(Mac);
                if (device.select(Mac) == null)
                {
                    return Content(JsonConvert.SerializeObject(new
                    {
                        code = 1,
                        des = "删除成功",
                    }));
                }
                else
                {
                    return Content(JsonConvert.SerializeObject(new
                    {
                        code = 0,
                        des = "删除失败",
                    }));
                }
            }
            else
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = -1,
                    des = "不存在此节点",
                }));
            }
        }
    }
}