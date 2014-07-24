using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>();
            AddMoviesToList(movies);

//            GetAListOfCrimeMoviesUsingFluentLinq(movies);

//            SortMoviesByYearUsingFluentLinq(movies);

            Console.ReadKey();
        }

        private static void SortMoviesByYearUsingFluentLinq(List<Movie> movies)
        {
            Console.WriteLine("Getting an ordered list of movies...");

            var orderedList = movies.OrderBy(movie => movie.Year).ThenBy(movie => movie.Title);

            foreach (var movie in orderedList)
            {
                Console.WriteLine("Title: {0} Genre: {1} Year: {2}", movie.Title, movie.Genre, movie.Year);
            }
        }

        private static void GetAListOfCrimeMoviesUsingFluentLinq(List<Movie> movies)
        {
            Console.WriteLine("Getting a list of Crime movies...");

            var crimeMovies = movies.Where(movie => movie.Genre == "Crime");

            foreach (var movie in crimeMovies)
            {
                Console.WriteLine("Title: {0} Genre: {1} Year: {2}", movie.Title, movie.Genre, movie.Year);
            }
        }

        private static void AddMoviesToList(List<Movie> movies)
        {
            movies.Add(new Movie { Title = "Star Wars", Genre = "Sci Fi", Year = "1977" });
            movies.Add(new Movie { Title = "Empire Strikes Back", Genre = "Sci Fi", Year = "1980" });
            movies.Add(new Movie { Title = "Return of the Jedi", Genre = "Sci Fi", Year = "1983" });
            movies.Add(new Movie { Title = "Raiders of the Lost Ark", Genre = "Adventure", Year = "1981" });
            movies.Add(new Movie { Title = "Indiana Jones and the Temple of Doom", Genre = "Adventure", Year = "1984" });
            movies.Add(new Movie { Title = "Indiana Jones and the Last Crusade", Genre = "Adventure", Year = "1989" });
            movies.Add(new Movie { Title = "The Godfather", Genre = "Crime", Year = "1972" });
            movies.Add(new Movie { Title = "The Godfather II", Genre = "Crime", Year = "1974" });
            movies.Add(new Movie { Title = "The Godfather III", Genre = "Crime", Year = "1990" });
            movies.Add(new Movie { Title = "Superbad", Genre = "Comdey", Year = "2007" });
            movies.Add(new Movie { Title = "The Hobbit", Genre = "Fantasy", Year = "2012" });
            movies.Add(new Movie { Title = "Evil Dead", Genre = "Horror", Year = "1981" });
        }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
    }
}
