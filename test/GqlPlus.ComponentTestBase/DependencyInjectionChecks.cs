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
  public string HtmlDiagramDependencyInjectionContainer()
  {
    DiagramDependencyInjectionContainer();

    StringBuilder sb = new();

    foreach (IGrouping<string, Node> group in nodes.Values.GroupBy(n => n.Group).OrderByDescending(g => g.Count())) {
      sb.Append("<h2>Group ");
      sb.Append(group.Key);
      sb.AppendLine("</h2>");
      sb.AppendLine("<pre class='mermaid'>");
      sb.AppendLine("flowchart TB");

      foreach (Node node in group.OrderBy(n => n.Edges.Count)) {
        sb.AppendLine(node.Mermaid());
        foreach (Edge edge in node.Edges) {
          sb.AppendLine(edge.Mermaid(node));
        }
      }

      sb.AppendLine("</pre>");
    }

    sb.AppendLine(@"<script type='module'>");
    sb.AppendLine(@"  import mermaid from 'https://cdn.jsdelivr.net/npm/mermaid@10/dist/mermaid.esm.min.mjs'; ");
    sb.AppendLine(@"  mermaid.initialize({ startOnLoad: true, maxTextSize: 90000, defaultRenderer: 'elk' }); ");
    sb.AppendLine(@"</script>");

    return sb.ToString();
  }

  private Node GetNode(Type type)
  {
    string key = type.ExpandTypeName();
    string group = type.Name.Split('`')[0];
    if (type.DeclaringType is not null) {
      group = type.DeclaringType.Name.Split('`')[0];
    }

    //if (type.IsGenericType || type.IsGenericTypeDefinition) {
    //  Type[] args = type.GetGenericArguments();
    //  if (args.Length > 0) {
    //    group = args[0].Name.Split('`')[0];
    //  }
    //}

    if (!nodes.TryGetValue(key, out Node? node)) {
      node = new(key, group);
      nodes.Add(key, node);
    }

    return node;
  }

  private Node GetNode(Type type, string ctor)
  {
    string key = type.ExpandTypeName() + ctor;
    string group = type.Name.Split('`')[0];
    if (!nodes.TryGetValue(key, out Node? node)) {
      node = new(key, group);
      nodes.Add(key, node);
    }

    return node;
  }

  private void DiagramDependencyInjectionContainer()
  {
    foreach (ServiceDescriptor sd in services) {
      Node from = GetNode(sd.ServiceType);

      string link = sd.Lifetime switch {
        ServiceLifetime.Singleton => "-->",
        ServiceLifetime.Scoped => "--o",
        ServiceLifetime.Transient => "--x",
        _ => "..x"
      };
      if (sd.ImplementationType is not null) {
        Node to = GetNode(sd.ImplementationType);
        if (from.Id != to.Id) {
          from.Add(to, link, "ctor");
        }

        DiagramConstructor(from, to, sd.ImplementationType);
      } else if (sd.ImplementationFactory is not null) {
        //        DiagramLink(service, link, "_Factory", "func", sb, ids);
      } else if (sd.ImplementationInstance is not null) {
        Node to = GetNode(sd.ImplementationInstance.GetType());
        from.Add(to, link, "inst");
      }
    }
  }

  private void DiagramConstructor(Node parent, Node from, Type implementationType)
  {
    foreach (ConstructorInfo constructor in implementationType.GetConstructors()) {
      ParameterInfo[] parameters = constructor.GetParameters();

      if (parameters.Length < 1) {
        continue;
      }

      parent.MakeGroup();

      Node ctor = GetNode(implementationType, constructor.Name);
      from.Add(ctor, "-->", "ctor");

      foreach (ParameterInfo parameter in parameters) {
        string parameterType = parameter.ParameterType.ExpandTypeName();
        if (!parameterType.StartsWith("ILogger", StringComparison.Ordinal)) {
          Node param = GetNode(parameter.ParameterType);
          ctor.Add(param, "-->", "param " + parameter.Name);
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

public class Node(string key)
{
  internal string Id { get; } = key
      .Replace('<', '_')
      .Replace('>', '_')
      .Replace('+', '_')
      .Replace('.', '_')
      .Replace(',', '_');
  internal string Group { get; set; } = "";
  internal string Description { get; } = key
    .Replace('<', '(')
    .Replace('>', ')');
  internal List<Edge> Edges { get; } = [];
  internal List<Node> Reverse { get; } = [];

  internal void Add(Node other, string link, string tag)
  {
    Edges.Add(new(other, link, tag));
    other.Reverse.Add(this);
  }

  private string GetGroup()
  {
    if (!string.IsNullOrWhiteSpace(Group)) {
      return Group;
    }

    string[] revGroups = Reverse
      .Select(r => r.Group)
      .Where(g => !string.IsNullOrWhiteSpace(g))
      .ToArray();

    return revGroups.Length < 1
      ? ""
      : revGroups.Aggregate(
        (a, r) => string.Compare(a, r, StringComparison.Ordinal) < 0
          ? a
          : r);
  }

  public void MakeGroup(string group = "")
  {

  }

  public string Mermaid()
    => "  " + Id + "[\"" + Description + "\"]";
}

public record class Edge(Node To, string Link, string Tag)
{
  public string Mermaid(Node from)
    => "    " + from.ThrowIfNull().Id + ' ' + Link + '|' + Tag + "| " + To.Id;
}
