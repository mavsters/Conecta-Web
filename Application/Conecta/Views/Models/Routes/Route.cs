using Conecta.Models.Location;
using Conecta.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.Routes
{
    public class Route
    {
        [Key]
        public int RouteID { get; set; }

        [Display(Name = "Latitud")]
        public int Lat { get; set; }

        [Display(Name = "Longitud")]
        public int Lon { get; set; }

        /**  "Foreing Key" **/
        //De Donde Viene
        [Display(Name = "Mapa")]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public UserMain UserMain { get; set; }

        //A Donde va 
        [Display(Name = "Una ruta lleva una localidad")]
        public LocationMain location { get; set; }

    }
}
