namespace GqlPlus.Verifier.Ast;

internal record class DirectiveAst : NamedAst
{
  public DirectiveAst(string name) : base(name) { }

  public ArgumentAst? Argument { get; set; }
}
