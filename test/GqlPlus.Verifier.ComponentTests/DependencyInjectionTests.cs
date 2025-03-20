using Microsoft.Extensions.DependencyInjection;
using Xunit.DependencyInjection;

namespace GqlPlus;

public class DependencyInjectionTests(
  IServiceCollection services,
  ITestOutputHelperAccessor output
) : DependencyInjectionChecks(services, output)
{
  [Fact]
  public void CheckVerifierDI()
    => CheckDependencyInjection();

  [Fact]
  public async Task HtmlVerifierDI()
    => await HtmlDependencyInjection("Verifier");

  [Fact]
  public async Task DiagramVerifierDI()
    => await DiagramDependencyInjection("Verifier");

  [Fact]
  public void FluidVerifierFiles()
    => CheckFluidFiles();
}
