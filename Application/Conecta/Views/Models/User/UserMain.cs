using Conecta.Models.Coins;
using Conecta.Models.Events;
using Conecta.Models.Points;
using Conecta.Models.Routes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.User
{
    public class UserMain
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Usuario")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /**  "Foreing Key" **/

        //A Donde va 
        [Display(Name = "Persona")]
        public Person Person { get; set; }

        [Display(Name = "QRs")]
        public List<QRMain> QRMain { get; set; }

        [Display(Name = "Puntos")]
        public List<PointsMain> PointsMain { get; set; }

        [Display(Name = "Usuario puede ir ha Eventos")]
        public List<UserMain_Event> UserMain_Event { get; set; }

        [Display(Name = "Usuario tiene muchas Rutas")]
        public List<Route> Route { get; set; }
        
    }
}
