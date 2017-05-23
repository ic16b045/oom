using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task4_tests
{
    /*
     Klasse Movie - erbt von Medien
     
    */
    public class Movie : Medien
    {
        //Fields
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
            Console.WriteLine("Handlung: " + description);
            Console.WriteLine("Preis     " + UpdatePrice);
        }
        public void print_name_rating()
        {
            Console.WriteLine("Film: " + name + " Rating: " + rating + "/10");
        }
        //Properties - nur GETs
        public string Name
        {
            get { return name; }
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
        //Constructors
        public Movie(string Name, decimal Rating, string Description, double Price, bool Seen)
        {

            if (Name == null || Name.Length == 0)
                throw new ArgumentException("Titel fehlt");
            name = Name;

            UpdateRating(Rating);
           // UpdateDescription(Description);
            SetPrice(Price);
            seen = false;
        }
        public Movie(string Name, double UpdatePrice) : this(Name, 0, "", UpdatePrice, false) { }
        [JsonConstructor] //fürs Wiedereinspielen vom Json-File
        public Movie(string Name, double Price, bool Seen, decimal Rating): this (Name, Rating,"",Price, Seen) { }

        //Methods
        /* Check ob Rating korrekt - setzt sobald Rating gesetzt ist seen auf TRUE
            seen kann über Rating 0 auf false gesetzt werden 
        */
        public void UpdateRating(decimal Rating)
        {
            if (Rating < 0 || Rating > 10)
            {
                throw new ArgumentException("Rating nicht in der Range!");
            }

            rating = Rating;

            if (rating > 0) SetSeen(true);
            if (rating == 0) SetSeen(false);
        }

        private void SetSeen(bool Seen)
        {
            seen = Seen;
        }

        /*Beschreibung wird geändert*/
        public void UpdateDescription(string Description)
        {
            if (Description != null || Description.Length >= 3 || Description != description)
            {
                description = Description;
            }
            else throw new ArgumentException("Beschreibung muss min. 3 Zeichen lang sein!");
        }
        /*Preis wird gesetzt +  check ob Negativ*/
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
        /*Liefert Beschreibung*/
        public string GetDescription()
        {
            return description;
        }

    }

}
