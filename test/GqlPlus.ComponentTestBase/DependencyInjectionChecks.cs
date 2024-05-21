using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Xunit.DependencyInjection;

namespace GqlPlus;

public class DependencyInjectionChecks(
  IServiceCollection services,
  ITestOutputHelperAccessor output
)
{
  private readonly Map<DiService[]> _diServices = DependencyInjectionContainerServices(services);

  internal static Map<DiService[]> DependencyInjectionContainerServices(IServiceCollection services)
  {
    List<DiService> diServices = [];

    foreach (ServiceDescriptor sd in services) {
      string context = sd.ServiceType.Namespace ?? "";

      if (!context.StartsWith("GqlPlus", StringComparison.Ordinal)) {
        continue;
      }

      DiService? service = null;

      if (sd.ImplementationType is not null) {
        service = new(sd, sd.ImplementationType);
        service.AddParameters(sd.ImplementationType);
      } else if (sd.ImplementationFactory is not null) {
        service = new(sd, sd.ImplementationFactory.Method.ReturnType) { IsFactory = true, IsInstance = true };

        if (sd.ImplementationFactory.Method.IsGenericMethod) {
          Type[] args = sd.ImplementationFactory.Method.GetGenericArguments();
          if (args.Length > 0) {
            service = new(sd, args[0]) { IsFactory = true };
            service.AddParameters(args[0]);
          }
        }
      } else if (sd.ImplementationInstance is not null) {
        service = new(sd, sd.ImplementationInstance.GetType()) { IsInstance = true };
      }

      if (service is not null) {
        diServices.Add(service);
      }
    }

    return diServices
      .ToLookup(d => d.Service.Id)
      .ToMap(l => l.Key, l => l.ToArray());
  }

  public void CheckDependencyInjectionContainer()
  {
    StringBuilder sb = new();
    DiService[] sds = [.. _diServices.Values
      .SelectMany(v => v)
      .OrderBy(s => s.Service.Name)];

    HashSet<string> hashset = [.. _diServices.Keys];

    using AssertionScope scope = new();

    foreach (DiService sd in sds) {
      sb.Clear();

      sb.Append(sd.Service.Id);
      sb.Append(", ");
      sb.Append(sd.Lifetime);
      sb.Append(", ");
      if (sd.IsFactory) {
        sb.Append(" () => ");
        if (!sd.IsInstance) {
          sb.Append(sd.Implementation.Name);
        }
      } else {
        if (sd.IsInstance) {
          sb.Append(" = ");
        }

        sb.Append(sd.Implementation.Name);
      }

      string prefix = sd.Service.Name + " <- " + sd.Implementation.Name;

      List<string> missing = sd.Parameters
        .Where(p => !MatchType(hashset, p.Value))
      .Select(p => $"{prefix} {p.Key} : " + p.Value.Name).ToList();

      missing.Should().BeEmpty();
      output.Output?.WriteLine(sb.ToString());
    }
  }

  private static readonly HashSet<string> s_optionalTypes = [
    "ILoggerFactory",
    "LoggerFilterOptions",
    "IExternalScopeProvider",
    "IServiceProvider",
  ];

  private static bool MatchType(HashSet<string> hashset, TypeIdName parameter)
  {
    TypeIdName? genericType = null;
    if (parameter.IsGeneric) {
      genericType = parameter.Generic;
    }

    return hashset.Contains(parameter.Id)
      || s_optionalTypes.Contains(parameter.Name)
      || parameter.Name.StartsWith("IEnumerable", StringComparison.Ordinal);
    //|| parameter.IsGeneric
    //  && genericType is not null
    //  && genericType.Id != parameter.Id
    //  && MatchType(hashset, genericType);
  }
}

internal sealed class TypeIdName(Type type)
{
  internal string Id { get; } = type.FullTypeName();
  internal string Name { get; } = type.ExpandTypeName();
  internal bool IsGeneric { get; } = type.IsGenericType;
  internal TypeIdName? Generic { get; } = type.IsGenericType && !type.IsGenericTypeDefinition ? new(type.GetGenericTypeDefinition()) : null;
}

internal sealed class DiService(ServiceDescriptor service, Type implementation)
{
  internal TypeIdName Service { get; } = new(service.ServiceType);
  internal ServiceLifetime Lifetime { get; } = service.Lifetime;
  internal bool IsFactory { get; init; }
  internal bool IsInstance { get; init; }
  internal TypeIdName Implementation { get; } = new(implementation);
  internal Map<TypeIdName> Parameters { get; } = [];

  internal void AddParameters(Type provider)
  {
    foreach (ConstructorInfo ctor in provider.GetConstructors()) {
      foreach (ParameterInfo parameter in ctor.GetParameters()) {
        Parameters.Add(ctor.Name + '!' + parameter.Name, new(parameter.ParameterType));
      }
    }
  }
}
