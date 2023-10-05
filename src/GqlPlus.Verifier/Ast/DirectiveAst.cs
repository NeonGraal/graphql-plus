namespace GqlPlus.Verifier.Ast;

internal sealed record class DirectiveAst(string Name)
  : AstNamed(Name)
{
  public ArgumentAst? Argument { get; set; }

  protected override string Abbr => "D";

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Append(Argument?.ToString());
}
