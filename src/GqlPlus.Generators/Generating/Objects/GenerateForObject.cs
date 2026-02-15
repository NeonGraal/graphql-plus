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
   => _generators[GqlpGeneratorType.Interface] = GenerateObjectInterfaces;

  private void GenerateObjectInterfaces(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    GenerateBlock(ast, context, AlternateHeader, AlternateMembers, AlternateMember);
    GenerateBlock(ast, context, InterfaceHeader, TypeMembers, InterfaceMember);
  }

  private IEnumerable<MapPair<string>> AlternateMembers(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    IEnumerable<MapPair<string>> alternates = ast.Alternates
        .Select(a => ModifiedTypeString(a, a, context).ToPair(AlternameName(a)));
    if (ast.Parent?.IsTypeParam == true) {
      string parentTypeParam = "T" + ast.Parent.Name.Capitalize();
      alternates = alternates.Append(parentTypeParam.ToPair("AsParent"));
    }

    string objectName = context.TypeName(ast, "I") + "Object" + TypeParamsString(ast);
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

  protected void AlternateHeader(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    context.Write($"public interface {context.TypeName(ast, "I")}{TypeParamsString(ast)}");
    if (ast.Parent is not null && !ast.Parent.IsTypeParam) {
      context.Write("  : " + context.TypeName(ast.Parent, "I") + TypeArgsString(ast.Parent.Args, context));
    }
  }

  protected void AlternateMember(MapPair<string> item, GqlpGeneratorContext context)
    => context.Write($"  {item.Value} {item.Key} {{ get; }}");

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

  protected override void InterfaceHeader(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    context.Write($"public interface {context.TypeName(ast, "I")}Object{TypeParamsString(ast)}");
    if (ast.Parent is not null && !ast.Parent.IsTypeParam) {
      context.Write("  : " + context.TypeName(ast.Parent, "I") + "Object" + TypeArgsString(ast.Parent.Args, context));
    }
  }

  protected override void ClassHeader(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    string typeParams = TypeParamsString(ast);

    context.Write($"public class {context.TypeName(ast, "")}{typeParams}");

    if (ast.Parent is not null && !ast.Parent.IsTypeParam) {
      context.Write("  : " + context.TypeName(ast.Parent, "") + TypeArgsString(ast.Parent.Args, context));
      context.Write("  , " + context.TypeName(ast, "I") + typeParams);
    } else {
      context.Write("  : " + context.TypeName(ast, "I") + typeParams);
    }
  }
}
