using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing;

public class CommonParsersTests
{
  private readonly IServiceProvider _services;

  public CommonParsersTests()
    => _services = new ServiceCollection()
      .AddLogging()
      .AddParserBase()
      .AddParsers(b => b.AddCommonParsers())
      .BuildServiceProvider();

  [Fact]
  public void CommonParsers_Repository_IsRegistered()
    => _services
    .GetService<IParserRepository>()
    .ShouldNotBeNull();

  [Fact]
  public void CommonParsers_Repository_ProvidesLazy_Constant()
    => _services
    .GetRequiredService<IParserRepository>()
    .ParserFor<IGqlpConstant>()
    .ShouldNotBeNull();

  [Fact]
  public void CommonParsers_Repository_ProvidesLazy_Modifier()
    => _services
    .GetRequiredService<IParserRepository>()
    .ArrayFor<IGqlpModifier>()
    .ShouldNotBeNull();

  [Fact]
  public void CommonParsers_Repository_ProvidesLazy_Default()
    => _services
    .GetRequiredService<IParserRepository>()
    .ParserFor<IParserDefault, IGqlpConstant>()
    .ShouldNotBeNull();

  [Fact]
  public void CommonParsers_Repository_ProvidesLazy_Collections()
    => _services
    .GetRequiredService<IParserRepository>()
    .ArrayFor<IParserCollections, IGqlpModifier>()
    .ShouldNotBeNull();
}
