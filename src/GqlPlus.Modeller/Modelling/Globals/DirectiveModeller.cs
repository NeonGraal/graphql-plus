namespace GqlPlus.Modelling.Globals;

internal class DirectiveModeller(
  IModeller<IGqlpInputParam, InputParamModel> parameter
) : ModellerBase<IAstSchemaDirective, DirectiveModel>
{
  protected override DirectiveModel ToModel(IAstSchemaDirective ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Repeatable = ast.DirectiveOption == DirectiveOption.Repeatable,
      Locations = ast.Locations,
      Parameter = parameter.TryModel(ast.Parameter, typeKinds),
    };
}
