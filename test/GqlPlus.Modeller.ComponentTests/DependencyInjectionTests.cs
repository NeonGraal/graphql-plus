using Microsoft.Extensions.DependencyInjection;
using Xunit.DependencyInjection;

namespace GqlPlus;

public class DependencyInjectionTests(
  IServiceCollection services,
  ITestOutputHelperAccessor output
) : DependencyInjectionChecks(services, output)
{
  [Fact]
  public void CheckModellerDIContainer()
    => CheckDependencyInjectionContainer();

  [Fact]
  public void HtmlDiagramModellerDIContainer()
    => HtmlDiagramDependencyInjectionContainer()
    .WriteHtmlFile("DI", "Modeller");
}
