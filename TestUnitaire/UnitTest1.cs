using System;
using System.Linq;
using ConsoleApp1;
using ConsoleApp1.voilier1;
using ConsoleApp1.Voilier1;
using mysqlefcore;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1EntityPersonne()
        {
            Assert.AreEqual(2, 2);
            voilier1Context model1 = new voilier1Context();
            GestionPersonne modelGestionPersonne = new GestionPersonne();
            Personne henri = new Personne(7, "to", "leo", 23, 14, "ddd", "dd");
            modelGestionPersonne.SupprimerPersonne(7);
            modelGestionPersonne.AjouterPersonne(henri);
            var listePersonne = from f in model1.Personne select f;
            modelGestionPersonne.DisplayPersonne(listePersonne.ToList());

            Assert.AreEqual(henri.IdPersonne, listePersonne.ToList()[0].IdPersonne);
            Assert.AreEqual(henri.Prenom, listePersonne.ToList()[0].Prenom);
            Assert.AreEqual(henri.Nom, listePersonne.ToList()[0].Nom);
            Assert.AreEqual(henri.Age, listePersonne.ToList()[0].Age);
            Assert.AreEqual(henri.Salaire, listePersonne.ToList()[0].Salaire);
            Assert.AreEqual(henri.Equipage, listePersonne.ToList()[0].Equipage);
        }

        [Test]
        public void Test2EntityVoilier()
        {
            voilier1Context model1 = new voilier1Context();
            GestionVoilier modelGestionVoilier = new GestionVoilier();
            Voilier LeGrand = new Voilier(7, "legrand", 2, 50000, "albatros", 60, 1500, 50, 7, 7);
            modelGestionVoilier.SupprimerVoilier(7);
            modelGestionVoilier.AjouterVoilier(LeGrand);
            var listeVoilier = from f in model1.Voilier select f;
            modelGestionVoilier.DisplayVoilier(listeVoilier.ToList());

            Assert.AreEqual(LeGrand.IdVoilier, listeVoilier.ToList()[0].IdVoilier);
            Assert.AreEqual(LeGrand.Name, listeVoilier.ToList()[0].Name);
            Assert.AreEqual(LeGrand.NbrPlace, listeVoilier.ToList()[0].NbrPlace);
            Assert.AreEqual(LeGrand.Prix, listeVoilier.ToList()[0].Prix);
            Assert.AreEqual(LeGrand.Marque, listeVoilier.ToList()[0].Marque);
            Assert.AreEqual(LeGrand.Vitesse, listeVoilier.ToList()[0].Vitesse);
            Assert.AreEqual(LeGrand.Poids, listeVoilier.ToList()[0].Poids);
            Assert.AreEqual(LeGrand.Latitude, listeVoilier.ToList()[0].Latitude);
            Assert.AreEqual(LeGrand.Longitude, listeVoilier.ToList()[0].Longitude);
            Assert.AreEqual(LeGrand.PersonneIdPersonne, listeVoilier.ToList()[0].PersonneIdPersonne);

        }

        [Test]
        public void Test3EntityPenalite()
        {
            voilier1Context model1 = new voilier1Context();
            GestionPenalite modelGestionPenalite = new GestionPenalite();
            TimeSpan teste = new TimeSpan(2, 14, 18);
            Penalite departEnAvance = new Penalite(5, "departEnAvance", teste, 10, 20.2);
            modelGestionPenalite.SupprimerPenalite(5);
            modelGestionPenalite.AjouterPenalite(departEnAvance);
            var listePenalite = from f in model1.Penalite select f;
            modelGestionPenalite.DisplayPenalite(listePenalite.ToList());

            Assert.AreEqual(departEnAvance.IdPenalite, listePenalite.ToList()[0].IdPenalite);
            Assert.AreEqual(departEnAvance.Name, listePenalite.ToList()[0].Name);
            Assert.AreEqual(departEnAvance.Duree, listePenalite.ToList()[0].Duree);
            Assert.AreEqual(departEnAvance.Latitude, listePenalite.ToList()[0].Latitude);
            Assert.AreEqual(departEnAvance.Longitude, listePenalite.ToList()[0].Longitude);


        }

        [Test]
        public void Test4VoilierEtape()
        {
            DateTime etape1Time = new DateTime(2020, 3, 2, 0, 0, 0);
            voilier1Context model1 = new voilier1Context();
            GestionVoilierEtape modelGestionVoilierEtape = new GestionVoilierEtape();
            DateTime tempsEtape = new DateTime(2020, 3, 3, 13, 1, 1);
            VoilierEtape voilierEtape = new VoilierEtape(10, tempsEtape, 5, 7, etape1Time, tempsEtape);
            VoilierEtape voilierEtape1 = new VoilierEtape(11, tempsEtape, 5, 7, etape1Time, tempsEtape);
            modelGestionVoilierEtape.SupprimerVoilierEtape(10);
            modelGestionVoilierEtape.SupprimerVoilierEtape(11);
            modelGestionVoilierEtape.AjouterVoilierEtape(voilierEtape);
            modelGestionVoilierEtape.AjouterVoilierEtape(voilierEtape1);
            var listeVoilierEtapes = from f in model1.VoilierEtape select f;
            modelGestionVoilierEtape.DisplayVoilierEtape(listeVoilierEtapes.ToList());
            Assert.AreEqual(voilierEtape.IdVoilierEtape, listeVoilierEtapes.ToList()[0].IdVoilierEtape);
            Assert.AreEqual(voilierEtape.PenaliteIdPenalite, listeVoilierEtapes.ToList()[0].PenaliteIdPenalite);
            Assert.AreEqual(voilierEtape.VoilierIdVoilier, listeVoilierEtapes.ToList()[0].VoilierIdVoilier);
            Assert.AreEqual(voilierEtape.DateDebut, listeVoilierEtapes.ToList()[0].DateDebut);
            Assert.AreEqual(voilierEtape.DateFin, listeVoilierEtapes.ToList()[0].DateFin);
        }

        [Test]
        public void Test5Etape()
        {
            voilier1Context model1 = new voilier1Context();
            DateTime etape1Time = new DateTime(2020, 3, 2, 0, 0, 0);
            DateTime etape2Time = new DateTime(2020, 3, 9, 16, 30, 0);
            Etape etape1 = new Etape(3, "etape002", etape1Time, etape2Time, 10, 7);
            Etape etape2 = new Etape(2, "etape002", etape1Time, etape2Time, 10, 7);
            GestionEtape modelGestionEtape = new GestionEtape();
            modelGestionEtape.SupprimerEtape(etape1);
            modelGestionEtape.SupprimerEtape(etape2);
            modelGestionEtape.AjouterEtape(etape1);
            modelGestionEtape.AjouterEtape(etape2);
            var listeEtape = from f in model1.Etape select f;
            modelGestionEtape.DisplayEtape(listeEtape.ToList());

            Assert.AreEqual(etape1.IdEtape, listeEtape.ToList()[1].IdEtape);
            Assert.AreEqual(etape1.Nom, listeEtape.ToList()[1].Nom);
            Assert.AreEqual(etape1.DateDebut, listeEtape.ToList()[1].DateDebut);
            Assert.AreEqual(etape1.DateFin, listeEtape.ToList()[1].DateFin);
            Assert.AreEqual(etape1.VoilierEtapeIdVoilierEtape, listeEtape.ToList()[1].VoilierEtapeIdVoilierEtape);
            Assert.AreEqual(etape1.VoilierIdVoilier, listeEtape.ToList()[1].VoilierIdVoilier);

            Assert.AreEqual(etape2.IdEtape, listeEtape.ToList()[0].IdEtape);
            Assert.AreEqual(etape2.Nom, listeEtape.ToList()[0].Nom);
            Assert.AreEqual(etape2.DateDebut, listeEtape.ToList()[0].DateDebut);
            Assert.AreEqual(etape2.DateFin, listeEtape.ToList()[0].DateFin);
            Assert.AreEqual(etape2.VoilierEtapeIdVoilierEtape, listeEtape.ToList()[0].VoilierEtapeIdVoilierEtape);
            Assert.AreEqual(etape2.VoilierIdVoilier, listeEtape.ToList()[0].VoilierIdVoilier);

        }


        [Test]
        public void Test6Course()
        {
            voilier1Context model1 = new voilier1Context();
            DateTime etape1Time = new DateTime(2020, 3, 2, 0, 0, 0);
            DateTime etape2Time = new DateTime(2020, 3, 9, 16, 30, 0);
            Course courseFrance = new Course(1,"course de france ",2,etape1Time,etape2Time,10,7);
            GestionCourse modelGestionCourse = new GestionCourse();
            modelGestionCourse.AjouterCourse(courseFrance);
            var listeCourse = from f in model1.Course select f;
            modelGestionCourse.DisplayCourse(listeCourse.ToList());
            
            Assert.AreEqual(courseFrance.IdCourse,listeCourse.ToList()[0].IdCourse);
            Assert.AreEqual(courseFrance.Nom,listeCourse.ToList()[0].Nom);
            Assert.AreEqual(courseFrance.EtapeIdEtape,listeCourse.ToList()[0].EtapeIdEtape);
            Assert.AreEqual(courseFrance.DureeCumuleBrute,listeCourse.ToList()[0].DureeCumuleBrute);
            Assert.AreEqual(courseFrance.DureeCumuleReel,listeCourse.ToList()[0].DureeCumuleReel);
            Assert.AreEqual(courseFrance.VoilierEtapeIdVoilierEtape,listeCourse.ToList()[0].VoilierEtapeIdVoilierEtape);
            Assert.AreEqual(courseFrance.VoilierIdVoilier,listeCourse.ToList()[0].VoilierIdVoilier);

        }
    }
}