using System;
using System.Collections.Generic;

namespace ConsoleApp1.voilier1
{
    public partial class Penalite
    {
        public Penalite()
        {
            VoilierEtape = new HashSet<VoilierEtape>();
        }

        public Penalite(int idPenalite, string name, TimeSpan duree, double? latitude, double? longitude)
        {
            IdPenalite = idPenalite;
            Name = name;
            Duree = duree;
            Latitude = latitude;
            Longitude = longitude;
        }

        public int IdPenalite { get; set; }
        public string Name { get; set; }
        public TimeSpan Duree { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public virtual ICollection<VoilierEtape> VoilierEtape { get; set; }
    }
}
