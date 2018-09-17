using IntelligentAgriculture.Models;
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
        private string username;
        private string password;

        // 用户登录
        public ActionResult Login(string username, string password)
        {
            username = Request["username"].Trim();
            password = Request["password"].Trim();
            AUser user = new AUser();
            var rs = user.select(username);
            Console.Write(rs);
            // 存在该用户
            if (rs != null)
            {
                // 登录成功
                if (rs.User_password == password)
                {
                    return Content(JsonConvert.SerializeObject(new
                    {
                        code = 1,
                        des = "登录成功",
                    }));
                }
                else
                // 密码错误
                {
                    return Content(JsonConvert.SerializeObject(new
                    {
                        code = 0,
                        des = "登录失败,密码错误",
                    }));
                }
            }
            else
            // 不存在该用户
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = -1,
                    des = "登录失败,不存在该用户",
                }));
            }
        }

        // 用户注册
        public ActionResult Register(user usr)
        {
            AUser user = new AUser();
            var rs = user.select(usr.User_name);
            if(rs == null)
            {
                user.insert(usr);
                if(user.select(usr.User_name) != null)
                {
                    return Content(JsonConvert.SerializeObject(new
                    {
                        code = 1,
                        des = "注册成功",
                    }));
                }
                else
                {
                    return Content(JsonConvert.SerializeObject(new
                    {
                        code = 0,
                        des = "注册失败,未能写入数据库",
                    }));
                }           
            }
            else
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = -1,
                    des = "注册失败,已有该用户",
                }));
            }
        }

    }
}

       
 