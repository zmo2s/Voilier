using System;
using System.Collections.Generic;

namespace ConsoleApp1.voilier1
{
    public partial class VoilierEtape
    {
        public VoilierEtape()
        {
            Course = new HashSet<Course>();
            Etape = new HashSet<Etape>();
        }

        public VoilierEtape(int idVoilierEtape, DateTime duree, int penaliteIdPenalite, int voilierIdVoilier, DateTime dateDebut, DateTime dateFin)
        {
            IdVoilierEtape = idVoilierEtape;
            Duree = duree;
            PenaliteIdPenalite = penaliteIdPenalite;
            VoilierIdVoilier = voilierIdVoilier;
            DateDebut = dateDebut;
            DateFin = dateFin;
        }

        public int IdVoilierEtape { get; set; }
        public DateTime Duree { get; set; }
        public int PenaliteIdPenalite { get; set; }
        public int VoilierIdVoilier { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public virtual Penalite PenaliteIdPenaliteNavigation { get; set; }
        public virtual Voilier VoilierIdVoilierNavigation { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Etape> Etape { get; set; }
    }
}
