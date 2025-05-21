using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing;

public class CommonParsersTests
{
  [Fact]
  public void CommonParsers_DefinesParser_FieldKey()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddCommonParsers()
      .BuildServiceProvider();

    services.GetService<Parser<IGqlpFieldKey>.D>()
      .ShouldNotBeNull();
  }
}
