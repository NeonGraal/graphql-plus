using GqlPlus.Abstractions;

namespace GqlPlus.Generating.Objects;

internal class GenerateForObject<TObjField>
  : GenerateForObject<TObjField, MapPair<string>>
  where TObjField : IGqlpObjField
{
  internal override IEnumerable<MapPair<string>> TypeMembers(IGqlpObject<TObjField> ast, GqlpGeneratorTypes types)
    => ast.Fields.Select(f => ModifiedTypeString(f.Type, f, types).ToPair(f.Name.Capitalize()));

  protected override void ClassMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  public {item.Value} {item.Key} {{ get; set; }}");

  protected override void InterfaceMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  {item.Value} {item.Key} {{ get; }}");
}

internal abstract class GenerateForObject<TObjField, TFieldItem>
  : GenerateForClass<IGqlpObject<TObjField>, TFieldItem>
  where TObjField : IGqlpObjField
{
  public GenerateForObject()
  {
    _generators[GqlpGeneratorType.Interface] = GenerateObjectInterfaces;
    _generators[GqlpGeneratorType.Implementation] = GenerateObjectClasses;
  }

  private void GenerateObjectClasses(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    GenerateBlock(ast, context, AlternateClassHeader, AlternateMembers, AlternateClassMember);
    GenerateBlock(ast, context, ClassHeader, TypeMembers, ClassMember, ClassTail);
  }

  private void GenerateObjectInterfaces(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    GenerateBlock(ast, context, AlternateInterfaceHeader, AlternateMembers, AlternateInterfaceMember);
    GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
  }

  private string AlternateHeader(IGqlpObject<TObjField> ast, GqlpGeneratorContext context, string type, string prefix, GqlpBaseType baseType)
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

  private IEnumerable<MapPair<string>> AlternateMembers(IGqlpObject<TObjField> ast, GqlpGeneratorTypes types)
  {
    IEnumerable<MapPair<string>> alternates = ast.Alternates
        .Select(a => ModifiedTypeString(a, a, types).ToPair(AlternameName(a)));

    if (ast.Parent?.IsTypeParam == true) {
      string parentTypeParam = "T" + ast.Parent.Name.Capitalize();
      alternates = alternates.Append(parentTypeParam.ToPair("_Parent"));
    }

    string objectName = types.TypeName(ast, "I") + "Object" + TypeParamsString(ast);
    return alternates.Append(objectName.ToPair("_" + ast.Name));

    string AlternameName(IGqlpAlternate alt)
    {
      IGqlpType? type = types.GetTypeAst<IGqlpType>(alt.Name);
      string name = (type?.Name).IfWhiteSpace(alt.Name);

      if (alt.EnumValue is not null) {
        name += alt.EnumValue.EnumLabel;
      }

      if (alt.Args.Any(a => a.EnumValue is not null)) {
        return alt.Args.Select(a => a.EnumValue?.EnumValue.Replace(".", "")).Joined();
      }

      return name;
    }
  }

  protected void AlternateClassHeader(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    string interfaceSep = AlternateHeader(ast, context, "class", "", GqlpBaseType.Class);
    context.Write("  " + interfaceSep + " " + context.TypeName(ast, "I") + TypeParamsString(ast));
  }

  protected void AlternateClassMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  public {item.Value}? As{item.Key} {{ get; set; }}");

  protected void AlternateInterfaceHeader(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
    => AlternateHeader(ast, context, "interface", "I", GqlpBaseType.Interface);

  protected void AlternateInterfaceMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  {item.Value}? As{item.Key} {{ get; }}");

  protected string ModifiedTypeString(IGqlpObjType type, IGqlpModifiers modifiers, GqlpGeneratorTypes types)
    => modifiers.Modifiers.Aggregate(TypeString(type, types, "I"), (s, m) => ModifyTypeString(s, m, types));

  protected string ModifyTypeString(string typeStr, IGqlpModifier modifier, GqlpGeneratorTypes types)
    => modifier.ModifierKind switch {
      ModifierKind.Optional => typeStr + "?",
      ModifierKind.List => $"ICollection<{typeStr}>",
      ModifierKind.Param => ModifyParamString(typeStr, modifier.Key, types),
      ModifierKind.Dictionary => $"IDictionary<{types.TypeName(modifier.Key, "I")}, {typeStr}>",
      _ => typeStr
    };

  protected string ModifyParamString(string typeStr, string key, GqlpGeneratorTypes types)
  {
    IGqlpObjType? arg = types.GetArg(key);
    if (arg is null) {
      return $"IDictionary<T{key.Capitalize()}, {typeStr}>";
    }

    if (arg.IsTypeParam) {
      return ModifyParamString(typeStr, arg.Name, types);
    }

    return $"IDictionary<{types.TypeName(arg.Name, "I")}, {typeStr}>";
  }

  protected string TypeString(IGqlpObjType type, GqlpGeneratorTypes types, string prefix = "")
  {
    if (type.IsTypeParam) {
      IGqlpObjType? arg = types.GetArg(type.Name);
      if (arg is null || arg.Name == type.Name) {
        return "T" + type.Name.Capitalize();
      }

      return TypeString(arg, types, prefix);
    }

    return types.TypeName(type, prefix) + TypeArgsString((type as IGqlpObjBase)?.Args, types);
  }

  private string TypeArgsString(IEnumerable<IGqlpTypeArg>? args, GqlpGeneratorTypes types)
  {
    if (args?.Any() == true) {
      return args.Surround("<", ">", a => TypeString(a!, types, "I"), ", ");
    }

    return "";
  }

  private static string TypeParamsString(IGqlpObject<TObjField> ast)
    => ast.TypeParams.Surround("<", ">", p => "T" + p!.Name.Capitalize(), ",");

  protected override void ClassTail(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    context.Write("");
    MapPair<string>[] required = RequiredMembers(ast, context);
    MapPair<string>[] parent = ParentRequired(ast, context);

    string paramList = parent.Concat(required).Joined(kv => kv.Value + " " + kv.Key, ", ");
    context.Write($"  public {context.TypeName(ast, "")}Object({paramList})");
    if (parent.Length > 0) {
      string parentArgs = parent.Joined(kv => kv.Key, ", ");
      context.Write($"    : base({parentArgs})");
    }

    context.Write("  {");
    foreach (KeyValuePair<string, string> kv in required) {
      context.Write($"    {kv.Key.Capitalize()} = {kv.Key};");
    }

    context.Write("  }");
  }
  internal virtual MapPair<string>[] RequiredMembers(IGqlpObject<TObjField> ast, GqlpGeneratorTypes types)
    => [.. ast.Fields
      .Where(f => f.Modifiers.LastOrDefault()?.ModifierKind != ModifierKind.Opt)
      .Select(f => ModifiedTypeString(f.Type, f, types).ToPair(f.Name))];

  internal virtual MapPair<string>[] ParentRequired(IGqlpObject<TObjField> ast, GqlpGeneratorTypes types)
  {
    if (ast.Parent is null || ast.Parent.IsTypeParam) {
      return [];
    }

    IGqlpObject? parentObject = types.GetTypeAst<IGqlpObject>(ast.Parent.Name);
    if (parentObject is not IGqlpObject<TObjField> parentAst) {
      return [];
    }

    GqlpGeneratorTypes parentTypes = new(types);
    parentTypes.AddArgs(ast.Parent.Args
      .Zip(parentAst.TypeParams, (a, p) => a.ToPair<IGqlpObjType>(p.Name)));

    MapPair<string>[] grandRequired = ParentRequired(parentAst, parentTypes);
    MapPair<string>[] parentRequired = RequiredMembers(parentAst, parentTypes);

    return [.. grandRequired, .. parentRequired];
  }

  protected override string TypeHeader(IGqlpObject<TObjField> ast, GqlpGeneratorContext context, string type, string prefix, GqlpBaseType baseType)
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

  protected override void TypeInterface(IGqlpObject<TObjField> ast, GqlpGeneratorContext context, string interfaceSep)
    => context.Write("  " + interfaceSep + " " + context.TypeName(ast, "I") + "Object" + TypeParamsString(ast));
}
