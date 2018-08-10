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

    }
}

        //private string timeStamp;
        //private string authenticator;

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        //public ActionResult BGQuery()
        //{
        //    try
        //    {

        //        timeStamp = Request["timeStamp"].Trim();
        //        authenticator = Request["authenticator"].Trim();
             
        //            return Content(JsonConvert.SerializeObject(new
        //            {
        //                code = 0,
        //                des = "OK",

        //            }));

                
        //    }
        //    catch (Exception error)
        //    {
        //        // 登录失败会抛出登录异常
        //        return Content(JsonConvert.SerializeObject(new
        //        {
        //            code = -1,
        //            err = error.Message
        //        }));
        //    }

 