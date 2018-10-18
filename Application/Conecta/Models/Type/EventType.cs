using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.Type
{
    public class EventType
    {
        [Key]
        public int EventTypeID { get; set; }

        [Display(Name = "Nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
