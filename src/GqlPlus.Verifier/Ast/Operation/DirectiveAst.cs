namespace GqlPlus.Verifier.Ast.Operation;

internal sealed record class DirectiveAst(ParseAt At, string Name)
  : AstNamed(At, Name)
{
  public ArgumentAst? Argument { get; set; }

  internal override string Abbr => "d";

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Concat(Argument.Bracket("(", ")"));
}
