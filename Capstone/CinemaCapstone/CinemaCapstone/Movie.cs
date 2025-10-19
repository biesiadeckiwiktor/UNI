using System;
using System.Collections.Generic;
using System.Linq;

namespace Capstone
{
    /// <summary>
    /// Represents a movie in the cinema system.
    /// </summary>
    public class Movie
    {
        private string _title;
        private int _lengthInMinutes;
        private string _genre;
        private string _rating;
        private static List<Movie> _allMovies = new List<Movie>();

        /// <summary>
        /// Gets the title of the movie.
        /// </summary>
        public string Title
        {
            get { return _title; }
        }

        /// <summary>
        /// Gets the length of the movie in minutes.
        /// </summary>
        public int LengthInMinutes
        {
            get { return _lengthInMinutes; }
        }

        /// <summary>
        /// Gets the genre of the movie.
        /// </summary>
        public string Genre
        {
            get { return _genre; }
        }

     

        /// <summary>
        /// Gets the age rating of the movie (alias for Rating).
        /// </summary>
        public string AgeRating
        {
            get { return _rating; }
        }

        /// <summary>
        /// Gets all movies loaded from configuration files.
        /// </summary>
        /// <returns>A list of all loaded movies.</returns>
        public static List<Movie> GetAllMovies()
        {
            return _allMovies.ToList();
        }

        /// <summary>
        /// Gets a movie by its title.
        /// </summary>
        /// <param name="title">The title of the movie to find.</param>
        /// <returns>The movie with the specified title, or null if not found.</returns>
        public static Movie GetByTitle(string title)
        {
            return _allMovies.FirstOrDefault(m => m.Title == title);
        }

        /// <summary>
        /// Initializes a new instance of the Movie class.
        /// </summary>
        /// <param name="title">The title of the movie.</param>
        /// <param name="lengthInMinutes">The length of the movie in minutes.</param>
        /// <param name="genre">The genre of the movie.</param>
        /// <param name="rating">The age rating of the movie.</param>
        public Movie(string title, int lengthInMinutes, string genre, string rating)
        {
            _title = title;
            _lengthInMinutes = lengthInMinutes;
            _genre = genre;
            _rating = rating;
            
            // Add to the list of all movies
            _allMovies.Add(this);
        }

        /// <summary>
        /// Returns a string representation of the movie.
        /// </summary>
        public override string ToString()
        {
            return $"{_title} ({_rating}) - {_lengthInMinutes} minutes - {_genre}";
        }
    }
} 