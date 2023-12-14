using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifier;

[UsesVerify]
public class DependencyInjectionTests(IServiceCollection services)
{
  [Fact]
  public async Task ParseSampleGraphQl()
  {
    StringBuilder sb = new();
    var sds = new List<ServiceDescriptor>(services)
        .OrderBy(o => o.ServiceType.ExpandTypeName());

    foreach (ServiceDescriptor sd in sds) {
      sb.Append(sd.ServiceType.FullTypeName());
      sb.Append(", ");
      sb.Append(sd.Lifetime);
      sb.Append(", ");
      if (sd.ImplementationType is not null) {
        sb.Append(sd.ImplementationType.FullTypeName(sd.ServiceType.Namespace));
      } else if (sd.ImplementationFactory is not null) {
        sb.Append("() => ");
      } else if (sd.ImplementationInstance is not null) {
        sb.Append("= ");
        sb.Append(sd.ImplementationInstance.GetType().FullTypeName(sd.ServiceType.Namespace));
      }

      sb.AppendLine();
    }

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();

    await Verify(sb, settings);
  }
}
