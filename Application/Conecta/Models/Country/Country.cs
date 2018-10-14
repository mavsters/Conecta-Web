using System;
using System.ComponentModel.DataAnnotations;


namespace Conecta.Models.Country
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }


        [Required]
        public string Name { get; set; }

    }
}
