namespace GqlPlus.Verifier.Ast;

internal abstract record class AstNamed(ParseAt At, string Name)
  : AstBase(At)
{
  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Append(Name);
}
