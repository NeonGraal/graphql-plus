using System.Globalization;
using System.Reflection;
using System.Text;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
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

  private readonly Map<DiService> _diServices = DependencyInjectionServices(services);

  internal static Map<DiService> DependencyInjectionServices(IServiceCollection services)
  {
    Map<DiService> diServices = [];
    TypeIdName func = new(typeof(Func<>));

    DiService GetOrCreate(Type type)
    {
      if (!diServices.TryGetValue(type.FullTypeName(), out DiService? di)) {
        di = new(type);
        diServices[di.Service.Id] = di;
      }

      return di;
    }

    foreach (ServiceDescriptor sd in services) {
      string context = sd.ServiceType.Namespace ?? "";

      if (!context.StartsWith("GqlPlus", StringComparison.Ordinal)) {
        continue;
      }

      DiService service = GetOrCreate(sd.ServiceType);

      if (sd.ImplementationType is not null) {
        if (sd.ImplementationType != sd.ServiceType) {
          TypeIdName impl = new(sd.ImplementationType);
          if (!service.Requires.Values.Any(r => r == impl)) {
            string key = service.Requires.Count.ToString(CultureInfo.InvariantCulture);
            service.Requires[key] = impl;
          }

          service = GetOrCreate(sd.ImplementationType);
        }

        service.AddParameters(sd.ImplementationType);
      } else if (sd.ImplementationFactory is not null) {
        service.Requires["()="] = func;
        if (sd.ImplementationFactory.Method.IsGenericMethod) {
          Type[] args = sd.ImplementationFactory.Method.GetGenericArguments();
          if (args.Length > 0) {
            service.Requires["()="] = new(args[0]);
          }
        }
      } else if (sd.ImplementationInstance is not null) {
        service.Requires["="] = new(sd.ImplementationInstance.GetType());
      }
    }

    Map<int> requiredBy = diServices.Values
      .SelectMany(s => s.Requires
        .Where(r => r.Value != func && r.Key != "=")
        .Select(r => r.Value.Id))
      .GroupBy(t => t)
      .ToMap(g => g.Key, g => g.Count());

    foreach ((string id, int count) in requiredBy) {
      if (diServices.TryGetValue(id, out DiService? service)) {
        service.RequiredBy = count;
      }
    }

    return diServices;
  }

  public void CheckDependencyInjection()
  {
    StringBuilder sb = new();
    DiService[] services = [.. _diServices.Values
      .OrderBy(s => s.Service.Name)];

    HashSet<string> hashset = [.. _diServices.Keys];

    using AssertionScope scope = new();

    foreach (DiService di in services) {
      sb.Clear();

      sb.Append(di.Service.Id);
      sb.Append(", ");

      List<string> missing = di.Requires
        .Where(p => p.Key != "=" && !MatchType(hashset, p.Value))
        .Select(p => $"{di.Service.Name} {p.Key} : " + p.Value.Name).ToList();

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
      .OrderBy(s => (s.RequiredBy, s.Service.Name));

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
      .OrderBy(s => (s.RequiredBy, s.Service.Name));

    string name = "";
    List<DiService> group = [];

    _group.Clear();
    _groupIds.Clear();
    foreach (DiService di in services) {
      if (_ids.Contains(di.Service.Id)) {
        continue;
      }

      AddToGroup(di);
      _ids.UnionWith(_groupIds);
      _groupIds.Clear();

      if (group.Count > 5 || group.Count > 0 && group.Count < _group.Count) {
        groups[name] = [.. group];
        name = di.Service.Safe;
        group.Clear();
      } else if (string.IsNullOrWhiteSpace(name)) {
        name = di.Service.Safe;
      }

      group.AddRange(_group);
      _group.Clear();
    }

    if (group.Count > 0) {
      groups[name] = [.. group];
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

    foreach ((string key, TypeIdName prereq) in di.Requires) {
      if (!int.TryParse(key, out int _)) {
        if (_diServices.TryGetValue(prereq.Id, out DiService? requires)) {
          AddToGroup(requires);
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

public sealed record TypeIdName
{
  public TypeIdName(Type type)
  {
    Id = type.ThrowIfNull().FullTypeName();
    NameSpace = type.Namespace ?? "";
    Name = type.ExpandTypeName();

    Key = Id
      .Replace('<', '_')
      .Replace('>', '_')
      .Replace('+', '_')
      .Replace('.', '_')
      .Replace(',', '_')
      .Replace("::", "_", StringComparison.Ordinal);

    Safe = Name
      .Replace('<', '(')
      .Replace('>', ')');
  }

  public string Id { get; }
  public string NameSpace { get; }
  public string Name { get; }
  public string Key { get; }
  public string Safe { get; }
}

public sealed class DiService(Type service)
{
  public TypeIdName Service { get; } = new(service);
  public Map<TypeIdName> Requires { get; } = [];
  public int RequiredBy { get; set; } = -1;

  internal void AddParameters(Type provider)
  {
    foreach (ConstructorInfo ctor in provider.GetConstructors()) {
      string prefix = ctor.Name == ".ctor" ? "" : ctor.Name + '!';
      foreach (ParameterInfo parameter in ctor.GetParameters()) {
        if (parameter.ParameterType.IsGenericType
          && parameter.ParameterType.GetGenericTypeDefinition() == typeof(IEnumerable<>)) {
          Requires.Add(prefix + parameter.Name + "[]", new(parameter.ParameterType.GetGenericArguments()[0]));
        } else if (parameter.ParameterType != typeof(ILoggerFactory)) {
          Requires.Add(prefix + parameter.Name, new(parameter.ParameterType));
        }
      }
    }
  }
}
