using api_cinema_challenge.Models;

namespace api_cinema_challenge.Data
{
    public static class Seeder
    {
        public async static void SeedCinemaDatabase(this WebApplication app)
        {
            using (var db = new CinemaContext())
            {

                // Ensure the database exists
                if (await db.Database.EnsureCreatedAsync())
                {
                    // Seed Movies
                    if (!db.Movies.Any())
                    {
                        db.Movies.AddRange(
                            new Movie { Id = 1, Title = "Inception", Rating = "10", Description = "A mind-bending thriller", runTimeMins = 148, createdAt = DateTime.Now, updatedAt = DateTime.Now },
                            new Movie { Id = 2, Title = "The Matrix", Rating = "8", Description = "A hacker learns the truth about his reality", runTimeMins = 136, createdAt = DateTime.Now, updatedAt = DateTime.Now }
                        );
                        await db.SaveChangesAsync();
                    }

                    // Seed Screenings
                    if (!db.Screenings.Any())
                    {
                        db.Screenings.AddRange(
                            new Screening { Id = 1, movieId = 1, screenNumber = 1, startsAt = DateTime.Now.AddHours(2), Capacity = 100, createdAt = DateTime.Now, updatedAt = DateTime.Now },
                            new Screening { Id = 2, movieId = 2, screenNumber = 2, startsAt = DateTime.Now.AddHours(3), Capacity = 120, createdAt = DateTime.Now, updatedAt = DateTime.Now }
                        );
                        await db.SaveChangesAsync();
                    }

                    // Seed Customers
                    if (!db.Customers.Any())
                    {
                        db.Customers.AddRange(
                            new Customer { Id = 1, Name = "John Doe", Email = "johndoe@example.com", Phone = "123456789", createdAt = DateTime.Now, updatedAt = DateTime.Now },
                            new Customer { Id = 2, Name = "Jane Smith", Email = "janesmith@example.com", Phone = "987654321", createdAt = DateTime.Now, updatedAt = DateTime.Now }
                        );
                        await db.SaveChangesAsync();
                    }

                    // Seed Tickets
                    if (!db.Tickets.Any())
                    {
                        db.Tickets.AddRange(
                            new Ticket { Id = 1, customerId = 1, screeningId = 1, numSeats = 2, createdAt = DateTime.Now, updatedAt = DateTime.Now },
                            new Ticket { Id = 2, customerId = 2, screeningId = 2, numSeats = 3, createdAt = DateTime.Now, updatedAt = DateTime.Now }
                        );
                        await db.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
