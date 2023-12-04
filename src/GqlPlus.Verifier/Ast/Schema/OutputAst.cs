using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class OutputAst(TokenAt At, string Name, string Description)
  : AstObject<OutputFieldAst, OutputReferenceAst>(At, Name, Description)
{
  internal override string Abbr => "O";

  public OutputAst(TokenAt at, string name)
    : this(at, name, "") { }
}
