using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Shouldly;

namespace GqlPlus.StarWars;

public class StarWarsApiTests : IClassFixture<StarWarsApiFactory>
{
  private readonly HttpClient _client;

  public StarWarsApiTests(StarWarsApiFactory factory)
  {
    factory = factory ?? throw new System.ArgumentNullException(nameof(factory));
    _client = factory.CreateClientForTests();
  }

  private sealed record Film(int Id, string Title, int Episode);

  [Fact]
  public async Task Health_endpoint_returns_healthy()
  {
    Uri uri = new("/api/health", System.UriKind.Relative);
    using HttpResponseMessage res = await _client.GetAsync(uri, TestContext.Current.CancellationToken);
    res.StatusCode.ShouldBe(HttpStatusCode.OK);

    await using Stream stream = await res.Content.ReadAsStreamAsync(TestContext.Current.CancellationToken);
    using JsonDocument doc = await JsonDocument.ParseAsync(stream, cancellationToken: TestContext.Current.CancellationToken);
    doc.RootElement.GetProperty("status").GetString().ShouldBe("healthy");
  }

  [Fact]
  public async Task Films_endpoint_returns_expected_films()
  {
    Uri uri = new("/api/starwars/films", System.UriKind.Relative);
    using HttpResponseMessage res = await _client.GetAsync(uri, TestContext.Current.CancellationToken);
    res.StatusCode.ShouldBe(HttpStatusCode.OK);

    Film[]? films = await res.Content.ReadFromJsonAsync<Film[]>(cancellationToken: TestContext.Current.CancellationToken);
    films.ShouldNotBeNull();
    films.Length.ShouldBe(2);
    films[0].Id.ShouldBe(1);
    films[0].Title.ShouldBe("A New Hope");
    films[1].Episode.ShouldBe(5);
  }
}
