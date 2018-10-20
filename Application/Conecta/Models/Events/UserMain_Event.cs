using Conecta.Models.Points;
using Conecta.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.Events
{
    public class UserMain_Event
    {
        [Key]
        public int UserMain_EventId { get; set; }

        [Display(Name = "¿Asistio?")]
        public Boolean Attend { get; set; }


        /**  "Foreing Key" **/
        //De Donde Viene
        [Display(Name = "Usuario")]
        [ForeignKey("UserMainId")]
        public int UserMainId { get; set; }
        public UserMain UserMain { get; set; }

        [Display(Name = "Evento")]
        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public Event Event { get; set; }

        //A Donde Va
        public List<PointsMain> PointsMain { get; set; }
    }
}
