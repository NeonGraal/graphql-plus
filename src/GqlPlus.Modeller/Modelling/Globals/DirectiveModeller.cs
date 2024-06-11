namespace GqlPlus.Modelling.Globals;

internal class DirectiveModeller(
  IModeller<IGqlpInputParameter, InputParameterModel> parameter
) : ModellerBase<IGqlpSchemaDirective, DirectiveModel>
{
  protected override DirectiveModel ToModel(IGqlpSchemaDirective ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Repeatable = ast.DirectiveOption == DirectiveOption.Repeatable,
      Locations = ast.Locations,
      Parameters = parameter.ToModels(ast.Parameters, typeKinds),
    };

  internal static DirectiveLocation Combine(DirectiveLocation[] values)
    => values.Aggregate((a, b) => a | b);
}
