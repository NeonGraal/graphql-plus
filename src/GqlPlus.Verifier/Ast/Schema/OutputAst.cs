namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class OutputAst(ParseAt At, string Name, string Description)
  : ObjectAst<OutputFieldAst, OutputReferenceAst>(At, Name, Description)
{
  internal override string Abbr => "O";

  public OutputAst(ParseAt at, string name)
    : this(at, name, "") { }
}
