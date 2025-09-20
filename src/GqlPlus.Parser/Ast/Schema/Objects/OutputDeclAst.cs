using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputDeclAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObject<IGqlpOutputField>(At, Name, Description)
  , IGqlpOutputObject
{
  internal override string Abbr => "Ou";
  public override string Label => "Output";

  public OutputDeclAst(TokenAt at, string name)
    : this(at, name, "") { }
}
