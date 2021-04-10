using System;
using System.Collections.Generic;

namespace ConsoleApp1.Voilier1
{
    public partial class Etape
    {
        public Etape()
        {
            Course = new HashSet<Course>();
        }

        public Etape(int idEtape, string nom, DateTime? dateDebut, DateTime? dateFin, int voilierEtapeIdVoilierEtape, int voilierEtapeVoilierIdVoilier)
        {
            IdEtape = idEtape;
            Nom = nom;
            DateDebut = dateDebut;
            DateFin = dateFin;
            VoilierEtapeIdVoilierEtape = voilierEtapeIdVoilierEtape;
            VoilierEtapeVoilierIdVoilier = voilierEtapeVoilierIdVoilier;
        }

        public int IdEtape { get; set; }
        public string Nom { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public int VoilierEtapeIdVoilierEtape { get; set; }
        public int VoilierEtapeVoilierIdVoilier { get; set; }

        public virtual VoilierEtape VoilierEtape { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
}
