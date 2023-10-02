namespace GqlPlus.Verifier.Ast;

internal record class DirectiveAst(string Name)
  : AstNamed(Name)
{
  public ArgumentAst? Argument { get; set; }

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Append(Argument?.ToString());
}
