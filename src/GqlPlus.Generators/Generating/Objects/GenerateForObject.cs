namespace GqlPlus.Generating.Objects;

internal abstract class GenerateForObject<TObj, TBase, TField, TAlt>
  : GenerateForClass<TObj>
  where TObj : IGqlpObject<TBase, TField, TAlt>
  where TBase : IGqlpObjBase
  where TField : IGqlpObjField
  where TAlt : IGqlpObjAlternate
{
  internal override IEnumerable<MapPair<string>> TypeMembers(TObj ast, GqlpGeneratorContext context)
    => [.. ast.Fields.Select(FieldMember(context)), .. ast.Alternates.Select(AlternateMember(context))];

  private Func<IGqlpObjField, MapPair<string>> FieldMember(GqlpGeneratorContext context)
    => field => new(field.Name, TypeString(field.Type, context));

  private Func<IGqlpObjAlternate, MapPair<string>> AlternateMember(GqlpGeneratorContext context)
    => alternate => new("As" + alternate.Name, TypeString(alternate, context));

  protected virtual string TypeString(IGqlpObjType type, GqlpGeneratorContext context)
  {
    if (type.IsTypeParam) {
      return "T" + type.Name;
    }

    string args = type is IGqlpObjBase baseAst ? baseAst.Args.Surround("<", ">", a => TypeString(a!, context), ", ") : "";

    IGqlpType? typeAst = context.GetTypeAst<IGqlpType>(type.Name);
    return typeAst is null
      ? type.Name + args
      : typeAst.Name + args;
  }

  protected override void InterfaceHeader(TObj ast, GqlpGeneratorContext context)
  {
    string typeParams = ast.TypeParams.Surround("<", ">", p => "T" + p!.Name, ",");

    context.Write($"public interface I{ast.Name}{typeParams}");
    if (ast.Parent is not null) {
      context.Write("  : I" + ast.Parent.Name);
    }
  }

  protected override void ClassHeader(TObj ast, GqlpGeneratorContext context)
  {
    string typeParams = ast.TypeParams.Surround("<", ">", p => "T" + p!.Name, ",");

    context.Write($"public class {TypePrefix}{ast.Name}{typeParams}");

    if (ast.Parent is not null) {
      context.Write("  : " + TypePrefix + ast.Parent.Name);
      context.Write("  , I" + ast.Name + typeParams);
    } else {
      context.Write("  : I" + ast.Name + typeParams);
    }
  }
}
