using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.User
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Display(Name = "Nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Display(Name = "Dirección")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        /**  "Foreing Key" **/
        //De Donde Viene
        [Display(Name = "Usuario")]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public UserMain UserMain { get; set; }

    }
}
