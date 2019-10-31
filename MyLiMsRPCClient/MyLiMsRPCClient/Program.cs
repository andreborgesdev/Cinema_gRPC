using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MyLiMsRPCClient
{
    class Program
    {
        private const string Address = "localhost:5001";

        private static string _token;

        static async Task Main(string[] args)
        {
            var channel = CreateAuthenticatedChannel($"https://{Address}");
            var client = new Alive.AliveClient(channel);
            var cinemaClient = new Cinema.CinemaClient(channel);

            Console.WriteLine("gRPC Ticketer");
            Console.WriteLine();
            Console.WriteLine("Press a key:");
            Console.WriteLine("1: Make a sum");
            Console.WriteLine("2: Get available movies");
            Console.WriteLine("3: Get available Tickets for movie");
            Console.WriteLine("4: Authenticate");
            Console.WriteLine("5: Exit");
            Console.WriteLine();

            var exiting = false;
            while (!exiting)
            {
                var consoleKeyInfo = Console.ReadKey(intercept: true);
                switch (consoleKeyInfo.KeyChar)
                {
                    case '1':
                        await MakeASum(client);
                        break;
                    case '2':
                        await GetAvailableMovies(cinemaClient);
                        break;
                    case '3':
                        await GetAvailableTicketsForMovie(cinemaClient);
                        break;
                    case '4':
                        _token = await Authenticate();
                        break;
                    case '5':
                        exiting = true;
                        break;
                }
            }

            Console.WriteLine("Exiting");
        }

        private static GrpcChannel CreateAuthenticatedChannel(string address)
        {
            var credentials = CallCredentials.FromInterceptor((context, metadata) =>
            {
                if (!string.IsNullOrEmpty(_token))
                {
                    metadata.Add("Authorization", $"Bearer {_token}");
                }
                return Task.CompletedTask;
            });

            // SslCredentials is used here because this channel is using TLS.
            // Channels that aren't using TLS should use ChannelCredentials.Insecure instead.
            var channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
            });
            return channel;
        }

        private static async Task<string> Authenticate()
        {
            Console.WriteLine($"Authenticating as {Environment.UserName}...");
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"https://{Address}/generateJwtToken?name={HttpUtility.UrlEncode(Environment.UserName)}"),
                Method = HttpMethod.Get,
                Version = new Version(2, 0)
            };
            var tokenResponse = await httpClient.SendAsync(request);
            tokenResponse.EnsureSuccessStatusCode();

            var token = await tokenResponse.Content.ReadAsStringAsync();
            Console.WriteLine("Successfully authenticated.");
            Console.WriteLine("You token is : Bearer " + token);
            Console.WriteLine();

            return token;
        }

        private static async Task MakeASum(Alive.AliveClient client)
        {
            Console.WriteLine();
            Console.WriteLine("Unary Call Test");
            Console.WriteLine("Write the first number");
            var number1 = Console.ReadLine();

            Console.WriteLine("Write the second number");
            var number2 = Console.ReadLine();
            Console.WriteLine();

            var aliveRequest = new SumRequest { Number1 = Convert.ToInt32(number1), Number2 = Convert.ToInt32(number2) };

            var alive = await client.SumAsync(aliveRequest);

            Console.WriteLine($"{number1} + {number2} = {alive.Message}");
        }

        private static async Task GetAvailableMovies(Cinema.CinemaClient client)
        {
            Console.WriteLine();
            Console.WriteLine("Server Call Test");
            Console.WriteLine("Getting available movies...");
            using (var call = client.GetAvailableMovies(new Empty()))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    var currentMovie = call.ResponseStream.Current;

                    Console.WriteLine();
                    Console.WriteLine($"Movie ID : {currentMovie.MovieId}");
                    Console.WriteLine($"Movie Name : {currentMovie.Name}");
                    Console.WriteLine($"Movie Genre : {currentMovie.Genre}");
                    Console.WriteLine($"Movie Duration (minutes) : {currentMovie.Duration}");
                    Console.WriteLine($"Movie Classification : {currentMovie.Classification}");
                    Console.WriteLine($"Number of Tickets For Movie : {currentMovie.NumberOfAvailableTickets}");
                }
            }
        }

        private static async Task GetAvailableTicketsForMovie(Cinema.CinemaClient client)
        {
            Console.WriteLine();
            Console.WriteLine("Choose a movieID to know how many tickets are available");
            var movieID = Console.ReadLine();
            var request = new GetAvailableTicketsForMovieRequest();
            request.MovieId = Convert.ToInt32(movieID);
            var response = await client.GetAvailableTicketsForMovieAsync(request);
            Console.WriteLine("There are " + response.AvailableTickets + " tickets available");
        }

        //private static async Task PurchaseTicket(Ticketer.TicketerClient client)
        //{
        //    Console.WriteLine("Purchasing ticket...");
        //    try
        //    {
        //        var response = await client.BuyTicketsAsync(new BuyTicketsRequest { Count = 1 });
        //        if (response.Success)
        //        {
        //            Console.WriteLine("Purchase successful.");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Purchase failed. No tickets available.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error purchasing ticket." + Environment.NewLine + ex.ToString());
        //    }
        //}

        //private static async Task GetAvailableTickets(Ticketer.TicketerClient client)
        //{
        //    Console.WriteLine("Getting available ticket count...");
        //    var response = await client.GetAvailableTicketsAsync(new Empty());
        //    Console.WriteLine("Available ticket count: " + response.Count);
        //}
    }
}
