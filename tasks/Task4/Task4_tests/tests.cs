using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4_tests
{
    [TestFixture]
    class tests
    {
        [Test]
        public void Serie_Season_Test()
        {
            var testserie = new Serie("Hallo",1,10);
            Assert.IsTrue(testserie.Season != 0);
        }
        [Test]
        public void Movie_Rating_Test()
        {
            var testmovie = new Movie("hallo",1.3);
            
            
            Assert.IsTrue(testmovie.Rating == 0);
        }
        [Test]
        public void Serie_Description_Test()
        {
            var testserie = new Serie("Hallo",0, 10);
            Assert.IsTrue(testserie.Description == "");
          
        
        }

        [Test]
        public void Movie_Rating_Update_Test()
        {
            var testmovie = new Movie("Hallo",1.3);

            testmovie.UpdateRating(10);

            Assert.IsTrue(testmovie.Rating <= 10 && testmovie.Rating > 0);
        }
        [Test]
        public void Serie_Rating_Update_Test()
        {
            var testserie = new Serie("Hallo", 10,20.4);
            testserie.UpdateRating(9);
            Assert.IsTrue(testserie.Rating <= 10 && testserie.Rating > 0);
        }
        [Test]
        public void Seen_Check_Test()
        {
            var testmovie = new Movie("hallo",1.3);
            var testserie = new Serie("Hallo",0,10);
            testmovie.UpdateRating(9);
            testserie.UpdateRating(8);
            Assert.IsTrue(testmovie.Seen == true && testserie.Seen == true);
        }
        [Test]
        public void Price_Check_Test()
        {
            var movie = new Movie("hallo", 3.2);
            Assert.IsTrue(movie.UpdatePrice == 3.2);
        }
        [Test]
        public void Movie_Bill_Test()
        {
            var movie_1 = new Movie("hallo", 2.5);
            var movie_2 = new Movie("hallo2", 1.5);
            var bill = new[] { movie_1, movie_2 };
            double erg = 0;
            foreach (var mov in bill)
            {
                erg = erg + mov.UpdatePrice;
            }

            Assert.IsTrue(erg == 4);
        }
    }
}


