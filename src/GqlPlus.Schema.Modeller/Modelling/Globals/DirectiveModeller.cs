namespace GqlPlus.Modelling.Globals;

internal class DirectiveModeller(
  IModellerRepository modellers
) : ModellerBase<IAstSchemaDirective, DirectiveModel>
{
  private readonly IModeller<IAstInputParam, InputParamModel> _parameter = modellers.ModellerFor<IAstInputParam, InputParamModel>();

  protected override DirectiveModel ToModel(IAstSchemaDirective ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Repeatable = ast.DirectiveOption == DirectiveOption.Repeatable,
      Locations = (DirectiveLocationModel)(int)ast.Locations,
      Parameter = _parameter.TryModel(ast.Parameter, typeKinds),
    };

  internal static DirectiveModeller Factory(IModellerRepository r) => new(r);
}
