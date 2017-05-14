using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    interface Medien
    {
        void print_all();
        string getname();
        string Description { get; set; }

    }


    public class Movie:Medien
    {
        private string name;
        private decimal rating;
        private bool seen = false;
        private string description;

        public string Description
        {
            get { return "Der Film" + name + "handelt von " + description; }
            set { UpdateDescription(value); }
        }
        public void print_all()
        {
            Console.WriteLine("Filmname: " + name);
            Console.WriteLine("Rating:   " + rating);
            Console.WriteLine("Gesehen:  " + seen);
            Console.WriteLine("Handlung  " + description);
        }
        public string getname()
        {
            return name;
        }
        //Constructoren
        public Movie(string newName, decimal newRating, string newDescription)
        {
            
            if (newName == null || newName.Length == 0)
                throw new ArgumentException("Titel fehlt");
            name = newName;

            UpdateRating(newRating);
            UpdateDescription(newDescription);
            seen = false;
        }
        public Movie(string newName, decimal newRating) : this(newName, newRating, "") { }
        public Movie(string newName, string newDescription) : this(newName, 0, newDescription) { }
        public Movie(string newName) : this(newName, 0, "") { }

        //Methods
        public void UpdateRating(decimal newRating)
        {
            if (newRating < 0 || newRating > 10)
            {
                throw new ArgumentException("Rating nicht in der Range!");
            }

            rating = newRating;

            if (rating > 0) UpdateSeen();
        }

        private void UpdateSeen()
        { 
            seen = true;
        }

        private void UpdateDescription(string NewDescription)
        {
            if(NewDescription != null || NewDescription.Length == 0 || NewDescription != description)
            {
                description = NewDescription;
            }

        }

    }

    class Serie:Medien
    {
        private string name;
        private decimal rating;
        private int seasons;
        private string description;
        private bool seen;

        public string Description
        {
            get { return "Die Serie" + name + "handelt von " + description; }
            set { UpdateDescription(value); }
        }
        public void print_all()
        {
            Console.WriteLine("Serienname: " + name);
            Console.WriteLine("Staffeln:   " + seasons);
            Console.WriteLine("Rating:     " + rating);
            Console.WriteLine("Gesehen:    " + seen);
            Console.WriteLine("Handlung:   " + description);
        }
        public string getname()
        {
            return name;
        }

        public Serie( string NewName, decimal NewRating,string NewDescription, int NewSeasons)
        {
            if (NewName == null || NewName.Length == 0)
                throw new ArgumentException("Titel fehlt");
            name = NewName;
            seasons = NewSeasons;
            UpdateRating(NewRating);
            UpdateDescription(NewDescription);
        }
        public Serie(string NewName,int NewSeasons): this (NewName,0,"",NewSeasons) { }
        public Serie(string NewName): this (NewName,0,"",1) { }
        public Serie(string NewName, decimal NewRating): this (NewName,NewRating,"",1) { }

        public void UpdateRating(decimal NewRating)
        {
            if (NewRating < 0 || NewRating > 10)
            {
                throw new ArgumentException("Rating nicht in der Range!");
            }

            rating = NewRating;

            if (rating > 0) UpdateSeen();
        }

        private void UpdateDescription(string NewDescription)
        {
            if (NewDescription != null || NewDescription != "" || NewDescription != description)
            {
                description = NewDescription;
            }

        }
        private void UpdateSeen()
        {
            seen = true;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            var movie_1 = new Movie("Flashback", 10, "Einige Jugendliche müssen einen Mord verschleiern...");
            var movie_2 = new Movie("Harry Potter und der Stein der Weisen","Harry erfährt, dass er ein Zauberer ist");
            var serie_1 = new Serie("How to get away with murder",3);

            Medien[] mixarray = new Medien[] { movie_1, movie_2, serie_1};
            var mixarray_movie = new [] { movie_1, movie_2 };
            var mixarray_serie = new[] { serie_1};
            foreach (var med in mixarray)
            { 
                Console.WriteLine(med.getname());
                Console.WriteLine(med.Description);
                Console.WriteLine();
            }
            
            foreach(var mov in mixarray_movie)
            {
                mov.UpdateRating(10);
                mov.print_all();
                Console.WriteLine();
            }

            foreach(var ser in mixarray_serie)
            {
                ser.UpdateRating(9);
                ser.print_all();
                Console.WriteLine();
            }

        }
    }
}