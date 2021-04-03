using System.Collections.Generic;

namespace mysqlefcore
{
    public class Course
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }   
        public int Pages { get; set; }
        public virtual Etape Etape { get; set; }
    }

    public class Etape
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Books { get; set; }
    }
}