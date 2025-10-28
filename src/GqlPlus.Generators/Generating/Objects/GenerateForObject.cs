using System.Linq;

namespace GqlPlus.Generating.Objects;

internal class GenerateForObject<TObjField>
  : GenerateForClass<IGqlpObject<TObjField>>
  where TObjField : IGqlpObjField
{
  public GenerateForObject()
  {
    _generators.Add(GqlpGeneratorType.Interface, GenerateObjectInterfaces);
  }

  private void GenerateObjectInterfaces(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    GenerateBlock(InterfaceHeader, InterfaceMember)(ast, context);
    GenerateBlock(ast, context, InterfaceFieldsHeader, ast.Alternates.Select(AlternateMember(context), ClassMember);
  }

  internal override IEnumerable<MapPair<string>> TypeMembers(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
    => [.. ast.Fields.Select(FieldMember(context)), .. AlternateMembers(ast, context)];

  private Func<IGqlpObjField, MapPair<string>> FieldMember(GqlpGeneratorContext context)
    => field => new(field.Name, TypeString(field.Type, context));

  private IEnumerable<MapPair<string>> AlternateMembers(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
    => ast.Alternates.Select(alternate => new MapPair<string>("As" + alternate.Name, TypeString(alternate, context)));

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

  protected override void InterfaceHeader(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    string typeParams = ast.TypeParams.Surround("<", ">", p => "T" + p!.Name, ",");

    context.Write($"public interface I{context.TypeName(ast)}{typeParams}");
    if (ast.Parent is not null) {
      context.Write("  : I" + context.TypeName(ast.Parent));
    }
  }

  protected override void ClassHeader(IGqlpObject<TObjField> ast, GqlpGeneratorContext context)
  {
    string typeParams = ast.TypeParams.Surround("<", ">", p => "T" + p!.Name, ",");

    context.Write($"public class {context.TypeName(ast)}{typeParams}");

    if (ast.Parent is not null) {
      context.Write("  : " + context.TypeName(ast.Parent));
      context.Write("  , I" + context.TypeName(ast) + typeParams);
    } else {
      context.Write("  : I" + context.TypeName(ast) + typeParams);
    }
  }
}
