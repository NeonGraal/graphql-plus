using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputAlternateAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjAlternate<IGqlpObjArg>(At, Name, Description)
  , IGqlpOutputAlternate
{
  public override string Label => "Output";
  internal override string Abbr => "OA";

  IGqlpDualBase IGqlpToDual<IGqlpDualBase>.ToDual => ToDual();
  IGqlpDualAlternate IGqlpToDual<IGqlpDualAlternate>.ToDual => ToDual();

  public DualAlternateAst ToDual()
    => new(At, Name, Description) {
      IsTypeParam = IsTypeParam,
      BaseArgs = [.. BaseArgs.Select(a => new DualArgAst(a.At, a.Name, a.Description) { IsTypeParam = a.IsTypeParam })],
      Modifiers = [.. Modifiers],
    };
}
