using api_cinema_challenge.Models;

namespace api_cinema_challenge.Repository
{
    public class Repository : IRepository
    {
        public Task CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<Screening> CreateScreening(Screening screening)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> CreateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetMovies()
        {
            throw new NotImplementedException();
        }

        public Task<Screening> GetScreenings()
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetTickets()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
