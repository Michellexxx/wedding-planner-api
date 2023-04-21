using Microsoft.EntityFrameworkCore;
using wedding_planner.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddDbContext<MvcMovieContext>(options =>
// options.UseSqlite(builder.Configuration.GetConnectionString("MvcMovieContext")));
builder.Services.AddDbContext<ApiDbContext>(opt => opt.UseInMemoryDatabase("Default"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();

