using api_cinema_challenge.Models;

namespace api_cinema_challenge.Data
{
    public static class Seeder
    {
        public async static void SeedCinemaDatabase(this WebApplication app)
        {
            using (var db = new CinemaContext())
            {

             
                    // Movies
                    if (!db.Movies.Any())
                    {
                        db.Movies.AddRange(
                            new Movie { Id = 1, Title = "Inception", Rating = "10", Description = "A mind-bending thriller", runTimeMins = 148, createdAt = DateTime.UtcNow, updatedAt = DateTime.UtcNow },
                            new Movie { Id = 2, Title = "The Matrix", Rating = "8", Description = "A hacker learns the truth about his reality", runTimeMins = 136, createdAt = DateTime.UtcNow, updatedAt = DateTime.UtcNow }
                        );
                        await db.SaveChangesAsync();
                    }

                    // Screenings
                    if (!db.Screenings.Any())
                    {
                        db.Screenings.AddRange(
                            new Screening { Id = 1, movieId = 1, screenNumber = 1, startsAt = DateTime.UtcNow.AddHours(2), Capacity = 100, createdAt = DateTime.UtcNow, updatedAt = DateTime.UtcNow },
                            new Screening { Id = 2, movieId = 2, screenNumber = 2, startsAt = DateTime.UtcNow.AddHours(3), Capacity = 120, createdAt = DateTime.UtcNow, updatedAt = DateTime.UtcNow }
                        );
                        await db.SaveChangesAsync();
                    }

                    // Customers
                    if (!db.Customers.Any())
                    {
                        db.Customers.AddRange(
                            new Customer { Id = 1, Name = "Ibbi Secka", Email = "123456@123.com", Phone = "123456789", createdAt = DateTime.UtcNow, updatedAt = DateTime.UtcNow },
                            new Customer { Id = 2, Name = "Lionel Messi", Email = "ibbi@ibbi.com", Phone = "987654321", createdAt = DateTime.UtcNow, updatedAt = DateTime.UtcNow }
                        );
                        await db.SaveChangesAsync();
                    }

                    // Tickets
                    if (!db.Tickets.Any())
                    {
                        db.Tickets.AddRange(
                            new Ticket { Id = 1, customerId = 1, screeningId = 1, numSeats = 2, createdAt = DateTime.UtcNow, updatedAt = DateTime.UtcNow },
                            new Ticket { Id = 2, customerId = 2, screeningId = 2, numSeats = 3, createdAt = DateTime.UtcNow, updatedAt = DateTime.UtcNow }
                        );
                        await db.SaveChangesAsync();
                    }
                
            }
        }
    }
}
