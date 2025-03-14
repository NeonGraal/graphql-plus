using System.Collections.Immutable;
using System.IO;
using System.Text;
using Microsoft.CodeAnalysis;

namespace GqlPlus;

[Generator(LanguageNames.CSharp)]
public class BuildDataGenerator : IIncrementalGenerator
{
  private readonly string _namespace;

  public BuildDataGenerator(string ns)
    => _namespace = ns;

  public BuildDataGenerator()
    => _namespace = "GqlPlus";

  public void Initialize(IncrementalGeneratorInitializationContext context)
  {
    IncrementalValueProvider<ImmutableArray<string>> gitDetails = context.AdditionalTextsProvider
                                .Where(text => text.Path.EndsWith("git-details.txt", StringComparison.OrdinalIgnoreCase))
                                .Select((text, token) => text.GetText(token)?.ToString())
                                .Where(text => text is not null)!
                                .Collect<string>();

    IncrementalValueProvider<ImmutableArray<string>> samples = context.AdditionalTextsProvider
                                .Select((text, token) => text.Path)
                                .Where(path => Path.GetExtension(path).StartsWith(".g", StringComparison.OrdinalIgnoreCase))
                                .Collect();

    context.RegisterSourceOutput(samples.Combine(gitDetails), GenerateCode);
  }

  private record struct DataPath(string Parent, string[] Directory, string FileName);

  private static DataPath FromArray(string[] path)
  {
    int first = Array.IndexOf(path, "Samples") + 1;
    int last = path.Length - 1;
    string filename = Path.GetFileNameWithoutExtension(path[last]);
    string[] dir = [];
    if (first + 1 < last) {
      dir = [.. path.Skip(first + 1).Take(last - first - 1)];
    }

    return new(path[first], dir, filename);
  }

  private record struct FileDetails(string Collected, string From, StringBuilder Builder)
  {
    internal readonly void AppendLine(string text = "")
      => Builder.AppendLine(text);

    internal readonly string Source
      => Builder.ToString();
  }

  private void GenerateCode(SourceProductionContext context, (ImmutableArray<string> Left, ImmutableArray<string> Right) tuple)
  {
    (ImmutableArray<string> array, ImmutableArray<string> gitDetails) = tuple;

    if (array.IsDefaultOrEmpty) {
      return;
    }

    string? collected = gitDetails.FirstOrDefault()?.Trim();

    IEnumerable<DataPath> filePaths = array
      .Select(path => path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar))
      .Where(path => path.Length > 2)
      .Select(FromArray);

    foreach (IGrouping<string, DataPath> parent in filePaths.GroupBy(path => path.Parent)) {
      FileDetails details = new(collected ?? "", PathCombine("Samples", parent.Key), new("// Generated from "));
      details.AppendLine(details.From);
      details.AppendLine("// Collected from " + collected);
      details.AppendLine();
      details.AppendLine($"namespace {_namespace};");

      foreach (IGrouping<string, DataPath> directory in parent.GroupBy(g => PathCombine(g.Directory))) {
        GenerateDataClass(details, directory.Key, directory);
      }

      context.AddSource(parent.Key + "Data.gen.cs", details.Source);
    }

    static string PathCombine(params string[] paths)
      => string.Join("/", paths);
  }

  static void GenerateDataClass(FileDetails details, string directory, IEnumerable<DataPath> paths)
  {
    string className = (details.From + directory).Replace("/", "") + "Data";
    details.AppendLine();
    details.AppendLine("public class " + className);
    details.AppendLine("  : TheoryData<string>");
    details.AppendLine("{");
    details.AppendLine($"  public {className}()");
    details.AppendLine("  {");

    foreach (DataPath file in paths.OrderBy(f => f.FileName, StringComparer.OrdinalIgnoreCase)) {
      details.AppendLine($"    Add(\"{file.FileName}\");");
    }

    details.AppendLine("  }");
    details.AppendLine();
    details.AppendLine($"  public const string From = \"{details.From}/{directory}\";");
    details.AppendLine($"  public const string Collected = \"{details.Collected}\";");
    details.AppendLine("}");
  }
}
