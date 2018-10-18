using Conecta.Models.Coins;
using Conecta.Models.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.Points
{
    public class PointsMain
    {
        [Key]
        public int PointsMainId { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Cantidad de Puntos")]
        public Double count { get; set; }
        
        /**  "Foreing Key" **/
        //De Donde Viene
        [Display(Name = "QR")]
        [ForeignKey("QRMainId")]
        public int QRMainId { get; set; }
        public QRMain QRMain { get; set; }


        //A donde va
        [Display(Name = "Beneficios")]
        public Benefits Benefits { get; set; }

    }
}
