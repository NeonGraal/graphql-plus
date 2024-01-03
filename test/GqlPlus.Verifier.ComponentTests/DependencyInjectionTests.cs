using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Xunit.DependencyInjection;

namespace GqlPlus.Verifier;

public class DependencyInjectionTests(IServiceCollection services, ITestOutputHelperAccessor output)
{
  [Fact]
  public void CheckDependencyInjectionContainer()
  {
    StringBuilder sb = new();
    var sds = new List<ServiceDescriptor>(services)
        .OrderBy(o => o.ServiceType.ExpandTypeName());

    var hashset = sds.Select(o => o.ServiceType.FullTypeName()).ToHashSet();

    using var scope = new AssertionScope();

    foreach (ServiceDescriptor sd in sds) {
      sb.Clear();

      sb.Append(sd.ServiceType.FullTypeName());
      sb.Append(", ");
      sb.Append(sd.Lifetime);
      sb.Append(", ");
      if (sd.ImplementationType is not null) {
        sb.Append(sd.ImplementationType.FullTypeName(sd.ServiceType.Namespace));

        CheckConstructor(sd.ImplementationType, hashset);
      } else if (sd.ImplementationFactory is not null) {
        sb.Append("() => ");
      } else if (sd.ImplementationInstance is not null) {
        sb.Append("= ");
        sb.Append(sd.ImplementationInstance.GetType().FullTypeName(sd.ServiceType.Namespace));
      }

      output.Output?.WriteLine(sb.ToString());
    }
  }

  private static void CheckConstructor(Type implementationType, HashSet<string> hashset)
  {
    foreach (var ctor in implementationType.GetConstructors()) {
      var missing = ctor.GetParameters()
        .Where(p => !MatchType(hashset, p.ParameterType))
        .Select(p => p.Name + ":" + p.ParameterType.ExpandTypeName()).ToList();

      missing.Should().BeEmpty();
    }
  }

  private static readonly HashSet<string> s_optionalTypes = [
    "LoggerFilterOptions",
  ];

  private static bool MatchType(HashSet<string> hashset, Type parameterType)
  {
    var genericType = parameterType;
    if (parameterType.IsGenericType) {
      genericType = parameterType.GetGenericTypeDefinition();
    }

    return hashset.Contains(parameterType.FullTypeName())
      || s_optionalTypes.Contains(parameterType.Name)
      || parameterType.Name == "IEnumerable`1"
      || parameterType.IsGenericType && genericType != parameterType && MatchType(hashset, genericType);
  }
}
