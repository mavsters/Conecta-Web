using Conecta.Models.Coins;
using Conecta.Models.CountryStructure;
using Conecta.Models.Events;
using Conecta.Models.Type;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conecta.Models.Location
{
    public class Place
    {
        [Key]
        public int PlaceId { get; set; }

        [Display(Name = "Nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "Dirección")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Display(Name = "Tipo de Localidad")]
        public PlaceType PlaceType { get; set; }


        /**  "Foreing Key" **/
        //De Donde Viene
        [Display(Name = "Mapa")]
        [ForeignKey("MapId")]
        public int MapId { get; set; }
        public Map Map { get; set; }

        //A Donde va 
        [Display(Name = "Ubicación")]
        public LocationMain LocationMain { get; set; }

        [Display(Name = "QR")]
        public QRMain QRMain { get; set; }

        [Display(Name = "Un lugar tiene muchos Eventos")]
        public List<Place_Event> Place_Event { get; set; }
    }
}
