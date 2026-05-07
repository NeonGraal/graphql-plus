namespace GqlPlus;

internal class GqlpGeneratorTypes(GqlpModelOptions modelOptions)
{
  private readonly Map<IAstType> _types = [];
  private readonly Map<IAstObjType> _args = [];

  internal GqlpGeneratorTypes(GqlpGeneratorTypes parent, IEnumerable<IAstTypeArg>? typeArgs = null, IEnumerable<IAstTypeParam>? typeParams = null)
    : this(parent.ModelOptions)
  {
    _types = [.. parent._types];
    _args = [.. parent._args];
    AddArgs(typeArgs ?? [], typeParams ?? []);
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
    ["_" + BuiltIn.AnyType] = "object",
    [BuiltIn.AnyType] = "object",
  };

  internal void AddArgs(IEnumerable<IAstTypeArg> typeArgs, IEnumerable<IAstTypeParam> typeParams)
  {
    IEnumerable<MapPair<IAstObjType>> args = typeArgs
      ?.Zip(typeParams, (a, p) => a.ToPair<IAstObjType>(p.Name))
      ?? [];

    foreach ((string key, IAstObjType value) in args) {
      AddArg(key, value);
    }
  }

  private void AddArg(string key, IAstObjType value)
  {
    if (_args.TryGetValue(key, out IAstObjType arg)) {
      if (arg.Name != value.Name && value.Name != key) {
        _args[key] = value;
      }

      return;
    }

    if (value.Name != key) {
      _args[key] = value;
    }
  }

  /// <summary> Both params will be not null if result true but can't use NotNullWhen </summary>
  internal bool GetArg(string? argName, out IAstObjType arg)
    => _args.TryGetValue(argName.IfWhiteSpace(), out arg);

  internal void AddTypes(params IAstType[] types)
  {
    foreach (IAstType type in types) {
      _types[type.Name] = type;
      foreach (string alias in type.Aliases) {
        if (!_types.ContainsKey(alias)) {
          _types[alias] = type;
        }
      }
    }
  }

  /// <summary> Both params will be not null if result true but can't use NotNullWhen </summary>
  internal bool GetTypeAst<TAst>(string? typeName, out TAst ast)
    where TAst : class, IAstType
  {
    if (!string.IsNullOrWhiteSpace(typeName)
        && _types.TryGetValue(typeName.IfWhiteSpace(), out IAstType type)
        && type is TAst astType) {
      ast = astType;
      return true;
    }

    ast = default!;
    return false;
  }

  internal string TypeName(IAstNamed type, string prefix)
    => TypeName(type.Name, prefix);

  internal string TypeName(string typeName, string prefix)
  {
    if (DotNetTypes.TryGetValue(typeName, out string dotNetType)) {
      return dotNetType;
    }

    if (_types.TryGetValue(typeName, out IAstType theType)) {
      return (theType is IAstEnum ? "" : prefix) + ModelOptions.TypePrefix + theType.Name;
    } else {
      return prefix + ModelOptions.TypePrefix + typeName;
    }
  }
}
