using System;
using System.Collections.Generic;
using ConsoleApp1.voilier;
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
        
        static void AfficherCourse(List<Course> course)
        {
            foreach (Course element in course)
            {
                Console.WriteLine(element.Nom);   
            }
        }
    }
}