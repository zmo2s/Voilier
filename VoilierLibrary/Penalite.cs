using System;

namespace VoilierLibrary
{
    public sealed class Penalite
    {
        public Penalite(int id, string name, TimeSpan duree)
        {
            Id = id;
            Name = name;
            Duree = duree;
        }

        #region  attribut
        public int Id { get; private set; }
        public String Name { get; private set; }
        public TimeSpan Duree { get; private set; } 
        #endregion
        
        #region

        public String Description()
        {
         return string.Format("Etape n°{0}, {1}, {2}", Id, Name,Duree);
        }
        #endregion
        
        
    }
}