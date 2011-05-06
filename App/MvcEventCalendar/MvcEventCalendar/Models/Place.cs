using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEventCalendar.Models
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string  Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
    }
}