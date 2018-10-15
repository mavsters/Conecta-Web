using Conecta.Models.CountryStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.ContryStructure
{
    public class Commune
    {
        [Key]
        public int CommuneId { get; set; }

        [Display(Name = "Nombre de la Comuna")]
        public string Name { get; set; }

        /**  "Foreing Key" **/
        //De Donde Viene
        [Display(Name = "Provincia")]
        [ForeignKey("ProvinceId")]
        public int ProvinceId { get; set; }
        public Province Province { get; set; }

        //A Donde va
        [Display(Name = "Barrio")]
        public List<Neighborhood> Communes { get; set; }

    }
}
