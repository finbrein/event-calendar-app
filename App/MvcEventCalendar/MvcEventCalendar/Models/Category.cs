﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEventCalendar.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Event> Events { get; set; }        
    }
}