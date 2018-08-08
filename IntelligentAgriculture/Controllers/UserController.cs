//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace IntelligentAgriculture.Controllers
//{
//    public class UserController : Controller
//    {
//        // 默认登录界面
//        public ActionResult Login()
//        {
//            return View();
//        }

//        // 登录验证
//        public ActionResult Confirmation()
//        {
//            {
//                //获取前台传回的数据
//                string userid = Request["userid"];
//                string password = Request["password"];
//                //声明spring容器中的LoginBll
//                //ILoginBll loginbll = SpringHelper.GetObject<ILoginBll>("LoginBll");
//                list<userinfoviewmodel> user = loginbll.queryuser(userid);
//                //如果验证通过，则把数据存到session中，返回成功
//                if (user[0].pwd == password)
//                {
//                    Session["userID"] = userid;
//                    Session["realName"] = user[0].realName;
//                    Session["JID"] = user[0].admin;
//                    return "OK";
//                }
//                //验证不通过，返回失败
//                else
//                {

//                    return "error";
//                }


//            }

//            return View();
//        }

//    }
//}