using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentAgriculture.Models
{
    public class AResult
    {
        intelligent_agricultureEntities agriculture = new intelligent_agricultureEntities();
        
        public sensor_results_record select(string mac)
        {
            var rs = from a in agriculture.sensor_results_record
                     where a.MAC == mac
                     select a;
            if(rs != null)
            {
                return rs.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}