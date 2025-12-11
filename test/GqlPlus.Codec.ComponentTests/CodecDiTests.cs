using Microsoft.Extensions.DependencyInjection;

using Xunit.DependencyInjection;

namespace GqlPlus;

public class CodecDiTests(IServiceCollection services)
  : DependencyInjectionChecks(services)
{
  protected override string Label => "Codec";
}
