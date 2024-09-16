using api_cinema_challenge.Models;

namespace api_cinema_challenge.Repository
{
    public interface IRepository
    {
        //Customers
        Task <List<Customer>>GetCustomers();
        Task<Customer> CreateCustomer(Customer customer);
        Task <Customer> UpdateCustomer(Customer customer, int id);
        Task <Customer>DeleteCustomer(int id);
        //Movies
        Task<List<Movie>> GetMovies();
        Task<Movie> CreateMovie(Movie movie);
        Task<Movie> UpdateMovie(Movie movie, int id);
        Task <Movie>DeleteMovie(int id);
        //Screenings
        Task <Screening>CreateScreening(Screening screening);
        Task<List<Screening>> GetScreenings();
        //Tickets
        Task<Ticket> CreateTicket(Ticket ticket);
        Task<List<Ticket>> GetTickets();

    }
}
