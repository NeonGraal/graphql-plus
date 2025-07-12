using Microsoft.Extensions.DependencyInjection;

using Xunit.DependencyInjection;

namespace GqlPlus;

public class CodecDiTests(
  IServiceCollection services,
  ITestOutputHelperAccessor output
) : DependencyInjectionChecks(services, output)
{
  protected override string Label => "Codec";
}
