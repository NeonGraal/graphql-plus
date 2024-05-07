namespace GqlPlus;

#pragma warning disable CA1034 // Nested types should not be visible
public class Structured<TValue, TStruct>
  where TValue : notnull
  where TStruct : Structured<TValue, TStruct>
{
  internal sealed class Dict
    : Dictionary<TValue, TStruct>, IDict
  {
    internal Dict() : base() { }
    internal Dict(IDictionary<TValue, TStruct> dictionary)
      : base(dictionary) { }
  }

  public interface IDict
    : IDictionary<TValue, TStruct>
  { }

  public IDict NewDict => new Dict();

  public TValue? Value { get; }
  public IList<TStruct> List { get; } = [];
  public IDict Map { get; } = new Dict();

  public Structured() { }
  public Structured(TValue value)
    => Value = value;
  public Structured(IEnumerable<TStruct> values)
    => List = [.. values];
  public Structured(IDictionary<TValue, TStruct> values)
    => Map = new Dict(values);
}
