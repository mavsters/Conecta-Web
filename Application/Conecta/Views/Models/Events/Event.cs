using Conecta.Models.Coins;
using Conecta.Models.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.Events
{
    public class Event
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Titulo")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Display(Name = "Tipo de Evento")]
        public EventType EventType { get; set; }

        /**  "Foreing Key" **/
        //A Donde va 
        [Display(Name = "Usuario puede ir ha Eventos")]
        public List<UserMain_Event> UserMain_Event { get; set; }

        [Display(Name = "Un evento es de Muchos Lugares")]
        public List<Place_Event> Place_Event { get; set; }

        [Display(Name = "Un evento tiene un QR")]
        public List<QRMain> QRMain { get; set; }

    }
}
