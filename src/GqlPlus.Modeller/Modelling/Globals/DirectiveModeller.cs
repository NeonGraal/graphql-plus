namespace GqlPlus.Modelling.Globals;

internal class DirectiveModeller(
  IModeller<IGqlpInputParam, InputParamModel> parameter
) : ModellerBase<IGqlpSchemaDirective, DirectiveModel>
{
  protected override DirectiveModel ToModel(IGqlpSchemaDirective ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Repeatable = ast.DirectiveOption == DirectiveOption.Repeatable,
      Locations = ast.Locations,
      Parameter = parameter.TryModel(ast.Parameter, typeKinds),
    };
}
