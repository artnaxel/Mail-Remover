using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Feedback.DB;
using Feedback.Repositories;
using M = Feedback.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FeedbackDbContext>(
    opt => opt
        .UseInMemoryDatabase("FeedbackDB")
        .EnableSensitiveDataLogging()
);
builder.Services.AddScoped<IEntityRepository<M.Feedback>, FeedbackRepository>();
builder.Services.AddScoped<IEntityRepository<M.Admin>, AdminRepository>();
builder.Services.AddControllers();

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
