using api_cinema_challenge.Data;
using api_cinema_challenge.Models;
using Microsoft.EntityFrameworkCore;


namespace api_cinema_challenge.Repository
{
    public class Repository : IRepository
    {
      private CinemaContext _context;
        private DbSet<Customer> _customer;

        public Repository(CinemaContext context)
        {
            _context = context;
            _customer = context.Set<Customer>();
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            await _context.AddAsync(customer);
            return customer;

        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            await _context.AddAsync(movie);
            return movie;
        }

        public async Task<Screening> CreateScreening(Screening screening)
        {
            await _context.AddAsync(screening);
            return screening;
        }

        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            await _context.AddAsync(ticket);
            return ticket;
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var target = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            _context.Customers.Remove(target);
            return target;
        }

        public async Task<Movie> DeleteMovie(int id)
        {
            var target = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            _context.Movies.Remove(target);
            return target;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _customer.ToListAsync();
        }

        public async Task<List<Movie>> GetMovies()
        {

            return await _context.Movies.ToListAsync();
        }

        public async Task<List<Screening>> GetScreenings()
        {
            return await _context.Screenings.ToListAsync();
        }

        public async Task<List<Ticket>> GetTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Customer> UpdateCustomer(Customer updatedCustomer, int id)
        {
            var customer1 = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            customer1.Email = updatedCustomer.Email;
            customer1.Phone = updatedCustomer.Phone;
            customer1.Name = updatedCustomer.Name;
            customer1.createdAt = updatedCustomer.createdAt;
            customer1.updatedAt = updatedCustomer.updatedAt;
            return customer1;

        }

        public async Task<Movie> UpdateMovie(Movie Updatedmovie, int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            movie.Title = Updatedmovie.Title;
            movie.Description = Updatedmovie.Description;
            movie.Rating = Updatedmovie.Rating;
            movie.runTimeMins = Updatedmovie.runTimeMins;
            return movie;
        }
    }
}
