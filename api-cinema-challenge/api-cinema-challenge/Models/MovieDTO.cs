namespace api_cinema_challenge.Models
{
    public class MovieDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public int runTimeMins { get; set; }
        public List<Screening> Screenings { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }


    }
}
