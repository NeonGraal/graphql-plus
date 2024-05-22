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
    => FluidDependencyInjection("Parser");

  [Fact]
  public void FluidParserFiles()
    => CheckFluidFiles();
}
