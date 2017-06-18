using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Threading;

namespace Task6
{

    public class Movie
    {
        //Fields
        private string name;
        private decimal rating;

        //Properties - nur GETs
        public string Name
        {
            get { return name; }
        }
        public decimal Rating
        {
            get { return rating; }
        }

        //Constructors
        public Movie(string Name, decimal Rating)
        {

            if (Name == null || Name.Length == 0)
                throw new ArgumentException("Titel fehlt");
            name = Name;

            UpdateRating(Rating);
        }

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

        }

    }

    class Program
    {
        private static Movie[] filme => new Movie[]
            {
                new Movie("Test 0", 0),
                new Movie("Test 1", 1),
                new Movie("Test 02", 0),
                new Movie("Test 3", 3),
                new Movie("Test 04", 0),
                new Movie("Test 7", 7),
            };
        static void Main(string[] args)
        {
            /*Anfang Task 6.1 */
            //Observer and Observable
            var subj = new Subject<Movie>();

            //Filtern - nur die Filme die ein Rating haben - Action filter_filme schreibt nach einer Sleep-Zeit den Namen des Films auf die Console
            subj.Where(filme => filme.Rating > 0).Subscribe(filter_filme => { Thread.Sleep(1000); Console.WriteLine(filter_filme.Name); });

            //Filme werden gepusht
            foreach (var film in filme)
            {
                subj.OnNext(film);
            }
          

          
            //subj. wird entsorgt
            subj.Dispose();
            /*ende Task 6.1*/

            /*Anfang Task 6.2*/
    
            var tasks = new List<Task<string>>();
            var tasks_cwl = new List<Task<int>>();


            foreach (var z in filme)
            {
                var task = Task.Run(() =>
                {
                    Console.WriteLine($"Neuer Task für Film erstellt. Wird jetzt irgendwas damit getan: {z.Name}");
                    Task.Delay(TimeSpan.FromSeconds(2.0));
                    Console.WriteLine($"Irgendwas ist fertig mit {z.Name}");
                    return z.Name;
                });
                tasks.Add(task);
                Console.WriteLine($"Task {z.Name} hinzugefügt");
            }
         
            foreach (var t in tasks)
            {
               
                tasks_cwl.Add(
                    t.ContinueWith(cw_fertig => { Console.WriteLine($"result is {cw_fertig.Id}"); return cw_fertig.Id; })
               );
            }
          
            foreach (var t in tasks)
            {
                t.Wait();
            }
        }
    }
}