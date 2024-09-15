namespace api_cinema_challenge.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int customerId { get; set; }
        public int screeningId { get; set; }
        public int numSeats { get; set; }
        public Screening Screening { get; set; }
        public Customer Customer { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
