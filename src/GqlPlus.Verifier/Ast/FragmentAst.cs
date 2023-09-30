namespace GqlPlus.Verifier.Ast;

internal sealed record class FragmentAst(string Name, string OnType, SelectionAst[] Selections)
  : NamedDirectivesAst(Name), IEquatable<FragmentAst>
{
  public bool Equals(FragmentAst? other)
    => base.Equals(other)
    && OnType == other.OnType
    && Selections.SequenceEqual(other.Selections);

  public override int GetHashCode()
    => HashCode.Combine((NamedAst)this, OnType, Selections);
}
