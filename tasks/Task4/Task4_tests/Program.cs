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
            string file_name = "test.json";
            var movie_1 = new Movie("Flashback", 10, "Einige Jugendliche müssen einen Mord verschleiern...", 10, false);
            var movie_2 = new Movie("Harry Potter und der Stein der Weisen", 10, "Harry erfährt, dass er ein Zauberer ist", 12.3,true);
            var serie_1 = new Serie("How to get away with murder", 3, 20.4);
            var movie_3 = new Movie("NCIS", 32.3);

            var mixarray = new Medien[] { movie_1, movie_2, serie_1, movie_3 };

            foreach (var med in mixarray)
            {
                med.print_name_rating();
            }

            string json_string = JsonConvert.SerializeObject(mixarray, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

            Console.WriteLine(json_string);

            File.WriteAllText(file_name, json_string);

            var json_retour_string = File.ReadAllText(file_name);
            var restoreSettings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };

            var json_array = JsonConvert.DeserializeObject<Medien[]>(json_retour_string,restoreSettings);

            Console.WriteLine("Json Restore");
            foreach (var med in json_array)
            {
                med.print_all();
            }
        
        }
    }
}