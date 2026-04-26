using System.Diagnostics.CodeAnalysis;

namespace GqlPlus;

public interface IValue
{
  string Tag { get; }

  bool TryGetBoolean([NotNullWhen(true)] out bool? value);
  bool TryGetNumber([NotNullWhen(true)] out decimal? value);
  bool TryGetText([NotNullWhen(true)] out string? value);

  bool TryGetList([NotNullWhen(true)] out IEnumerable<IValue>? list);
  bool TryGetMap([NotNullWhen(true)] out IMap<IValue>? map);
}

public abstract class BaseValue
  : IValue
{
  public virtual string Tag { get; set; } = "";

  internal static bool TryGet<T>(out T? value, Func<T?> valueGetter)
  {
    value = valueGetter.Invoke();
    return value is not null;
  }

  public abstract bool TryGetBoolean([NotNullWhen(true)] out bool? value);
  public abstract bool TryGetNumber([NotNullWhen(true)] out decimal? value);
  public abstract bool TryGetText([NotNullWhen(true)] out string? value);

  public virtual bool TryGetList([NotNullWhen(true)] out IEnumerable<IValue>? list)
    => (list = null) is not null;

  public virtual bool TryGetMap([NotNullWhen(true)] out IMap<IValue>? map)
    => (map = null) is not null;
}

public class ScalarValue
  : BaseValue
  , IEquatable<ScalarValue>
{
  public ScalarValue(bool? value, string? tag = null)
    => (Boolean, Tag) = (value, tag.IfWhiteSpace());
  public ScalarValue(string? value, string? tag = null)
    => (Text, Tag) = (value, tag.IfWhiteSpace());
  public ScalarValue(decimal? value, string? tag = null)
    => (Number, Tag) = (value, tag.IfWhiteSpace());

  public virtual bool IsEmpty
    => string.IsNullOrEmpty(Text)
    && Boolean is null
    && Number is null;

  public bool? Boolean { get; }
  public virtual string? Text { get; private init; }
  public decimal? Number { get; }

  internal static bool TryGet(out string? value, Func<string?> valueGetter)
  {
    value = valueGetter.ThrowIfNull().Invoke();
    return !string.IsNullOrEmpty(value);
  }

  public override bool TryGetBoolean([NotNullWhen(true)] out bool? value)
    => TryGet(out value, () => Boolean);
  public override bool TryGetNumber([NotNullWhen(true)] out decimal? value)
    => TryGet(out value, () => Number);
  public override bool TryGetText([NotNullWhen(true)] out string? value)
    => TryGet(out value, () => Text);

  public override bool Equals(object obj)
    => Equals(obj as ScalarValue);
  public bool Equals(ScalarValue? other)
    => ScalarEquals(other, () => IsEmpty && other?.IsEmpty == true);
  protected bool ScalarEquals(ScalarValue? other, Func<bool>? otherwise = null)
    => other is not null
      && string.Equals(Tag, other.Tag, StringComparison.Ordinal)
      && this switch {
        { Boolean: not null }
          => other.Boolean == Boolean,
        { Number: not null }
          => other.Number == Number,
        _ when !string.IsNullOrEmpty(Text)
          => string.Equals(Text, other.Text, StringComparison.Ordinal),
        _ => otherwise?.Invoke() ?? false,
      };

  public override int GetHashCode()
    => HashCode.Combine(Tag, Boolean, Number, Text);
}

#pragma warning disable CA1034 // Nested types should not be visible
public class ComplexValue<TValue, TObject>
  : BaseValue
  , IEquatable<ComplexValue<TValue, TObject>>
  where TValue : ScalarValue, IEquatable<TValue>
  where TObject : ComplexValue<TValue, TObject>, IEquatable<TObject>, IValue
{
  internal sealed class Dict
    : SortedDictionary<TValue, TObject>, IDict
  {
    internal Dict() : base() { }
    internal Dict(IDictionary<TValue, TObject> dictionary)
      : base(dictionary) { }

    public bool Equals(IDict other)
      => other is not null
      && Keys.OrderedEqual(other.Keys)
      && Keys.All(k => this[k].Equals(other[k]));
  }

  public interface IDict
    : IDictionary<TValue, TObject>
    , IEquatable<IDict>
  { }

  public TValue? Value { get; }
  public IList<TObject> List { get; } = [];
  public IDict Map { get; } = new Dict();

  public ComplexValue(TValue? value)
    => Value = value;
  public ComplexValue(IEnumerable<TObject> values)
    => List = [.. values];
  public ComplexValue(IDictionary<TValue, TObject> values)
    => Map = new Dict(values);
  public bool IsEmpty
    => (Value?.IsEmpty ?? true) && List.Count == 0 && Map.Count == 0;

  public override bool TryGetBoolean([NotNullWhen(true)] out bool? value)
    => TryGet(out value, () => Value?.TryGetBoolean(out bool? val) == true ? val : null);
  public override bool TryGetNumber([NotNullWhen(true)] out decimal? value)
    => TryGet(out value, () => Value?.TryGetNumber(out decimal? val) == true ? val : null);
  public override bool TryGetText([NotNullWhen(true)] out string? value)
    => TryGet(out value, () => Value?.TryGetText(out string? val) == true ? val : null);
  public override bool TryGetList([NotNullWhen(true)] out IEnumerable<IValue>? list)
    => TryGet(out list, () => List.Count > 0 ? List : null);
  public override bool TryGetMap([NotNullWhen(true)] out IMap<IValue>? map)
    => TryGet(out map, () => Map.Count > 0 ? Map.ToMap(k => k.Key.TryGetText(out string? text) ? text : "", v => v.Value as IValue) : null);

  public override bool Equals(object obj)
    => Equals(obj as ComplexValue<TValue, TObject>);
  public bool Equals(ComplexValue<TValue, TObject>? other)
    => other is not null
      && string.Equals(Tag, other.Tag, StringComparison.Ordinal)
      && Apply(
        l => l.SequenceEqual(other.List),
        m => m.Equals(other.Map),
        v => v.Equals(other.Value),
        other.IsEmpty);
  public override int GetHashCode()
    => HashCode.Combine(Tag,
      Value.NullHashCode(),
      List.NullHashCode(),
      Map.NullHashCode());

  public override string ToString()
    => Apply(
      l => Tag.Suffixed("!") + l.Surround("[ ", " ]", i => $"{i}", ", "),
      m => Tag.Suffixed("!") + m.Surround("{ ", " }", i => $"{i.Key}: {i.Value}", ", "),
      v => $"{v}",
      Tag + "()");

  private T Apply<T>(
    Func<IList<TObject>, T> listFunc,
    Func<IDict, T> mapFunc,
    Func<TValue, T> valueFunc,
    T empty
  ) => this switch {
    { List.Count: > 0 } => listFunc(List),
    { Map.Count: > 0 } => mapFunc(Map),
    { Value: not null } => valueFunc(Value),
    _ => empty
  };
}
