using System;
using System.Collections.Generic;

namespace ConsoleApp1.Voilier1
{
    public partial class VoilierEtape
    {
        public VoilierEtape()
        {
            Course = new HashSet<Course>();
            Etape = new HashSet<Etape>();
        }

        public int IdVoilierEtape { get; set; }
        public DateTime? Duree { get; set; }
        public int PenaliteIdPenalite { get; set; }
        public int VoilierIdVoilier { get; set; }

        public virtual Penalite PenaliteIdPenaliteNavigation { get; set; }
        public virtual Voilier VoilierIdVoilierNavigation { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Etape> Etape { get; set; }
    }
}
