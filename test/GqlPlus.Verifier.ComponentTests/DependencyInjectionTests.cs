using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Xunit.DependencyInjection;

namespace GqlPlus;

public class DependencyInjectionTests(IServiceCollection services, ITestOutputHelperAccessor output)
{
  [Fact]
  public void CheckDependencyInjectionContainer()
  {
    StringBuilder sb = new();
    ServiceDescriptor[] sds = services
        .OrderBy(o => o.ServiceType.ExpandTypeName())
        .ToArray();

    HashSet<string> hashset = sds.Select(o => o.ServiceType.FullTypeName()).ToHashSet();

    using AssertionScope scope = new();

    foreach (ServiceDescriptor sd in sds) {
      sb.Clear();

      string service = sd.ServiceType.FullTypeName();
      sb.Append(service);
      sb.Append(", ");
      sb.Append(sd.Lifetime);
      sb.Append(", ");
      if (sd.ImplementationType is not null) {
        string implementation = sd.ImplementationType.FullTypeName(sd.ServiceType.Namespace);
        sb.Append(implementation);

        CheckConstructor(service + " <- " + implementation, sd.ImplementationType, hashset);
      } else if (sd.ImplementationFactory is not null) {
        sb.Append("() => ");
      } else if (sd.ImplementationInstance is not null) {
        sb.Append("= ");
        sb.Append(sd.ImplementationInstance.GetType().FullTypeName(sd.ServiceType.Namespace));
      }

      output.Output?.WriteLine(sb.ToString());
    }
  }

  private static void CheckConstructor(string prefix, Type implementationType, HashSet<string> hashset)
  {
    foreach (System.Reflection.ConstructorInfo ctor in implementationType.GetConstructors()) {
      List<string> missing = ctor.GetParameters()
        .Where(p => !MatchType(hashset, p.ParameterType))
        .Select(p => $"{prefix} {p.Name} : " + p.ParameterType.ExpandTypeName()).ToList();

      missing.Should().BeEmpty();
    }
  }

  private static readonly HashSet<string> s_optionalTypes = [
    "LoggerFilterOptions",
    "IExternalScopeProvider",
    "IServiceProvider",
  ];

  private static bool MatchType(HashSet<string> hashset, Type parameterType)
  {
    Type genericType = parameterType;
    if (parameterType.IsGenericType) {
      genericType = parameterType.GetGenericTypeDefinition();
    }

    return hashset.Contains(parameterType.FullTypeName())
      || s_optionalTypes.Contains(parameterType.Name)
      || parameterType.Name == "IEnumerable`1"
      || parameterType.IsGenericType && genericType != parameterType && MatchType(hashset, genericType);
  }
}
