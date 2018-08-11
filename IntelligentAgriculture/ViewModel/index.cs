using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentAgriculture.ViewModel
{
    public class index
    {
        public string MAC { get; set; }     
        public string Type { get; set; }
        public string Node_name { get; set; }
        public Nullable<double> X { get; set; }
        public Nullable<double> Y { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public Nullable<double> Temperature { get; set; }
        public Nullable<double> Humidity { get; set; }
        public Nullable<double> Pressure { get; set; }
        public Nullable<double> Precipitation { get; set; }
        public Nullable<double> Wind_speed { get; set; }
        public Nullable<double> Wind_direction { get; set; }
        public Nullable<double> Soil_temperature { get; set; }
        public Nullable<double> Soil_water_content { get; set; }
        public Nullable<double> Light { get; set; }
        public Nullable<double> Dissolved_oxygen { get; set; }
        public Nullable<double> Oxygen_density { get; set; }
        public Nullable<double> CO2_density { get; set; }
        public Nullable<double> Water_level { get; set; }
    }
}