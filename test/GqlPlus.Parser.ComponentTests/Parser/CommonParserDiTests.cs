using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parser;

public class CommonParserDiTests(IServiceCollection services)
  : DependencyInjectionChecks(services)
{
  protected override string Label => "CommonParser";
}
