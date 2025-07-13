﻿using System.Collections.Immutable;

namespace GqlPlus.Ast;

internal class AstFields<TValue>
  : Dictionary<IGqlpFieldKey, TValue>
  , IEquatable<Dictionary<IGqlpFieldKey, TValue>>
  , IGqlpFields<TValue>
  where TValue : IGqlpValue<TValue>
{
  public AstFields()
    : base() { }
  public AstFields(IGqlpFieldKey key, TValue value)
    : base(key.DictWith(value)) { }
  public AstFields(IDictionary<IGqlpFieldKey, TValue> dict)
    : base(dict) { }

  public virtual bool Equals(Dictionary<IGqlpFieldKey, TValue>? other)
    => other is not null
    && Keys.OrderedEqual(other.Keys)
    && Keys.All(k => this[k]?.Equals(other[k]) ?? false);

  [ExcludeFromCodeCoverage]
  IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.Add(IGqlpFieldKey key, TValue value)
    => throw new NotImplementedException();
  [ExcludeFromCodeCoverage]
  IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.AddRange(IEnumerable<KeyValuePair<IGqlpFieldKey, TValue>> pairs)
    => throw new NotImplementedException();
  [ExcludeFromCodeCoverage]
  IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.Clear()
    => throw new NotImplementedException();
  [ExcludeFromCodeCoverage]
  IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.Remove(IGqlpFieldKey key)
    => throw new NotImplementedException();
  [ExcludeFromCodeCoverage]
  IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.RemoveRange(IEnumerable<IGqlpFieldKey> keys)
    => throw new NotImplementedException();
  [ExcludeFromCodeCoverage]
  IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.SetItem(IGqlpFieldKey key, TValue value)
    => throw new NotImplementedException();
  [ExcludeFromCodeCoverage]
  IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.SetItems(IEnumerable<KeyValuePair<IGqlpFieldKey, TValue>> items)
    => throw new NotImplementedException();
  [ExcludeFromCodeCoverage]
  bool IImmutableDictionary<IGqlpFieldKey, TValue>.TryGetKey(IGqlpFieldKey equalKey, out IGqlpFieldKey actualKey)
    => throw new NotImplementedException();

  bool IImmutableDictionary<IGqlpFieldKey, TValue>.Contains(KeyValuePair<IGqlpFieldKey, TValue> pair)
    => this.Contains(pair);
  bool IEquatable<IGqlpFields<TValue>>.Equals(IGqlpFields<TValue>? other)
    => Equals(other as AstFields<TValue>);
}
