using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentAgriculture.Models
{
    public class AControl
    {

        intelligent_agricultureEntities agriculture = new intelligent_agricultureEntities();

        // 添加新的控制设备
        public void insert(controllable_equipment new_controllable)
        {
            agriculture.controllable_equipment.Add(new_controllable);
            agriculture.SaveChanges();
        }

        // 删除某个控制设备
        public void delete(string mac)
        {
            var rs = this.select(mac);
            if(rs != null)
            {
                agriculture.controllable_equipment.Remove(rs);
                agriculture.SaveChanges();
            }
            else
            {
            }
        }

        // 修改某个控制设备
        public void update(controllable_equipment exist_controllable)
        {
            var con = from a in agriculture.controllable_equipment
                      where a.MAC == exist_controllable.MAC
                      select a;

            if(con != null)
            {
                con.FirstOrDefault().State = exist_controllable.State;
                agriculture.SaveChanges();
            }
            else
            {
            }

        }

        // 查询某个控制设备
        public controllable_equipment select(string mac)
        {
            var con = from a in agriculture.controllable_equipment
                      where a.MAC == mac
                      select a;

            if(con != null)
            {
                return con.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        // 查询某控制点的状态

        // 查询全部
        public List<controllable_equipment> select_all()
        {
            var rs = from a in agriculture.controllable_equipment
                     select a;
            return rs.ToList();
        }
    }
}