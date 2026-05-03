using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Argon;
using Fluid;
using Microsoft.Extensions.FileProviders;

namespace GqlPlus;

public static class DiFluid
{
  private const int MaxGroupSize = 5;

  private static readonly FluidParser s_parser = new();
  private static readonly Map<IFluidTemplate> s_templates = [];
  private static readonly TemplateOptions s_options = new();

  static DiFluid()
  {
    s_options.FileProvider = new EmbeddedFileProvider(Assembly.GetAssembly(typeof(DependencyInjectionChecks))!, "GqlPlus.DI");
    s_options.MemberAccessStrategy.Register<DiService>();
    s_options.MemberAccessStrategy.Register<DiLink>();
    s_options.MemberAccessStrategy.Register<DiTree>();
    s_options.MemberAccessStrategy.Register<TypeIdName>();
  }

  private static IFluidTemplate GetTemplate(string template)
  {
    if (!s_templates.TryGetValue(template, out IFluidTemplate? value)) {
      value = s_parser.Parse("{% render '" + template + "' %}")
        ?? throw new InvalidOperationException($"Failed to parse template '{template}'");
      s_templates.TryAdd(template, value);
    }

    return value;
  }

  public static void CheckFiles(string label)
  {
    IFileProvider files = s_options.FileProvider;

    IDirectoryContents contents = files.GetDirectoryContents("");

    contents.ShouldSatisfyAllConditions(label,
      c => c.Exists.ShouldBeTrue(),
      c => c.ShouldNotBeEmpty(),
      c => c.ShouldContain(fi => fi.Name == "pico.liquid"));
  }

  public static void WriteTree(string label, [NotNull] IMap<DiTree> tree)
  {
    TemplateContext context = new(s_options);
    context.SetValue("name", label);
    context.SetValue("services", tree.Values.OrderBy(s => (s.RequiredBy, s.Name)));

    IFluidTemplate template = GetTemplate("table");
    template.Render(context).WriteHtmlFile("DI/Table", label);

    DiLink[] links = [.. tree.Values.SelectMany(s => s.Links)];
    string[] nodes = [.. links
      .SelectMany(l => new string[] { l.From, l.To })
      .Distinct()];

    context = new(s_options);
    context.SetValue("name", label);
    context.SetValue("nodes", nodes);
    context.SetValue("links", links);

    template = GetTemplate("force3d");
    template.Render(context).WriteHtmlFile("DI/Force-3D", label);

    HashSet<string> ids = [];
    Map<DiTree[]> groups = [];
    string name = "";
    List<DiTree> group = [];
    List<DiTree> subGroup = [];
    HashSet<string> subGroupIds = [];

    IOrderedEnumerable<DiTree> withRequires = tree.Values
      .Where(s => s.Requires.Any())
      .OrderBy(s => (s.Requires.Count - s.RequiredBy, s.Name));

    foreach (DiTree di in withRequires) {
      if (ids.Contains(di.Name)) {
        continue;
      }

      AddToGroup(di);
      ids.UnionWith(subGroupIds);
      subGroupIds.Clear();

      if (group.Count > MaxGroupSize || group.Count > 0 && group.Count < subGroup.Count) {
        groups[name] = [.. group];
        name = di.Name;
        group.Clear();
      } else if (string.IsNullOrWhiteSpace(name)) {
        name = di.Name;
      }

      group.AddRange(subGroup);
      subGroup.Clear();
    }

    if (group.Count > 0) {
      groups[name] = [.. group];
    }

    context = new(s_options);
    context.SetValue("name", label);
    context.SetValue("services", groups);

    template = GetTemplate("diagram");
    template.Render(context).WriteHtmlFile("DI/Diagram", label);

    void AddToGroup(DiTree di)
    {
      if (subGroupIds.Contains(di.Name)) {
        return;
      }

      subGroup.Add(di);
      subGroupIds.Add(di.Name);

      foreach ((string key, string prereq) in di.Requires) {
        if (!subGroupIds.Contains(prereq)
          && tree.TryGetValue(prereq, out DiTree? requires)) {
          if (ids.Contains(prereq)) {
            subGroup.Add(new(requires) { Requires = requires.Requires });
            subGroupIds.Add(requires.Name);
          } else {
            AddToGroup(requires);
          }
        }
      }
    }
  }
}

public sealed class DiTree(string name, bool isHref, int requiredBy)
{
  public string Name { get; } = name;
  public bool IsHref { get; } = isHref;
  public int RequiredBy { get; } = requiredBy;
  public required Map<string> Requires { get; init; }

  public DiTree([NotNull] DiTree other)
    : this(other.Name, other.IsHref, other.RequiredBy)
  { }

  public IEnumerable<DiLink> Links
    => Requires.Select(r => new DiLink(Name, r.Value, r.Key));

  public override string? ToString()
    => Requires
    .Select(kv => $"  {kv.Key:-15} {kv.Value}")
    .Prepend(Name + (IsHref ? " ~" : " :"))
    .Joined(Environment.NewLine);
}

public sealed class DiLink(string from, string to, string style)
{
  public string From { get; } = from;
  public string To { get; } = to;
  public string Style { get; } = style;
}

