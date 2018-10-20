using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Conecta.Models.CountryStructure
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Nombre del País")]
        public string Name { get; set; }

        [Display(Name = "Código IATA")]
        [DataType(DataType.Text)]
        public string IATA { get; set; }

        [Display(Name = "URL de la Bandera del País")]
        [DataType(DataType.ImageUrl)]
        public string CountryFlagUrl { get; set; }

        // "Foreing Key" - A Donde va
        public List<Province> Provinces { get; set; }
    }
}
