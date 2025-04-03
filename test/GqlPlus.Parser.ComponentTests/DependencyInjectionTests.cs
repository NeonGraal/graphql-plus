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
  public void HtmlParserDI()
    => HtmlDependencyInjection("Parser");

  [Fact]
  public void Force3DParserDI()
    => Force3dDependencyInjection("Parser");

  [Fact]
  public void DiagramParserDI()
    => DiagramDependencyInjection("Parser");

  [Fact]
  public void FluidParserFiles()
    => CheckFluidFiles();
}
