using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parser;

public class ParserDiTests(IServiceCollection services)
  : DependencyInjectionChecks(services)
{
  protected override string Label => "CommonParser";
}
