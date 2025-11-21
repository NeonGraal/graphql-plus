using System.Collections.Immutable;

namespace GqlPlus.Ast;

internal sealed class FieldsAst<TValue>
  : Dictionary<IGqlpFieldKey, TValue>
  , IEquatable<Dictionary<IGqlpFieldKey, TValue>>
  , IGqlpFields<TValue>
  where TValue : IGqlpValue<TValue>
{
  public FieldsAst()
    : base() { }
  public FieldsAst(IGqlpFieldKey key, TValue value)
    : base(key.DictWith(value)) { }
  public FieldsAst(IDictionary<IGqlpFieldKey, TValue> dict)
    : base(dict) { }

  public bool Equals(Dictionary<IGqlpFieldKey, TValue>? other)
    => other is not null
    && Keys.OrderedEqual(other.Keys)
    && Keys.All(k => this[k]?.Equals(other[k]) ?? false);


  IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.Add(IGqlpFieldKey key, TValue value)
    => throw new NotImplementedException();

  IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.AddRange(IEnumerable<KeyValuePair<IGqlpFieldKey, TValue>> pairs)
    => throw new NotImplementedException();

  IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.Clear()
    => throw new NotImplementedException();

  IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.Remove(IGqlpFieldKey key)
    => throw new NotImplementedException();

  IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.RemoveRange(IEnumerable<IGqlpFieldKey> keys)
    => throw new NotImplementedException();

  IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.SetItem(IGqlpFieldKey key, TValue value)
    => throw new NotImplementedException();

  IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.SetItems(IEnumerable<KeyValuePair<IGqlpFieldKey, TValue>> items)
    => throw new NotImplementedException();

  bool IImmutableDictionary<IGqlpFieldKey, TValue>.TryGetKey(IGqlpFieldKey equalKey, out IGqlpFieldKey actualKey)
    => throw new NotImplementedException();

  bool IImmutableDictionary<IGqlpFieldKey, TValue>.Contains(KeyValuePair<IGqlpFieldKey, TValue> pair)
    => this.Contains(pair);
  bool IEquatable<IGqlpFields<TValue>>.Equals(IGqlpFields<TValue>? other)
    => Equals(other as FieldsAst<TValue>);
}
