using System.Text;
using System.Text.RegularExpressions;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus;

internal sealed class GqlpGeneratorContext
{
  private readonly StringBuilder _builder = new();
  private readonly Map<IGqlpType> _types = [];
  private readonly StringBuilder _prefix;
  private bool _prefixWritten;

  public GqlpGeneratorContext(string path, GqlpGeneratorOptions generatorOptions, GqlpModelOptions modelOptions)
  {
    File = Path.GetFileNameWithoutExtension(path);
    GeneratorOptions = generatorOptions;
    ModelOptions = modelOptions;

    _prefix = new();
    _prefix.AppendLine($"// Generated from {path} for {GeneratorOptions.GeneratorType}");
    _prefix.AppendLine("\n/*");

    AddTypes(BuiltIn.Internal);
    AddTypes(BuiltIn.Basic);
  }

  public string File { get; }
  public GqlpGeneratorOptions GeneratorOptions { get; }
  public GqlpModelOptions ModelOptions { get; }

  public string FileName => $"{ModelOptions.TypePrefix}_{File}_{GeneratorOptions.GeneratorType}.gen.cs";
  public string SafeFile => Safe(File);

  private readonly Regex _unsafeRegex = new(@"[^_a-zA-Z0-9]+");

  public string Safe(string unsafeName)
    => _unsafeRegex.Replace(unsafeName, "_");

  public void WritePrefix(string text)
    => (_prefixWritten ? _builder : _prefix).Append(text);

  public void Write(string text)
  {
    if (!_prefixWritten) {
      _builder.AppendLine(_prefix.ToString());
      _prefixWritten = true;
    }

    _builder.AppendLine(text);
  }

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

  internal TAst? GetTypeAst<TAst>(string? typeName)
    where TAst : class, IGqlpType
  {
    if (!string.IsNullOrWhiteSpace(typeName)
        && _types.TryGetValue(typeName!, out IGqlpType type)
        && type is TAst ast) {
      return ast;
    }

    return null;
  }

  internal string TypeName(IGqlpNamed type)
    => ModelOptions.TypePrefix +
      (_types.TryGetValue(type.Name, out IGqlpType theType)
      ? theType.Name : type.Name);
}
