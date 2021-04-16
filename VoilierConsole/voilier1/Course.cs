using System;
using System.Collections.Generic;

namespace ConsoleApp1.voilier1
{
    public partial class Course
    {
        public Course(int idCourse, string nom, int etapeIdEtape, DateTime? dureeCumuleBrute, DateTime? dureeCumuleReel, int voilierEtapeIdVoilierEtape, int voilierIdVoilier)
        {
            IdCourse = idCourse;
            Nom = nom;
            EtapeIdEtape = etapeIdEtape;
            DureeCumuleBrute = dureeCumuleBrute;
            DureeCumuleReel = dureeCumuleReel;
            VoilierEtapeIdVoilierEtape = voilierEtapeIdVoilierEtape;
            VoilierIdVoilier = voilierIdVoilier;
        }

        public int IdCourse { get; set; }
        public string Nom { get; set; }
        public int EtapeIdEtape { get; set; }
        public DateTime? DureeCumuleBrute { get; set; }
        public DateTime? DureeCumuleReel { get; set; }
        public int VoilierEtapeIdVoilierEtape { get; set; }
        public int VoilierIdVoilier { get; set; }

        public virtual Etape EtapeIdEtapeNavigation { get; set; }
        public virtual VoilierEtape VoilierEtapeIdVoilierEtapeNavigation { get; set; }
        public virtual Voilier VoilierIdVoilierNavigation { get; set; }
    }
}
