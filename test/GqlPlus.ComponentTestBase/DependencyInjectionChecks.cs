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
          }
        }
      } else if (sd.ImplementationInstance is not null) {
        service = new(sd, sd.ImplementationInstance.GetType()) { IsInstance = true };
      }

      if (service is not null) {
        diServices.Add(service);
      }
    }

    Map<DiService[]> result = diServices
      .GroupBy(d => d.Service.Id)
      .ToMap(l => l.Key, l => l.ToArray());

    IEnumerable<IGrouping<string, DiService>> factories = diServices
      .Where(di => di.IsInstance && !di.IsInstance)
      .GroupBy(d => d.Implementation.Id);

    foreach (IGrouping<string, DiService> group in factories) {
      IEnumerable<TypeIdName> parents = group.Select(g => g.Service).DistinctBy(t => t.Id);
      result[group.Key].First().Parents = [.. parents];
    }

    return result;
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

  private readonly HashSet<string> _ids = [];
  private readonly List<DiService> _group = [];
  private readonly HashSet<string> _groupIds = [];

  public void DiagramDependencyInjection(string file)
  {
    _ids.Clear();
    Map<DiService[]> groups = [];

    IOrderedEnumerable<DiService> services = _diServices.Values
      .SelectMany(v => v)
      .OrderBy(s => (-s.Parameters.Count, s.Implementation.Name));

    string name = "";
    _group.Clear();
    _groupIds.Clear();
    foreach (DiService di in services) {
      if (_ids.Contains(di.Service.Id)) {
        continue;
      }

      if (string.IsNullOrWhiteSpace(name)) {
        name = di.Service.HtmlName;
      }

      AddToGroup(di);
      _ids.UnionWith(_groupIds);

      if (_group.Count > 5) {
        groups[name] = [.. _group];
        name = "";
        _group.Clear();
        _groupIds.Clear();
      }
    }

    if (_group.Count > 0) {
      groups[name] = [.. _group];
      name = "";
      _group.Clear();
      _groupIds.Clear();
    }

    TemplateContext context = new(s_options);
    context.SetValue("name", file);
    context.SetValue("services", groups);

    IFluidTemplate template = GetTemplate("diagram");
    template.Render(context).WriteHtmlFile("DI", file + "-diagram");
  }

  private void AddToGroup(DiService di)
  {
    if (_groupIds.Contains(di.Service.Id)) {
      return;
    }

    _group.Add(di);
    _groupIds.Add(di.Service.Id);
    if (di.Service.Id != di.Implementation.Id
      && _diServices.TryGetValue(di.Implementation.Id, out DiService[]? impl)) {
      AddAllToGroup(impl);
    }

    AddAllToGroup([.. di.Parents.SelectMany(p => _diServices.GetValueOrDefault(p.Id) ?? [])]);
    AddChildren(_group, di);
  }

  private void AddAllToGroup(params DiService[] toAdd)
  {
    foreach (DiService di in toAdd) {
      AddToGroup(di);
    }
  }

  private void AddChildren(List<DiService> group, DiService service)
  {
    foreach (TypeIdName prereq in service.Parameters.Values) {
      if (_diServices.TryGetValue(prereq.Id, out DiService[]? prereqs)) {
        AddAllToGroup(prereqs);

        foreach (DiService child in prereqs) {
          AddChildren(group, child);
        }
      }
    }
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
  public bool IsFactory { get; init; }
  public bool IsInstance { get; init; }
  public TypeIdName Implementation { get; } = new(implementation);
  public Map<TypeIdName> Parameters { get; } = [];
  public IEnumerable<TypeIdName> Parents { get; set; } = [];

  internal void AddParameters(Type provider)
  {
    foreach (ConstructorInfo ctor in provider.GetConstructors()) {
      string prefix = ctor.Name == ".ctor" ? "" : ctor.Name + '!';
      foreach (ParameterInfo parameter in ctor.GetParameters()) {
        Parameters.Add(prefix + parameter.Name, new(parameter.ParameterType));
      }
    }
  }

  public string Provider => IsFactory
    ? " () => " + (IsInstance ? "" : Implementation.Name)
    : (IsInstance ? " = " : "") + Implementation.Name;
  public string HtmlProvider => IsFactory
    ? " () => " + (IsInstance ? "" : Implementation.HtmlName)
    : (IsInstance ? " = " : "") + Implementation.HtmlName;

  private string? _prefix;
  public string Prefix => _prefix ??= "    " + Implementation.Key + " -->";

  public string Mermaid
    => Service.Id == Implementation.Id ? ""
    : "    " + Service.Key + " --> " + Implementation.Key;

  public IEnumerable<string> MermaidParameters
    => Parameters.Select(p => Prefix + '|' + p.Key + '|' + p.Value.Key);
}
