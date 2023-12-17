using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class OutputDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstObject<OutputFieldAst, OutputReferenceAst>(At, Name, Description)
{
  internal override string Abbr => "O";
  public override string Label => "Output";

  public OutputDeclAst(TokenAt at, string name)
    : this(at, name, "") { }
}
