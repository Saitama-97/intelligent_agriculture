using IntelligentAgriculture.ViewModel;
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

        // 按节点查询其信息(按时间降序) 
        public List<sensor_results_record> show_mac(string mac)
        {
            var rs = from a in agriculture.sensor_results_record
                     where a.MAC == mac
                     orderby a.Time descending
                     select a;
            return rs.ToList();
        }

        // 按节点查询最新信息
        public sensor_results_record showlatestByMac(string mac)
        {
            var rs = (from a in agriculture.sensor_results_record
                      where a.MAC == mac
                      orderby a.Time descending
                      select a).First();
            return rs;                    
        }

        // 查询所有节点的最新信息
        public List<ViewModel.index> showlatest()
        {
            var IndexList = from ei in agriculture.equipment_information

                            join data in agriculture.sensor_results_record on ei.MAC equals data.MAC

                            orderby ei.MAC ascending

                            select new index
                            {
                                MAC = ei.MAC,
                                Type = ei.Type,
                                Node_name = ei.Node_name,
                                X = ei.X,
                                Y = ei.Y,
                                Time = data.Time,
                                Temperature = data.Temperature,
                                Humidity = data.Humidity,
                                Pressure = data.Pressure,
                                Precipitation = data.Precipitation,
                                Wind_speed = data.Wind_speed,
                                Wind_direction = data.Wind_direction,
                                Soil_temperature = data.Soil_temperature,
                                Soil_water_content = data.Soil_water_content,
                                Light = data.Light,
                                Dissolved_oxygen = data.Dissolved_oxygen,
                                Oxygen_density = data.Oxygen_density,
                                CO2_density = data.CO2_density,
                                Water_level = data.Water_level,
                            };

                var rsGroup = from a in IndexList
                              group a by a.MAC;

                var returnlist = new List<ViewModel.index>();
                foreach (var f in rsGroup)
                {
                    var newrs = (from a in f
                                 orderby a.Time descending
                                 select a).First();
                    returnlist.Add(newrs);
                }
                return returnlist;
            }

    }
}