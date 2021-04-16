using System;
using System.Collections.Generic;

namespace ConsoleApp1.voilier1
{
    public partial class Personne
    {
        public Personne()
        {
            Voilier = new HashSet<Voilier>();
        }

        public Personne(int idPersonne, string prenom, string nom, int? age, float? salaire, string equipage, string sponsors)
        {
            IdPersonne = idPersonne;
            Prenom = prenom;
            Nom = nom;
            Age = age;
            Salaire = salaire;
            Equipage = equipage;
            Sponsors = sponsors;
        }

        public int IdPersonne { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int? Age { get; set; }
        public float? Salaire { get; set; }
        public string Equipage { get; set; }
        public string Sponsors { get; set; }

        public virtual ICollection<Voilier> Voilier { get; set; }
    }
}
