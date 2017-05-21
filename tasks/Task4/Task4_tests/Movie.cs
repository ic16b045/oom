using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task4_tests
{
    public class Movie: Medien
    {
        //Properties
        private string name;
        private decimal rating;
        private bool seen = false;
        private string description;
        private double price;
        //geerbt aus Interface
        public void print_all()
        {
            Console.WriteLine("Filmname: " + name);
            Console.WriteLine("Rating:   " + rating);
            Console.WriteLine("Gesehen:  " + seen);
            Console.WriteLine("Handlung  " + description);
            Console.WriteLine("Preis     " + UpdatePrice);
        }
        public void print_name_rating()
        {
            Console.WriteLine("Film: " + name + " Rating: " + rating + "/10");
        }
        
        public string Name
        {
            get { return name; }
        }
        public string Description
        {
            get { return description ; }
            set { UpdateDescription(value); }
        }
        public double Price
        {
            get { return price; }
        }
        public bool Seen
        {
            get { return seen; }
        }
        public decimal Rating
        {
            get { return rating; }
        }
        //Constructoren
        public Movie(string newName, decimal newRating, string newDescription, double newPrice)
        {

            if (newName == null || newName.Length == 0)
                throw new ArgumentException("Titel fehlt");
            name = newName;

            UpdateRating(newRating);
            UpdateDescription(newDescription);
            SetPrice(newPrice);
            seen = false;
        }
        public Movie(string newName, double newPrice) : this(newName, 0, "", newPrice) { }

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
        public void UpdateDescription(string NewDescription)
        {
            if (NewDescription != null || NewDescription.Length == 0 || NewDescription != description)
            {
                description = NewDescription;
            }

        }
        private void SetPrice(double newPrice)
        {
            if (newPrice <= 0) throw new ArgumentException("Preis darf nicht negativ sein!");
            price = newPrice;
        }
        public double UpdatePrice
        {
           set { SetPrice(value); }
           get { return price; }
        }

    }

}
