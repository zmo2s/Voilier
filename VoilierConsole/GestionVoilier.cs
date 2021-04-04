using ConsoleApp1.Voilier1;

namespace mysqlefcore
{
    public class GestionVoilier
    {
        private mydbContext model = new mydbContext();
        public Personne AjouterPersonne(Personne produit)
        {
            // Ajoute le produit à l'ORM EF
            model.Personne.Add(produit);
            // Valide les changement dans la base de données
            if (model.SaveChanges() > 0)
                return produit;
            return null;
        }
        
    }
}