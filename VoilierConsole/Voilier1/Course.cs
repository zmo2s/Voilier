using System;
using System.Collections.Generic;

namespace ConsoleApp1.Voilier1
{
    public partial class Course
    {
        public Course(int idCourse, string nom, int etapeIdEtape, int voilierEtapeIdVoilierEtape, int voilierEtapeVoilierIdVoilier)
        {
            IdCourse = idCourse;
            Nom = nom;
            EtapeIdEtape = etapeIdEtape;
        
            VoilierEtapeIdVoilierEtape = voilierEtapeIdVoilierEtape;
            VoilierEtapeVoilierIdVoilier = voilierEtapeVoilierIdVoilier;
           
          
        }

        public int IdCourse { get; set; }
        public string Nom { get; set; }
        public int EtapeIdEtape { get; set; }
        public DateTime? DureeCumuleBrute { get; set; }
        public DateTime? DureeCumuleReel { get; set; }
        public int VoilierEtapeIdVoilierEtape { get; set; }
        public int VoilierEtapeVoilierIdVoilier { get; set; }

        public virtual Etape EtapeIdEtapeNavigation { get; set; }
        public virtual VoilierEtape VoilierEtape { get; set; }
    }
}
