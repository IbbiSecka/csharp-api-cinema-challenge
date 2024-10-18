using api_cinema_challenge.Data;
using api_cinema_challenge.Endpoints;
using api_cinema_challenge.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CinemaContext>();
builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowS3Bucket", policy =>
    {
        policy.WithOrigins("http://ibbibucket.s3-website.eu-north-1.amazonaws.com/")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
app.UseCors("AllowS3Bucket");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureCinemaEndpoint();
app.SeedCinemaDatabase();
app.Run();
