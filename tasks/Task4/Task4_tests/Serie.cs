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

        public Serie(string NewName, decimal NewRating, string NewDescription, int NewSeason, double newPrice)
        {
            if (NewName == null || NewName.Length == 0)
                throw new ArgumentException("Titel fehlt");
            name = NewName;
            season = NewSeason;
            UpdateRating(NewRating);
            UpdateDescription(NewDescription);
        }
        public Serie(string NewName, int NewSeason, double newPrice) : this(NewName, 0, "", NewSeason, newPrice) { }

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
