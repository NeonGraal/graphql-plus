using System.Collections;
using System.Collections.Immutable;

namespace GqlPlus.Abstractions;

public interface IGqlpError
{
  ITokenMessages MakeError(string message);
}

public interface IGqlpAbbreviated
  : IGqlpError
{
  ITokenAt At { get; }
  string Abbr { get; }
  IEnumerable<string?> GetFields();
}

public interface IGqlpNamed
  : IGqlpAbbreviated
{
  string Name { get; }
}

public interface IGqlpFieldKey
  : IGqlpAbbreviated
  , IEquatable<IGqlpFieldKey>
  , IComparable<IGqlpFieldKey>
{
  decimal? Number { get; }
  string? Text { get; }
  string? EnumMember { get; }
  string? EnumType { get; }
  string? EnumValue { get; }
}

public interface IGqlpModifier
  : IGqlpError
{
  ModifierKind ModifierKind { get; }
  string? Key { get; }
  bool IsOptional { get; }
}

public enum ModifierKind
{
  Opt,
  Optional = Opt,
  List,
  Dict,
  Dictionary = Dict,
  Param,
  TypeParam = Param,
}

public interface IGqlpModifiers
{
  IEnumerable<IGqlpModifier> Modifiers { get; }
}

public interface IGqlpConstant
  : IGqlpValue<IGqlpConstant>
  , IEquatable<IGqlpConstant>
{
  IGqlpFieldKey? Value { get; }
}

public interface IGqlpValue<TValue>
  : IGqlpAbbreviated
  , IEquatable<IGqlpValue<TValue>>
{
  IEnumerable<TValue> Values { get; }
  IGqlpFields<TValue> Fields { get; }
}

public interface IGqlpFields<TValue>
  : IImmutableDictionary<IGqlpFieldKey, TValue>
  , IEquatable<IGqlpFields<TValue>>
{ }

public static class IGqlpValuesHelper
{
  private sealed class GqlpFieldsWrapper<TValue>(
    IImmutableDictionary<IGqlpFieldKey, TValue> fields
  ) : IGqlpFields<TValue>
  {
    TValue IReadOnlyDictionary<IGqlpFieldKey, TValue>.this[IGqlpFieldKey key] => fields[key];
    IEnumerable<IGqlpFieldKey> IReadOnlyDictionary<IGqlpFieldKey, TValue>.Keys => fields.Keys;
    IEnumerable<TValue> IReadOnlyDictionary<IGqlpFieldKey, TValue>.Values => fields.Values;
    int IReadOnlyCollection<KeyValuePair<IGqlpFieldKey, TValue>>.Count => fields.Count;

    IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.Add(IGqlpFieldKey key, TValue value)
      => fields.Add(key, value);
    IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.AddRange(IEnumerable<KeyValuePair<IGqlpFieldKey, TValue>> pairs)
      => fields.AddRange(pairs);
    IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.Clear()
      => fields.Clear();
    bool IImmutableDictionary<IGqlpFieldKey, TValue>.Contains(KeyValuePair<IGqlpFieldKey, TValue> pair)
      => fields.Contains(pair);
    bool IReadOnlyDictionary<IGqlpFieldKey, TValue>.ContainsKey(IGqlpFieldKey key)
      => fields.ContainsKey(key);
    bool IEquatable<IGqlpFields<TValue>>.Equals(IGqlpFields<TValue>? other)
      => fields.Equals(other);
    IEnumerator<KeyValuePair<IGqlpFieldKey, TValue>> IEnumerable<KeyValuePair<IGqlpFieldKey, TValue>>.GetEnumerator()
      => fields.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
      => fields.GetEnumerator();
    IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.Remove(IGqlpFieldKey key)
      => fields.Remove(key);
    IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.RemoveRange(IEnumerable<IGqlpFieldKey> keys)
      => fields.RemoveRange(keys);
    IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.SetItem(IGqlpFieldKey key, TValue value)
      => fields.SetItem(key, value);
    IImmutableDictionary<IGqlpFieldKey, TValue> IImmutableDictionary<IGqlpFieldKey, TValue>.SetItems(IEnumerable<KeyValuePair<IGqlpFieldKey, TValue>> items)
      => fields.SetItems(items);
    bool IImmutableDictionary<IGqlpFieldKey, TValue>.TryGetKey(IGqlpFieldKey equalKey, out IGqlpFieldKey actualKey)
      => fields.TryGetKey(equalKey, out actualKey);
#pragma warning disable CS8601 // Possible null reference assignment.
    bool IReadOnlyDictionary<IGqlpFieldKey, TValue>.TryGetValue(IGqlpFieldKey key, out TValue value)
      => fields.TryGetValue(key, out value);
#pragma warning restore CS8601 // Possible null reference assignment.
  }

  public static IGqlpFields<TResult> ToFields<TKey, TValue, TResult>(this IDictionary<TKey, TValue> dictionary, Func<TValue, TResult> valueSelector)
    where TKey : IGqlpFieldKey
    => new GqlpFieldsWrapper<TResult>(dictionary.ToImmutableDictionary(
      kv => (IGqlpFieldKey)kv.Key,
      kv => valueSelector(kv.Value)));
}
