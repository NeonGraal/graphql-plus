namespace GqlPlus.Verifier.Ast;

internal sealed record class DirectiveAst(ParseAt At, string Name)
  : AstNamed(At, Name)
{
  public ArgumentAst? Argument { get; set; }

  protected override string Abbr => "D";

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Append(Argument?.ToString());
}
