using System;
using System.Collections.Generic;

namespace ConsoleApp1.Voilier1
{
    public partial class Penalite
    {
        public Penalite()
        {
            VoilierEtape = new HashSet<VoilierEtape>();
        }

        public Penalite(int idPenalite, string name, TimeSpan? duree)
        {
            IdPenalite = idPenalite;
            Name = name;
            Duree = duree;
        }

        public int IdPenalite { get; set; }
        public string Name { get; set; }
        public TimeSpan? Duree { get; set; }

        public virtual ICollection<VoilierEtape> VoilierEtape { get; set; }
    }
}
