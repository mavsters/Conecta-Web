using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conecta.Models.CountryStructure
{
    public class Neighborhood
    {
        [Key]
        public int NeighborhoodId { get; set; }

        [Display(Name = "Nombre del Barrio")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        /**  "Foreing Key" **/
        //De Donde Viene
        [Display(Name = "Comuna")]
        [ForeignKey("CommuneId")]
        public int CommuneId { get; set; }
        public Commune Commune { get; set; }

        //A Donde va
        [Display(Name = "Mapa")]
        public List<Map> Maps { get; set; }

    }
}
