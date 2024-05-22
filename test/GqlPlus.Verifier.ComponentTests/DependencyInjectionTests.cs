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
  public void HtmlVerifierDI()
    => HtmlDependencyInjection("Verifier");

  [Fact]
  public void DiagramVerifierDI()
    => DiagramDependencyInjection("Verifier");

  [Fact]
  public void FluidVerifierFiles()
    => CheckFluidFiles();
}
