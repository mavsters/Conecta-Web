using Conecta.Models.Points;
using Conecta.Models.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Conecta.Models.Coins
{
    public class Benefits
    {
        [Key]
        public int BenefitsId { get; set; }

        [Display(Name = "Tipo de Beneficio")]
        public BenefitType BenefitType { get; set; }
    
        [Display(Name = "Fecha Inicio")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Fecha Fin")]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }

        [Display(Name = "Valor de Puntos")]
        public Double Count { get; set; }

        /**  "Foreing Key" **/
        //De Donde Viene
        [Display(Name = "Puntos")]
        [ForeignKey("PointsMainId")]
        public int PointsMainId { get; set; }
        public PointsMain PointsMain { get; set; }

    }
}
