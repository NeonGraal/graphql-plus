namespace GqlPlus.Verifier;

internal class Structured<TValue, TStruct>
  where TValue : notnull
  where TStruct : Structured<TValue, TStruct>
{
  internal class Dict : Dictionary<TValue, TStruct> { }

  internal TValue? Value { get; }
  internal List<TStruct> List { get; } = [];
  internal Dict Map { get; } = [];

  internal Structured() { }
  internal Structured(TValue value)
    => Value = value;
  internal Structured(IEnumerable<TStruct> values)
    => List = [.. values];
  internal Structured(Dictionary<TValue, TStruct> values)
    => Map = (Dict)values;

  public static implicit operator TStruct(Structured<TValue, TStruct> structured)
    => (TStruct)structured;
}

internal static class StructuredHelper
{
  internal static TStruct ToStructured<TSource, TValue, TStruct>(this IEnumerable<TSource> sources, Func<TSource, TStruct> value)
    where TValue : notnull
    where TStruct : Structured<TValue, TStruct>
    => new Structured<TValue, TStruct>(sources.Select(value));

  internal static TStruct ToStructured<TSource, TValue, TStruct>(this IEnumerable<TSource> sources, Func<TSource, TValue> key, Func<TSource, TStruct> value)
    where TValue : notnull
    where TStruct : Structured<TValue, TStruct>
    => new Structured<TValue, TStruct>(sources.ToDictionary(key, value));
}
