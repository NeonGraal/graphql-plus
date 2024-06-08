namespace GqlPlus.Modelling.Globals;

internal class SchemaModeller(
  IModeller<IGqlpSchemaCategory, CategoryModel> category,
  IModeller<IGqlpSchemaDirective, DirectiveModel> directive,
  IModeller<IGqlpSchemaSetting, SettingModel> setting,
  ITypesModeller type
) : ModellerBase<IGqlpSchema, SchemaModel>
{
  protected override SchemaModel ToModel(IGqlpSchema ast, IMap<TypeKindModel> typeKinds)
  {
    IGqlpType[] types = ast.Declarations.ArrayOf<IGqlpType>();
    ITokenMessages errors = ast.Errors;
    if (typeKinds is TypesCollection collection) {
      errors = collection.Errors;
      errors.Clear();
      errors.Add(ast.Errors);
    }

    type.AddTypeKinds(types, typeKinds);

    IGqlpSchemaOption[] options = ast.Declarations.ArrayOf<IGqlpSchemaOption>();
    string name = options.LastOrDefault(options => !string.IsNullOrWhiteSpace(options.Name))?.Name ?? "";
    IEnumerable<string> aliases = options.SelectMany(a => a.Aliases);
    IEnumerable<SettingModel> settings = options.SelectMany(o => setting.ToModels(o.Settings, typeKinds));

    return new(name,
        DeclarationModel(ast, category, typeKinds),
        DeclarationModel(ast, directive, typeKinds),
        settings,
        types.Select(t => type.ToModel(t, typeKinds)),
        errors
        ) { Aliases = [.. aliases] };
  }

  private IEnumerable<TModel> DeclarationModel<TAst, TModel>(IGqlpSchema ast, IModeller<TAst, TModel> modeller, IMap<TypeKindModel> typeKinds)
    where TAst : IGqlpError
    where TModel : IRendering
    => ast.Declarations.OfType<TAst>().Select(m => modeller.ToModel(m, typeKinds));
}
