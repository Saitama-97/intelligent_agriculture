using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentAgriculture.Models
{
    public class AResult
    {
        intelligent_agricultureEntities agriculture = new intelligent_agricultureEntities();

        // 查询全部信息
        public List<sensor_results_record> showall()
        {
            var rs = from a in agriculture.sensor_results_record
                     select a;
            return rs.ToList();
        }

        // 按节点查询其信息
        public List<sensor_results_record> show_mac(string mac)
        {
            var rs = from a in agriculture.sensor_results_record
                     where a.MAC == mac
                     select a;
            return rs.ToList();
        }

        // 按节点查询最新信息
        public sensor_results_record showlatest(string mac)
        {
            var rs = (from a in agriculture.sensor_results_record
                      where a.MAC == mac
                      orderby a.Time descending
                      select a).First();
            return rs;                    
        }
    }
}