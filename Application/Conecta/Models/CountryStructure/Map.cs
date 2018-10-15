using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.CountryStructure
{
    public class Map
    {
        [Key]
        public int MapId { get; set; }

        [Display(Name = "Tipo de Mapa")]
        public string Type { get; set; }

        /**  "Foreing Key" **/
        //De Donde Viene
        [Display(Name = "Neighborhood")]
        [ForeignKey("NeighborhoodId")]
        public int NeighborhoodId { get; set; }
        public Neighborhood Neighborhood { get; set; }

        //A Donde va [Display(Name = "Mapa")]public List<Map> Maps { get; set; }
    }
}
