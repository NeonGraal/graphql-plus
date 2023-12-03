namespace GqlPlus.Verifier.Ast.Operation;

public sealed record class DirectiveAst(TokenAt At, string Name)
  : AstNamed(At, Name)
{
  public ArgumentAst? Argument { get; set; }

  internal override string Abbr => "d";

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Concat(Argument.Bracket("(", ")"));
}
