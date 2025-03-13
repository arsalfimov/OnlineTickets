using OnlineTickets.Models;

namespace OnlineTickets.Data;

public class AppDbInitialize
{
	public static void Seed(IApplicationBuilder applicationBuilder)
	{
		using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();

		var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

		context.Database.EnsureCreated();

		//Cinema
		if (!context.Cinemas.Any())
		{
			context.Cinemas.AddRange(new List<Cinema>()
			{
				new Cinema()
				{
					Name = "Cinema 1",
					Logo = "https://img.icons8.com/?size=100&id=64580&format=png&color=000000",
					Description = "This is the description of the first cinema"
				},
				new Cinema()
				{
					Name = "Cinema 2",
					Logo = "https://img.icons8.com/?size=100&id=19870&format=png&color=000000",
					Description = "This is the description of the second cinema"
				},
				new Cinema()
				{
					Name = "Cinema 3",
					Logo = "https://img.icons8.com/?size=100&id=6Ujtt7adsfSb&format=png&color=000000",
					Description = "This is the description of the third cinema"
				},
				new Cinema()
				{
					Name = "Cinema 4",
					Logo = "https://img.icons8.com/?size=100&id=98995&format=png&color=000000",
					Description = "This is the description of the fourth cinema"
				},
				new Cinema()
				{
					Name = "Cinema 5",
					Logo = "https://img.icons8.com/?size=100&id=105888&format=png&color=000000",
					Description = "This is the description of the fifth cinema"
				},
			});
			context.SaveChanges();
		}

		//Actors
		if (!context.Actors.Any())
		{
			context.Actors.AddRange(new List<Actor>()
			{
				new Actor()
				{
					FullName = "Actor 1",
					Bio = "This is the Bio of the first actor",
					ProfilePicture = "https://img.icons8.com/color/48/actor.png"

				},
				new Actor()
				{
					FullName = "Actor 2",
					Bio = "This is the Bio of the second actor",
					ProfilePicture = "https://img.icons8.com/color/48/actor.png"
				},
				new Actor()
				{
					FullName = "Actor 3",
					Bio = "This is the Bio of the third actor",
					ProfilePicture = "https://img.icons8.com/color/48/actor.png"
				},
				new Actor()
				{
					FullName = "Actor 4",
					Bio = "This is the Bio of the fourth actor",
					ProfilePicture = "https://img.icons8.com/color/48/actor.png"
				},
				new Actor()
				{
					FullName = "Actor 5",
					Bio = "This is the Bio of the fifth actor",
					ProfilePicture = "https://img.icons8.com/color/48/actor.png"
				}
			});
			context.SaveChanges();
		}

		//Producers
		if (!context.Producers.Any())
		{
			context.Producers.AddRange(new List<Producer>()
			{
				new Producer()
				{
					FullName = "Producer 1",
					Bio = "This is the Bio of the first actor",
					ProfilePicture = "https://img.icons8.com/color/48/hayao-miyazaki.png"

				},
				new Producer()
				{
					FullName = "Producer 2",
					Bio = "This is the Bio of the second actor",
					ProfilePicture = "https://img.icons8.com/color/48/hayao-miyazaki.png"
				},
				new Producer()
				{
					FullName = "Producer 3",
					Bio = "This is the Bio of the third actor",
					ProfilePicture = "https://img.icons8.com/color/48/hayao-miyazaki.png"
				},
				new Producer()
				{
					FullName = "Producer 4",
					Bio = "This is the Bio of the fourth actor",
					ProfilePicture = "https://img.icons8.com/color/48/hayao-miyazaki.png"
				},
				new Producer()
				{
					FullName = "Producer 5",
					Bio = "This is the Bio of the fifth actor",
					ProfilePicture = "https://img.icons8.com/color/48/hayao-miyazaki.png"
				}
			});
			context.SaveChanges();
		}

		//Movies
		if (!context.Movies.Any())
		{
			context.Movies.AddRange(new List<Movie>()
			{
				new Movie()
				{
					Name = "Movie1",
					Description = "This is the Movie1 description",
					Price = 39.50,
					ImageURL = "wwwroot/icons/M3.svg",
					StartDate = DateTime.Now.AddDays(-10),
					EndDate = DateTime.Now.AddDays(10),
					CinemaId = 3,
					ProducerId = 3,
					MovieCategory = MovieCategory.Documentary
				},
				new Movie()
				{
					Name = "Movie2",
					Description = "This is the Movie2 description",
					Price = 29.50,
					ImageURL = "wwwroot/icons/M2.svg",
					StartDate = DateTime.Now,
					EndDate = DateTime.Now.AddDays(3),
					CinemaId = 1,
					ProducerId = 1,
					MovieCategory = MovieCategory.Action
				},
				new Movie()
				{
					Name = "Movie3",
					Description = "This is the Movie3 description",
					Price = 39.50,
					ImageURL = "wwwroot/icons/M1.svg",
					StartDate = DateTime.Now,
					EndDate = DateTime.Now.AddDays(7),
					CinemaId = 4,
					ProducerId = 4,
					MovieCategory = MovieCategory.Horror
				},
				new Movie()
				{
					Name = "Movie4",
					Description = "This is the Movie4 description",
					Price = 39.50,
					ImageURL = "wwwroot/icons/M4.svg",
					StartDate = DateTime.Now.AddDays(-10),
					EndDate = DateTime.Now.AddDays(-5),
					CinemaId = 1,
					ProducerId = 2,
					MovieCategory = MovieCategory.Documentary
				},
				new Movie()
				{
					Name = "Movie5",
					Description = "This is the Movie5 description",
					Price = 39.50,
					ImageURL = "wwwroot/icons/M2.svg",
					StartDate = DateTime.Now.AddDays(-10),
					EndDate = DateTime.Now.AddDays(-2),
					CinemaId = 1,
					ProducerId = 3,
					MovieCategory = MovieCategory.Cartoon
				},
				new Movie()
				{
					Name = "Movie6",
					Description = "This is the Movie6 description",
					Price = 39.50,
					ImageURL = "wwwroot/icons/M4.svg",
					StartDate = DateTime.Now.AddDays(3),
					EndDate = DateTime.Now.AddDays(20),
					CinemaId = 1,
					ProducerId = 5,
					MovieCategory = MovieCategory.Drama
				}
			});
			context.SaveChanges();
		}

		//Actor & Movies
		if (!context.ActorsMovies.Any())
		{
			context.ActorsMovies.AddRange(new List<ActorMovie>()
			{
				new ActorMovie()
				{
					ActorId = 1,
					MovieId = 1
				},
				new ActorMovie()
				{
					ActorId = 3,
					MovieId = 1
				},

				new ActorMovie()
				{
					ActorId = 1,
					MovieId = 2
				},
				new ActorMovie()
				{
					ActorId = 4,
					MovieId = 2
				},

				new ActorMovie()
				{
					ActorId = 1,
					MovieId = 3
				},
				new ActorMovie()
				{
					ActorId = 2,
					MovieId = 3
				},
				new ActorMovie()
				{
					ActorId = 5,
					MovieId = 3
				},


				new ActorMovie()
				{
					ActorId = 2,
					MovieId = 4
				},
				new ActorMovie()
				{
					ActorId = 3,
					MovieId = 4
				},
				new ActorMovie()
				{
					ActorId = 4,
					MovieId = 4
				},


				new ActorMovie()
				{
					ActorId = 2,
					MovieId = 5
				},
				new ActorMovie()
				{
					ActorId = 3,
					MovieId = 5
				},
				new ActorMovie()
				{
					ActorId = 4,
					MovieId = 5
				},
				new ActorMovie()
				{
					ActorId = 5,
					MovieId = 5
				},


				new ActorMovie()
				{
					ActorId = 3,
					MovieId = 6
				},
				new ActorMovie()
				{
					ActorId = 4,
					MovieId = 6
				},
				new ActorMovie()
				{
					ActorId = 5,
					MovieId = 6
				},
			});
			context.SaveChanges();
		}
	}
}