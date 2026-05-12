using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Fluid;
using Microsoft.Extensions.FileProviders;
using Shouldly;

namespace GqlPlus;

public static class DiFluid
{
  private const int MaxGroupSize = 5;

  private static readonly FluidParser s_parser = new();
  private static readonly Map<IFluidTemplate> s_templates = [];
  private static readonly TemplateOptions s_options = new();

  static DiFluid()
  {
    s_options.FileProvider = new EmbeddedFileProvider(Assembly.GetAssembly(typeof(DiFluid))!, "GqlPlus.DI");
    s_options.MemberAccessStrategy.Register<DiLink>();
    s_options.MemberAccessStrategy.Register<DiTree>();
  }

  public static void Register<T>() where T : class
    => s_options.MemberAccessStrategy.Register<T>();

  private static IFluidTemplate GetTemplate(string template)
  {
    lock (s_templates) {
      return s_templates.GetValueOrCreate(template,
        k => s_parser.Parse("{% render '" + k + "' %}")
          ?? throw new InvalidOperationException($"Failed to parse template '{k}'"));
    }
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
      if (ids.Contains(di.Safe)) {
        continue;
      }

      AddToGroup(di);
      ids.UnionWith(subGroupIds);
      subGroupIds.Clear();

      if (group.Count > MaxGroupSize || group.Count > 0 && group.Count < subGroup.Count) {
        groups[name] = [.. group];
        name = di.Safe;
        group.Clear();
      } else if (string.IsNullOrWhiteSpace(name)) {
        name = di.Safe;
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
      if (subGroupIds.Contains(di.Safe)) {
        return;
      }

      subGroup.Add(di);
      subGroupIds.Add(di.Safe);

      foreach (string safe in di.SafeRequires) {
        if (!subGroupIds.Contains(safe)
          && tree.TryGetValue(safe, out DiTree? requires)) {
          if (ids.Contains(safe)) {
            subGroup.Add(new(requires) { Requires = requires.Requires });
            subGroupIds.Add(safe);
          } else {
            AddToGroup(requires);
          }
        }
      }
    }
  }

  private static readonly string s_solutionDir = Assembly.GetAssembly(typeof(DiFluid))?.Location.Split("test")[0] ?? "";

  public static void WriteHtmlFile(this string contents, string dir, string file)
  {
    string dirPath = Path.Join(s_solutionDir, "test", "Html", dir);
    if (!Directory.Exists(dirPath)) {
      Directory.CreateDirectory(dirPath);
    }

    string filePath = Path.Join(dirPath, file + ".html");
    const int MaxAttempts = 8;
    for (int attempt = 1; attempt <= MaxAttempts; ++attempt) {
      try {
        File.WriteAllText(filePath, contents);
        return;
      } catch (IOException) {
        if (attempt >= MaxAttempts) {
          throw;
        }

        Thread.Sleep(50 * attempt);
      } catch (UnauthorizedAccessException) {
        if (attempt >= MaxAttempts) {
          throw;
        }

        Thread.Sleep(50 * attempt);
      }
    }
  }

  public static async Task WriteHtmlFileAsync(this ValueTask<string> contents, string dir, string file)
  {
    string dirPath = Path.Join(s_solutionDir, "test", "Html", dir);
    if (!Directory.Exists(dirPath)) {
      Directory.CreateDirectory(dirPath);
    }

    string filePath = Path.Join(dirPath, file + ".html");
    const int MaxAttempts = 8;
    string text = await contents;
    for (int attempt = 1; attempt <= MaxAttempts; ++attempt) {
      try {
        await File.WriteAllTextAsync(filePath, text);
        return;
      } catch (IOException) {
        if (attempt >= MaxAttempts) {
          throw;
        }

        await Task.Delay(50 * attempt);
      } catch (UnauthorizedAccessException) {
        if (attempt >= MaxAttempts) {
          throw;
        }

        await Task.Delay(50 * attempt);
      }
    }
  }
}

public class DiBase
{
  protected static string SafeName(string name)
    => name.ThrowIfNull()
      .Replace('<', '(')
      .Replace('>', ')');
  protected static string KeyName(string name)
    => name.ThrowIfNull()
      .Replace('<', '_')
      .Replace('>', '_')
      .Replace('+', '_')
      .Replace('.', '_')
      .Replace(',', '_')
      .Replace("::", "_", StringComparison.Ordinal)
      .Replace("[]", "_Array_", StringComparison.Ordinal);
}

public sealed class DiTree(string name, bool isHref, int requiredBy)
  : DiBase
{
  public string Name { get; } = name;
  public bool IsHref { get; } = isHref;
  public int RequiredBy { get; } = requiredBy;
  public required Map<string> Requires { get; init; }

  public DiTree([NotNull] DiTree other)
    : this(other.Name, other.IsHref, other.RequiredBy)
  { }

  public IEnumerable<string> SafeRequires
    => Requires.Select(r => r.Value).Distinct();

  public IEnumerable<DiLink> Links
    => Requires.Select(r => new DiLink(Name, r.Value, r.Key));

  public string Safe => SafeName(Name);
  public string Key => KeyName(Name);

  public override string? ToString()
    => Requires
    .Select(kv => $"  {kv.Key:-15} {kv.Value}")
    .Prepend(Name + (IsHref ? " ~" : " :"))
    .Joined(Environment.NewLine);
}

public sealed class DiLink(string from, string to, string style)
  : DiBase
{
  public string From { get; } = from;
  public string FromKey => KeyName(From);
  public string To { get; } = to;
  public string ToKey => KeyName(To);
  public string Style { get; } = style;
}

