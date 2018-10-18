using Conecta.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.Location
{
    public class LocationMain
    {
        [Key]
        public int LocationMainId { get; set; }

        [Display(Name = "Latitud")]
        public int Lat { get; set; }

        [Display(Name = "Longitud")]
        public int Lon { get; set; }
        
        /**  "Foreing Key" **/
        //De Donde Viene
        [Display(Name = "Localidad")]
        [ForeignKey("PlaceId")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }

        [Display(Name = "Usuario")]
        [ForeignKey("UserMainId")]
        public int UserMainId { get; set; }
        public UserMain UserMain { get; set; }

    }
}
