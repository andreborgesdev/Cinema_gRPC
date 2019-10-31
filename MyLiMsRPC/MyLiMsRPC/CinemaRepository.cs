using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLiMsRPC
{
    public class CinemaRepository
    {
        private readonly ILogger<CinemaRepository> _logger;

        public CinemaRepository(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CinemaRepository>();
        }

        public List<GetAvailableMoviesResponse> ListOfMovies()
        {
            return new List<GetAvailableMoviesResponse>
            {
                new GetAvailableMoviesResponse
                {
                    MovieId = 1,
                    Name = "Avengers",
                    Genre = "Superheros",
                    Duration = 159,
                    Classification = 8.9,
                    NumberOfAvailableTickets = 8
                },
                new GetAvailableMoviesResponse
                {
                    MovieId = 2,
                    Name = "Titanic",
                    Genre = "Documentary",
                    Duration = 125,
                    Classification = 7.2,
                    NumberOfAvailableTickets = 27
                },
                new GetAvailableMoviesResponse
                {
                    MovieId = 3,
                    Name = "IT",
                    Genre = "Terror",
                    Duration = 172,
                    Classification = 6.4,
                    NumberOfAvailableTickets = 5
                }
            };
        }

        public int GetAvailableTickets(int movieId)
        {
            return ListOfMovies().First(movie => movie.MovieId == movieId).NumberOfAvailableTickets;
        }
    }
}
