using GqlPlus.Abstractions;

namespace GqlPlus.Generating.Objects;

internal abstract class GenerateForObject<TObjField>
  : GenerateForObject<TObjField, MapPair<string>>
  where TObjField : IAstObjField
{
  internal override IEnumerable<MapPair<string>> TypeMembers(IAstObject<TObjField> ast, GqlpGeneratorTypes types)
    => ast.Fields.Select(f => ModifiedTypeString(f.Type, f, types).ToPair(f.Name.Capitalize()));

  protected override void ClassMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  public {item.Value} {item.Key} {{ get; set; }}");

  protected override void InterfaceMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  {item.Value} {item.Key} {{ get; }}");
}

internal abstract class GenerateForObject<TObjField, TFieldItem>
  : GenerateForClass<IAstObject<TObjField>, TFieldItem>
  where TObjField : IAstObjField
{
  protected void GenerateObjectClasses(IAstObject<TObjField> ast, GqlpGeneratorContext context)
  {
    GenerateBlock(ast, context, AlternateClassHeader, AlternateMembers, AlternateClassMember);
    GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);
  }

  protected void GenerateObjectInterfaces(IAstObject<TObjField> ast, GqlpGeneratorContext context)
  {
    GenerateBlock(ast, context, AlternateInterfaceHeader, AlternateMembers, AlternateInterfaceMember);
    GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
  }

  private string AlternateHeader(IAstObject<TObjField> ast, GqlpGeneratorContext context, string type, string prefix, GqlpBaseType baseType)
  {
    context.Write($"public {type} {context.TypeName(ast, prefix)}{TypeParamsString(ast)}");
    if (ast.Parent is not null && !ast.Parent.IsTypeParam) {
      context.Write("  : " + context.TypeName(ast.Parent, prefix) + TypeArgsString(ast.Parent.Args, context));
      return ",";
    }

    if (context.GeneratorOptions.BaseType == baseType) {
      context.Write("  : " + context.GeneratorOptions.BaseName);
      return ",";
    }

    context.Write($"  // No Base because it's {context.GeneratorOptions.BaseType}");
    return ":";
  }

  private IEnumerable<MapPair<string>> AlternateMembers(IAstObject<TObjField> ast, GqlpGeneratorTypes types)
  {
    IEnumerable<MapPair<string>> alternates = ast.Alternates
        .Select(a => ModifiedTypeString(a, a, types).ToPair(AlternameName(a)));

    if (ast.Parent?.IsTypeParam == true) {
      string parentTypeParam = "T" + ast.Parent.Name.Capitalize();
      alternates = alternates.Append(parentTypeParam.ToPair("_Parent"));
    }

    string objectName = types.TypeName(ast, "I") + "Object" + TypeParamsString(ast);
    return alternates.Append(objectName.ToPair("_" + ast.Name));

    string AlternameName(IAstAlternate alt)
    {
      string name = (types.GetTypeAst(alt.Name, out IAstType type)
        ? type.Name : "").IfWhiteSpace(alt.Name);

      if (alt.EnumValue is not null) {
        name += alt.EnumValue.EnumLabel;
      }

      if (alt.Args.Any(a => a.EnumValue is not null)) {
        return alt.Args.Select(a => a.EnumValue?.EnumValue.Replace(".", "")).Joined();
      }

      return name;
    }
  }

  protected void AlternateClassHeader(IAstObject<TObjField> ast, GqlpGeneratorContext context)
  {
    string interfaceSep = AlternateHeader(ast, context, "class", "", GqlpBaseType.Class);
    context.Write("  " + interfaceSep + " " + context.TypeName(ast, "I") + TypeParamsString(ast));
  }

  protected override void DecoderHeader(IAstObject<TObjField> ast, GqlpGeneratorContext context)
    => context.Write("internal class " + context.TypeName(ast, "") + "Decoder" + TypeParamsString(ast));

  protected override void EncoderHeader(IAstObject<TObjField> ast, GqlpGeneratorContext context)
    => context.Write("internal class " + context.TypeName(ast, "") + "Encoder" + TypeParamsString(ast));

  protected void AlternateClassMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  public {item.Value}? As{item.Key} {{ get; set; }}");

  protected void AlternateInterfaceHeader(IAstObject<TObjField> ast, GqlpGeneratorContext context)
    => AlternateHeader(ast, context, "interface", "I", GqlpBaseType.Interface);

  protected void AlternateInterfaceMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  {item.Value}? As{item.Key} {{ get; }}");

  protected string ModifiedTypeString(IAstObjType type, IAstModifiers modifiers, GqlpGeneratorTypes types)
    => modifiers.Modifiers.Aggregate(TypeString(type, types, "I"), (s, m) => ModifyTypeString(s, m, types));

  protected string ModifyTypeString(string typeStr, IAstModifier modifier, GqlpGeneratorTypes types)
    => modifier.ModifierKind switch {
      ModifierKind.Optional => typeStr + "?",
      ModifierKind.List => $"ICollection<{typeStr}>",
      ModifierKind.Param => ModifyParamString(typeStr, modifier.Key, types),
      ModifierKind.Dictionary => $"IDictionary<{types.TypeName(modifier.Key, "I")}, {typeStr}>",
      _ => typeStr
    };

  protected string ModifyParamString(string typeStr, string key, GqlpGeneratorTypes types)
  {
    if (!types.GetArg(key, out IAstObjType? arg)) {
      return $"IDictionary<T{key.Capitalize()}, {typeStr}>";
    }

    if (arg.IsTypeParam) {
      return ModifyParamString(typeStr, arg.Name, types);
    }

    return $"IDictionary<{types.TypeName(arg.Name, "I")}, {typeStr}>";
  }

  protected string TypeString(IAstObjType type, GqlpGeneratorTypes types, string prefix = "")
  {
    if (type.IsTypeParam) {
      if (!types.GetArg(type.Name, out IAstObjType arg) || arg.Name == type.Name) {
        return "T" + type.Name.Capitalize();
      }

      return TypeString(arg, types, prefix);
    }

    return types.TypeName(type, prefix) + TypeArgsString((type as IAstObjBase)?.Args, types);
  }

  private string TypeArgsString(IEnumerable<IAstTypeArg>? args, GqlpGeneratorTypes types)
  {
    if (args?.Any() == true) {
      return args.Surround("<", ">", a => TypeString(a!, types, "I"), ", ");
    }

    return "";
  }

  private static string TypeParamsString(IAstObject<TObjField> ast)
    => ast.TypeParams.Surround("<", ">", p => "T" + p!.Name.Capitalize(), ",");

  protected override void ClassTail(IAstObject<TObjField> ast, GqlpGeneratorContext context)
  {
    context.Write("");
    MapPair<RequiredField>[] required = RequiredMembers(ast, context);
    RequiredParents parents = DetermineParentAndGrandParent(ast, context);

    IEnumerable<MapPair<RequiredField>> paramList = parents.ParamList(required);
    context.Write($"  public {context.TypeName(ast, "")}Object");
    string prefix = "(";
    foreach ((string key, RequiredField value) in paramList) {
      context.Write($"    {prefix} {value.Type} {key}");
      prefix = ",";
    }

    prefix = prefix == "(" ? "()" : ")";

    if (parents.HasBase) {
      context.Write($"    {prefix} : base({parents.ParentArgs(FieldValue)})");
    } else {
      context.Write("    " + prefix);
    }

    context.Write("  {");
    foreach (KeyValuePair<string, RequiredField> kv in required) {
      context.Write($"    {kv.Key.Capitalize()} = {FieldValue(kv)};");
    }

    context.Write("  }");
  }

  private RequiredParents DetermineParentAndGrandParent(IAstObject<TObjField> ast, GqlpGeneratorContext context)
  {
    if (context.GetTypeAst(ast.Parent?.Name, out IAstObject parentObject) && ast.Parent?.IsTypeParam == false) {
      GqlpGeneratorTypes parentTypes = new(context, ast.Parent.Args, parentObject!.TypeParams);
      RequiredSplit split = ParentRequiredSplit(parentObject!, parentTypes);
      return new(RequiredMembers(parentObject!, parentTypes), split);
    }

    return new([], new());
  }

  private RequiredSplit ParentRequiredSplit(IAstObject ast, GqlpGeneratorTypes types)
  {
    if (ast.Parent is null || ast.Parent.IsTypeParam) {
      return new();
    }

    if (!types.GetTypeAst(ast.Parent.Name, out IAstObject parentObject)) {
      return new();
    }

    GqlpGeneratorTypes parentTypes = new(types, ast.Parent.Args, parentObject!.TypeParams);

    MapPair<RequiredField>[] deep = ParentRequired(parentObject!, parentTypes);
    MapPair<RequiredField>[] shallow = RequiredMembers(parentObject!, parentTypes);

    return new(deep, shallow);
  }

  private static string FieldValue(MapPair<RequiredField> field)
    => string.IsNullOrEmpty(field.Value.Label)
      ? field.Key
      : field.Value.Type + "." + field.Value.Label;

  internal virtual MapPair<RequiredField>[] RequiredMembers(IAstObject ast, GqlpGeneratorTypes types)
  {
    return [.. ast.Fields
      .Where(f => f.Modifiers.LastOrDefault()?.ModifierKind != ModifierKind.Opt)
      .Select(RequiredMember(types))];
  }

  internal Func<IAstObjField, MapPair<RequiredField>> RequiredMember(GqlpGeneratorTypes types)
    => f => {
      string type = ModifiedTypeString(f.Type, f, types);
      string label = "";
      if (f.Type.IsTypeParam) {
        if (types.GetArg(f.Type.Name, out IAstObjType arg) && arg is IAstTypeArg typeArg) {
          label = (typeArg.EnumValue?.EnumLabel).IfWhiteSpace();
        }
      }

      return new RequiredField(type, label).ToPair(f.Name);
    };

  internal virtual MapPair<RequiredField>[] ParentRequired(IAstObject ast, GqlpGeneratorTypes types)
  {
    if (ast.Parent is null || ast.Parent.IsTypeParam) {
      return [];
    }

    if (!types.GetTypeAst(ast.Parent.Name, out IAstObject parentObject)) {
      return [];
    }

    GqlpGeneratorTypes parentTypes = new(types, ast.Parent.Args, parentObject!.TypeParams);

    MapPair<RequiredField>[] grandRequired = ParentRequired(parentObject, parentTypes);
    MapPair<RequiredField>[] parentRequired = RequiredMembers(parentObject, parentTypes);

    return [.. grandRequired, .. parentRequired];
  }

  protected override string TypeHeader(IAstObject<TObjField> ast, GqlpGeneratorContext context, string type, string prefix, GqlpBaseType baseType)
  {
    context.Write($"public {type} {context.TypeName(ast, prefix)}Object{TypeParamsString(ast)}");
    if (ast.Parent is not null && !ast.Parent.IsTypeParam) {
      context.Write("  : " + context.TypeName(ast.Parent, prefix) + "Object" + TypeArgsString(ast.Parent.Args, context));
      return ",";
    }

    if (context.GeneratorOptions.BaseType == baseType) {
      context.Write("  : " + context.GeneratorOptions.BaseName);
      return ",";
    }

    context.Write($"  // No Base because it's {context.GeneratorOptions.BaseType}");
    return ":";
  }

  protected override void TypeInterface(IAstObject<TObjField> ast, GqlpGeneratorContext context, string interfaceSep)
    => context.Write("  " + interfaceSep + " " + context.TypeName(ast, "I") + "Object" + TypeParamsString(ast));
}

internal record struct RequiredField(string Type, string Label);

internal record struct RequiredSplit(MapPair<RequiredField>[] Deep, MapPair<RequiredField>[] Shallow)
{
  public RequiredSplit()
    : this([], [])
  { }
}

internal record struct RequiredParents(MapPair<RequiredField>[] Parent, RequiredSplit Split)
{
  internal readonly IEnumerable<MapPair<RequiredField>> ParamList(MapPair<RequiredField>[] required)
    => Split.Deep
      .Concat(Split.Shallow)
      .Concat(Parent)
      .Where(kv => string.IsNullOrEmpty(kv.Value.Label))
      .Concat(required);

  internal readonly bool HasBase
    => Parent.Length > 0
      || Split.Deep.Length > 0
      || Split.Shallow.Any(kv => string.IsNullOrEmpty(kv.Value.Label));

  internal readonly string ParentArgs(Func<MapPair<RequiredField>, string> fieldValue)
    => Split.Deep
        .Concat(Split.Shallow.Where(kv => string.IsNullOrEmpty(kv.Value.Label)))
        .Concat(Parent)
        .Joined(fieldValue, ", ");
}
