using MailRemoverAPI.Interfaces;
using MailRemoverAPI.Services;
using MailRemoverAPI.Configurations;
using Microsoft.EntityFrameworkCore;
using MailRemoverAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("MailRemoverDbConnectionString");
builder.Services.AddDbContext<MailRemoverDbContext>(options =>{
    options.UseSqlServer(connectionString);
});


builder.Services.AddControllers();
builder.Services.AddScoped<IJSONFileReaderService, JSONFileReaderService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperConfig));

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
