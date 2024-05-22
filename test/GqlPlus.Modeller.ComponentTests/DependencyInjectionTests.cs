using Microsoft.Extensions.DependencyInjection;
using Xunit.DependencyInjection;

namespace GqlPlus;

public class DependencyInjectionTests(
  IServiceCollection services,
  ITestOutputHelperAccessor output
) : DependencyInjectionChecks(services, output)
{
  [Fact]
  public void CheckModellerDI()
    => CheckDependencyInjection();

  [Fact]
  public void HtmlModellerDI()
    => HtmlDependencyInjection("Modeller");

  [Fact]
  public void FluidModellerFiles()
    => CheckFluidFiles();
}
