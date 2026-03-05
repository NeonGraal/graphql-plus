using Microsoft.AspNetCore.Mvc.Testing;

namespace GqlPlus.StarWars;

public class StarWarsApiFactory : WebApplicationFactory<Program>
{
  public HttpClient CreateClientForTests() => CreateClient();
}
