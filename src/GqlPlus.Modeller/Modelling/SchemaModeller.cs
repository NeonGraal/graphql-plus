using GqlPlus.Resolving;

namespace GqlPlus.Modelling;

internal class SchemaModeller(
  IModeller<IGqlpSchemaCategory, CategoryModel> category,
  IModeller<IGqlpSchemaDirective, DirectiveModel> directive,
  IModeller<IGqlpSchemaSetting, SettingModel> setting,
  ITypesModeller types
) : ModellerBase<IGqlpSchema, SchemaModel>
{
  protected override SchemaModel ToModel(IGqlpSchema ast, IMap<TypeKindModel> typeKinds)
  {
    IGqlpType[] typeDeclarations = ast.Declarations.ArrayOf<IGqlpType>();
    IMessages errors = ast.Errors;
    if (typeKinds is IModelsContext collection) {
      errors = collection.Errors;
      errors.Clear();
      errors.Add(ast.Errors);
    }

    types.AddTypeKinds(typeDeclarations, typeKinds);

    IGqlpSchemaOption[] options = ast.Declarations.ArrayOf<IGqlpSchemaOption>();
    string? name = options.LastOrDefault(options => !string.IsNullOrWhiteSpace(options.Name))?.Name;
    IEnumerable<string> aliases = options.SelectMany(a => a.Aliases);
    IEnumerable<SettingModel> settings = options.SelectMany(o => setting.ToModels(o.Settings, typeKinds));

    return new(name.IfWhitespace(),
        DeclarationModel(ast, category, typeKinds),
        DeclarationModel(ast, directive, typeKinds),
        settings,
        typeDeclarations.Select(t => types.ToModel(t, typeKinds)),
        errors
        ) { Aliases = [.. aliases] };
  }

  private IEnumerable<TModel> DeclarationModel<TAst, TModel>(IGqlpSchema ast, IModeller<TAst, TModel> modeller, IMap<TypeKindModel> typeKinds)
    where TAst : IGqlpError
    where TModel : IModelBase
    => ast.Declarations.OfType<TAst>().Select(m => modeller.ToModel(m, typeKinds));
}
