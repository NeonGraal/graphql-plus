namespace GqlPlus.Verifier.Ast;

internal record class DirectiveAst(string Name) : NamedAst(Name)
{
  public ArgumentAst? Argument { get; set; }
}
