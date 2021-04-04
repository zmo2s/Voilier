using System;
using System.Collections.Generic;
using ConsoleApp1.Voilier1;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class GestionVoilierEtape
    {
       
        
            private mydbContext model = new mydbContext();

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
        }
    }
