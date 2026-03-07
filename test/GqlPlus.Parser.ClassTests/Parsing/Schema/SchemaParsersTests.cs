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
      .AddCommonParsers()
      .AddSchemaParsers()
      .BuildServiceProvider();

    services.GetRequiredService<IParserRepository>()
      .Get<IGqlpFieldKey>()
      .ShouldNotBeNull();
  }
}
