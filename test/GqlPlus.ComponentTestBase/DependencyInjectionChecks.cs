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

  public string HtmlDependencyInjection()
  {
    StringBuilder sb = new();

    sb.AppendLine("<HEAD>");
    sb.AppendLine("<meta charset='utf-8'/>");
    sb.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1' />");
    sb.AppendLine("<meta name='color-scheme' content='light dark' />");
    sb.AppendLine("<link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/@picocss/pico@2/css/pico.min.css' />");
    sb.AppendLine("<style>");
    sb.AppendLine("  th { position: sticky; top: 0; }");
    sb.AppendLine("  td { background-image: linear-gradient(var(--pico-background-color), var(--pico-table-row-stripped-background-color)); }");
    sb.AppendLine("</style>");
    sb.AppendLine("</HEAD><BODY class='fluid-container'>");
    sb.AppendLine("<TABLE><THEAD data-theme='dark'><TR>");
    sb.Append("<TH>Service</TH><TH>Namespace</TH><TH>Lifetime</TH>");
    sb.AppendLine("<TH>Provider</TH><TH>Parameter</TH><TH>Prerequisite</TH>");
    sb.AppendLine("</TR></THEAD>");

    IOrderedEnumerable<DiService> services = _diServices.Values
      .SelectMany(v => v)
      .OrderBy(s => (-s.Parameters.Count, s.Implementation.Name));

    foreach (DiService di in services) {
      string start = di.Parameters.Count > 1
        ? $"<TD rowspan={di.Parameters.Count}>" : "<TD>";
      sb.Append("<TR>");
      sb.Append(start);
      sb.Append(di.Service.HtmlName);
      sb.AppendLine("</TD>");
      sb.Append(start);
      sb.Append(di.Service.NameSpace);
      sb.AppendLine("</TD>");
      sb.Append(start);
      sb.Append(di.Lifetime);
      sb.AppendLine("</TD>");
      sb.Append(start);
      sb.Append(di.HtmlProvider);
      sb.AppendLine("</TD>");

      if (di.Parameters.Count > 0) {
        string prefix = "<TD>";
        foreach ((string param, TypeIdName prereq) in di.Parameters) {
          sb.Append(prefix);
          prefix = "<TR><TD>";
          sb.Append(param);
          sb.Append("</TD><TD>");
          sb.Append(prereq.HtmlName);
          sb.AppendLine("</TD</TR>");
        }
      } else {
        sb.AppendLine("</TD</TR>");
      }
    }

    sb.AppendLine("</TABLE></BODY>");
    return sb.ToString();
  }

  public string DiagramDependencyInjection()
  {
    StringBuilder sb = new();

    sb.AppendLine(@"<script type='module'>");
    sb.AppendLine(@"  import mermaid from 'https://cdn.jsdelivr.net/npm/mermaid@10/dist/mermaid.esm.min.mjs'; ");
    sb.AppendLine(@"  mermaid.initialize({ startOnLoad: true, maxTextSize: 90000, defaultRenderer: 'elk' }); ");
    sb.AppendLine(@"</script>");

    return sb.ToString();
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

internal sealed class TypeIdName(Type type)
{
  internal string Id { get; } = type.FullTypeName();
  internal string NameSpace { get; } = type.Namespace ?? "";
  internal string Name { get; } = type.ExpandTypeName();
  internal string Key { get; } = type.FullTypeName()
      .Replace('<', '_')
      .Replace('>', '_')
      .Replace('+', '_')
      .Replace('.', '_')
      .Replace(',', '_');

  internal string HtmlName => Name.Replace('<', '(').Replace('>', ')');
  internal string Mermaid => "  " + Id + "[\"" + HtmlName + "\"]";
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

  internal string Provider => IsFactory
    ? " () => " + (IsInstance ? "" : Implementation.Name)
    : (IsInstance ? " = " : "") + Implementation.Name;

  internal string HtmlProvider => IsFactory
    ? " () => " + (IsInstance ? "" : Implementation.HtmlName)
    : (IsInstance ? " = " : "") + Implementation.HtmlName;

  private string? _prefix;

  internal string Prefix => _prefix ??=
    "    " + Service.Key +
    ' ' + Lifetime switch {
      ServiceLifetime.Singleton => "-->",
      ServiceLifetime.Scoped => "--o",
      ServiceLifetime.Transient => "--x",
      _ => "..x"
    };

  internal IEnumerable<string> Mermaid
    => Parameters.Select(p => Prefix + '|' + p.Key + '|' + p.Value.Key);
}
