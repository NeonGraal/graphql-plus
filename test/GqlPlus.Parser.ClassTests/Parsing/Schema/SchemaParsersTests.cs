using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing.Schema;

public class SchemaParsersTests
{
  [Fact]
  public void SchemaParsers_Repository_ProvidesLazy_FieldKey()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddFieldObjectKinds()
      .AddParserBase()
      .AddParsers(b => b
        .AddCommonParsers()
        .AddSchemaParsers())
      .BuildServiceProvider();

    services.GetRequiredService<IParserRepository>()
      .ParserFor<IGqlpFieldKey>()
      .ShouldNotBeNull();
  }
}
