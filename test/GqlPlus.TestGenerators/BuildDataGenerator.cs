using System.Collections.Immutable;
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

  private record struct DataPath(string[] Prefix, string Parent, string Directory, string FileName);

  private static DataPath FromArray(string[] path)
  {
    int prefix = path.Length - 3;
    string filename = Path.GetFileNameWithoutExtension(path[prefix + 2]);
    return new([.. path.Take(prefix)], path[prefix], path[prefix + 1], filename);
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
      DataPath first = parent.First();
      string from = string.Join("/", first.Prefix.Append(parent.Key));
      StringBuilder builder = new("// Generated from ");
      builder.AppendLine(from);
      builder.Append("// Collected from ");
      builder.AppendLine(collected);
      builder.AppendLine();
      builder.AppendLine($"namespace {_namespace};");

      foreach (IGrouping<string, DataPath> directory in parent.GroupBy(g => g.Directory)) {
        string className = parent.Key + directory.Key + "Data";
        builder.AppendLine();
        builder.AppendLine("public class " + className);
        builder.AppendLine("  : TheoryData<string>");
        builder.AppendLine("{");
        builder.AppendLine($"  public {className}()");
        builder.AppendLine("  {");

        foreach (DataPath file in directory.OrderBy(f => f.FileName, StringComparer.OrdinalIgnoreCase)) {
          builder.AppendLine($"    Add(\"{file.FileName}\");");
        }

        builder.AppendLine("  }");
        builder.AppendLine();
        builder.AppendLine($"  public const string From = \"{from}/{directory.Key}\";");
        builder.AppendLine($"  public const string Collected = \"{collected}\";");
        builder.AppendLine("}");
      }

      context.AddSource(parent.Key + "Data.gen.cs", builder.ToString());
    }
  }
}
