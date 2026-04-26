namespace GqlPlus.Modelling.Simple;

internal class UnionModeller
  : ModellerType<IAstUnion, IAstTypeRef, TypeUnionModel>
{
  public UnionModeller()
    : base(TypeKindModel.Union)
  { }

  protected override TypeUnionModel ToModel(IAstUnion ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ast.Parent.TypeRef(SimpleKindModel.Union),
      Items = [.. ast.Items.Select(ToMember)],
    };

  internal static AliasedModel ToMember(IAstUnionMember ast)
    => new(ast.Name, ast.Description);

  internal static UnionModeller Factory(IModellerRepository _) => new();
}
