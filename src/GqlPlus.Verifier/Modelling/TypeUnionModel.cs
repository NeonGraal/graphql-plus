using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling;

public record class TypeUnionModel(
  string Name
) : ParentTypeModel<AliasedModel, UnionMemberModel>(TypeKindModel.Union, Name)
{
  protected override Func<AliasedModel, UnionMemberModel> NewItem(string parent)
    => member
        => new(member.Name, parent) {
          Aliases = member.Aliases,
          Description = member.Description,
        };
}

public record class UnionMemberModel(
  string Name,
  string OfUnion
) : AliasedModel(Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("union", OfUnion);
}

internal class UnionModeller
  : ModellerType<UnionDeclAst, string, TypeUnionModel>
{
  public UnionModeller()
    : base(TypeKindModel.Union)
  { }

  protected override TypeUnionModel ToModel(UnionDeclAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Union),
      Items = [.. ast.Members.Select(ToMember)],
    };

  internal static AliasedModel ToMember(UnionMemberAst ast)
    => new(ast.Name);
}
