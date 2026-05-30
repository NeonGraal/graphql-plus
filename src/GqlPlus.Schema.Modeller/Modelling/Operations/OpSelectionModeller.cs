using GqlPlus.Ast.Operation;

namespace GqlPlus.Modelling;

internal class OpSelectionModeller(
  IModellerRepository modellers
) : ModellerBase<IAstSelection, OpSelectionModel>
{
  private readonly Modeller<IAstArg, OpArgumentModel> _argument = modellers.ModellerFor<IAstArg, OpArgumentModel>();
  private readonly Modeller<IAstDirective, OpDirectiveModel> _directive = modellers.ModellerFor<IAstDirective, OpDirectiveModel>();
  private readonly Modeller<IAstModifier, ModifierModel> _modifier = modellers.ModellerFor<IAstModifier, ModifierModel>();

  protected override OpSelectionModel ToModel(IAstSelection ast, IMap<TypeKindModel> typeKinds)
  {
    OpSelectionModel result = ast switch {
      IAstField field => new OpFieldSelectionModel(field.Identifier, "") {
        Alias = field.FieldAlias,
        Argument = _argument.TryModel(field.Arg, typeKinds),
      },
      IAstInline inline => new OpInlineSelectionModel(inline.OnType.TypeRef(TypeKindModel.Output), ""),
      IAstSpread spread => new OpSpreadSelectionModel(spread.Identifier, ""),
      _ => throw new NotSupportedException($"Unsupported selection type: {ast.GetType().Name}")
    };

    return result with {
      Directives = _directive.ToModels(ast.Directives, typeKinds),
      Modifiers = _modifier.ToModels(ast.Modifiers, typeKinds),
    };
  }

  internal static OpSelectionModeller Factory(IModellerRepository repo) => new(repo);
}
