using System;
using System.Collections.Generic;
using ConsoleApp1.voilier;
using ConsoleApp1.Voilier1;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class GestionVoilierEtape
    {
       
        
        private voilier1Context model = new voilier1Context();
        private List<VoilierEtape> listeEtape = new List<VoilierEtape>();
            public VoilierEtape AjouterVoilierEtape(VoilierEtape VoilierEtape)
            {
                // Ajoute le produit à l'ORM EF
                model.VoilierEtape.Add(VoilierEtape);
                // Valide les changement dans la base de données
                if (model.SaveChanges() > 0)
                    return VoilierEtape;
                return null;
            }

            public void DisplayVoilierEtape(List<VoilierEtape> liste)
            {
                foreach (VoilierEtape VoilierEtape in liste)
                {
                    Console.WriteLine("{0} réalisé par {1} {2} {3} {4} ", VoilierEtape.IdVoilierEtape, VoilierEtape.Duree,
                        VoilierEtape.IdVoilierEtape, VoilierEtape.PenaliteIdPenalite, VoilierEtape.VoilierIdVoilier);
                }
            }


            public VoilierEtape RechercherVoilierEtape(int id)
            {
                return model.VoilierEtape.Find(id);
            }

            public bool ModifierPersnne(VoilierEtape VoilierEtape)
            {
                // Mettre le statut de l'entité à "Modifiée" dans l'ORM
                model.Entry(VoilierEtape).State = EntityState.Modified;
                // Valide les changement dans la base de données
                return (model.SaveChanges() > 0);
            }

            public bool SupprimerVoilierEtape(int id)
            {
                VoilierEtape p = RechercherVoilierEtape(id);
                if (p == null)
                    return false;
                return SupprimerVoilierEtape(p);
            }

            public bool SupprimerVoilierEtape(VoilierEtape produit)
            {
                if (produit != null)
                {
                    // Supprime le produit dans l'ORM
                    model.VoilierEtape.Remove(produit);
                    // Valide les changement dans la base de données
                    return (model.SaveChanges() > 0);
                }

                return false;
            }
            public void DisplayCourse(List<VoilierEtape> liste)
            {
                foreach (VoilierEtape voilierEtape in liste)
                {
                    Console.WriteLine("{0} réalisé par {1} {2}  ", voilierEtape.Course,voilierEtape.DateDebut,voilierEtape.DateFin);
                }
            }
            
            
            public String DureeCumuleBruteTotal1(List<VoilierEtape> liste)
            {
                int jour = 0;
                int minute = 0;
                int heure = 0;
            
                ///DateTime date= DateTime.Now;

                foreach (VoilierEtape etape in liste)
                {
                    
                    jour += etape.DateFin.Subtract(etape.DateDebut).Days;
                    minute += etape.DateFin.Subtract(etape.DateDebut).Minutes;
                    heure += etape.DateFin.Subtract(etape.DateDebut).Hours;
                   
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
                
                
                return string.Format("jour {0}, heure {1}, minute {2}", jour, heure,minute);

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
            
            
        }
    }
