namespace GqlPlus;

internal class GqlpGeneratorTypes(GqlpModelOptions modelOptions)
{
  private readonly Map<IGqlpType> _types = [];
  private readonly Map<IGqlpObjType> _args = [];

  internal GqlpGeneratorTypes(GqlpGeneratorTypes parent)
    : this(parent.ModelOptions)
  {
    _types = new(parent._types);
    _args = new(parent._args);
  }

  public GqlpModelOptions ModelOptions { get; } = modelOptions;

  public static readonly Map<string> DotNetTypes = new() {
    ["_" + BuiltIn.VoidType] = "void",
    [BuiltIn.VoidType] = "void",
    ["_" + BuiltIn.ValueType] = "GqlpValue",
    [BuiltIn.ValueType] = "GqlpValue",
    ["_" + BuiltIn.UnitType] = "GqlpUnit",
    [BuiltIn.UnitType] = "GqlpUnit",
    [BuiltIn.UnitValue] = "GqlpUnit",
    ["_" + BuiltIn.StringType] = "string",
    [BuiltIn.StringType] = "string",
    [BuiltIn.StringAlias] = "string",
    ["_" + BuiltIn.ScalarType] = "GqlpScalar",
    [BuiltIn.ScalarType] = "GqlpScalar",
    ["_" + BuiltIn.NullType] = "GqlpNull",
    [BuiltIn.NullType] = "GqlpNull",
    [BuiltIn.NullValue] = "GqlpNull",
    ["_" + BuiltIn.NumberType] = "decimal",
    [BuiltIn.NumberType] = "decimal",
    [BuiltIn.NumberAlias] = "decimal",
    ["_" + BuiltIn.BooleanType] = "bool",
    [BuiltIn.BooleanType] = "bool",
    [BuiltIn.BooleanAlias] = "bool",
  };

  internal void AddArgs(IEnumerable<MapPair<IGqlpObjType>> args)
  {
    foreach ((string key, IGqlpObjType value) in args) {
      if (_args.TryGetValue(key, out IGqlpObjType arg)) {
        if (arg.Name != value.Name && value.Name != key) {
          _args[key] = value;
        }
      } else if (value.Name != key) {
        _args[key] = value;
      }
    }
  }

  internal IGqlpObjType? GetArg(string? argName)
  {
    return _args.TryGetValue(argName!, out IGqlpObjType arg)
     ? arg : null;
  }

  internal void AddTypes(params IGqlpType[] types)
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
