using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parser.Schema;

public class SchemaParserDiTests(IServiceCollection services)
  : DiChecks(services)
{
  protected override string Label => "SchemaParser";
}
