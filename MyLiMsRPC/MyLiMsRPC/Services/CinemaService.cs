using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLiMsRPC.Services
{
    public class CinemaService : Cinema.CinemaBase
    {
        private readonly ILogger<CinemaService> _logger;
        private readonly CinemaRepository _cinemaRepository;

        public CinemaService(ILogger<CinemaService> logger, CinemaRepository cinemaRepository)
        {
            _logger = logger;
            _cinemaRepository = cinemaRepository;
        }

        public override async Task GetAvailableMovies(Empty request, IServerStreamWriter<GetAvailableMoviesResponse> responseStream, ServerCallContext context)
        {
            Console.WriteLine("LISTTTTT OF MOVIEEEEES - " + _cinemaRepository.ListOfMovies());
            foreach (var movie in _cinemaRepository.ListOfMovies())
            {
                Console.WriteLine("MOVIEEEEEEEEEEEEE - " + movie);
                //await Task.Delay(1000);
                await responseStream.WriteAsync(movie);
            }
        }

        public override Task<GetAvailableTicketsForMovieResponse> GetAvailableTicketsForMovie(GetAvailableTicketsForMovieRequest request, ServerCallContext context)
        {
            GetAvailableTicketsForMovieResponse reponse = new GetAvailableTicketsForMovieResponse();
            reponse.AvailableTickets = _cinemaRepository.GetAvailableTickets(request.MovieId);
            return Task.FromResult(reponse);
        }
    }
}
