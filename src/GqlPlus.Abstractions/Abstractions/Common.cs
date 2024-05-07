using System.Collections;
using System.Collections.Immutable;

namespace GqlPlus.Abstractions;

public interface IGqlpConstant
  : IGqlpValue<IGqlpConstant>
{
  IGqlpFieldKey? Value { get; }
}

public interface IGqlpError
{
  ITokenMessages MakeError(string message);
}

public interface IGqlpFieldKey
  : IGqlpError
{
  decimal? Number { get; }
  string? Text { get; }
  string? EnumMember { get; }
  string? EnumType { get; }
  string? EnumValue { get; }
}

public interface IGqlpFields<TValue>
  : IImmutableDictionary<IGqlpFieldKey, TValue>
{ }

public interface IGqlpModifier
{
  ModifierKind ModifierKind { get; }
  IGqlpFieldKey? Key { get; }
}

public enum ModifierKind
{
  Opt,
  Optional = Opt,
  List,
  Dict,
  Dictionary = Dict,
}

public interface IGqlpModifiers
{
  IEnumerable<IGqlpModifier> Modifiers { get; }
}

public interface IGqlpNamed
  : IGqlpError
{
  string Name { get; }
}

public interface IGqlpValue<TValue>
  : IGqlpError
{
  IEnumerable<TValue> Values { get; }
  IGqlpFields<TValue> Fields { get; }
}

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
