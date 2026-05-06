using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class CodecDiTests(IServiceCollection services)
  : DiChecks(services)
{
  protected override string Label => "Codec";
}
