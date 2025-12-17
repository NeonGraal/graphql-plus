using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class CodecDiTests(IServiceCollection services)
  : DependencyInjectionChecks(services)
{
  protected override string Label => "Codec";
}
