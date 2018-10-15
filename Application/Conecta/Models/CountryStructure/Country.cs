using Conecta.Models.CountryStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.CountryStructure
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Display(Name = "Nombre del País")]
        public string Name { get; set; }

        [Display(Name = "Código IATA")]
        public string IATA { get; set; }

        [Display(Name = "Indicador")]
        public string Indicator { get; set; }

        [Display(Name = "Descripción del País")]
        public string About { get; set; }

        [Display(Name = "URL de la Bandera del País")]
        [DataType(DataType.ImageUrl)]
        public string CountryFlagUrl { get; set; }

        // "Foreing Key" - A Donde va
        public List<Province> Provinces { get; set; }
    }
}
