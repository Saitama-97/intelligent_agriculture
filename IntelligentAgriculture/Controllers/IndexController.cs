using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelligentAgriculture.ViewModel;
using Newtonsoft.Json;

namespace IntelligentAgriculture.Controllers
{
    public class IndexController : Controller
    {
        intelligent_agricultureEntities agriculture = new intelligent_agricultureEntities();

        public ActionResult Show()
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

            if(IndexList != null)
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = 1,
                    des = "查询成功",
                    data = IndexList, 
                }));
            }
            else
            {
                return Content(JsonConvert.SerializeObject(new
                {
                    code = 0,
                    des = "查询失败"
                }));
            }
        }
    }
}