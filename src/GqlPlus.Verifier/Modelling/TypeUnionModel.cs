using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class TypeUnionModel(
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

internal record class UnionMemberModel(
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

  internal override TypeUnionModel ToModel(UnionDeclAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Union),
      Items = [.. ast.Members.Select(ToMember)],
    };

  internal static AliasedModel ToMember(UnionMemberAst ast)
    => new(ast.Name);
}
