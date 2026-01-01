using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parser.Operation;

public class ParserDiTests(IServiceCollection services)
  : DependencyInjectionChecks(services)
{
  protected override string Label => "OperationParser";
}
