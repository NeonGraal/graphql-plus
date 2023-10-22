namespace GqlPlus.Verifier.Ast;

internal abstract record class AstValues<T>
  : AstBase, IEquatable<AstValues<T>>
{
  public T[] Values { get; } = Array.Empty<T>();
  public ObjectAst Fields { get; } = new ObjectAst();

  protected AstValues(ParseAt at)
    : base(at) { }
  internal AstValues(ParseAt at, T[] values)
    : base(at)
    => Values = values;
  internal AstValues(ParseAt at, ObjectAst fields)
    : base(at)
    => Fields = fields;

  public virtual bool Equals(AstValues<T>? other)
    => other is not null
    && Values.SequenceEqual(other.Values)
    && Fields.Equals(other.Fields);
  public override int GetHashCode()
    => HashCode.Combine(Values.Length, Fields.Count);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Values.Bracket("[", "]"))
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
