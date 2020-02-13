using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelProject.Models
{
    public class Tours
    {
        public int Id { get; set; }
        public int Place_id { get; set; }
        public int Transporter_id { get; set; }
        public string Titile { get; set; }
        public string Description { get; set; }
        public string Quantity_people { get; set; }
        public double Price { get; set; }
        public DateTime Time_start { get; set; }
        public DateTime Time_end { get; set; }
        public double Duration { get; set; }
        public DateTime Time_departure {get;set;}
    }
}