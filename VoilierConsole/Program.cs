/*using System;
using VoilierLibrary;

namespace VoilierConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime etape1Time = new DateTime(2020, 3, 9, 9, 0, 0);
            DateTime etape2Time = new DateTime(2020,3,9,16,30,0);
            DateTime tempsCourse = new DateTime(2020,1,2,3,2,3);
            Console.WriteLine("Hello World!");
            Etape etape1=new Etape(1, "etape001",etape1Time,etape2Time);
            Etape etape2=new Etape(2, "etape002",etape1Time,etape2Time);

            Course courseFrance = new Course(1,"course de france ",tempsCourse);
            courseFrance.AjouterEtape(etape1);
            courseFrance.AjouterEtape(etape2);
            courseFrance.AfficherEtape();
            Console.WriteLine(courseFrance.DureeCumuleBruteTotal());
            
            VoilierEtape eta = new VoilierEtape();
            TimeSpan teste = new TimeSpan(2, 14, 18);
            Penalite penalite = new Penalite(1,"tsubishi",teste);
            Penalite penalite1 = new Penalite(2,"tsubishi",teste);
            eta.AjouterPenalite(penalite);
            eta.AjouterPenalite(penalite1);
            
            Console.WriteLine(eta.DureeCumulePenalite());
        }
    }
}

*/

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using ConsoleApp1;
using ConsoleApp1.Voilier1;
using NetTopologySuite.LinearReferencing;

namespace mysqlefcore
{
    class Program
    {
        static void Main(string[] args)
        {

             mydbContext model1 = new mydbContext();
             GestionPersonne modelGestionPersonne = new GestionPersonne();
             Personne henri = new Personne(6,"to","leo",23,14,"ddd","dd");
             
             
             modelGestionPersonne.SupprimerPersonne(6);
             modelGestionPersonne.AjouterPersonne(henri);
             var listePersonne = from f in model1.Personne select f;
             modelGestionPersonne.DisplayPersonne(listePersonne.ToList());


             GestionVoilier modelGestionVoilier = new GestionVoilier();
             Voilier LeGrand = new Voilier(1, "legrand", 2, 50000, "albatros", 60, 1500, 50, 50, 2);
             modelGestionVoilier.SupprimerVoilier(1);
             modelGestionVoilier.AjouterVoilier(LeGrand);
             var lsiteVoilier = from f in model1.Voilier select f;
             modelGestionVoilier.DisplayVoilier(lsiteVoilier.ToList());

             GestionPenalite modelGestionPenalite = new GestionPenalite();
             TimeSpan teste = new TimeSpan(2, 14, 18);
             Penalite departEnAvance = new Penalite(2, "departEnAvance", teste);
             modelGestionPenalite.SupprimerPenalite(1);
             modelGestionPenalite.AjouterPenalite(departEnAvance);
             var listePenalite = from f in model1.Penalite select f;
             modelGestionPenalite.DisplayPenalite(listePenalite.ToList());
             
             

             /*
             DateTime etape1Time = new DateTime(2020, 3, 9, 9, 0, 0);
             DateTime etape2Time = new DateTime(2020,3,9,16,30,0);
             DateTime tempsCourse = new DateTime(2020,1,2,3,2,3);
             Console.WriteLine("Hello World!");
             Etape etape1=new Etape(1, "etape001",etape1Time,etape2Time,2,2);
             Etape etape2=new Etape(2, "etape002",etape1Time,etape2Time,2,1);
             GestionEtape modelGestionEtape = new GestionEtape();
             modelGestionEtape.AjouterEtape(etape1);
             modelGestionEtape.AjouterEtape(etape2);
             var listeEtape = from f in model1.Etape select f;
             modelGestionEtape.DisplayEtape(listeEtape.ToList());
             */

             //faire en premier personne puis voilier puis pénalite puis idetape puis etape puis course

             /*
             Course courseFrance = new Course(1,"course de france ",2,3,2);
             
             courseFrance.AjouterEtape(etape1);
             courseFrance.AjouterEtape(etape2);
             courseFrance.AfficherEtape();
             Console.WriteLine(courseFrance.DureeCumuleBruteTotal());
*/

        }

    }
}          