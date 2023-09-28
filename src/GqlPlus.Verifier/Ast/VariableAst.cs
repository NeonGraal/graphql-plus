namespace GqlPlus.Verifier.Ast;

internal record class VariableAst : NamedAst
{
  public VariableAst(string name) : base(name) { }
}
