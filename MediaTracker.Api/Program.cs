using MediaTracker.Infrastructure.Persistence;
using MediaTracker.Infrastructure.Repositories;
using MediaTracker.Domain.Repositories;
using MediaTracker.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MediaTrackerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserListRepository, UserListRepository>();
builder.Services.AddScoped<IMediaEntryRepository, MediaEntryRepository>();
builder.Services.AddScoped<UserListService>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
