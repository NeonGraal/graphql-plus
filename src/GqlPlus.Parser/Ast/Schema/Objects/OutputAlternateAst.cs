using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputAlternateAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjAlternate<IGqlpOutputArg>(At, Name, Description)
  , IEquatable<OutputAlternateAst>
  , IGqlpOutputAlternate
{
  public override string Label => "Output";
  internal override string Abbr => "OA";

  public string Output => Name;

  IGqlpDualAlternate IGqlpToDual<IGqlpDualAlternate>.ToDual => ToDual();

  public DualAlternateAst ToDual()
    => new(At, Name, Description) {
      IsTypeParam = IsTypeParam,
      BaseArgs = [.. BaseArgs.Select(a => a.ToDual)],
      Modifiers = [.. Modifiers],
    };
}
