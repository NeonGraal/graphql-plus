using Microsoft.Extensions.DependencyInjection;

using Xunit.DependencyInjection;

namespace GqlPlus;

public class DependencyInjectionTests(
  IServiceCollection services,
  ITestOutputHelperAccessor output
) : DependencyInjectionChecks(services, output)
{
  [Fact]
  public void CheckParserDI()
    => CheckDependencyInjection();

  [Fact]
  public async Task HtmlParserDI()
    => await HtmlDependencyInjection("Parser");

  [Fact]
  public async Task Force3DParserDI()
    => await Force3dDependencyInjection("Parser");

  [Fact]
  public async Task DiagramParserDI()
    => await DiagramDependencyInjection("Parser");

  [Fact]
  public void FluidParserFiles()
    => CheckFluidFiles();
}
