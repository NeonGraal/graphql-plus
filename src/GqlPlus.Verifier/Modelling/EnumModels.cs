using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public record class TypeEnumModel(
  string Name
) : ParentTypeModel<AliasedModel, EnumMemberModel>(TypeKindModel.Enum, Name)
{
  protected override Func<AliasedModel, EnumMemberModel> NewItem(string parent)
    => member
        => new(member.Name, parent) {
          Aliases = member.Aliases,
          Description = member.Description,
        };
}

public record class EnumMemberModel(
  string Name,
  string OfEnum
) : AliasedModel(Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("enum", OfEnum);
}

public record class EnumValueModel(
  string Name,
  string Value
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("value", Value);
}

internal class EnumModeller
  : ModellerType<EnumDeclAst, string, TypeEnumModel>
{
  public EnumModeller()
    : base(TypeKindModel.Enum)
  { }

  internal override TypeEnumModel ToModel(EnumDeclAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Enum),
      Items = [.. ast.Members.Select(ToMember)],
    };

  internal static AliasedModel ToMember(EnumMemberAst ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
    };
}
