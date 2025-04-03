namespace GqlPlus.Modelling.Simple;

internal class EnumModeller
  : ModellerType<IGqlpEnum, string, TypeEnumModel>
{
  public EnumModeller()
    : base(TypeKindModel.Enum)
  { }

  protected override TypeEnumModel ToModel(IGqlpEnum ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ast.Parent.TypeRef(SimpleKindModel.Enum),
      Items = [.. ast.Items.Select(ToLabel)],
    };

  internal static AliasedModel ToLabel(IGqlpEnumLabel ast)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
    };
}
