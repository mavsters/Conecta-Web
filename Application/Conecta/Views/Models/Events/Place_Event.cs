using Conecta.Models.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.Events
{
    public class Place_Event
    {
        [Key]
        public int Place_EventId { get; set; }
        /**  "Foreing Key" **/
        //De Donde Viene
        
        [Display(Name = "Evento")]
        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public Event Event { get; set; }

        [Display(Name = "Place")]
        [ForeignKey("PlaceId")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }

    }
}
