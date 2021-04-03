using System;
using System.Collections.Generic;

namespace VoilierLibrary
{
    public sealed class VoilierEtape
    {
        
        public Voilier Voilier = new Voilier("katari",4,10.894221F,"tesla",15.4F,150,1400,14.2);
        
        #region attribut
        public DateTime dureeCumule { get; private set; }
        private List<Penalite> listePenalite = new List<Penalite>();
        private List<Etape> listeEtape = new List<Etape>();
        public Course course;
        
        #endregion

        #region function
        public List<Penalite> Penalite
        {
            get { return listePenalite; }
        }
        #endregion
        
        public void AfficherPenalite()
        {
            listePenalite.ForEach(delegate(Penalite penalite) { Console.WriteLine(penalite.Description());  });
        }

        public bool AjouterPenalite(Penalite penalite)
        {
            if (penalite == null)
            {
                return false;
            }

            Penalite existePenalite = RecherchePenalite(penalite.Id);
            if (existePenalite != null)
            {
                return false;}
            
            listePenalite.Add(penalite);
            

            return true;
        }


        public Penalite RecherchePenalite(int id)
        {
            return listePenalite.Find(delegate(Penalite penalite) { return penalite.Id == id; });
        }
        
        public String DureeCumulePenalite()
        {
            int jour = 0;
            int minute = 0;
            int heure = 0;
            
            foreach (var penalite in listePenalite)
            {
                jour += penalite.Duree.Days;
                minute += penalite.Duree.Minutes;
                heure += penalite.Duree.Hours;
            }

            return string.Format("jour {0}, heure {1}, minute {2}", jour, heure,minute);;

        }
        
    }
}