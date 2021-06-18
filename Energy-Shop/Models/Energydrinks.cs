using System;
namespace Energy_Shop.Models
{
    public class Energydrinks
    {
        public Energydrinks()
        {
        }

        public int Id { get; set; }


        public string Bez { get; set; }


        public int MarkeId { get; set; }
        public virtual Marke Marke { get; set; }

        public int GeschmackId { get; set; }
        public virtual Geschmack Geschmack { get; set; }

        public double Preis { get; set; }

        public int Anzahl { get; set; }
    }
}
