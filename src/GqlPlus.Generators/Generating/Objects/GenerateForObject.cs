using GqlPlus.Abstractions;

namespace GqlPlus.Generating.Objects;

internal class GenerateForObject<TObjField>
  : GenerateForClass<IGqlpObject<TObjField>>
  where TObjField : IGqlpObjField
{
  public GenerateForObject()
    => _generators[GqlpGeneratorType.Interface] = GenerateObjectInterfaces;

  private void GenerateObjectInterfaces(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    GenerateBlock(ast, context, InterfaceHeader, AlternateMembers, InterfaceMember);
    GenerateBlock(ast, context, InterfaceFieldsHeader, FieldMembers, InterfaceMember);
  }

  internal override IEnumerable<MapPair<string>> TypeMembers(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
    => [.. FieldMembers(ast, context), .. AlternateMembers(ast, context)];

  private IEnumerable<MapPair<string>> FieldMembers(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
    => ast.Fields.Select(f => ModifiedTypeString(f.Type, f, context).ToPair(f.Name.Capitalize()));

  private IEnumerable<MapPair<string>> AlternateMembers(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    IEnumerable<MapPair<string>> alternates = ast.Alternates
        .Select(a => ModifiedTypeString(a, a, context).ToPair(AlternameName(a)));
    string objectName = context.TypeName(ast, "I") + "Object";

    return alternates.Append(objectName.ToPair("As" + ast.Name));

    string AlternameName(IGqlpAlternate alt)
    {
      IGqlpType? type = context.GetTypeAst<IGqlpType>(alt.Name);
      string name = (type?.Name).IfWhiteSpace(alt.Name);

      if (alt.EnumValue is not null) {
        name += alt.EnumValue.EnumLabel;
      }

      if (alt.Args.Any(a => a.EnumValue is not null)) {
        name = alt.Args.Select(a => a.EnumValue?.EnumValue.Replace(".", "")).Joined();
      }

      return "As" + name;
    }
  }

  protected string ModifiedTypeString(IGqlpObjType type, IGqlpModifiers modifiers, GqlpGeneratorContext context)
    => modifiers.Modifiers.Aggregate(TypeString(type, context, "I"), (s, m) => ModifyTypeString(s, m, context));

  protected virtual string ModifyTypeString(string typeStr, IGqlpModifier modifier, GqlpGeneratorContext context)
  {
    if (modifier.ModifierKind == ModifierKind.Optional) {
      return typeStr + "?";
    }

    if (modifier.ModifierKind == ModifierKind.List) {
      return $"ICollection<{typeStr}>";
    }

    string keyTypeStr = modifier.Key;
    if (modifier.ModifierKind == ModifierKind.Param) {
      keyTypeStr = "T" + modifier.Key.Capitalize();
    } else {
      keyTypeStr = context.TypeName(modifier.Key, "I");
    }

    return $"IDictionary<{keyTypeStr}, {typeStr}>";
  }

  protected virtual string TypeString(IGqlpObjType type, GqlpGeneratorContext context, string prefix = "")
  {
    if (type.IsTypeParam) {
      return "T" + type.Name.Capitalize();
    }

    string args = type is IGqlpObjBase baseAst ? baseAst.Args.Surround("<", ">", a => TypeString(a!, context, prefix), ", ") : "";

    return context.TypeName(type, prefix) + args;
  }

  private void InterfaceFieldsHeader(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    context.Write($"public interface {context.TypeName(ast, "I")}Object{TypeParamsString(ast)}");
    if (ast.Parent is not null) {
      string parentArgs = ast.Parent.Args.Surround("<", ">", a => TypeString(a!, context, "I"), ", ");
      context.Write("  : " + context.TypeName(ast.Parent, "I") + "Object" + parentArgs);
    }
  }

  private static string TypeParamsString(IGqlpObject<TObjField> ast)
    => ast.TypeParams.Surround("<", ">", p => "T" + p!.Name.Capitalize(), ",");

  protected override void InterfaceHeader(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    context.Write($"public interface {context.TypeName(ast, "I")}{TypeParamsString(ast)}");
    if (ast.Parent is not null) {
      string parentArgs = ast.Parent.Args.Surround("<", ">", a => TypeString(a!, context, "I"), ", ");
      context.Write("  : " + context.TypeName(ast.Parent, "I") + parentArgs);
    }
  }

  protected override void ClassHeader(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    string typeParams = TypeParamsString(ast);

    context.Write($"public class {context.TypeName(ast, "")}{typeParams}");

    if (ast.Parent is not null) {
      string parentArgs = ast.Parent.Args.Surround("<", ">", a => TypeString(a!, context, "I"), ", ");
      context.Write("  : " + context.TypeName(ast.Parent, "") + parentArgs);
      context.Write("  , " + context.TypeName(ast, "I") + typeParams);
    } else {
      context.Write("  : " + context.TypeName(ast, "I") + typeParams);
    }
  }
}
