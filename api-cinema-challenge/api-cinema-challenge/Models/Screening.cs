namespace api_cinema_challenge.Models
{
    public class Screening
    {
        public int Id { get; set; }
        public int movieId { get; set; }
        public int screenNumber { get; set; }
        public int Capacity { get; set; }
        public DateTime startsAt { get; set; }
        public List<Ticket> Tickets { get; set; }
        public Movie Movie { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }


}
