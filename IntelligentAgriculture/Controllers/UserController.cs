using IntelligentAgriculture.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntelligentAgriculture.Controllers
{
    public class UserController : Controller
    {
        // 显示全部用户
        public ActionResult ShowAll()
        {
            AUser user = new AUser();
            var rs = user.select_all();
            if (rs != null)
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

        // 添加用户
        public ActionResult Add(user usr)
        {
            AUser user = new AUser();
            var rs = user.select(usr.User_name);
            // 本来没有该用户
            if(rs == null)
            {
                user.insert(usr);
                if(user.select(usr.User_name) != null)
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
                        des = "添加失败,未添加到数据库",
                    }));
                }
            }
            else
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = -1,
                    des = "添加失败，系统已有该用户"
                }));
            }
        }

        // 编辑用户
        public ActionResult Update(user usr)
        {
            AUser user = new AUser();
            user.update(usr);
            return Content(JsonConvert.SerializeObject(new
            {
                code = 1,
                des = "修改成功"
            }));
        }

        // 删除用户
        public ActionResult Delete(string name)
        {
            AUser user = new AUser();
            var rs = user.select(name);
            if (rs != null)
            {
                user.delete(name);
                if (user.select(name) == null)
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
                    des = "不存在此用户",
                }));
            }
        }

    }
}