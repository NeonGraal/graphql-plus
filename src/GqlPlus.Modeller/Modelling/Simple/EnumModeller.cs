namespace GqlPlus.Modelling.Simple;

internal class EnumModeller
  : ModellerType<IGqlpEnum, string, TypeEnumModel>
{
  public EnumModeller()
    : base(TypeKindModel.Enum)
  { }

  protected override TypeEnumModel ToModel(IGqlpEnum ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Enum),
      Items = [.. ast.Items.Select(ToMember)],
    };

  internal static AliasedModel ToMember(IGqlpEnumItem ast)
    => new(ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
    };
}
