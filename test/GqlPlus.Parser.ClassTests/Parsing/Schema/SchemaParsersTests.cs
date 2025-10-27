using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing.Schema;

public class SchemaParsersTests
{
  [Fact]
  public void SchemaParsers_DefinesParser_FieldKey()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddFieldObjectKinds()
      .AddCommonParsers()
      .AddSchemaParsers()
      .BuildServiceProvider();

    services.GetService<Parser<IGqlpFieldKey>.D>()
      .ShouldNotBeNull();
  }
}
