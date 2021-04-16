using System;
using System.Collections.Generic;
using ConsoleApp1.voilier;
using ConsoleApp1.voilier1;
using ConsoleApp1.Voilier1;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Voilier1
{
    public class GestionCourse
    {
        private voilier1Context model = new voilier1Context();
        private List<Etape> listeEtape = new List<Etape>();

        public Course AjouterCourse(Course course)
        {
            // Ajoute le produit à l'ORM EF
            model.Course.Add(course);
            // Valide les changement dans la base de données
            if (model.SaveChanges() > 0)
                return course;
            return null;
        }

        public void DisplayCourse(List<Course> liste)
        {
            foreach (Course Course in liste)
            {
                Console.WriteLine("{0} réalisé par {1} {2} {3} {4} {5} ", Course.IdCourse, Course.Nom,
                    Course.VoilierIdVoilier, Course.DureeCumuleBrute, Course.DureeCumuleReel, Course.EtapeIdEtape);
            }
        }
        
        public int GetIdEtape(List<Course> liste)
        {
            int idEtape = 0;
            foreach (Course Course in liste)
            {
                idEtape = Course.EtapeIdEtape;
            }

            return idEtape;
        }


        public Course RechercherCourse(int id)
        {
            return model.Course.Find(id);
        }

        public bool ModifierPersnne(Course Course)
        {
            // Mettre le statut de l'entité à "Modifiée" dans l'ORM
            model.Entry(Course).State = EntityState.Modified;
            // Valide les changement dans la base de données
            return (model.SaveChanges() > 0);
        }

        public bool SupprimerCourse(int id)
        {
            Course p = RechercherCourse(id);
            if (p == null)
                return false;
            return SupprimerCourse(p);
        }

        public bool SupprimerCourse(Course produit)
        {
            if (produit != null)
            {
                // Supprime le produit dans l'ORM
                model.Course.Remove(produit);
                // Valide les changement dans la base de données
                return (model.SaveChanges() > 0);
            }

            return false;
        }
        
         public TimeSpan DureeCumuleBruteTotal2(List<VoilierEtape> liste)
            {
                int jour = 0;
                int minute = 0;
                int heure = 0;
                int seconde = 0;


                foreach (VoilierEtape etape in liste)
                {
                    
                    jour += etape.DateFin.Subtract(etape.DateDebut).Days;
                    minute += etape.DateFin.Subtract(etape.DateDebut).Minutes;
                    heure += etape.DateFin.Subtract(etape.DateDebut).Hours;
                    seconde += etape.DateFin.Subtract(etape.DateDebut).Seconds;
                   
                }
                if (seconde >= 60)
                {
                    minute += TimeRecursion(seconde);
                    
                    seconde = seconde % 60; 
                }
                
                if (minute >= 60)
                {
                    heure += TimeRecursion(minute);
                    
                    minute = minute % 60; 
                }

                if (heure >= 24)
                {
                    jour += JourRecursion(heure);
                    heure = heure % 24;

                }


                TimeSpan resultat= new TimeSpan(jour, heure, minute,seconde);
                return resultat;
            }

            public int TimeRecursion(int time)
            {
                return time >= 60 ? 1 + TimeRecursion(time - 60):0;
            }
            
            public int JourRecursion(int time)
            {
                return time >= 24 ? 1 + TimeRecursion(time - 24):0;
            }
            
            public int AnneeJourRecursion(int time)
            {
                return time >= 365 ? 1 + TimeRecursion(time - 365):0;
            }


            public TimeSpan DureeCumuleReel(TimeSpan dureeCumuleBrute, List<Penalite> listePenalites)
            {
                TimeSpan span = new TimeSpan(0, 0, 0, 0);
                foreach (Penalite penalite in listePenalites)
                {
                    span.Add(penalite.Duree);
                }

                span.Add(dureeCumuleBrute);
                return span;
            }
            
            public String DureeCumuleReel1(TimeSpan dureeCumuleBrute, List<Penalite> listePenalites)
            {
                TimeSpan span = new TimeSpan(0, 0, 0, 0);
                foreach (Penalite penalite in listePenalites)
                {
                   span = span.Add(penalite.Duree);
                
                }

                span = span.Add(dureeCumuleBrute);
                return string.Format("jour {0}, heure {1}, minute {2} seconde {3}", span.Days, span.Hours,span.Minutes,span.Seconds);
            }
            
            public String DureeCumuleBruteTotal1(List<VoilierEtape> liste)
            {
                int jour = 0;
                int minute = 0;
                int heure = 0;
                int seconde = 0;
            
                ///DateTime date= DateTime.Now;

                foreach (VoilierEtape etape in liste)
                {
                    
                    jour += etape.DateFin.Subtract(etape.DateDebut).Days;
                    minute += etape.DateFin.Subtract(etape.DateDebut).Minutes;
                    heure += etape.DateFin.Subtract(etape.DateDebut).Hours;
                    seconde += etape.DateFin.Subtract(etape.DateDebut).Seconds;
                   
                }
                if (seconde >= 60)
                {
                    minute += TimeRecursion(seconde);
                    
                    seconde = seconde % 60; 
                }
                
                if (minute >= 60)
                {
                    heure += TimeRecursion(minute);
                    
                    minute = minute % 60; 
                }

                if (heure >= 24)
                {
                    jour += JourRecursion(heure);
                    heure = heure % 24;

                }


        
                
                return string.Format("jour {0}, heure {1}, minute {2} seconde {3}", jour, heure,minute,seconde);

            }
        
        static void AfficherCourse(List<Course> course)
        {
            foreach (Course element in course)
            {
                Console.WriteLine(element.Nom);   
            }
        }
    }
}