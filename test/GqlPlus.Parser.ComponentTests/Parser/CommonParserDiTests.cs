using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parser;

public class CommonParserDiTests(IServiceCollection services)
  : DiChecks(services)
{
  protected override string Label => "CommonParser";
}
