using System;
using System.Collections.Generic;
using ConsoleApp1.voilier;
using ConsoleApp1.Voilier1;
using Microsoft.EntityFrameworkCore;
namespace ConsoleApp1
{
    public class GestionEtape
    {
        private voilier1Context model = new voilier1Context();
        public Etape AjouterEtape(Etape Etape)
        {
            // Ajoute le produit à l'ORM EF
            model.Etape.Add(Etape);
            // Valide les changement dans la base de données
            if (model.SaveChanges() > 0)
                return Etape;
            return null;
        }
        
        public void DisplayEtape(List<Etape> liste)
        {
            foreach (Etape Etape in liste)
            {
                Console.WriteLine("{0} réalisé par {1} {2} {3} {4} {5} ",Etape.IdEtape,Etape.Nom,Etape.DateDebut,Etape.DateFin,Etape.VoilierEtapeIdVoilierEtape,Etape.VoilierIdVoilier);
            }
        }
         
         
        public Etape RechercherEtape(int id)
        {
            return model.Etape.Find(id);
        }
        
        public bool ModifierPersnne(Etape Etape)
        {
            // Mettre le statut de l'entité à "Modifiée" dans l'ORM
            model.Entry(Etape).State = EntityState.Modified;
            // Valide les changement dans la base de données
            return (model.SaveChanges() > 0);
        }
         
        public bool SupprimerEtape(int id)
        {
            Etape p = RechercherEtape(id);
            if (p == null)
                return false;
            return SupprimerEtape(p);
        }
        public bool SupprimerEtape(Etape produit)
        {
            if (produit != null)
            {
                // Supprime le produit dans l'ORM
                model.Etape.Remove(produit);
                // Valide les changement dans la base de données
                return (model.SaveChanges() > 0);
            }
            return false;
        }
    }
}