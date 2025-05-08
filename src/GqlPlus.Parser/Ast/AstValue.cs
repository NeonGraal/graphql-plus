using GqlPlus.Token;

namespace GqlPlus.Ast;

internal abstract record class AstValue<TValue>(
  TokenAt At
) : AstAbbreviated(At)
  , IGqlpValue<TValue>
  where TValue : IGqlpValue<TValue>
{
  public TValue[] Values { get; init; } = [];
  public IGqlpFields<TValue> Fields { get; init; } = new AstFields<TValue>();

  IEnumerable<TValue> IGqlpValue<TValue>.Values => Values;
  IGqlpFields<TValue> IGqlpValue<TValue>.Fields => Fields;

  internal AstValue(TokenAt at, IEnumerable<TValue> values)
    : this(at)
    => Values = [.. values];
  internal AstValue(TokenAt at, IGqlpFields<TValue> fields)
    : this(at)
    => Fields = fields;

  public virtual bool Equals(AstValue<TValue>? other)
    => other is IGqlpValue<TValue> value && Equals(value);
  public bool Equals(IGqlpValue<TValue>? other)
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
