namespace GqlPlus.Verifier.Ast;

internal sealed record class ConstantAst : FieldKeyAst, IEquatable<ConstantAst>
{
  internal ConstantAst[] Values { get; set; } = Array.Empty<ConstantAst>();

  internal IDictionary<FieldKeyAst, ConstantAst> Fields { get; set; } = new Dictionary<FieldKeyAst, ConstantAst>();

  public bool Equals(ConstantAst? other)
    => base.Equals(other)
    && Values.SequenceEqual(other.Values)
    && Fields.Ordered().SequenceEqual(other.Fields.Ordered());

  public override int GetHashCode()
    => HashCode.Combine((FieldKeyAst)this, Values, Fields);
}
