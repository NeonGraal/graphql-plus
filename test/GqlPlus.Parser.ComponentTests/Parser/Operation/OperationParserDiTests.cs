using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parser.Operation;

public class OperationParserDiTests(IServiceCollection services)
  : DiChecks(services)
{
  protected override string Label => "OperationParser";
}
