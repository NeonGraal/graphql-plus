using System.Collections;

namespace GqlPlus;

public static class Defer<T>
  where T : class
{
  public delegate T D();
  public delegate IEnumerable<T> DA();
  public delegate IReadOnlyMap<T> DM();
  public delegate IReadOnlyDictionary<TKey, T> DD<TKey>();

#pragma warning disable CA1034 // Nested types should not be visible
  public class L(D factory)
    : Lazy<T>(() => factory())
  {
    public static implicit operator L(D factory)
      => new(factory.ThrowIfNull());

    public T I => Value;
  }

  public class LA(DA factory)
    : Lazy<IEnumerable<T>>(() => factory())
  {
    public static implicit operator LA(DA factory)
      => new(factory.ThrowIfNull());

    public IEnumerable<T> IA => Value;

    public LM ToMap(Func<T, string> keySelector)
      => new(() => Value.ToMap(keySelector));
    public Defer<TOutput>.LM ToMap<TOutput>(Func<T, string> keySelector, Func<T, TOutput> valueSelector)
      where TOutput : class
      => new(() => Value.ToMap(keySelector, valueSelector));

    public LD<TKey> ToDictionary<TKey>(Func<T, TKey> keySelector)
      => new(() => Value.ToDictionary(keySelector));
    public Defer<TOutput>.LD<TKey> ToDictionary<TOutput, TKey>(Func<T, TKey> keySelector, Func<T, TOutput> valueSelector)
      where TOutput : class
      => new(() => Value.ToDictionary(keySelector, valueSelector));
  }

  public class LM(DM factory)
    : Lazy<IReadOnlyMap<T>>(() => factory())
    , IReadOnlyMap<T>
  {
    public static implicit operator LM(DM factory)
      => new(factory.ThrowIfNull());

    public IReadOnlyMap<T> IM => Value;
    public IEnumerable<string> Keys => IM.Keys;
    public IEnumerable<T> Values => IM.Values;
    public int Count => IM.Count;
    public T this[string key] => ((IReadOnlyDictionary<string, T>)IM)[key];
    public T? GetValueOr(string key) => IM.GetValueOr(key);
    public bool ContainsKey(string key) => IM.ContainsKey(key);
    public bool TryGetValue(string key, out T value) => IM.TryGetValue(key, out value);
    public IEnumerator<KeyValuePair<string, T>> GetEnumerator() => IM.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)IM).GetEnumerator();
  }

  public class LD<TKey>(DD<TKey> factory)
    : Lazy<IReadOnlyDictionary<TKey, T>>(() => factory())
    , IReadOnlyDictionary<TKey, T>
  {
    public static implicit operator LD<TKey>(DD<TKey> factory)
      => new(factory.ThrowIfNull());

    public IReadOnlyDictionary<TKey, T> ID => Value;
    public IEnumerable<TKey> Keys => ID.Keys;
    public IEnumerable<T> Values => ID.Values;
    public int Count => ID.Count;
    public T this[TKey key] => ID[key];
    public bool ContainsKey(TKey key) => ID.ContainsKey(key);
    public bool TryGetValue(TKey key, out T value) => ID.TryGetValue(key, out value);
    public IEnumerator<KeyValuePair<TKey, T>> GetEnumerator() => ID.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)ID).GetEnumerator();
  }
}

public static class DeferHelpers
{
  public static Defer<T>.LM ToMap<T>(this Defer<T>.DA items, Func<T, string> keySelector)
    where T : class
    => new(() => items().ToMap(keySelector));
  public static Defer<TOutput>.LM ToMap<TInput, TOutput>(this Defer<TInput>.DA items, Func<TInput, string> keySelector, Func<TInput, TOutput> valueSelector)
    where TInput : class
    where TOutput : class
    => new(() => items().ToMap(keySelector, valueSelector));

  public static Defer<T>.LD<TKey> ToDictionary<TKey, T>(this Defer<T>.DA items, Func<T, TKey> keySelector)
    where T : class
    => new(() => items().ToDictionary(keySelector));
  public static Defer<TOutput>.LD<TKey> ToDictionary<TKey, TInput, TOutput>(this Defer<TInput>.DA items, Func<TInput, TKey> keySelector, Func<TInput, TOutput> valueSelector)
    where TInput : class
    where TOutput : class
    => new(() => items().ToDictionary(keySelector, valueSelector));
}
