﻿using System;
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
        public Movie(string Name, decimal rRting, string Description, double Price)
        {

            if (Name == null || Name.Length == 0)
                throw new ArgumentException("Titel fehlt");
            name = Name;

            UpdateRating(Rating);
            UpdateDescription(Description);
            SetPrice(Price);
            seen = false;
        }
        public Movie(string Name, double Price) : this(Name, 0, "", Price) { }

        //Methods
        public void UpdateRating(decimal Rating)
        {
            if (Rating < 0 || Rating > 10)
            {
                throw new ArgumentException("Rating nicht in der Range!");
            }

            rating = Rating;

            if (rating > 0) UpdateSeen();
        }
        private void UpdateSeen()
        {
            seen = true;
        }
        public void UpdateDescription(string Description)
        {
            if (Description != null || Description.Length == 0 || Description != description)
            {
                description = Description;
            }

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
