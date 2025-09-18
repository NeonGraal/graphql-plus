using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputAlternateAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjAlternate(At, Name, Description)
  , IGqlpOutputAlternate
{
  public override string Label => "Output";
  internal override string Abbr => "OA";
}
