using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MyMinimalApi.Tests
{
    public class TestingApplication : WebApplicationFactory<Person>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IPeopleService, TestPeopleService>();
            });
            return base.CreateHost(builder);
        }
    }
}

