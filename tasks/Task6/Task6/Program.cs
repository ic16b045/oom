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
        //Array mit Filmen(static braucht keine Instanz)
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
    
            //Listen für tasks und continue.with
            var tasks = new List<Task<string>>();
            var tasks_cwl = new List<Task<string>>();


            foreach (var z in filme)
            {
                //Starte Task; Warte 2 Sek; gib Namen zurück;
                var task = Task.Run(() =>
                {
                    Console.WriteLine($"Neuer Task für Film erstellt. Wird jetzt irgendwas damit getan: {z.Name}");
                    Task.Delay(TimeSpan.FromSeconds(2.0)).Wait();
                    Console.WriteLine($"Irgendwas ist fertig mit {z.Name}");
                    return z.Name;
                });
                //Task in Liste hinzufügen
                tasks.Add(task);
                Console.WriteLine($"Task {z.Name} hinzugefügt");
            }
         
            foreach (var t in tasks)
            {
               //gib Name aus, wenn Task fertig
                tasks_cwl.Add(
                    t.ContinueWith(cw_fertig => { Console.WriteLine($"Name is {cw_fertig.Result}"); return cw_fertig.Result; })
               );
            }

           // Console.ReadLine();
           
            foreach (var t in tasks)
            {
                //warte bis Task fertig
                t.Wait();
            }

            //Ermöglicht das manuelle Beenden während der Task läuft
            var can_tok_src = new CancellationTokenSource();
            //Berechneetwas wird gestartet + Möglichkeit zum Beenden
            var ber_task = Berechneetwas(can_tok_src.Token);

            Console.ReadLine(); 
            can_tok_src.Cancel(); //Berechneetwas stoppt
            Console.WriteLine("Berechnung beendet");

            Console.ReadLine();
        }

        public static Task<bool> Gerade_Zahl(int x, CancellationToken can_tok_src)
        {
            return Task.Run(() =>
            {
                //Ist Zahl gerade?
                for (var i = 0; i < x + 1; i++) 
                {
                    //wenn man etwas eingibt, wird die Operation beendet
                    can_tok_src.ThrowIfCancellationRequested();
                    //keine gerade Zahl
                    if (x % 2 != 0) return false; 
                }
                return true; //ansonsten - gerade Zahl
            }, can_tok_src);
        }

       //async muss für await angegeben werden
        public static async Task Berechneetwas(CancellationToken can_tok_src)
        {
            for (var i = 1; i < int.MaxValue; i++)
            {
                //wenn man etwas eingibt, wird die Operation beendet
                can_tok_src.ThrowIfCancellationRequested();
                //wartet auf Gerade_Zahl, Programm blockiert aber nicht
                if (await Gerade_Zahl(i, can_tok_src)) Console.WriteLine($"Zahl: {i}");
            }
        }
    }
    
}