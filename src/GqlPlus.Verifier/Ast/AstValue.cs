using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast;

public abstract record class AstValue<T>(TokenAt At)
  : AstBase(At), IEquatable<AstValue<T>>
  where T : AstValue<T>
{
  public T[] Values { get; protected init; } = [];
  public AstObject<T> Fields { get; protected init; } = [];

  internal AstValue(TokenAt at, T[] values)
    : this(at)
    => Values = values;
  internal AstValue(TokenAt at, AstObject<T> fields)
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
}
