using Conecta.Models.Location;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conecta.Models.CountryStructure
{
    public class Map
    {
        [Key]
        public int MapId { get; set; }

        [Display(Name = "Tipo de Mapa")]
        [DataType(DataType.Text)]
        public string Type { get; set; }

        /**  "Foreing Key" **/
        //De Donde Viene
        [Display(Name = "Barrio")]
        [ForeignKey("NeighborhoodId")]
        public int NeighborhoodId { get; set; }
        public Neighborhood Neighborhood { get; set; }

        //A Donde va 
        [Display(Name = "Localidad")]
        public Place place { get; set; }
    }
}
