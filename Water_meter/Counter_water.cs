using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Water_meter
{
    internal class Counter_water
    {
        public string model { get; set; }
        public string Contry { get; set; }
        public long serial_number { get; set; }
        public double hot_water { get; set; }
        public double cold_water { get; set; }
        public string last_check { get; set; }
        public double new_hot_water { get; set; }
        public double new_cold_water { get; set; }
    }
}
