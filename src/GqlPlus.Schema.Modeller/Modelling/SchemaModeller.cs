using GqlPlus.Resolving;

namespace GqlPlus.Modelling;

internal class SchemaModeller(
  IModellerRepository modellers
) : ModellerBase<IAstSchema, SchemaModel>
{
  private readonly DeferOne<IModeller<IAstSchemaCategory, CategoryModel>> _category = modellers.ModellerFor<IAstSchemaCategory, CategoryModel>();
  private readonly DeferOne<IModeller<IAstSchemaDirective, DirectiveModel>> _directive = modellers.ModellerFor<IAstSchemaDirective, DirectiveModel>();
  private readonly DeferOne<IModeller<IAstSchemaSetting, SettingModel>> _setting = modellers.ModellerFor<IAstSchemaSetting, SettingModel>();
  private readonly DeferOne<ITypesModeller> _types = modellers.TypesModeller();

  protected override SchemaModel ToModel(IAstSchema ast, IMap<TypeKindModel> typeKinds)
  {
    IAstType[] typeDeclarations = ast.Declarations.ArrayOf<IAstType>();
    IMessages errors = ast.Errors;
    if (typeKinds is IModelsContext collection) {
      errors = collection.Errors;
      errors.Clear();
      errors.Add(ast.Errors);
    }

    _types.I.AddTypeKinds(typeDeclarations, typeKinds);

    IAstSchemaOption[] options = ast.Declarations.ArrayOf<IAstSchemaOption>();
    string? name = options.LastOrDefault(options => !string.IsNullOrWhiteSpace(options.Name))?.Name;
    IEnumerable<string> aliases = options.SelectMany(a => a.Aliases);
    IEnumerable<SettingModel> settings = options.SelectMany(o => _setting.I.ToModels(o.Settings, typeKinds));

    return new(name.IfWhiteSpace(),
        DeclarationModel(ast, _category.I, typeKinds),
        DeclarationModel(ast, _directive.I, typeKinds),
        settings,
        typeDeclarations.Select(t => _types.I.ToModel(t, typeKinds)),
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

  internal static SchemaModeller Factory(IModellerRepository r) => new(r);
}
