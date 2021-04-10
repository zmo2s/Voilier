using System;
using System.Collections.Generic;

namespace ConsoleApp1.voilier
{
    public partial class Etape
    {
        public Etape()
        {
            Course = new HashSet<Course>();
        }

        public Etape(int idEtape, string nom, DateTime? dateDebut, DateTime? dateFin, int voilierEtapeIdVoilierEtape, int voilierIdVoilier)
        {
            IdEtape = idEtape;
            Nom = nom;
            DateDebut = dateDebut;
            DateFin = dateFin;
            VoilierEtapeIdVoilierEtape = voilierEtapeIdVoilierEtape;
            VoilierIdVoilier = voilierIdVoilier;
        }

        public int IdEtape { get; set; }
        public string Nom { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public int VoilierEtapeIdVoilierEtape { get; set; }
        public int VoilierIdVoilier { get; set; }

        public virtual VoilierEtape VoilierEtapeIdVoilierEtapeNavigation { get; set; }
        public virtual Voilier VoilierIdVoilierNavigation { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
}
