using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;


namespace Task4_tests
{


    class Program
    {
        static void Main(string[] args)
        {
            string c_file_name = "test.json";
            var movie_1 = new Movie("Flashback", 10, "Einige Jugendliche müssen einen Mord verschleiern...", 10);
            var movie_2 = new Movie("Harry Potter und der Stein der Weisen", 10, "Harry erfährt, dass er ein Zauberer ist", 12.3);
            var serie_1 = new Serie("How to get away with murder", 3, 20.4);


            var mixarray = new Medien[] { movie_1, movie_2, serie_1 };
            var mixarray_movie = new[] { movie_1, movie_2 };
            var mixarray_serie = new[] { serie_1 };

            foreach (var med in mixarray)
            {
                med.print_name_rating();
            }

            foreach (var mov in mixarray_movie)
            {
                mov.UpdateRating(10);
                mov.print_all();
                Console.WriteLine();
            }

            foreach (var ser in mixarray_serie)
            {
                ser.UpdateRating(9);
                ser.print_all();
                Console.WriteLine();
            }

            string json_string = JsonConvert.SerializeObject(mixarray_movie, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

            Console.WriteLine(json_string);

            File.WriteAllText(c_file_name, json_string);

            var json_retour_string = File.ReadAllText(c_file_name);
            var restoreSettings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };

            var json_array = JsonConvert.DeserializeObject<Movie[]>(json_retour_string,restoreSettings);
        
        }
    }
}