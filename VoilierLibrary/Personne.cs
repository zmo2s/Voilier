using System;

namespace VoilierLibrary
{
    public sealed class Personne
    {
        public Personne(string prenom, string nom, int age, float salaire, Equipage fonction)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.age = age;
            this.salaire = salaire;
            this.fonction = fonction;
        }

        #region attribut
        public String prenom { get; private set; }
        public String nom { get; private set; } 
        public int age { get; private set; } 
        public float salaire { get; private set; } 
        public Equipage fonction { get; private set; } 
        #endregion
    }
}