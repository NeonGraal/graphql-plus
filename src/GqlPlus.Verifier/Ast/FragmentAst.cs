namespace GqlPlus.Verifier.Ast;

internal sealed record class FragmentAst(string Name, string OnType, AstSelection[] Selections)
  : AstNamedDirectives(Name), IEquatable<FragmentAst>
{
  protected override string Abbr => "T";

  public bool Equals(FragmentAst? other)
    => base.Equals(other)
    && OnType == other.OnType
    && Selections.SequenceEqual(other.Selections);
  public override int GetHashCode()
    => HashCode.Combine((AstNamedDirectives)this, OnType, Selections);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(OnType.Prefixed(":"))
      .Concat(Selections.Bracket("{", "}", d => $"{d}"));
}
