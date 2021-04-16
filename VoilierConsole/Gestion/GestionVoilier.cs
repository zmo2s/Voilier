using System;
using System.Collections.Generic;
using ConsoleApp1.voilier;
using ConsoleApp1.voilier1;
using ConsoleApp1.Voilier1;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class GestionVoilier
    {
       
        
        private voilier1Context model = new voilier1Context();

            public Voilier AjouterVoilier(Voilier Voilier)
            {
                // Ajoute le produit à l'ORM EF
                model.Voilier.Add(Voilier);
                // Valide les changement dans la base de données
                if (model.SaveChanges() > 0)
                    return Voilier;
                return null;
            }

            public void DisplayVoilier(List<Voilier> liste)
            {
                foreach (Voilier Voilier in liste)
                {
                    Console.WriteLine("{0} réalisé par {1} {2} {3} {4} {5} ", Voilier.IdVoilier, Voilier.Name,
                        Voilier.Latitude, Voilier.Longitude, Voilier.Marque, Voilier.Poids);
                }
            }


            public Voilier RechercherVoilier(int id)
            {
                return model.Voilier.Find(id);
            }

            public bool ModifierPersnne(Voilier Voilier)
            {
                // Mettre le statut de l'entité à "Modifiée" dans l'ORM
                model.Entry(Voilier).State = EntityState.Modified;
                // Valide les changement dans la base de données
                return (model.SaveChanges() > 0);
            }

            public bool SupprimerVoilier(int id)
            {
                Voilier p = RechercherVoilier(id);
                if (p == null)
                    return false;
                return SupprimerVoilier(p);
            }

            public bool SupprimerVoilier(Voilier produit)
            {
                if (produit != null)
                {
                    // Supprime le produit dans l'ORM
                    model.Voilier.Remove(produit);
                    // Valide les changement dans la base de données
                    return (model.SaveChanges() > 0);
                }

                return false;
            }

        }
    }

