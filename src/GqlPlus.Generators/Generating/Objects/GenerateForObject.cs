using System.Runtime.InteropServices.ComTypes;
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
      string name = (types.GetTypeAst(alt.Name, out IGqlpType type)
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
    if (!types.GetArg(key, out IGqlpObjType? arg)) {
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
      if (!types.GetArg(type.Name, out IGqlpObjType arg) || arg.Name == type.Name) {
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
    MapPair<RequiredField>[] required = RequiredMembers(ast, context);
    (MapPair<RequiredField>[] parent, MapPair<RequiredField>[] grandParent) = DetermineParentAndGrandParent(ast, context);

    IEnumerable<MapPair<RequiredField>> paramList = grandParent
      .Concat(parent)
      .Where(kv => string.IsNullOrEmpty(kv.Value.Label))
      .Concat(required);
    context.Write($"  public {context.TypeName(ast, "")}Object");
    string prefix = "(";
    foreach ((string key, RequiredField value) in paramList) {
      context.Write($"    {prefix} {value.Type} {key}");
      prefix = ",";
    }

    prefix = prefix == "(" ? "()" : ")";

    if (parent.Length > 0) {
      string parentArgs = grandParent.Concat(parent).Joined(FieldValue, ", ");
      context.Write($"    {prefix} : base({parentArgs})");
    } else {
      context.Write("    " + prefix);
    }

    context.Write("  {");
    foreach (KeyValuePair<string, RequiredField> kv in required) {
      context.Write($"    {kv.Key.Capitalize()} = {FieldValue(kv)};");
    }

    context.Write("  }");
  }

  private (MapPair<RequiredField>[], MapPair<RequiredField>[]) DetermineParentAndGrandParent(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    if (context.GetTypeAst(ast.Parent?.Name, out IGqlpObject parentObject) && ast.Parent?.IsTypeParam == false) {
      GqlpGeneratorTypes parentTypes = new(context, ast.Parent.Args, parentObject!.TypeParams);
      return (RequiredMembers(parentObject!, parentTypes), ParentRequired(parentObject!, parentTypes));
    }

    return ([], []);
  }

  private static string FieldValue(MapPair<RequiredField> field)
    => string.IsNullOrEmpty(field.Value.Label)
      ? field.Key
      : field.Value.Type + "." + field.Value.Label;

  internal virtual MapPair<RequiredField>[] RequiredMembers(IGqlpObject ast, GqlpGeneratorTypes types)
  {
    return [.. ast.Fields
      .Where(f => f.Modifiers.LastOrDefault()?.ModifierKind != ModifierKind.Opt)
      .Select(RequiredMember(types))];
  }

  internal Func<IGqlpObjField, MapPair<RequiredField>> RequiredMember(GqlpGeneratorTypes types)
    => f => {
      string type = ModifiedTypeString(f.Type, f, types);
      string label = "";
      if (f.Type.IsTypeParam) {
        if (types.GetArg(f.Type.Name, out IGqlpObjType arg) && arg is IGqlpTypeArg typeArg) {
          label = (typeArg.EnumValue?.EnumLabel).IfWhiteSpace();
        }
      }

      return new RequiredField(type, label).ToPair(f.Name);
    };

  internal virtual MapPair<RequiredField>[] ParentRequired(IGqlpObject ast, GqlpGeneratorTypes types)
  {
    if (ast.Parent is null || ast.Parent.IsTypeParam) {
      return [];
    }

    if (!types.GetTypeAst(ast.Parent.Name, out IGqlpObject parentObject)) {
      return [];
    }

    GqlpGeneratorTypes parentTypes = new(types, ast.Parent.Args, parentObject!.TypeParams);

    MapPair<RequiredField>[] grandRequired = ParentRequired(parentObject, parentTypes);
    MapPair<RequiredField>[] parentRequired = RequiredMembers(parentObject, parentTypes);

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

internal record struct RequiredField(string Type, string Label);
