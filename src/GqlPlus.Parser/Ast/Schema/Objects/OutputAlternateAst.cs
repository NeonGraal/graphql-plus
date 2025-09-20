using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputAlternateAst(
  ITokenAt At,
  string Name,
  string Description
) : ObjAlternateAst(At, Name, Description)
{
  public override string Label => "Output";
  internal override string Abbr => "OA";
}
