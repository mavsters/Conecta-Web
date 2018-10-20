using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.Type
{
    public class PlaceType
    {
        [Key]
        public int PlaceTypeID { get; set; }

        [Display(Name = "Nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "Categoria")]
        [DataType(DataType.Text)]
        public CategoryType Category { get; set; }

    }
}
