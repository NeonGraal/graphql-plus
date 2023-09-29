namespace GqlPlus.Verifier.Ast;

internal record class SpreadAst : NamedAst, FragmentAst
{
  public SpreadAst(string name) : base(name) { }
}
