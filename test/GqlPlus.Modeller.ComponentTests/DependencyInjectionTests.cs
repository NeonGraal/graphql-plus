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
  public async Task HtmlModellerDI()
    => await HtmlDependencyInjection("Modeller");

  [Fact]
  public async Task DiagramModellerDI()
    => await HtmlDependencyInjection("Modeller");

  [Fact]
  public void Force3DModellerDI()
    => Force3dDependencyInjection("Modeller");

  [Fact]
  public void FluidModellerFiles()
    => CheckFluidFiles();
}
