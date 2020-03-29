using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Lab11_5_From_Database_To_HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            SakilaContext sakila = new SakilaContext();
            film war1917 = new film("1917", "2019 War Drama By Director Sam Mendes", "2019", 3, 5.99m, 179, 19.99m, "R");
            film joker = new film("Joker", "Oscar-Nominated SuperHero Drama", "2019", 3, 6.99m, 182, 23.99m, "R");
            film jarjarAbrams = new film("Star Wars: The Rise of SkyWalker", "Trash Disney Fanfic", "2019", 3, 4.99m, 202, 21.99m, "PG-13");

            sakila.Film.Add(war1917);  //uncomment these lines to insert the film
            sakila.Film.Add(joker);  // uncomment these lines to insert the film
            sakila.Film.Add(jarjarAbrams); //uncomment these lines to insert the film
            sakila.SaveChanges();

            //Get All Films from the Sakila DB


            film[] allfilms = sakila.Film.ToArray();
            //Film[] allfilms = (from db in sakila.Film
            //                   select new Film(db.title, db.description, db.release_year, db.rental_duration, db.rental_rate, db.length, db.replacement_cost, db.rating)).ToArray();

            //Filter to get the new 2019 films you added
            var newfilms = allfilms.Where(x => x.release_year == "2019");

            StringBuilder html = new StringBuilder();
            html.Append("<html>\n");
            html.Append("  <head>");
            html.Append("    <title>Sakila New Films</title>\n");
            html.Append("  </head>\n");
            html.Append("  <body\n");
            html.Append("    <h1> New Films Coming Soon! </h1>\n");
            html.Append("      <ul>\n");
            foreach (var film in newfilms)
            {
                html.Append("<li>");
                html.Append(film.title + " " + film.description);
                html.Append("</li>");
            }


            html.Append("      </ul>\n");
            html.Append("  </body>\n");
            html.Append("</html>\n");

            string htmlFile = "D:\\output\\newfilms.html";
            File.WriteAllText(htmlFile, html.ToString());
        }
    }
}

