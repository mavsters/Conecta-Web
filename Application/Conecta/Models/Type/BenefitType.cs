using System;
using System.ComponentModel.DataAnnotations;

namespace Conecta.Models.Type
{
    public class BenefitType
    {
        [Key]
        public int BenefitTypeId { get; set; }

        [Display(Name = "Titulo")]
        [DataType(DataType.Text)]
        public String Title { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        public String Description { get; set; }

    }
}
