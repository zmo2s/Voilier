using System;

namespace VoilierLibrary
{
    public sealed class Personne
    {
        #region attribut
        public String prenom { get; private set; }
        public String nom { get; private set; } 
        public int age { get; private set; } 
        public float salaire { get; private set; } 
        public Equipage fonction { get; private set; } 
        #endregion
    }
}