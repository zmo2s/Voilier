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
using ConsoleApp1.Voilier1;
using NetTopologySuite.LinearReferencing;

namespace mysqlefcore
{
    class Program
    {
        static void Main(string[] args)
        {

             mydbContext model1 = new mydbContext();
             GestionPersonne model = new GestionPersonne();
             Personne henri = new Personne(6,"to","leo",23,14,"ddd","dd");
             model.SupprimerPersonne(6);
             model.AjouterPersonne(henri);
             var liste = from f in model1.Personne select f;
             model.DisplayPersonne(liste.ToList());
             



        }

    }
}          