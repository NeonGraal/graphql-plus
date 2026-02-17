using GqlPlus.Abstractions;

namespace GqlPlus.Generating.Objects;

internal class GenerateForObject<TObjField>
  : GenerateForObject<TObjField, MapPair<string>>
  where TObjField : IGqlpObjField
{
  internal override IEnumerable<MapPair<string>> TypeMembers(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
    => ast.Fields.Select(f => ModifiedTypeString(f.Type, f, context).ToPair(f.Name.Capitalize()));

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

  private IEnumerable<MapPair<string>> AlternateMembers(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    IEnumerable<MapPair<string>> alternates = ast.Alternates
        .Select(a => ModifiedTypeString(a, a, context).ToPair(AlternameName(a)));
    if (ast.Parent?.IsTypeParam == true) {
      string parentTypeParam = "T" + ast.Parent.Name.Capitalize();
      alternates = alternates.Append(parentTypeParam.ToPair("_Parent"));
    }

    string objectName = context.TypeName(ast, "I") + "Object" + TypeParamsString(ast);
    return alternates.Append(objectName.ToPair("_" + ast.Name));

    string AlternameName(IGqlpAlternate alt)
    {
      IGqlpType? type = context.GetTypeAst<IGqlpType>(alt.Name);
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

  protected string ModifiedTypeString(IGqlpObjType type, IGqlpModifiers modifiers, GqlpGeneratorContext context)
    => modifiers.Modifiers.Aggregate(TypeString(type, context, "I"), (s, m) => ModifyTypeString(s, m, context));

  protected virtual string ModifyTypeString(string typeStr, IGqlpModifier modifier, GqlpGeneratorContext context)
    => modifier.ModifierKind switch {
      ModifierKind.Optional => typeStr + "?",
      ModifierKind.List => $"ICollection<{typeStr}>",
      ModifierKind.Param => $"IDictionary<T{modifier.Key.Capitalize()}, {typeStr}>",
      ModifierKind.Dictionary => $"IDictionary<{context.TypeName(modifier.Key, "I")}, {typeStr}>",
      _ => typeStr
    };

  protected virtual string TypeString(IGqlpObjType type, GqlpGeneratorContext context, string prefix = "")
  {
    if (type.IsTypeParam) {
      return "T" + type.Name.Capitalize();
    }

    return context.TypeName(type, prefix) + TypeArgsString((type as IGqlpObjBase)?.Args, context);
  }

  private string TypeArgsString(IEnumerable<IGqlpTypeArg>? args, GqlpGeneratorContext context)
  {
    if (args?.Any() == true) {
      return args.Surround("<", ">", a => TypeString(a!, context, "I"), ", ");
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
  internal virtual MapPair<string>[] RequiredMembers(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
    => [.. ast.Fields
      .Where(f => f.Modifiers.LastOrDefault()?.ModifierKind != ModifierKind.Opt)
      .Select(f => ModifiedTypeString(f.Type, f, context).ToPair(f.Name))];

  internal virtual MapPair<string>[] ParentRequired(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    IGqlpObject? parentObject = context.GetTypeAst<IGqlpObject>(ast.Parent?.Name);
    if (parentObject is not IGqlpObject<TObjField> parentAst) {
      return [];
    }

    MapPair<string>[] grandRequired = ParentRequired(parentAst, context);
    MapPair<string>[] parentRequired = RequiredMembers(parentAst, context);

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
