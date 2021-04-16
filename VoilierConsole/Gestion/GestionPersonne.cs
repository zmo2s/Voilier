using System;
using System.Collections.Generic;
using ConsoleApp1.voilier;
using ConsoleApp1.voilier1;
using ConsoleApp1.Voilier1;
using Microsoft.EntityFrameworkCore;

namespace mysqlefcore
{
    public class GestionPersonne
    {
        private voilier1Context model = new voilier1Context();
        public Personne AjouterPersonne(Personne personne)
        {
            // Ajoute le produit à l'ORM EF
            model.Personne.Add(personne);
            // Valide les changement dans la base de données
            if (model.SaveChanges() > 0)
                return personne;
            return null;
        }
        
         public void DisplayPersonne(List<Personne> liste)
        {
            foreach (Personne personne in liste)
            {
                Console.WriteLine("{0} réalisé par {1} {2} {3} {4} {5} ",personne.IdPersonne,personne.Nom,personne.Prenom,personne.Salaire,personne.Sponsors,personne.Sponsors);
            }
        }
         
         
         public Personne RechercherPersonne(int id)
         {
             return model.Personne.Find(id);
         }
        
         public bool ModifierPersnne(Personne personne)
         {
             // Mettre le statut de l'entité à "Modifiée" dans l'ORM
             model.Entry(personne).State = EntityState.Modified;
             // Valide les changement dans la base de données
             return (model.SaveChanges() > 0);
         }
         
         public bool SupprimerPersonne(int id)
         {
             Personne p = RechercherPersonne(id);
             if (p == null)
                 return false;
             return SupprimerPersonne(p);
         }
         public bool SupprimerPersonne(Personne produit)
         {
             if (produit != null)
             {
                 // Supprime le produit dans l'ORM
                 model.Personne.Remove(produit);
                 // Valide les changement dans la base de données
                 return (model.SaveChanges() > 0);
             }
             return false;
         }
         
         
         
        
        
    }
}