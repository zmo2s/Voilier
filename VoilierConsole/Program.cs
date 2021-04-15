using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using ConsoleApp1;
using ConsoleApp1.voilier;
using ConsoleApp1.Voilier1;
using mysqlefcore;
using NetTopologySuite.LinearReferencing;

namespace ConsoleApp1.voilier
{
    class Program
    {
        static void Main(string[] args)
        {
         
            
             voilier1Context model1 = new voilier1Context();
             GestionPersonne modelGestionPersonne = new GestionPersonne();
             Personne henri = new Personne(7,"to","leo",23,14,"ddd","dd");
             
             //ajotuer uen personne dans la bdd
             
             modelGestionPersonne.SupprimerPersonne(7);
             modelGestionPersonne.AjouterPersonne(henri);
             var listePersonne = from f in model1.Personne select f;
             modelGestionPersonne.DisplayPersonne(listePersonne.ToList());
             
             //ajouter un voilier dans la bdd

             GestionVoilier modelGestionVoilier = new GestionVoilier();
             Voilier LeGrand = new Voilier(7, "legrand", 2, 50000, "albatros", 60, 1500, 50, 7);
             modelGestionVoilier.SupprimerVoilier(7);
             modelGestionVoilier.AjouterVoilier(LeGrand);
             var lsiteVoilier = from f in model1.Voilier select f;
             modelGestionVoilier.DisplayVoilier(lsiteVoilier.ToList());
            
             //ajouter une pénalité dans la bdd
             
             GestionPenalite modelGestionPenalite = new GestionPenalite();
             TimeSpan teste = new TimeSpan(2, 14, 18);
             Penalite departEnAvance = new Penalite(5, "departEnAvance", teste,10,20.2);
              modelGestionPenalite.SupprimerPenalite(5);
             modelGestionPenalite.AjouterPenalite(departEnAvance);
             var listePenalite = from f in model1.Penalite select f;
             modelGestionPenalite.DisplayPenalite(listePenalite.ToList());
             
             DateTime etape1Time = new DateTime(2020, 3, 2, 0, 0, 0);
             //ajouter un Voilieretape dans la bdd
             
             GestionVoilierEtape modelGestionVoilierEtape = new GestionVoilierEtape();
             DateTime tempsEtape = new DateTime(2020,3,3,13,1,1);
             VoilierEtape voilierEtape = new VoilierEtape(10,tempsEtape,5,7,etape1Time,tempsEtape);
             VoilierEtape voilierEtape1 = new VoilierEtape(11,tempsEtape,5,7,etape1Time,tempsEtape);
             modelGestionVoilierEtape.SupprimerVoilierEtape(10);
             modelGestionVoilierEtape.SupprimerVoilierEtape(11);
            modelGestionVoilierEtape.AjouterVoilierEtape(voilierEtape);
            modelGestionVoilierEtape.AjouterVoilierEtape(voilierEtape1);
             var listeVoilierEtapes = from f in model1.VoilierEtape select f;
             modelGestionVoilierEtape.DisplayVoilierEtape(listeVoilierEtapes.ToList());

         

             //ajouter ybe etape dans la bdd
             
             DateTime etape2Time = new DateTime(2020,3,9,16,30,0);
             DateTime tempsCourse = new DateTime(2020,1,2,3,2,3);
             Console.WriteLine("Hello World!");
             Etape etape1=new Etape(3, "etape002",etape1Time,etape2Time,10,7);
             Etape etape2=new Etape(2, "etape002",etape1Time,etape2Time,10,7);
             GestionEtape modelGestionEtape = new GestionEtape();
             modelGestionEtape.AjouterEtape(etape1);
             modelGestionEtape.AjouterEtape(etape2);
             var listeEtape = from f in model1.Etape select f;
             modelGestionEtape.DisplayEtape(listeEtape.ToList());
             

             //faire en premier personne puis voilier puis pénalite puis idetape puis etape puis course

             //ajouter une course dnas la bdd
             
             Course courseFrance = new Course(1,"course de france ",2,etape1Time,etape2Time,10,7);
             GestionCourse modelGestionCourse = new GestionCourse();
             modelGestionCourse.AjouterCourse(courseFrance);
             var listeCourse = from f in model1.Course select f;
             modelGestionCourse.DisplayCourse(listeCourse.ToList());
    

             IQueryable<Course> Zerodium = model1.Course;
             Zerodium = Zerodium.Where(a => a.IdCourse == 1);
             modelGestionCourse.DisplayCourse(Zerodium.ToList());
             Console.WriteLine(modelGestionCourse.GetIdEtape(Zerodium.ToList()));


             IQueryable<VoilierEtape> Zerodium1 = model1.VoilierEtape;
             Zerodium1 = Zerodium1.Where(a => a.PenaliteIdPenalite == 5);
             modelGestionVoilierEtape.DisplayCourse(Zerodium1.ToList());
             
             //affiche la duré de la course pour le voilier toute étape confondu
             // affiche la duré avec les pénalité du voilier pour toutes étapes confondu
             Console.WriteLine(modelGestionCourse.DureeCumuleBruteTotal1(Zerodium1.ToList()));
             Console.WriteLine(modelGestionCourse.TimeRecursion(120));
             Console.WriteLine(modelGestionCourse.DureeCumuleReel1(modelGestionVoilierEtape.DureeCumuleBruteTotal2(Zerodium1.ToList()), listePenalite.ToList()));



             // var listeCourse1 = from f in model1.Course where f.IdCourse==1 select f.EtapeIdEtape;
             // a = (int) listeCourse1;
             //Console.WriteLine(listeCourse1.Expression);











        }

    }
}          