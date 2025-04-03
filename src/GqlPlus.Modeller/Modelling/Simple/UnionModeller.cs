namespace GqlPlus.Modelling.Simple;

internal class UnionModeller
  : ModellerType<IGqlpUnion, string, TypeUnionModel>
{
  public UnionModeller()
    : base(TypeKindModel.Union)
  { }

  protected override TypeUnionModel ToModel(IGqlpUnion ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ast.Parent.TypeRef(SimpleKindModel.Union),
      Items = [.. ast.Items.Select(ToMember)],
    };

  internal static AliasedModel ToMember(IGqlpUnionMember ast)
    => new(ast.Name, ast.Description);
}
