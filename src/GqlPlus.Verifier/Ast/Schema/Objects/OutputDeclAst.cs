using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Objects;

public sealed record class OutputDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstObject<OutputFieldAst, OutputBaseAst>(At, Name, Description)
{
  internal override string Abbr => "Ou";
  public override string Label => "Output";

  public OutputDeclAst(TokenAt at, string name)
    : this(at, name, "") { }
}
