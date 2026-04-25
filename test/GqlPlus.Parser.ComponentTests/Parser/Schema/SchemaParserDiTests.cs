using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parser.Schema;

public class SchemaParserDiTests(IServiceCollection services)
  : DependencyInjectionChecks(services)
{
  protected override string Label => "SchemaParser";
}
