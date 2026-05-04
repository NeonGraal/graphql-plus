using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Text;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.Internal;

namespace GqlPlus;

[Trait("Generate", "Html")]
public abstract class DependencyInjectionChecks(IServiceCollection services)
{
  private const string FunctionRequirement = "=>";
  private const string InstanceRequirement = "==";
  private const string ParentRequirement = "->";

  protected abstract string Label { get; }

  private readonly Map<DiService> _diServices = DependencyInjectionServices(services);

  private static DiService GetOrCreate(Map<DiService> diServices, Type type)
    => diServices.GetValueOrCreate(type.FullTypeName(), k => new(type));

  internal static Map<DiService> DependencyInjectionServices(IServiceCollection services)
  {
    Map<DiService> diServices = [];

    foreach (ServiceDescriptor sd in services) {
      string context = sd.ServiceType.Namespace ?? "";

      if (!context.StartsWith("GqlPlus", StringComparison.Ordinal)) {
        continue;
      }

      DiService service = GetOrCreate(diServices, sd.ServiceType);
      ServiceBase(diServices, service, service.Service.BaseName);

      if (sd.ImplementationType is not null) {
        ServiceType(sd.ImplementationType, service, sd.ImplementationType == sd.ServiceType, diServices);
      } else if (sd.ImplementationFactory is not null) {
        ServiceFactory(sd.ImplementationFactory, service);
      } else if (sd.ImplementationInstance is not null) {
        service.Requires[InstanceRequirement] = new(sd.ImplementationInstance.GetType());
      }
    }

    CalculateServicesRequiredBy(diServices);

    return diServices;
  }

  private static void CalculateServicesRequiredBy(Map<DiService> diServices)
  {
    Map<int> requiredBy = diServices.Values
      .SelectMany(s => s.Requires
        .Where(r => r.Value != s_func && r.Key != InstanceRequirement)
        .Select(r => r.Value.Id))
      .GroupBy(t => t)
      .ToMap(g => g.Key, g => g.Count());

    foreach ((string id, int count) in requiredBy) {
      if (diServices.TryGetValue(id, out DiService? service)) {
        service.RequiredBy = count;
      }
    }
  }

  private static void ServiceType(Type implementationType, DiService service, bool selfImplementing, Map<DiService> diServices)
  {
    if (!selfImplementing) {
      TypeIdName impl = new(implementationType);
      if (!service.Requires.Values.Any(r => r == impl)) {
        string key = service.Requires.Count.ToString(CultureInfo.InvariantCulture);
        service.Requires[key] = impl;
      }

      service = GetOrCreate(diServices, implementationType);
    }

    service.AddParams(implementationType);
  }

  private static readonly TypeIdName s_func = new(typeof(Func<>));

  private static void ServiceFactory(Func<IServiceProvider, object> implementationFactory, DiService service)
  {
    service.Requires[FunctionRequirement] = s_func;
    if (implementationFactory.Method.IsGenericMethod) {
      Type[] args = implementationFactory.Method.GetGenericArguments();
      if (args.Length > 0) {
        service.Requires[FunctionRequirement] = new(args[0]);
      }
    }
  }

  private static void ServiceBase(Map<DiService> diServices, DiService service, TypeIdName? baseName)
  {
    if (baseName is null) {
      return;
    }

    DiService baseService = diServices.GetValueOrCreate(baseName.Id, _ => service.BaseService);

    service.Requires[ParentRequirement] = baseName;
  }

  [Fact]
  public void CheckDependencyInjection()
  {
    StringBuilder sb = new();
    DiService[] services = [.. _diServices.Values
      .OrderBy(s => s.Service.Name)];

    HashSet<string> hashset = [.. _diServices.Keys];

    services.ShouldSatisfyAllConditions(Label,
      s =>
        s.ForEach(di => {
          sb.Append(di.Service.Id);
          sb.Append(", ");

          List<string> missing = [.. di.Requires
            .Where(p => p.Key != InstanceRequirement && !MatchType(hashset, p.Value))
            .Select(p => $"{di.Service.Name} {p.Key} : " + p.Value.Name)];

          sb.AppendLine(missing.Joined(" "));
          missing.ShouldBeEmpty("missing requirements for " + di.Service.Id);
        }));

    TestContext.Current.AddAttachment("DI " + Label, sb.ToString());
  }

  [Fact]
  public void CheckFluidFiles()
    => DiFluid.CheckFiles(Label);

  [Fact]
  public void HtmlDependencyInjection()
    => DiFluid.WriteTree(Label, ServicesTree.ToMap(s => s.Name));

  private IEnumerable<DiTree> ServicesTree
    => _diServices.Values
      .Select(s => new DiTree(s.Service.Safe, s.IsLink, s.RequiredBy) {
        Requires = s.Requires.ToMap(r => r.Key, r => r.Value.Safe)
      });

  private static readonly HashSet<string> s_optionalTypes = [
    "ILoggerFactory",
    "LoggerFilterOptions",
    "IExternalScopeProvider",
    "IServiceProvider",
  ];

  private static bool MatchType(HashSet<string> hashset, TypeIdName parameter)
    => hashset.Contains(parameter.Id)
      || s_optionalTypes.Contains(parameter.Name)
      || parameter.Name.StartsWith("IEnumerable", StringComparison.Ordinal);
}

public sealed record TypeIdName
{
  public TypeIdName([NotNull] Type type)
    : this(type.FullTypeName(), type.ExpandTypeName(), type.Namespace)
  { }

  private TypeIdName(string id, string name, string? nameSpace = null)
  {
    Id = id;
    NameSpace = nameSpace ?? "";
    Name = name;
    Key = id
      .Replace('<', '_')
      .Replace('>', '_')
      .Replace('+', '_')
      .Replace('.', '_')
      .Replace(',', '_')
      .Replace("::", "_", StringComparison.Ordinal)
      .Replace("[]", "_Array_", StringComparison.Ordinal);
    Safe = name
      .Replace('<', '(')
      .Replace('>', ')');

    string[] strings = name.Split('<');
    if (strings.Length > 1) {
      BaseName = new(id.Split('<')[0], strings[0], nameSpace);
    }
  }

  public string Id { get; }
  public string NameSpace { get; }
  public string Name { get; }
  public string Key { get; }
  public string Safe { get; }
  public TypeIdName? BaseName { get; }
}

public sealed class DiService
{
  public TypeIdName Service { get; }
  public Map<TypeIdName> Requires { get; } = [];
  public int RequiredBy { get; set; } = -1;
  public bool IsLink { get; set; }

  public DiService(Type service)
    => Service = new(service);
  private DiService(TypeIdName service)
    => Service = service;

  public DiService(DiService service)
  {
    ArgumentNullException.ThrowIfNull(service);

    Service = service.Service;
    Requires = service.Requires;
    RequiredBy = service.RequiredBy;
    IsLink = true;
  }

  public override string? ToString()
    => Service.Name + (IsLink ? " ~" : " ") + $"{RequiredBy}/{Requires.Count}";

  internal void AddParams(Type provider)
  {
    foreach (ConstructorInfo ctor in provider.GetConstructors()) {
      string prefix = ctor.Name == ".ctor" ? "" : ctor.Name + '!';
      foreach (ParameterInfo parameter in ctor.GetParameters()) {
        Type paramType = parameter.ParameterType;
        if (paramType.IsGenericType
          && paramType.GetGenericTypeDefinition() == typeof(IEnumerable<>)) {
          Requires.Add(prefix + parameter.Name + "[]", new(paramType.GetGenericArguments()[0]));
        } else if (paramType != typeof(ILoggerFactory)) {
          if (!Requires.TryAdd(prefix + parameter.Name, new(paramType))) {
            throw new ArgumentException(prefix + parameter.Name + " duplicate in " + provider.ExpandTypeName());
          }
        }
      }
    }
  }

  public DiService BaseService
    => new(Service.BaseName!);
}
