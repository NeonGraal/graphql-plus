namespace GqlPlus.Verifier.Ast;

internal sealed record class DefinitionAst : NamedAst, IEquatable<DefinitionAst>
{
  internal DefinitionAst(string name, string onType)
    : base(name)
    => OnType = onType;

  internal string OnType { get; }

  internal required SelectionAst[] Selections { get; init; }

  public bool Equals(DefinitionAst? other)
    => base.Equals(other) &&
      OnType == other.OnType &&
      Selections.SequenceEqual(other.Selections);

  public override int GetHashCode()
    => HashCode.Combine((NamedAst)this, OnType, Selections);
}
