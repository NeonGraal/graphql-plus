using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing;

public class CommonParsersTests
{
  private readonly IServiceProvider _services;

  public CommonParsersTests()
    => _services = new ServiceCollection()
      .AddLogging()
      .AddCommonParsers()
      .BuildServiceProvider();

  [Fact]
  public void CommonParsers_DefinesParser_Constant()
    => _services
    .GetService<Parser<IGqlpConstant>.D>()
    .ShouldNotBeNull();

  [Fact]
  public void CommonParsers_DefinesParserArray_Modifier()
    => _services
    .GetService<Parser<IGqlpModifier>.DA>()
    .ShouldNotBeNull();

  [Fact]
  public void CommonParsers_DefinesParser_Default()
    => _services
    .GetService<Parser<IParserDefault, IGqlpConstant>.D>()
    .ShouldNotBeNull();

  [Fact]
  public void CommonParsers_DefinesParserArray_Collections()
    => _services
    .GetService<ParserArray<IParserCollections, IGqlpModifier>.DA>()
    .ShouldNotBeNull();
}
