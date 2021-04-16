using System;
using System.Collections.Generic;
using ConsoleApp1.voilier;
using ConsoleApp1.voilier1;
using ConsoleApp1.Voilier1;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class GestionPenalite
    {
      
        private voilier1Context model = new voilier1Context();

            public Penalite AjouterPenalite(Penalite Penalite)
            {
                // Ajoute le produit à l'ORM EF
                model.Penalite.Add(Penalite);
                // Valide les changement dans la base de données
                if (model.SaveChanges() > 0)
                    return Penalite;
                return null;
            }

            public void DisplayPenalite(List<Penalite> liste)
            {
                foreach (Penalite Penalite in liste)
                {
                    Console.WriteLine("{0} réalisé par {1} {2} {3}  ", Penalite.IdPenalite, Penalite.Name,
                        Penalite.Duree, Penalite.IdPenalite);
                }
            }


            public Penalite RechercherPenalite(int id)
            {
                return model.Penalite.Find(id);
            }

            public bool ModifierPersnne(Penalite Penalite)
            {
                // Mettre le statut de l'entité à "Modifiée" dans l'ORM
                model.Entry(Penalite).State = EntityState.Modified;
                // Valide les changement dans la base de données
                return (model.SaveChanges() > 0);
            }

            public bool SupprimerPenalite(int id)
            {
                Penalite p = RechercherPenalite(id);
                if (p == null)
                    return false;
                return SupprimerPenalite(p);
            }

            public bool SupprimerPenalite(Penalite produit)
            {
                if (produit != null)
                {
                    // Supprime le produit dans l'ORM
                    model.Penalite.Remove(produit);
                    // Valide les changement dans la base de données
                    return (model.SaveChanges() > 0);
                }

                return false;
            }
        }
    }
