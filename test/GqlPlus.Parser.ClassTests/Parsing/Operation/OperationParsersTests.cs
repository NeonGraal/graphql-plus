using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing.Operation;

public class OperationParsersTests
{
  [Fact]
  public void OperationParsers_DefinesParser_FieldKey()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddCommonParsers()
      .AddOperationParsers()
      .BuildServiceProvider();

    services.GetService<Parser<IGqlpFieldKey>.D>()
      .ShouldNotBeNull();
  }
}
