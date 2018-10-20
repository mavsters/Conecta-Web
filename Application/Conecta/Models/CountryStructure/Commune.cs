using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conecta.Models.CountryStructure
{
    public class Commune
    {
        [Key]
        public int CommuneId { get; set; }

        [Display(Name = "Nombre de la Comuna")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        /**  "Foreing Key" **/
        //De Donde Viene
        [Display(Name = "Provincia")]
        [ForeignKey("ProvinceId")]
        public int ProvinceId { get; set; }
        public Province Province { get; set; }

        //A Donde va
        [Display(Name = "Barrio")]
        public List<Neighborhood> Neighborhoods { get; set; }

    }
}
