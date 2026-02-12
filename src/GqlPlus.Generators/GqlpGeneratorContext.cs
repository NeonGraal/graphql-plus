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

    AddTypes(BuiltIn.Internal);
    AddTypes(BuiltIn.Basic);
  }

  public static readonly Map<string> DotNetTypes = new() {
    ["_" + BuiltIn.VoidType] = "void",
    [BuiltIn.VoidType] = "void",
    ["_" + BuiltIn.ValueType] = "GqlpValue",
    [BuiltIn.ValueType] = "GqlpValue",
    ["_" + BuiltIn.UnitType] = "GqlpUnit",
    [BuiltIn.UnitType] = "GqlpUnit",
    ["_" + BuiltIn.StringType] = "string",
    [BuiltIn.StringType] = "string",
    [BuiltIn.StringAlias] = "string",
    ["_" + BuiltIn.ScalarType] = "GqlpScalar",
    [BuiltIn.ScalarType] = "GqlpScalar",
    ["_" + BuiltIn.NumberType] = "decimal",
    [BuiltIn.NumberType] = "decimal",
    [BuiltIn.NumberAlias] = "decimal",
    ["_" + BuiltIn.BooleanType] = "bool",
    [BuiltIn.BooleanType] = "bool",
    [BuiltIn.BooleanAlias] = "bool",
  };

  public string File { get; }
  public GqlpGeneratorOptions GeneratorOptions { get; }
  public GqlpModelOptions ModelOptions { get; }

  public string FileName => $"{ModelOptions.TypePrefix}_{File}_{GeneratorOptions.GeneratorType}.gen.cs";
  public string SafeFile => Safe(File);

  private readonly Regex _unsafeRegex = new(@"[^_a-zA-Z0-9]+");

  public string Safe(string unsafeName)
    => _unsafeRegex.Replace(unsafeName, "_");

  public void WritePrefixLine(string text)
    => (_prefixWritten ? _builder : _prefix).AppendLine(text);

  public void Write(string text)
  {
    if (!_prefixWritten) {
      _prefixWritten = true;
      string prefix = _prefix.ToString();
      if (!string.IsNullOrWhiteSpace(prefix)) {
        _builder.AppendLine(prefix);
      }

      if (string.IsNullOrWhiteSpace(text)) {
        return;
      }
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

  internal string TypeName(IGqlpNamed type, string prefix)
    => TypeName(type.Name, prefix);

  internal string TypeName(string typeName, string prefix)
  {
    if (DotNetTypes.TryGetValue(typeName, out string dotNetType)) {
      return dotNetType;
    }

    if (_types.TryGetValue(typeName, out IGqlpType theType)) {
      return (theType is IGqlpEnum ? "" : prefix) + ModelOptions.TypePrefix + theType.Name;
    } else {
      return prefix + ModelOptions.TypePrefix + typeName;
    }
  }
}
