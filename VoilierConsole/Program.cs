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
using System.Text;

namespace mysqlefcore
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertData();
            PrintData();
        }

        private static void InsertData()
        {
            using(var context = new Voilier())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                // Adds a publisher
                var publisher = new Publisher
                {
                    Name = "Mariner Books"
                };
                context.Publisher.Add(publisher);

                // Adds some books
                context.Course.Add(new Course
                {
                    ISBN = "978-0545540035415",
                    Title = "The Lord of the Rings",
                    Author = "J.R.R. Tolkien",
                    Language = "English",
                    Pages = 1216,
                    Publisher = publisher
                });
                context.Course.Add(new Course
                {
                    ISBN = "978-0555475247762",
                    Title = "The Sealed Letter",
                    Author = "Emma Donoghue",
                    Language = "English",
                    Pages = 416,
                    Publisher = publisher
                });

                // Saves changes
                context.SaveChanges();
            }
        }

        private static void PrintData()
        {
            // Gets and prints all books in database
            using (var context = new Voilier())
            {
                var books = context.Course
                    .Include(p => p.Publisher);
                foreach(var book in books)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"ISBN: {book.ISBN}");
                    data.AppendLine($"Title: {book.Title}");
                    data.AppendLine($"Publisher: {book.Publisher.Name}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
    }
}          