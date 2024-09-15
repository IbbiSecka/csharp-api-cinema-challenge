using api_cinema_challenge.Models;

namespace api_cinema_challenge.Repository
{
    public interface IRepository
    {
        //Customers
        Task <List<Customer>>GetCustomers();
        Task CreateCustomer(Customer customer);
        Task <Customer> Update(Customer customer);
        Task Delete(Customer customer);
        //Movies
        Task<List<Movie>> GetMovies();
        Task CreateMovie(Movie movie);
        Task<Movie> UpdateMovie(Movie movie);
        Task DeleteMovie(Movie movie);
        //Screenings
        Task<Screening> CreateScreening(Screening screening);
        Task<Screening> GetScreenings();
        //Tickets
        Task<Ticket> CreateTicket(Ticket ticket);
        Task<List<Ticket>> GetTickets();

    }
}
