using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcEventCalendar.Models
{
    [Bind(Exclude = "EventId")]
    public class Event
    {
        [ScaffoldColumn(false)]
        public int EventId { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [DisplayName("Place")]
        public int PlaceId { get; set; }
        [Required(ErrorMessage = "An Event Title is required")]
        [StringLength(160)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Event Date is required")]
        [DisplayName("Event Date")]
        public DateTime? EventDate { get; set; }
        [Required(ErrorMessage = "Start Time is required")]
        [DisplayName("Start Time")]
        public TimeSpan? StartTime { get; set; }
        [Required(ErrorMessage = "End Time is required")]
        [DisplayName("End Time")]
        public TimeSpan? EndTime { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000)]
        public string Description { get; set; }
        [DisplayName("Event Place URL")]
        [StringLength(1024)]
        public string EventPlaceUrl { get; set; }
        public virtual Category Category { get; set; }
        public virtual Place Place { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}