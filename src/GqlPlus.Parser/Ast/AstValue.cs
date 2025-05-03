﻿using GqlPlus.Token;

namespace GqlPlus.Ast;

internal abstract record class AstValue<TValue>(ITokenAt At)
  : AstAbbreviated(At)
  , IEquatable<AstValue<TValue>>
  , IGqlpValue<TValue>
  where TValue : IGqlpValue<TValue>
{
  public TValue[] Values { get; init; } = [];
  public IGqlpFields<TValue> Fields { get; init; } = new AstFields<TValue>();

  IEnumerable<TValue> IGqlpValue<TValue>.Values => Values;
  IGqlpFields<TValue> IGqlpValue<TValue>.Fields => Fields;

  internal AstValue(ITokenAt at, IEnumerable<TValue> values)
    : this(at)
    => Values = [.. values];
  internal AstValue(ITokenAt at, IGqlpFields<TValue> fields)
    : this(at)
    => Fields = fields;

  public virtual bool Equals(AstValue<TValue>? other)
    => other is not null
    && Values.SequenceEqual(other.Values)
    && Fields.Equals(other.Fields);
  public override int GetHashCode()
    => HashCode.Combine(Values.Length, Fields.Count);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Values.Bracket("[", "]"))
      .Concat(Fields.Bracket("{", "}", kv => $"{kv.Key}:{kv.Value}"));
  bool IEquatable<IGqlpValue<TValue>>.Equals(IGqlpValue<TValue>? other)
    => Equals(other as AstValue<TValue>);
}
