using GqlPlus.Ast.Operation;

namespace GqlPlus.Schema.Modelling;

internal class SchOpSelectionModeller(
#pragma warning disable CS9113 // Parameter is unread.
  ISchModellerRepository modellers
#pragma warning restore CS9113 // Parameter is unread.
) : ModellerBase<IAstSelection, ISch_OpSelection>
{
  //private readonly Modeller<IAstArg, ISch_OpArgument> _argument = modellers.ModellerFor<IAstArg, ISch_OpArgument>();
  //private readonly Modeller<IAstDirective, ISch_OpDirective> _directive = modellers.ModellerFor<IAstDirective, ISch_OpDirective>();
  //private readonly Modeller<IAstModifier, ISch_Modifiers> _modifier = modellers.ModellerFor<IAstModifier, ISch_Modifiers>();

  internal static IModeller<IAstSelection, ISch_OpSelection> Factory(ISchModellerRepository repo)
    => new SchOpSelectionModeller(repo);

  protected override ISch_OpSelection ToModel(IAstSelection ast, IMap<GqlpTypeKind> typeKinds)
  {
    //ISch_OpSelection result = ast switch {
    //  IAstField field => new Sch_OpFieldSelection(field.Identifier, "") {
    //    Alias = field.FieldAlias,
    //    Argument = _argument.TryModel(field.Arg, typeKinds),
    //  },
    //  IAstInline inline => new Sch_OpInlineSelection(inline.OnType.TypeRef(GqlpTypeKind.Output), ""),
    //  IAstSpread spread => new Sch_OpSpreadSelection(spread.Identifier, ""),
    //  _ => throw new NotSupportedException($"Unsupported selection type: {ast.GetType().Name}")
    //};

    //return result with {
    //  Directives = _directive.ToModels(ast.Directives, typeKinds),
    //  Modifiers = _modifier.ToModels(ast.Modifiers, typeKinds),
    //};

    return new Sch_OpSelection();
  }
}
