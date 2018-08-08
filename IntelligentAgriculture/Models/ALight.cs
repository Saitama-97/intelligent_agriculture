using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentAgriculture.Models
{
    public class ALight
    {

        intelligent_agricultureEntities agriculture = new intelligent_agricultureEntities();

        public void insert(light user)
        {

            agriculture.light.Add(user);
            agriculture.SaveChanges();
        }

        public light select(int id)
        {
            var user = from a in agriculture.light
                       where a.id == id
                       select a;

            if (user != null)
            {
                return user.FirstOrDefault();
            }
            else
            {
                return null;
            }

        }

        //个人信息查询（按页数）  多个东西   页码pageNum        一页几个pageSize
        public List<light> select_All(int pageNum, int pageSize)
        {
            var con = from a in agriculture.light
                      orderby a.id descending
                      select a;
            return con.Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
            //这里的number是当前页数，count是每页的数据条数。skip，除去前多少条数据剩下的数据。take,取几条数据，这句话就是查询除去前多少条之后的剩下的数据的前多少条数据
        }

        //根据设备编号查找
        public List<light> select_lic(string NodeID)
        {
            List<light> user = (from a in agriculture.light
                                   where a.Node_ID == NodeID
                                   select a).ToList();

            if (user != null && user.Count != 0)
            {
                return user;
            }
            else
            {
                return null;
            }

        }

       
        //更改
        public void update(light lig)
        {
            //先查询要获取的对象
            var db_user = from a in agriculture.light where a.id == lig.id select a;

            db_user.FirstOrDefault().Light1 = lig.Light1;
            db_user.FirstOrDefault().Time = lig.Time;

            agriculture.Entry<light>(db_user.FirstOrDefault()).State = System.Data.Entity.EntityState.Modified;
            agriculture.SaveChanges();
        }

        //删除
        public void delete(int id)
        {
            var rs = this.select(id);
            if (rs != null)
            {
                agriculture.light.Remove(rs);
                agriculture.SaveChanges();
            }
            else
            { }
        }






        public light changeInfo(light user)
        {
            if (this.select(user.id) != null)
            {
                this.update(user);
            }
            else
            {
                this.insert(user);
            }
            return select(user.id);
        }

        

        
    
}
}