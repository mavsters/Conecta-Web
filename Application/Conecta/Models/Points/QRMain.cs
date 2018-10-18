using Conecta.Models.Events;
using Conecta.Models.Location;
using Conecta.Models.Points;
using Conecta.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.Coins
{
    public class QRMain
    {
        [Key]
        public int QRMainId { get; set; }

        [Display(Name = "Fecha de Creación")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "¿Esta Activo?")]
        public Boolean active { get; set; }

        [Display(Name = "¿Esta Escaneado?")]
        public Boolean scan { get; set; }

        /**  "Foreing Key" **/
        //De Donde Viene
        [Display(Name = "Usuario")]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public UserMain UserMain { get; set; }

        [Display(Name = "Localidad")]
        [ForeignKey("PlaceId")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }

        [Display(Name = "Evento")]
        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public Event Event { get; set; }

        //A Donde va
        [Display(Name = "Puntos")]
        public PointsMain PointsMain { get; set; }
    }
}
