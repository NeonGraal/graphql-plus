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
    GenerateBlock(ast, context, InterfaceHeader, AlternateMembers, ClassMember);
    GenerateBlock(ast, context, InterfaceFieldsHeader, FieldMembers, ClassMember);
  }

  internal override IEnumerable<MapPair<string>> TypeMembers(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
    => [.. FieldMembers(ast, context), .. AlternateMembers(ast, context)];

  private IEnumerable<MapPair<string>> FieldMembers(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
    => ast.Fields.Select(f => ModifiedTypeString(f.Type, f, context).ToPair(f.Name.Capitalize()));

  private IEnumerable<MapPair<string>> AlternateMembers(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
    => ast.Alternates
      .Select(a => ModifiedTypeString(a, a, context).ToPair("As" + (a.EnumValue is not null ? a.Name + a.EnumValue.EnumLabel : a.Name)))
      .Append((context.TypeName(ast, "I") + "Object").ToPair("As" + ast.Name));

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
      keyTypeStr = "T" + modifier.Key;
    } else {
      keyTypeStr = context.TypeName(modifier.Key, "");
    }

    return $"IDictionary<{keyTypeStr}, {typeStr}>";
  }

  protected virtual string TypeString(IGqlpObjType type, GqlpGeneratorContext context, string prefix = "")
  {
    if (type.IsTypeParam) {
      return "T" + type.Name;
    }

    string args = type is IGqlpObjBase baseAst ? baseAst.Args.Surround("<", ">", a => TypeString(a!, context, prefix), ", ") : "";

    return context.TypeName(type, prefix) + args;
  }

  private void InterfaceFieldsHeader(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    string typeParams = ast.TypeParams.Surround("<", ">", p => "T" + p!.Name, ",");

    context.Write($"public interface {context.TypeName(ast, "I")}Object{typeParams}");
    if (ast.Parent is not null) {
      context.Write("  : " + context.TypeName(ast.Parent, "I") + "Object");
    }
  }

  protected override void InterfaceHeader(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    string typeParams = ast.TypeParams.Surround("<", ">", p => "T" + p!.Name, ",");

    context.Write($"public interface {context.TypeName(ast, "I")}{typeParams}");
    if (ast.Parent is not null) {
      context.Write("  : " + context.TypeName(ast.Parent, "I"));
    }
  }

  protected override void ClassHeader(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    string typeParams = ast.TypeParams.Surround("<", ">", p => "T" + p!.Name, ",");

    context.Write($"public class {context.TypeName(ast, "")}{typeParams}");

    if (ast.Parent is not null) {
      context.Write("  : " + context.TypeName(ast.Parent, ""));
      context.Write("  , " + context.TypeName(ast, "I") + typeParams);
    } else {
      context.Write("  : " + context.TypeName(ast, "I") + typeParams);
    }
  }
}
