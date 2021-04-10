using System;
using System.Collections.Generic;

namespace ConsoleApp1.voilier
{
    public partial class Voilier
    {
        public Voilier()
        {
            Course = new HashSet<Course>();
            Etape = new HashSet<Etape>();
            VoilierEtape = new HashSet<VoilierEtape>();
        }

        public Voilier(int idVoilier, string name, int? nbrPlace, float? prix, string marque, float? vitesse, double? latitude, double? longitude, int personneIdPersonne)
        {
            IdVoilier = idVoilier;
            Name = name;
            NbrPlace = nbrPlace;
            Prix = prix;
            Marque = marque;
            Vitesse = vitesse;
            Latitude = latitude;
            Longitude = longitude;
            PersonneIdPersonne = personneIdPersonne;
        }

        public int IdVoilier { get; set; }
        public string Name { get; set; }
        public int? NbrPlace { get; set; }
        public float? Prix { get; set; }
        public string Marque { get; set; }
        public float? Vitesse { get; set; }
        public float? Poids { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int PersonneIdPersonne { get; set; }

        public virtual Personne PersonneIdPersonneNavigation { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Etape> Etape { get; set; }
        public virtual ICollection<VoilierEtape> VoilierEtape { get; set; }
    }
}
