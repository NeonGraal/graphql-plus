using System.Reflection;
using System.Text;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Xunit.DependencyInjection;

namespace GqlPlus;

public class DependencyInjectionChecks(
  IServiceCollection services,
  ITestOutputHelperAccessor output
)
{
  private static readonly FluidParser s_parser = new();
  private static readonly Map<IFluidTemplate> s_templates = [];
  private static readonly TemplateOptions s_options = new();

  static DependencyInjectionChecks()
  {
    s_options.FileProvider = new EmbeddedFileProvider(Assembly.GetAssembly(typeof(DependencyInjectionChecks))!, "GqlPlus.DI");
    s_options.MemberAccessStrategy.Register<DiService>();
    s_options.MemberAccessStrategy.Register<TypeIdName>();
  }

  private static IFluidTemplate GetTemplate(string template)
  {
    if (!s_templates.TryGetValue(template, out IFluidTemplate? value)) {
      value = s_parser.Parse("{% render '" + template + "' %}");
      s_templates.Add(template, value);
    }

    return value;
  }

  private readonly Map<DiService[]> _diServices = DependencyInjectionServices(services);

  internal static Map<DiService[]> DependencyInjectionServices(IServiceCollection services)
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
            // service.AddParameters(args[0]);
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

  public void CheckDependencyInjection()
  {
    StringBuilder sb = new();
    DiService[] services = [.. _diServices.Values
      .SelectMany(v => v)
      .OrderBy(s => s.Service.Name)];

    HashSet<string> hashset = [.. _diServices.Keys];

    using AssertionScope scope = new();

    foreach (DiService di in services) {
      sb.Clear();

      sb.Append(di.Service.Id);
      sb.Append(", ");
      sb.Append(di.Lifetime);
      sb.Append(", ");
      sb.Append(di.Provider);

      string prefix = di.Service.Name + " <- " + di.Implementation.Name;
      List<string> missing = di.Parameters
        .Where(p => !MatchType(hashset, p.Value))
      .Select(p => $"{prefix} {p.Key} : " + p.Value.Name).ToList();

      missing.Should().BeEmpty();
      output.Output?.WriteLine(sb.ToString());
    }
  }

  public void CheckFluidFiles()
  {
    IFileProvider files = s_options.FileProvider;

    IDirectoryContents contents = files.GetDirectoryContents("");

    using AssertionScope scope = new();

    contents.Exists.Should().BeTrue();
    contents.Should().NotBeEmpty();
    contents.Should().Contain(fi => fi.Name == "pico.liquid");
  }

  public void HtmlDependencyInjection(string file)
  {
    IOrderedEnumerable<DiService> services = _diServices.Values
      .SelectMany(v => v)
      .OrderBy(s => (-s.Parameters.Count, s.Implementation.Name));

    TemplateContext context = new(s_options);
    context.SetValue("name", file);
    context.SetValue("services", services);

    IFluidTemplate template = GetTemplate("table");
    template.Render(context).WriteHtmlFile("DI", file + "-table");
  }

  public void DiagramDependencyInjection(string file)
  {
    IOrderedEnumerable<DiService> services = _diServices.Values
      .SelectMany(v => v)
      .OrderBy(s => (-s.Parameters.Count, s.Implementation.Name));

    TemplateContext context = new(s_options);
    context.SetValue("name", file);
    context.SetValue("services", services);

    IFluidTemplate template = GetTemplate("diagram");
    template.Render(context).WriteHtmlFile("DI", file + "-diagram");
  }

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

public sealed class TypeIdName(Type type)
{
  public string Id { get; } = type.FullTypeName();
  public string NameSpace { get; } = type.Namespace ?? "";
  public string Name { get; } = type.ExpandTypeName();
  public string Key { get; } = type.FullTypeName()
      .Replace('<', '_')
      .Replace('>', '_')
      .Replace('+', '_')
      .Replace('.', '_')
      .Replace(',', '_')
      .Replace("::", "_", StringComparison.Ordinal);

  public string HtmlName => Name.Replace('<', '(').Replace('>', ')');
  public string Mermaid => "  " + Key + "[\"" + HtmlName + "\"]";
}

public sealed class DiService(ServiceDescriptor service, Type implementation)
{
  public TypeIdName Service { get; } = new(service.ServiceType);
  public ServiceLifetime Lifetime { get; } = service.Lifetime;
  public bool IsFactory { get; init; }
  public bool IsInstance { get; init; }
  public TypeIdName Implementation { get; } = new(implementation);
  public Map<TypeIdName> Parameters { get; } = [];

  internal void AddParameters(Type provider)
  {
    foreach (ConstructorInfo ctor in provider.GetConstructors()) {
      foreach (ParameterInfo parameter in ctor.GetParameters()) {
        Parameters.Add(ctor.Name + '!' + parameter.Name, new(parameter.ParameterType));
      }
    }
  }

  public string HtmlLifetime => Lifetime.ToString();

  public string Provider => IsFactory
    ? " () => " + (IsInstance ? "" : Implementation.Name)
    : (IsInstance ? " = " : "") + Implementation.Name;
  public string HtmlProvider => IsFactory
    ? " () => " + (IsInstance ? "" : Implementation.HtmlName)
    : (IsInstance ? " = " : "") + Implementation.HtmlName;

  private string? _link;
  public string Link => _link ??=
    ' ' + Lifetime switch {
      ServiceLifetime.Singleton => "-->",
      ServiceLifetime.Scoped => "--o",
      ServiceLifetime.Transient => "--x",
      _ => "..x"
    };

  private string? _prefix;
  public string Prefix => _prefix ??= "    " + Implementation.Key + Link;

  public string Mermaid
    => Service.Id == Implementation.Id ? ""
    : "    " + Service.Key + Link + ' ' + Implementation.Key;

  public IEnumerable<string> MermaidParameters
    => Parameters.Select(p => Prefix + '|' + p.Key + '|' + p.Value.Key);
}
