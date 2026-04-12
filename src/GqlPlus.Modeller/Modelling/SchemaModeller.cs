using GqlPlus.Resolving;

namespace GqlPlus.Modelling;

internal class SchemaModeller(
  IModellerRepository modellers
) : ModellerBase<IAstSchema, SchemaModel>
{
  private readonly IModeller<IAstSchemaCategory, CategoryModel> _category = modellers.ModellerFor<IAstSchemaCategory, CategoryModel>();
  private readonly IModeller<IAstSchemaDirective, DirectiveModel> _directive = modellers.ModellerFor<IAstSchemaDirective, DirectiveModel>();
  private readonly IModeller<IAstSchemaSetting, SettingModel> _setting = modellers.ModellerFor<IAstSchemaSetting, SettingModel>();
  private readonly ITypesModeller _types = modellers.TypesModeller;

  protected override SchemaModel ToModel(IAstSchema ast, IMap<TypeKindModel> typeKinds)
  {
    IAstType[] typeDeclarations = ast.Declarations.ArrayOf<IAstType>();
    IMessages errors = ast.Errors;
    if (typeKinds is IModelsContext collection) {
      errors = collection.Errors;
      errors.Clear();
      errors.Add(ast.Errors);
    }

    _types.AddTypeKinds(typeDeclarations, typeKinds);

    IAstSchemaOption[] options = ast.Declarations.ArrayOf<IAstSchemaOption>();
    string? name = options.LastOrDefault(options => !string.IsNullOrWhiteSpace(options.Name))?.Name;
    IEnumerable<string> aliases = options.SelectMany(a => a.Aliases);
    IEnumerable<SettingModel> settings = options.SelectMany(o => _setting.ToModels(o.Settings, typeKinds));

    return new(name.IfWhiteSpace(),
        DeclarationModel(ast, _category, typeKinds),
        DeclarationModel(ast, _directive, typeKinds),
        settings,
        typeDeclarations.Select(t => _types.ToModel(t, typeKinds)),
        errors
        ) { Aliases = [.. aliases] };
  }

  private IEnumerable<TModel> DeclarationModel<TAst, TModel>(
    IAstSchema ast,
    IModeller<TAst, TModel> modeller,
    IMap<TypeKindModel> typeKinds
  )
    where TAst : IAstError
    where TModel : IModelBase
    => ast.Declarations.OfType<TAst>().Select(m => modeller.ToModel(m, typeKinds));
}
