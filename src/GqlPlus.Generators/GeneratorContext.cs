using System.Text;
using System.Text.RegularExpressions;

namespace GqlPlus;

internal sealed class GeneratorContext
{
  private readonly StringBuilder _builder = new();
  private readonly Map<IGqlpType> _types = [];

  public GeneratorContext(string path, GqlModelOptions options)
  {
    File = Path.GetFileNameWithoutExtension(path);
    Options = options;

    AppendLine("// Generated from " + path);
    AppendLine("\n/*");

    AddTypes(BuiltIn.Internal);
    AddTypes(BuiltIn.Basic);
  }

  public string File { get; }
  public GqlModelOptions Options { get; }

  public string SafeFile => Safe(File);

  private readonly Regex _unsafeRegex = new(@"[^_a-zA-Z0-9]+");

  public string Safe(string unsafeName)
    => _unsafeRegex.Replace(unsafeName, "_");

  public void AppendLine(string text)
    => _builder.AppendLine(text);
  public override string ToString()
    => _builder.ToString();

  internal void AddTypes(IGqlpType[] types)
  {
    foreach (IGqlpType type in types) {
      _types[type.Name] = type;
      foreach (string alias in type.Aliases) {
        if (!_types.ContainsKey(alias)) {
          _types[alias] = type;
        }
      }
    }
  }

  internal TAst? GetTypeAst<TAst>(string? parent)
    where TAst : class, IGqlpType
  {
    if (!string.IsNullOrWhiteSpace(parent)
        && _types.TryGetValue(parent!, out IGqlpType type)
        && type is TAst ast) {
      return ast;
    }

    return null;
  }
}
