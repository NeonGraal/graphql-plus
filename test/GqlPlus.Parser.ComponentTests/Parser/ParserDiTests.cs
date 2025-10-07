using Microsoft.Extensions.DependencyInjection;

using Xunit.DependencyInjection;

namespace GqlPlus.Parser;

public class ParserDiTests(
  IServiceCollection services,
  ITestOutputHelperAccessor output
) : DependencyInjectionChecks(services, output)
{
  protected override string Label => "Parser";
}
