This example shows how to test EF 7 MinimalAPI by using <br/>
<b>await using var application = new WebApplicationFactory<Program>();</b><br/>
<b>var client = application.CreateClient();</b><br/>
Instead of using the "real" HttpClient, we use <b>"client.PostAsJsonAsync"</b>.
</br></br>
We can also replace xxxService with <b>Fake Service</b> in testing project, and adjust <b>"application's builder.ConfigureService"</b> with <b>Dependency Injection</b> for Fake Service.

p.s. This testing project is using XUnit.

