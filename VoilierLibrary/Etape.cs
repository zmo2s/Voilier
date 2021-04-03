using System;

namespace VoilierLibrary
{
    public sealed class Etape
    {
        public Etape(int id, string nom, DateTime dateDebut,DateTime dateFin)
        {
            Id = id;
            Nom = nom;
            DateDebut = dateDebut;
            DateFin = dateFin;
        }

        #region attribut
        public int Id { get; private set; }
        public String Nom { get; private set; }
        public DateTime DateDebut { get; private set; } 
        public DateTime DateFin { get; private set; } 
      
        #endregion
        
        #region function
        public String Description()
        {
            return string.Format("Etape n°{0}, {1}, {2} {3}", Id, Nom,DateDebut,DateFin);
        }
        #endregion
    }
    
    
}