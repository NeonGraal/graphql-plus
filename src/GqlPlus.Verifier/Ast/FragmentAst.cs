namespace GqlPlus.Verifier.Ast;

internal sealed record class FragmentAst : NamedAst, IEquatable<FragmentAst>
{
  internal FragmentAst(string name, string onType)
    : base(name)
    => OnType = onType;

  internal string OnType { get; }

  internal required SelectionAst[] Selections { get; init; }

  public bool Equals(FragmentAst? other)
    => base.Equals(other)
    && OnType == other.OnType
    && Selections.SequenceEqual(other.Selections);

  public override int GetHashCode()
    => HashCode.Combine((NamedAst)this, OnType, Selections);
}
