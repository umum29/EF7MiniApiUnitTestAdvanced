using System;
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
namespace MyMinimalApi.Tests
{
	public class PeopleTests
	{
        [Fact]
        public async Task Post_CreatePerson_Successful()
        {
            await using var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();

            var result = await client.PostAsJsonAsync("/people", new Person
            {
                FirstName = "Kai",
                LastName = "Chen",
                Email = "test@gmail.com",
            });

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("\"Kai Chen created.\"", await result.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task Post_CreatePerson_ValidatesObject_ErrorMessage()
        {
            await using var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            var result = await client.PostAsJsonAsync("/people", new Person());

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            var validationResult = await result.Content.ReadFromJsonAsync<HttpValidationProblemDetails>();
            Assert.NotNull(validationResult);
            Assert.Equal("The FirstName field is required.",
                        validationResult!.Errors["FirstName"][0]);
        }

        //for replacing "CRUD" function of PeopeService with "TestPeopleSerivce"(dummy)
        [Fact]
        public async Task Post_CreatePerson_WithTestPeopleService_Successful()
        {
            await using var application = new WebApplicationFactory<Program>()
       .WithWebHostBuilder(builder => builder
           .ConfigureServices(services =>
           {
               services.AddScoped<IPeopleService, TestPeopleService>();
           }));
            var client = application.CreateClient();

            var result = await client.PostAsJsonAsync("/people", new Person
            {
                FirstName = "Kai",
                LastName = "Chen",
                Email = "test@gmail.com",
            });

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("\"It works!\"", await result.Content.ReadAsStringAsync());
        }

        //for replacing "CRUD" function of PeopeService with "TestPeopleSerivce"(dummy)
        [Fact]
        public async Task Post_CreatePerson_WithTestPeopleServiceInApplication_Successful()
        {
            await using var application = new TestingApplication();
            var client = application.CreateClient();

            var result = await client.PostAsJsonAsync("/people", new Person
            {
                FirstName = "Kai",
                LastName = "Chen",
                Email = "test@gmail.com",
            });

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("\"It works!\"", await result.Content.ReadAsStringAsync());
        }
    }
}

