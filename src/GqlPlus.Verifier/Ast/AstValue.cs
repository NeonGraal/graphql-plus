namespace GqlPlus.Verifier.Ast;

public abstract record class AstValue<T>(ParseAt At)
  : AstBase(At), IEquatable<AstValue<T>>
{
  public T[] Values { get; protected init; } = Array.Empty<T>();
  public ObjectAst Fields { get; protected init; } = new ObjectAst();

  internal AstValue(ParseAt at, T[] values)
    : this(at)
    => Values = values;
  internal AstValue(ParseAt at, ObjectAst fields)
    : this(at)
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
