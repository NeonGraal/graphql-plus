using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Modelling;

internal record class ModifierModel(ModifierKind Kind)
  : CollectionModel(Kind)
{ }

internal class ModifierModeller
  : ModellerBase<ModifierAst, ModifierModel>
{
  internal override ModifierModel ToModel(ModifierAst ast)
    => new(ast.Kind) {
      Key = ast.Key ?? "",
      KeyOptional = ast.KeyOptional,
    };

  public override T? TryModel<T>(ModifierAst? ast)
    where T : default
  {
    if (typeof(T).Equals(typeof(CollectionModel))) {
      if (ast is not null && ast.Kind != ModifierKind.Optional) {
        return (T?)(object)ToModel(ast);
      }

      return default;
    } else {
      return base.TryModel<T>(ast);
    }
  }
}
