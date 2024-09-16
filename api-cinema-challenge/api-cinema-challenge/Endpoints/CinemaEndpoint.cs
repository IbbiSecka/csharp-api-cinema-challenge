using api_cinema_challenge.Models;
using api_cinema_challenge.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api_cinema_challenge.Endpoints
{
    public static class CinemaEndpoint
    {
        public static void ConfigureCinemaEndpoint(this WebApplication app)
        {
            var cinemaApi = app.MapGroup("cinema");

            cinemaApi.MapGet("/customers", GetCustomers);
            cinemaApi.MapPost("/customers", CreateCustomer);
            cinemaApi.MapPut("/customers/{id}", UpdateCustomer);
            cinemaApi.MapDelete("/customers/{id}", DeleteCustomer);

            cinemaApi.MapGet("/movies", GetMovies);
            cinemaApi.MapPost("/movies", CreateMovie);
            cinemaApi.MapPut("/movies/{id}", UpdateMovie);
            cinemaApi.MapDelete("/movies/{id}", DeleteMovie);

            cinemaApi.MapGet("movies/{id}/screenings", GetScreenings);
            cinemaApi.MapPost("movies/{id}/screenings", CreateScreening);

            cinemaApi.MapGet("/customers/{customerId}/screenings/{screeningId}", GetTickets);
            cinemaApi.MapPost("/customers/{customerId}/screenings/{screeningId}", CreateTicket);
        }

        //Customer Endpoints

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(IRepository repository)
        {
            try
            {
                var customers = await repository.GetCustomers();
                var results = new List<CustomerDTO>();

                foreach (var customer in customers)
                {
                    CustomerDTO customerDTO = new CustomerDTO();
                    customerDTO.Name = customer.Name;
                    customerDTO.Email = customer.Email;
                    customerDTO.Phone = customer.Phone;
                    customerDTO.updatedAt = DateTime.UtcNow;
                    customerDTO.createdAt = DateTime.UtcNow;

                    results.Add(customerDTO);
                }

                return TypedResults.Ok(new { status = "success", data = results });
            }
            catch (Exception)
            {
                return TypedResults.Problem("Error getting customers");
            }
        }



        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCustomer(IRepository repository, CustomerDTO customerDTO)
        {
            try
            {
                var customer = new Customer
                {
                    Name = customerDTO.Name,
                    Email = customerDTO.Email,
                    Phone = customerDTO.Phone,
                    createdAt = DateTime.UtcNow,
                    updatedAt = DateTime.UtcNow
                };

                var createdCustomer = await repository.CreateCustomer(customer);
                return TypedResults.Ok( new { status = "success", data = createdCustomer });
            }
            catch (Exception)
            {
                return TypedResults.BadRequest("Customer creation failed");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateCustomer(IRepository repository, CustomerDTO customerDTO, int id)
        {
            try
            {
                var updatedCustomer = await repository.UpdateCustomer(new Customer
                {
                    Name = customerDTO.Name,
                    Email = customerDTO.Email,
                    Phone = customerDTO.Phone,
                    createdAt = customerDTO.createdAt,
                    updatedAt = DateTime.UtcNow
                }, id);

                if (updatedCustomer == null) return TypedResults.NotFound("Customer not found");

                return TypedResults.Ok(new { status = "success", data = updatedCustomer });
            }
            catch (Exception)
            {
                return TypedResults.Problem("Error updating customer");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCustomer(IRepository repository, int id)
        {
            try
            {
                var deletedCustomer = await repository.DeleteCustomer(id);
                if (deletedCustomer == null) return TypedResults.NotFound("Customer not found");

                return TypedResults.Ok(new { status = "success", data = deletedCustomer });
            }
            catch (Exception)
            {
                return TypedResults.Problem("Error deleting customer");
            }
        }

        //Movie Endpoints

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetMovies(IRepository repository)
        {
            try
            {
                var movies = await repository.GetMovies();
                var results = new List<MovieDTO>();

                foreach (var movie in movies)
                {
                    MovieDTO movieDTO = new MovieDTO();
                    movieDTO.Title = movie.Title;
                    movieDTO.Rating = movie.Rating;
                    movieDTO.Description = movie.Description;
                    movieDTO.runTimeMins = movie.runTimeMins;
                    movieDTO.createdAt = movie.createdAt;
                    movieDTO.updatedAt = movie.updatedAt;


                    results.Add(movieDTO);
                }

                return TypedResults.Ok(new { status = "success", data = results });
            }
            catch (Exception)
            {
                return TypedResults.Problem("Error getting customers");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateMovie(IRepository repository, MovieDTO movieDTO)
        {
            try
            {
                var movie = new Movie
                {
                    Title = movieDTO.Title,
                    Description = movieDTO.Description,
                    Rating = movieDTO.Rating,
                    runTimeMins = movieDTO.runTimeMins
                };

                var createdMovie = await repository.CreateMovie(movie);
                return TypedResults.Ok( new { status = "success", data = createdMovie });
            }
            catch (Exception)
            {
                return TypedResults.BadRequest("Movie creation failed");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateMovie(IRepository repository, MovieDTO movieDTO, int id)
        {
            try
            {
                var updatedMovie = await repository.UpdateMovie(new Movie
                {
                    Title = movieDTO.Title,
                    Description = movieDTO.Description,
                    Rating = movieDTO.Rating,
                    runTimeMins = movieDTO.runTimeMins
                }, id);

                if (updatedMovie == null) return TypedResults.NotFound("Movie not found");

                return TypedResults.Ok(new { status = "success", data = updatedMovie });
            }
            catch (Exception)
            {
                return TypedResults.Problem("Error updating movie");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteMovie(IRepository repository, int id)
        {
            try
            {
                var deletedMovie = await repository.DeleteMovie(id);
                if (deletedMovie == null) return TypedResults.NotFound("Movie not found");

                return TypedResults.Ok(new { status = "success", data = deletedMovie });
            }
            catch (Exception)
            {
                return TypedResults.Problem("Error deleting movie");
            }
        }
        //Screening endpoints
        [ProducesResponseType(StatusCodes.Status201Created)]

        public static async Task<IResult> CreateScreening(IRepository repository, ScreeningDTO screeningDTO)
        {
            try
            {
                var screening = new Screening
                {
                    
                    Capacity = screeningDTO.Capacity,
                    screenNumber = screeningDTO.screenNumber,
                    startsAt = screeningDTO.startsAt,
                    createdAt = DateTime.UtcNow,
                    updatedAt = DateTime.UtcNow
                };

                var updatedScreening = await repository.CreateScreening(screening);
                return TypedResults.Ok(new { status = "success", Data = screening });
            }
            catch (Exception)
            {

                return TypedResults.Problem("Error deleting movie");
            }
        }
            [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> GetScreenings(IRepository repository)
        {
            try
            {
                var screenings = await repository.GetScreenings();
                var results = new List<ScreeningDTO>();
                if (screenings == null) return TypedResults.NotFound();

                foreach (var screen in screenings)
                {
                    ScreeningDTO screeningDTO = new ScreeningDTO();
                    screeningDTO.screenNumber = screen.screenNumber;
                    screeningDTO.Capacity = screen.Capacity;
                    screeningDTO.createdAt = screen.createdAt;
                    screeningDTO.updatedAt = screen.updatedAt;
                    results.Add(screeningDTO);
                }
                return TypedResults.Ok(new { status = "success", data = results });
            }
            catch (Exception)
            {
                return TypedResults.Problem("Error getting customers");
            }
        }
        //Tickets endpoints

        [ProducesResponseType(StatusCodes.Status201Created)]

        public static async Task<IResult> CreateTicket(IRepository repository, TicketDTO ticketDTO)
        {
            try
            {
                var ticket = new Ticket
                {
                    numSeats = ticketDTO.numSeats,
                    createdAt = DateTime.UtcNow,
                    updatedAt = DateTime.UtcNow

                };
                await repository.CreateTicket(ticket);
                return TypedResults.Ok(new {status = "success", data = ticket });    
            }
            catch (Exception)
            {

                return TypedResults.Problem("Error getting customers") ;
            }
        }


            [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> GetTickets(IRepository repository)
        {
            try
            {

                var tickets = await repository.GetTickets();
                var results = new List<TicketDTO>();

                foreach (var tick in tickets)
                {
                    var ticketDTO = new TicketDTO();
                    ticketDTO.numSeats = tick.numSeats;
                    ticketDTO.createdAt = tick.createdAt;
                    ticketDTO.updatedAt = tick.updatedAt;
                    results.Add(ticketDTO);
                }
                return TypedResults.Ok(new { status = "success", data = results });
            }
            catch (Exception)
            {
                return TypedResults.Problem("Error getting customers");
            }
        }



    }
}
