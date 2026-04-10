using System.Collections.Immutable;

namespace GqlPlus.Ast;

[ExcludeFromCodeCoverage]
internal sealed class FieldsAst<TValue>
  : Dictionary<IAstFieldKey, TValue>
  , IEquatable<Dictionary<IAstFieldKey, TValue>>
  , IAstFields<TValue>
  where TValue : IAstValue<TValue>
{
  public FieldsAst()
    : base() { }
  public FieldsAst(IAstFieldKey key, TValue value)
    : base(key.DictWith(value)) { }
  public FieldsAst(IDictionary<IAstFieldKey, TValue> dict)
    : base(dict) { }

  public bool Equals(Dictionary<IAstFieldKey, TValue>? other)
    => other is not null
    && Keys.OrderedEqual(other.Keys)
    && Keys.All(k => this[k]?.Equals(other[k]) ?? false);

  IImmutableDictionary<IAstFieldKey, TValue> IImmutableDictionary<IAstFieldKey, TValue>.Add(IAstFieldKey key, TValue value)
    => throw new NotImplementedException();

  IImmutableDictionary<IAstFieldKey, TValue> IImmutableDictionary<IAstFieldKey, TValue>.AddRange(IEnumerable<KeyValuePair<IAstFieldKey, TValue>> pairs)
    => throw new NotImplementedException();

  IImmutableDictionary<IAstFieldKey, TValue> IImmutableDictionary<IAstFieldKey, TValue>.Clear()
    => throw new NotImplementedException();

  IImmutableDictionary<IAstFieldKey, TValue> IImmutableDictionary<IAstFieldKey, TValue>.Remove(IAstFieldKey key)
    => throw new NotImplementedException();

  IImmutableDictionary<IAstFieldKey, TValue> IImmutableDictionary<IAstFieldKey, TValue>.RemoveRange(IEnumerable<IAstFieldKey> keys)
    => throw new NotImplementedException();

  IImmutableDictionary<IAstFieldKey, TValue> IImmutableDictionary<IAstFieldKey, TValue>.SetItem(IAstFieldKey key, TValue value)
    => throw new NotImplementedException();

  IImmutableDictionary<IAstFieldKey, TValue> IImmutableDictionary<IAstFieldKey, TValue>.SetItems(IEnumerable<KeyValuePair<IAstFieldKey, TValue>> items)
    => throw new NotImplementedException();

  bool IImmutableDictionary<IAstFieldKey, TValue>.TryGetKey(IAstFieldKey equalKey, out IAstFieldKey actualKey)
    => throw new NotImplementedException();

  bool IImmutableDictionary<IAstFieldKey, TValue>.Contains(KeyValuePair<IAstFieldKey, TValue> pair)
    => this.Contains(pair);
  bool IEquatable<IAstFields<TValue>>.Equals(IAstFields<TValue>? other)
    => Equals(other as FieldsAst<TValue>);
}
