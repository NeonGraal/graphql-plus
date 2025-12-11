using Microsoft.Extensions.DependencyInjection;

using Xunit.DependencyInjection;

namespace GqlPlus.Parser;

public class ParserDiTests(IServiceCollection services)
  : DependencyInjectionChecks(services)
{
  protected override string Label => "Parser";
}
