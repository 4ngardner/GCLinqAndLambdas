using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LinqSyntaxx
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>();
            AddMoviesToList(movies);

            //GetListOfCrimeMoviesWithoutLinq(movies);
            
            //GetListOfCrimeMovieWithLinq(movies);

            //SortMoviesWithoutLinq(movies);

            //SortMoviesWithLinq(movies);

            Console.WriteLine();



            Console.ReadKey();
        }

        private static void SortMoviesWithLinq(List<Movie> movies)
        {
            Console.WriteLine("Before sort");
            foreach (var movie in movies)
            {
                Console.WriteLine("Title: {0} Genre: {1} Year: {2}", movie.Title, movie.Genre, movie.Year);
            }
            Console.WriteLine();

            var sortedMovies =
                from movie in movies
                orderby movie.Year
                select movie;

            Console.WriteLine("after sort");
            foreach (var movie in sortedMovies)
            {
                Console.WriteLine("Title: {0} Genre: {1} Year: {2}", movie.Title, movie.Genre, movie.Year);
            }
        }

        private static void SortMoviesWithoutLinq(List<Movie> movies)
        {
            Console.WriteLine("Before sort");
            foreach (var movie in movies)
            {
                Console.WriteLine("Title: {0} Genre: {1} Year: {2}", movie.Title, movie.Genre, movie.Year);
            }
            Console.WriteLine();

            movies.Sort(delegate(Movie x, Movie y)
            {
                if (string.IsNullOrEmpty(x.Year) && string.IsNullOrEmpty(y.Year))
                {
                    return 0;
                }
                else if (string.IsNullOrEmpty(x.Year))
                {
                    return -1;
                }
                else if (string.IsNullOrEmpty(y.Year))
                {
                    return 1;
                }
                else
                {
                    return x.Year.CompareTo(y.Year);
                }
            });
            Console.WriteLine("After sort");
            foreach (var movie in movies)
            {
                Console.WriteLine("Title: {0} Genre: {1} Year: {2}", movie.Title, movie.Genre, movie.Year);
            }
        }

        private static void GetListOfCrimeMovieWithLinq(List<Movie> movies)
        {
            Console.WriteLine("With Linq - get a list of crime movies");

            var linqCrimeMovies =
                from movie in movies
                where movie.Genre == "Crime"
                select movie;

            foreach (var linqCrimeMovie in linqCrimeMovies)
            {
                Console.WriteLine("Title: {0} Year: {1}", linqCrimeMovie.Title, linqCrimeMovie.Year);
            }
        }

        private static void GetListOfCrimeMoviesWithoutLinq(List<Movie> movies)
        {
            Console.WriteLine("The old way - get a list of Crime movies");
            var crimeMovies = new List<Movie>();

            foreach (var movie in movies)
            {
                if (movie.Genre == "Crime")
                {
                    crimeMovies.Add(movie);
                }
            }

            foreach (var crimeMovie in crimeMovies)
            {
                Console.WriteLine("Title: {0} Year: {1}", crimeMovie.Title, crimeMovie.Year);
            }
            Console.WriteLine();
        }

        private static void AddMoviesToList(List<Movie> movies)
        {
            movies.Add(new Movie {Title = "Star Wars", Genre = "Sci Fi", Year = "1977"});
            movies.Add(new Movie {Title = "Empire Strikes Back", Genre = "Sci Fi", Year = "1980"});
            movies.Add(new Movie {Title = "Return of the Jedi", Genre = "Sci Fi", Year = "1983"});
            movies.Add(new Movie {Title = "Raiders of the Lost Ark", Genre = "Adventure", Year = "1981"});
            movies.Add(new Movie {Title = "Indiana Jones and the Temple of Doom", Genre = "Adventure", Year = "1984"});
            movies.Add(new Movie {Title = "Indiana Jones and the Last Crusade", Genre = "Adventure", Year = "1989"});
            movies.Add(new Movie {Title = "The Godfather", Genre = "Crime", Year = "1972"});
            movies.Add(new Movie {Title = "The Godfather II", Genre = "Crime", Year = "1974"});
            movies.Add(new Movie {Title = "The Godfather III", Genre = "Crime", Year = "1990"});
            movies.Add(new Movie {Title = "Superbad", Genre = "Comdey", Year = "2007"});
            movies.Add(new Movie {Title = "The Hobbit", Genre = "Fantasy", Year = "2012"});
            movies.Add(new Movie {Title = "Evil Dead", Genre = "Horror", Year = "1981"});
        }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
    }
}
