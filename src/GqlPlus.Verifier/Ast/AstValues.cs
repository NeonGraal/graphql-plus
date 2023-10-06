namespace GqlPlus.Verifier.Ast;

internal abstract record class AstValues<T> : AstBase, IEquatable<AstValues<T>>
{
  public T[] Values { get; } = Array.Empty<T>();
  public ObjectAst Fields { get; } = new ObjectAst();

  protected AstValues() { }
  internal AstValues(T[] values)
    => Values = values;
  internal AstValues(ObjectAst fields)
    => Fields = fields;

  public virtual bool Equals(AstValues<T>? other)
    => other is not null
    && Values.SequenceEqual(other.Values)
    && Fields.Equals(other.Fields);
  public override int GetHashCode()
    => HashCode.Combine(Values, Fields);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Values.Bracket("[", "]", v => $"{v}"))
      .Concat(Fields.Bracket("{", "}", kv => $"{kv.Key}:{kv.Value}"));

  internal class ObjectAst : Dictionary<FieldKeyAst, T>, IEquatable<Dictionary<FieldKeyAst, T>>
  {
    public ObjectAst() : base() { }
    public ObjectAst(IDictionary<FieldKeyAst, T> dict) : base(dict) { }

    public virtual bool Equals(Dictionary<FieldKeyAst, T>? other)
      => other is not null
      && Keys.Order().SequenceEqual(other.Keys.Order())
      && Keys.All(k => this[k]?.Equals(other[k]) ?? false);
  }
}
