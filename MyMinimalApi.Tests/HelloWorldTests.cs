namespace MyMinimalApi.Tests;
using Microsoft.AspNetCore.Mvc.Testing;

public class HelloWorldTests
{
    [Fact]
    public async Task Get_RootPath_ReturnHelloWorld()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var response = await client.GetStringAsync("/");

        Assert.Equal("Hello World!", response);
    }
}
