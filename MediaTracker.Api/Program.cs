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
builder.Services.AddScoped<IMediaRepository, MediaRepository>();
builder.Services.AddScoped<IUserListItemRepository, UserListItemRepository>();
builder.Services.AddScoped<UserListItemService>();
builder.Services.AddScoped<UserListService>();
builder.Services.AddScoped<MediaService>();

builder.Services.AddControllers();
// Swagger
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
