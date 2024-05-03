namespace GqlPlus;

public class Structured<TValue, TStruct>
  where TValue : notnull
  where TStruct : Structured<TValue, TStruct>
{
  internal class Dict : Dictionary<TValue, TStruct>
  {
    internal Dict() : base() { }
    internal Dict(IDictionary<TValue, TStruct> dictionary)
      : base(dictionary) { }
  }

  internal TValue? Value { get; }
  internal List<TStruct> List { get; } = [];
  internal Dict Map { get; } = [];

  internal Structured() { }
  internal Structured(TValue value)
    => Value = value;
  internal Structured(IEnumerable<TStruct> values)
    => List = [.. values];
  internal Structured(IDictionary<TValue, TStruct> values)
    => Map = new(values);
}
