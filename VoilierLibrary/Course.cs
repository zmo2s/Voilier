using System;
using System.Collections.Generic;
using System.Linq;

namespace VoilierLibrary
{
    public sealed class Course
    {
        public Course(int id, string nom, DateTime duree)
        {
            Id = id;
            Nom = nom;
            Duree = duree;
        }
        #region attribut
        public int Id { get; private set; }
        public String Nom { get; private set; }
        private List<Etape> listeEtape = new List<Etape>();
        public DateTime Duree { get; private set; } 
        public DateTime DureeCmumuleBrute { get; private set; } 
        public DateTime DureeCumuleReel { get; private set; } 
        private List<VoilierEtape> listeVoilierEtapes = new List<VoilierEtape>();
        #endregion

 

        #region function
        public List<Etape> Etape
        {
            get { return new List<Etape>(listeEtape);}
        }
        
        public void AfficherEtape()
        {
            listeEtape.ForEach(delegate(Etape etape) { Console.WriteLine(etape.Description());  });
        }

        public bool AjouterEtape(Etape etape)
        {
            if (etape == null)
            {
                return false;
            }

            Etape existeEtape = RechercheEtape(etape.Id);
            if (existeEtape != null)
            {
                return false;}
            
            listeEtape.Add(etape);
            

            return true;
        }


        public Etape RechercheEtape(int id)
        {
            return listeEtape.Find(delegate(Etape etape) { return etape.Id == id; });
        }

        public String DureeCumuleBruteTotal()
        {
            int jour = 0;
            int minute = 0;
            int heure = 0;
            
            ///DateTime date= DateTime.Now;

           foreach (Etape etape in listeEtape)
           {
               jour += etape.DateFin.Subtract(etape.DateDebut).Days;
               minute += etape.DateFin.Subtract(etape.DateDebut).Minutes;
               heure += etape.DateFin.Subtract(etape.DateDebut).Hours;
           }
                
          return string.Format("jour {0}, heure {1}, minute {2}", jour, heure,minute);

        }

        public Double DureeCumuleReelTotal(DateTime DureeCumuleBrute,DateTime DureePenalite)
        {
            return (DureeCumuleBrute - DureePenalite).TotalHours;
        }
        
        
        #endregion
        
    }
}