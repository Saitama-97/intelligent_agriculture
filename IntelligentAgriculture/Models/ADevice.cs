using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentAgriculture.Models
{
    public class ADevice
    {

        intelligent_agricultureEntities agriculture = new intelligent_agricultureEntities();

        public void insert(equipment_information user)
        {

            agriculture.equipment_information.Add(user);
            agriculture.SaveChanges();
        }

        public equipment_information select(string  MAC)
        {
            var dev = from a in agriculture.equipment_information
                       where a.MAC == MAC
                       select a;

            if (dev != null)
            {
                return dev.FirstOrDefault();
            }
            else
            {
                return null;
            }

        }

        //个人信息查询（按页数）  多个东西   页码pageNum        一页几个pageSize
        public List<equipment_information> select_All(int pageNum, int pageSize)
        {
            var con = from a in agriculture.equipment_information
                  
                      select a;
            return con.Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
            //这里的number是当前页数，count是每页的数据条数。skip，除去前多少条数据剩下的数据。take,取几条数据，这句话就是查询除去前多少条之后的剩下的数据的前多少条数据
        }

        //根据设备编号查找
        public List<equipment_information> select_lic(string MAC)
        {
            List<equipment_information> user = (from a in agriculture.equipment_information
                                                where a.MAC == MAC
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
        public void update(equipment_information lig)
        {
            //先查询要获取的对象
            var db_user = from a in agriculture.equipment_information where a.MAC == lig.MAC select a;

            db_user.FirstOrDefault().X = lig.X;
            db_user.FirstOrDefault().Y = lig.Y;

            agriculture.Entry<equipment_information>(db_user.FirstOrDefault()).State = System.Data.Entity.EntityState.Modified;
            agriculture.SaveChanges();
        }

        //删除
        public void delete(string MAC)
        {
            var rs = this.select(MAC);
            if (rs != null)
            {
                agriculture.equipment_information.Remove(rs);
                agriculture.SaveChanges();
            }
            else
            { }
        }






        public equipment_information changeInfo(equipment_information dev)
        {
            if (this.select(dev.MAC) != null)
            {
                this.update(dev);
            }
            else
            {
                this.insert(dev);
            }
            return select(dev.MAC);
        }

        

        
    
}
}