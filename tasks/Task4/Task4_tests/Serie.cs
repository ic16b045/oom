using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_tests
{

    class Serie : Medien
    {
        private string name;
        private decimal rating;
        private int season;
        private string description;
        private bool seen;
        private double price;

        //geerbt aus Interface
        public void print_all()
        {
            Console.WriteLine("Serienname: " + name);
            Console.WriteLine("Staffeln:   " + season);
            Console.WriteLine("Rating:     " + rating);
            Console.WriteLine("Gesehen:    " + seen);
            Console.WriteLine("Handlung:   " + description);
        }
        public void print_name_rating()
        {
            Console.WriteLine("Serie: " + name + " Rating: " + rating + "/10");
        }
       
        //raus?
        public string Name
        {
            get { return name; }
        }
        public string Description
        {
            get { return description; }
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
        public int Season
        {
            get { return season; }
        }

        public Serie(string Name, decimal Rating, string Description, int Season, double Price)
        {
            if (Name == null || Name.Length == 0)
                throw new ArgumentException("Titel fehlt");
            name = Name;
            season = Season;
            UpdateRating(Rating);
            UpdateDescription(Description);
        }
        public Serie(string Name, int Season, double Price) : this(Name, 0, "", Season, Price) { }

        public void UpdateRating(decimal Rating)
        {
            if (Rating < 0 || Rating > 10)
            {
                throw new ArgumentException("Rating nicht in der Range!");
            }

            rating = Rating;

            if (rating > 0) UpdateSeen();
        }
        private void UpdateDescription(string Description)
        {
            if (Description != null || Description != "" || Description != description)
            {
                description = Description;
            }

        }
        private void UpdateSeen()
        {
            seen = true;
        }
        private void SetPrice(double Price)
        {
            if (Price <= 0) throw new ArgumentException("Preis darf nicht negativ sein!");
            price = Price;
        }
        public double UpdatePrice
        {
            set { SetPrice(value); }
            get { return price; }
        }
    }

}
