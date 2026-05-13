using System.Collections;

namespace GqlPlus;

public class DeferOne<TValue>(
  DeferOne<TValue>.D factory
) : Lazy<TValue>(() => factory())
  where TValue : class
{
  public delegate TValue D();
  public static implicit operator DeferOne<TValue>(D factory)
    => new(factory.ThrowIfNull());
  public TValue I => Value;
}

public class DeferList<TValue>(
  DeferList<TValue>.D factory
) : Lazy<IEnumerable<TValue>>(() => [.. factory()])
  , IEnumerable<TValue>
  where TValue : class
{
  public delegate IEnumerable<TValue> D();
  public static implicit operator DeferList<TValue>(D factory)
    => new(factory.ThrowIfNull());

  public DeferMap<TValue> ToMap(Func<TValue, string> keySelector)
    => new(() => Value.ToMap(keySelector));
  public DeferMap<TOutput> ToMap<TOutput>(Func<TValue, string> keySelector, Func<TValue, TOutput> valueSelector)
    where TOutput : class
    => new(() => Value.ToMap(keySelector, valueSelector));

  public DeferDict<TKey, TValue> ToDictionary<TKey>(Func<TValue, TKey> keySelector)
    => new(() => Value.ToDictionary(keySelector));
  public DeferDict<TKey, TOutput> ToDictionary<TKey, TOutput>(Func<TValue, TKey> keySelector, Func<TValue, TOutput> valueSelector)
    where TOutput : class
    => new(() => Value.ToDictionary(keySelector, valueSelector));

  public IEnumerator<TValue> GetEnumerator() => Value.GetEnumerator();
  IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Value).GetEnumerator();
}

public class DeferMap<TValue>(
  DeferMap<TValue>.D factory
) : Lazy<IReadOnlyMap<TValue>>(() => factory())
  , IReadOnlyMap<TValue>
{
  public delegate IReadOnlyMap<TValue> D();

  public IEnumerable<string> Keys => Value.Keys;
  public IEnumerable<TValue> Values => Value.Values;
  public int Count => Value.Count;
  public TValue this[string key] => ((IReadOnlyDictionary<string, TValue>)Value)[key];
  public TValue? GetValueOr(string key) => Value.GetValueOr(key);
  public bool ContainsKey(string key) => Value.ContainsKey(key);
  public bool TryGetValue(string key, out TValue value) => Value.TryGetValue(key, out value);
  public IEnumerator<KeyValuePair<string, TValue>> GetEnumerator() => Value.GetEnumerator();
  IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Value).GetEnumerator();
}

public class DeferDict<TKey, TValue>(
  DeferDict<TKey, TValue>.D factory
) : Lazy<IReadOnlyDictionary<TKey, TValue>>(() => factory())
  , IReadOnlyDictionary<TKey, TValue>
{
  public delegate IReadOnlyDictionary<TKey, TValue> D();

  public IEnumerable<TKey> Keys => Value.Keys;
  public IEnumerable<TValue> Values => Value.Values;
  public int Count => Value.Count;
  public TValue this[TKey key] => Value[key];
  public bool ContainsKey(TKey key) => Value.ContainsKey(key);
  public bool TryGetValue(TKey key, out TValue value) => Value.TryGetValue(key, out value);
  public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Value.GetEnumerator();
  IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Value).GetEnumerator();
}

public static class DeferHelpers
{
  public static DeferMap<T> ToMap<T>(this DeferList<T>.D items, Func<T, string> keySelector)
    where T : class
    => new(() => items().ToMap(keySelector));
  public static DeferMap<TOutput> ToMap<TInput, TOutput>(this DeferList<TInput>.D items, Func<TInput, string> keySelector, Func<TInput, TOutput> valueSelector)
    where TInput : class
    where TOutput : class
    => new(() => items().ToMap(keySelector, valueSelector));

  public static DeferDict<TKey, TValue> ToDictionary<TKey, TValue>(this DeferList<TValue>.D items, Func<TValue, TKey> keySelector)
    where TValue : class
    => new(() => items().ToDictionary(keySelector));
  public static DeferDict<TKey, TOutput> ToDictionary<TKey, TInput, TOutput>(this DeferList<TInput>.D items, Func<TInput, TKey> keySelector, Func<TInput, TOutput> valueSelector)
    where TInput : class
    where TOutput : class
    => new(() => items().ToDictionary(keySelector, valueSelector));
}
