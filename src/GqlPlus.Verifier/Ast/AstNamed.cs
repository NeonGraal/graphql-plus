namespace GqlPlus.Verifier.Ast;

internal record class AstNamed(string Name) : AstBase
{
  internal override IEnumerable<string?> GetFields()
    => new[] { Name };
}
