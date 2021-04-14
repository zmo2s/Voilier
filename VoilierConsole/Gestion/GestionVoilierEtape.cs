using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            
            public TimeSpan DureeCumuleBruteTotal2(List<VoilierEtape> liste)
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
            
        }
    }
