namespace GqlPlus.Modelling.Simple;

internal class EnumModeller
  : ModellerType<IAstEnum, IAstTypeRef, TypeEnumModel>
{
  public EnumModeller()
    : base(TypeKindModel.Enum)
  { }

  protected override TypeEnumModel ToModel(IAstEnum ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ast.Parent.TypeRef(SimpleKindModel.Enum),
      Items = [.. ast.Items.Select(ToLabel)],
    };

  internal static AliasedModel ToLabel(IAstEnumLabel ast)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
    };
}
