using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.ContryStructure
{
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }

        [Display(Name = "Nombre de la Provincia")]
        public string Name { get; set; }

        /**  "Foreing Key" **/
        //De Donde Viene
        [Display(Name = "País")]
        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        //A Donde va
        [Display(Name = "Comuna")]
        public List<Commune> Communes { get; set; }

    }
}
