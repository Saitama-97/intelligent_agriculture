using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentAgriculture.Models
{
    public class ADevice
    {

        intelligent_agricultureEntities agriculture = new intelligent_agricultureEntities();

        // 增加节点
        public void insert(equipment_information user)
        {

            agriculture.equipment_information.Add(user);
            agriculture.SaveChanges();
        }

        // 根据 MAC 查询单个节点信息
        public equipment_information select(string MAC)
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
        
        // 查询全部节点信息
        public List<equipment_information> select_all()
        {
            var con = from a in agriculture.equipment_information
                      select a;
            return con.ToList();
        }

        // 修改节点信息
        public void update(equipment_information lig)
        {
            //先查询要获取的对象
            var db_user = from a in agriculture.equipment_information where a.MAC == lig.MAC select a;

            db_user.FirstOrDefault().X = lig.X;
            db_user.FirstOrDefault().Y = lig.Y;

            agriculture.Entry<equipment_information>(db_user.FirstOrDefault()).State = System.Data.Entity.EntityState.Modified;
            agriculture.SaveChanges();
        }

        // 根据 MAC 删除节点信息
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

        // 根据 MAC 查询节点类型的 01 字符串
        public equipment_information returnType(string mac)
        {
            var rs = from a in agriculture.equipment_information
                     where a.MAC == mac
                     select a;
            return rs.FirstOrDefault();
        }
    }
}