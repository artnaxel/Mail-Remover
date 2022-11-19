using MailRemoverAPI.Interfaces;
using MailRemoverAPI.Services;
using MailRemoverAPI.Configurations;
using Microsoft.EntityFrameworkCore;
using MailRemoverAPI.Data;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("MailRemoverDbConnectionString");
builder.Services.AddDbContext<MailRemoverDbContext>(options =>{
    options.UseSqlServer(connectionString);
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


builder.Services.AddControllers();
builder.Services.AddScoped<IJSONFileReaderService, JSONFileReaderService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();

public partial class Program { }
