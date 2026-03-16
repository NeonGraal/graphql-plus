using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing;

public class AllParsersTests
{
  [Fact]
  public void AllParsers_Repository_IsRegistered()
    => Services
    .GetService<IParserRepository>()
    .ShouldNotBeNull();

  [Fact]
  public void AllParsers_ParserForConstant_IsRegistered()
    => Services
    .GetRequiredService<IParserRepository>()
    .ParserFor<IGqlpConstant>()
    .ShouldNotBeNull();

  [Fact]
  public void AllParsers_ArrayForModifier_IsRegistered()
    => Services
    .GetRequiredService<IParserRepository>()
    .ArrayFor<IGqlpModifier>()
    .ShouldNotBeNull();

  [Fact]
  public void AllParsers_ParserForDefault_IsRegistered()
    => Services
    .GetRequiredService<IParserRepository>()
    .ParserFor<IParserDefault, IGqlpConstant>()
    .ShouldNotBeNull();

  [Fact]
  public void AllParsers_ArrayForCollections_IsRegistered()
    => Services
    .GetRequiredService<IParserRepository>()
    .ArrayFor<IParserCollections, IGqlpModifier>()
    .ShouldNotBeNull();

  [Fact]
  public void AllParsers_SinglesFactories_ReturnNotNull()
  {
    IParserRepository repo = Services.GetRequiredService<IParserRepository>();
    ParserRepositoryBuilder builder = Services.GetRequiredService<ParserRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.Singles.Values.Select(CheckParser)]);
  }

  [Fact]
  public void AllParsers_ArraysFactories_ReturnNotNull()
  {
    IParserRepository repo = Services.GetRequiredService<IParserRepository>();
    ParserRepositoryBuilder builder = Services.GetRequiredService<ParserRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.Arrays.Values.Select(CheckParser)]);
  }

  [Fact]
  public void AllParsers_InterfaceSinglesFactories_ReturnNotNull()
  {
    IParserRepository repo = Services.GetRequiredService<IParserRepository>();
    ParserRepositoryBuilder builder = Services.GetRequiredService<ParserRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.InterfaceSingles.Values.Select(CheckParser)]);
  }

  [Fact]
  public void AllParsers_InterfaceArraysFactories_ReturnNotNull()
  {
    IParserRepository repo = Services.GetRequiredService<IParserRepository>();
    ParserRepositoryBuilder builder = Services.GetRequiredService<ParserRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.InterfaceArrays.Values.Select(CheckParser)]);
  }

  [Fact]
  public void AllParsers_DeclarationsFactories_ReturnNotNull()
  {
    IParserRepository repo = Services.GetRequiredService<IParserRepository>();
    ParserRepositoryBuilder builder = Services.GetRequiredService<ParserRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.Declarations.Values.Select(CheckParser)]);
  }

  private static Action<IParserRepository> CheckParser(Factory<object, IParserRepository> factory)
    => r => factory(r)
        .ShouldNotBeNull($"Parser for {factory.GetType().ExpandTypeName()} should not be null");

  protected IServiceProvider Services { get; } = new ServiceCollection()
      .AddLogging()
      .AddParsers(b => b
        .AddCommonParsers()
        .AddSchemaParsers()
        .AddOperationParsers()
      )
      .BuildServiceProvider();
}
