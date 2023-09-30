namespace GqlPlus.Verifier.Ast;

internal record class SpreadAst : NamedAst, SelectionAst
{
  public SpreadAst(string name) : base(name) { }
}
