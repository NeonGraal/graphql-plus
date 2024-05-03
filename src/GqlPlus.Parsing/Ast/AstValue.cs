using GqlPlus.Token;

namespace GqlPlus.Ast;

public abstract record class AstValue<T>(TokenAt At)
  : AstAbbreviated(At), IEquatable<AstValue<T>>
  where T : AstValue<T>
{
  public T[] Values { get; init; } = [];
  public AstFields<T> Fields { get; init; } = [];

  internal AstValue(TokenAt at, T[] values)
    : this(at)
    => Values = values;
  internal AstValue(TokenAt at, AstFields<T> fields)
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
