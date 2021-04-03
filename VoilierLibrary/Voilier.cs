using System;

namespace VoilierLibrary
{
    public sealed class Voilier
    {
        public Voilier(string name, int nbrPlace, float prix, string marque, float vitesse, int poids, double latitude, double longitude)
        {
            Name = name;
            NbrPlace = nbrPlace;
            Prix = prix;
            Marque = marque;
            Vitesse = vitesse;
            Poids = poids;
            Latitude = latitude;
            Longitude = longitude;
        }

        #region attribut
        public String Name { get; private set; }
        public int NbrPlace { get; private set; }
        public float Prix { get; private set; }
        // remplacer la marque par une liste d'entreprise
        public String Marque { get; private set; }
        public float Vitesse { get; private set; }
        public int Poids { get; private set; }
        public Double Latitude { get; private set; }
        public Double Longitude { get; private set; }

        public Personne Personne;
        public VoilierEtape VoilierEtape;

        #endregion


    }
}