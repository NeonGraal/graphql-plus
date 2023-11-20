namespace GqlPlus.Verifier.Ast;

public abstract record class AstValue<T>
  : AstBase, IEquatable<AstValue<T>>
{
  public T[] Values { get; } = Array.Empty<T>();
  public ObjectAst Fields { get; } = new ObjectAst();

  protected AstValue(ParseAt at)
    : base(at) { }
  internal AstValue(ParseAt at, T[] values)
    : base(at)
    => Values = values;
  internal AstValue(ParseAt at, ObjectAst fields)
    : base(at)
    => Fields = fields;

  public virtual bool Equals(AstValue<T>? other)
    => other is not null
    && Values.SequenceEqual(other.Values)
    && Fields.Equals(other.Fields);
  public override int GetHashCode()
    => HashCode.Combine(Values.Length, Fields.Count);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Values.Bracket("[", "]"))
      .Concat(Fields.Bracket("{", "}", kv => $"{kv.Key}:{kv.Value}"));

  public class ObjectAst : Dictionary<FieldKeyAst, T>, IEquatable<Dictionary<FieldKeyAst, T>>
  {
    public ObjectAst() : base() { }
    public ObjectAst(IDictionary<FieldKeyAst, T> dict) : base(dict) { }

    public virtual bool Equals(Dictionary<FieldKeyAst, T>? other)
      => other is not null
      && Keys.Order().SequenceEqual(other.Keys.Order())
      && Keys.All(k => this[k]?.Equals(other[k]) ?? false);
  }
}
