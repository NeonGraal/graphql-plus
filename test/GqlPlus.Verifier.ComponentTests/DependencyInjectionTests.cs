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
        .OrderBy(o => ExpandTypeName(o.ServiceType));

    foreach (ServiceDescriptor sd in sds) {
      sb.Append("Service: ");
      sb.Append(ExpandTypeName(sd.ServiceType));
      sb.Append(", ");
      sb.Append(sd.Lifetime);
      sb.Append(", ");
      if (sd.ImplementationType is not null) {
        sb.Append(ExpandTypeName(sd.ImplementationType));
      } else if (sd.ImplementationFactory is not null) {
        sb.Append("() => ");
      } else if (sd.ImplementationInstance is not null) {
        sb.Append(sd.ImplementationInstance);
        sb.Append("()");
      }
      sb.AppendLine();
    }

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();

    await Verify(sb, settings);
  }
  private static string ExpandTypeName(Type? t)
  {
    if (t is null) {
      return "{null}";
    }

    var nested = "";

    if (t.IsNested) {
      nested = ExpandTypeName(t.DeclaringType) + "+";
    }

    if (!t.IsGenericType || t.IsGenericTypeDefinition) {
      return nested + t.Name;
    }

    var baseType = ExpandTypeName(t.GetGenericTypeDefinition());
    var arguments = "<" + string.Join(",", t.GetGenericArguments().Select(ExpandTypeName)) + ">";
    var placeholder = $"`{t.GetGenericArguments().Length}";

    return baseType.Replace(placeholder, arguments);
  }
}
