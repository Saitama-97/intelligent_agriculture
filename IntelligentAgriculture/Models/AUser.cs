using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentAgriculture.Models
{
    public class AUser
    {

        intelligent_agricultureEntities agriculture = new intelligent_agricultureEntities();

        // 添加新的用户
        public void insert(user new_user)
        {
            agriculture.user.Add(new_user);
            agriculture.SaveChanges();
        }

        // 删除用户
        public void delete(string user_name)
        {
            var rs = this.select(user_name);
            if (rs != null)
            {
                agriculture.user.Remove(rs);
                agriculture.SaveChanges();
            }
        }

        // 修改用户
        public void update(user exist_user)
        {
            var rs = from a in agriculture.user
                      where a.User_name == exist_user.User_name
                      select a;
            if(rs != null)
            {
                rs.FirstOrDefault().User_name = exist_user.User_name;
                rs.FirstOrDefault().User_password = exist_user.User_password;
                rs.FirstOrDefault().E_mail = exist_user.E_mail;
                rs.FirstOrDefault().Phone = exist_user.Phone;
                rs.FirstOrDefault().Status = exist_user.Status;
                agriculture.SaveChanges();
            }
            else
            {
            }
        }

        // 查询单个用户
        public user select(string user_name)
        {
            var rs = from a in agriculture.user
                      where a.User_name == user_name
                      select a;

            if (rs != null)
            {
                return rs.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        // 查询全部
        public List<user> select_all()
        {
            var rs = from a in agriculture.user
                      select a;
            return rs.ToList();
        }
    }
}