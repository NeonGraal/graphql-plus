namespace GqlPlus.Verifier.Ast;

internal record class ValuesAst<T> : IEquatable<ValuesAst<T>>
{
  internal T[] Values { get; } = Array.Empty<T>();
  internal ObjectAst Fields { get; } = new ObjectAst();

  protected ValuesAst() { }
  internal ValuesAst(T[] values)
    => Values = values;
  internal ValuesAst(ObjectAst fields)
    => Fields = fields;

  public virtual bool Equals(ValuesAst<T>? other)
    => other is not null
    && Values.SequenceEqual(other.Values)
    && Fields.Equals(other.Fields);

  public override int GetHashCode()
    => HashCode.Combine(Values, Fields);

  internal class ObjectAst : Dictionary<FieldKeyAst, T>, IEquatable<Dictionary<FieldKeyAst, T>>
  {
    public virtual bool Equals(Dictionary<FieldKeyAst, T>? other)
      => other is not null
      && Keys.Order().SequenceEqual(other.Keys.Order())
      && Keys.All(k => this[k]?.Equals(other[k]) ?? false);
  }
}
