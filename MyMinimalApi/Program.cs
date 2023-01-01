using MyMinimalApi;
using MiniValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPeopleService, PeopleService>();

// Add services to the container.
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

app.MapGet("/", () => "Hello World!");

app.MapPost("/people", (Person person, IPeopleService peopleService) =>
  !MiniValidator.TryValidate(person, out var errors)
  ? Results.ValidationProblem(errors)
  : Results.Ok(peopleService.Create(person))
);

app.Run();

public partial class Program { }

public interface IPeopleService
{
    string Create(Person person);
}

public class PeopleService : IPeopleService
{
    public string Create(Person person)
        => $"{person.FirstName} {person.LastName} created.";
}
