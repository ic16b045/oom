using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Movie
    {
        private string title;
        private decimal rating;
        private bool seen;

        //Constructor
        public Movie(string newTitle, decimal newRating, bool seen)
        {
            UpdateRating(newRating);
            if (newTitle == null || newTitle.Length == 0)
                throw new ArgumentException("Titel fehlt");
            title = newTitle;
        }

        public Movie(string newTitle, decimal newRating): this(newTitle, newRating, false) { }
        public Movie(string newTitle, bool newSeen): this(newTitle, 0, newSeen) { }
        public Movie(string newTitle): this (newTitle,0,false) { }

        //gets title
        public string Title => title;
        //gets rating
        public decimal Rating => rating;
        //gets or sets status of seen
        public bool Seen
        {
            get { return seen; }
            set { UpdateSeen(value); }
        }

        //updates rating + Errorhandling
        public void UpdateRating(decimal newRating)
        {
            if (newRating < 0 || newRating > 10)
            {
                throw new ArgumentException("Rating nicht in der Range!");
            }

            rating = newRating;
        }
        
        //updates status of seen + check if sth changes
        private void UpdateSeen(bool newSeen)
        {
            if (seen == newSeen) Console.WriteLine("Keine Änderung!");

            seen = newSeen;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var movie_1 = new Movie("Orphan");
            var movie_2 = new Movie("Fast & Furious", 8, true);
            var movie_3 = new Movie("Harry Potter",true);

            Console.WriteLine("Title: " + movie_1.Title + " Rating: " + movie_1.Rating + "/10 Seen: " + movie_1.Seen);
            Console.WriteLine("Title: " + movie_2.Title + " Rating: " + movie_2.Rating + "/10 Seen: " + movie_2.Seen);
            Console.WriteLine("Title: " + movie_3.Title + " Rating: " + movie_3.Rating + "/10 Seen: " + movie_3.Seen);

            movie_1.Seen = true;
            movie_1.UpdateRating(9);
            movie_3.Seen = true;
            movie_3.UpdateRating(10);

            Console.WriteLine("Title: " + movie_1.Title + " Rating: " + movie_1.Rating + "/10 Seen: " + movie_1.Seen);
            Console.WriteLine("Title: " + movie_3.Title + " Rating: " + movie_3.Rating + "/10 Seen: " + movie_3.Seen);
        }
    }
}
