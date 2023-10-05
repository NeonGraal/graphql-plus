namespace GqlPlus.Verifier.Ast;

internal abstract record class AstNamed(string Name) : AstBase
{
  internal override IEnumerable<string?> GetFields()
    => new[] { Name };
}
