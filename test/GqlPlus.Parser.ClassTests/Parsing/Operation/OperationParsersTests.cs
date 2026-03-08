using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing.Operation;

public class OperationParsersTests
{
  [Fact]
  public void OperationParsers_Repository_ProvidesLazy_FieldKey()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddParserBase()
      .AddParsers(b => b
        .AddCommonParsers()
        .AddOperationParsers())
      .BuildServiceProvider();

    services.GetRequiredService<IParserRepository>()
      .ParserFor<IGqlpFieldKey>()
      .ShouldNotBeNull();
  }
}
