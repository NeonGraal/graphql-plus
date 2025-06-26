namespace GqlPlus.Abstractions;

public interface IValue
{
  string Tag { get; }

  bool TryGetString(out string? value);
  bool TryGetNumber(out decimal? value);
  bool TryGetBoolean(out bool? value);

  bool TryGetList(out IEnumerable<IValue>? list);
  bool TryGetMap(out IMap<IValue>? map);
}

public class ScalarValue
  : IValue
{
  public ScalarValue(bool? value, string? tag = null)
    => (Boolean, Tag) = (value, tag ?? "");
  public ScalarValue(string? value, string? tag = null)
    => (Text, Tag) = (value, tag ?? "");
  public ScalarValue(decimal? value, string? tag = null)
    => (Number, Tag) = (value, tag ?? "");

  public virtual string Tag { get; protected set; } = "";

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
    return string.IsNullOrEmpty(value);
  }

  internal static bool TryGet<T>(out T? value, Func<T?> valueGetter)
  {
    value = valueGetter.ThrowIfNull().Invoke();
    return value is not null;
  }

  public virtual bool TryGetString(out string? value)
    => TryGet(out value, () => this switch {
      { Boolean: not null } => Boolean.Value.TrueFalse(),
      { Number: not null } => $"{Number:0.#####}",
      _ => Text,
    });

  public virtual bool TryGetNumber(out decimal? value)
    => TryGet(out value, () => this switch {
      { Boolean: not null } => Boolean.Value ? 1m : 0m,
      { Text: not null } when !string.IsNullOrWhiteSpace(Text)
        => decimal.TryParse(Text, out decimal num) ? num : null,
      _ => Number,
    });

  public virtual bool TryGetBoolean(out bool? value)
    => TryGet(out value, () => this switch {
      { Text: not null } when !string.IsNullOrWhiteSpace(Text)
        => Text.Equals("false", StringComparison.Ordinal) ? false
          : Text.Equals("true", StringComparison.Ordinal) ? true : null,
      { Number: not null } => Number == 0m ? false : Number == 1m ? true : null,
      _ => Boolean,
    });

  public virtual bool TryGetList(out IEnumerable<IValue>? list)
    => TryGet(out list, () => IsEmpty ? null : [this]);

  public virtual bool TryGetMap(out IMap<IValue>? map)
    => TryGet(out map, () => null);
}

#pragma warning disable CA1034 // Nested types should not be visible
public class ComplexValue<TValue, TObject>
  where TValue : ScalarValue
  where TObject : ComplexValue<TValue, TObject>
{
  internal sealed class Dict
    : Dictionary<TValue, TObject>, IDict
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

  public ComplexValue(TValue value)
    => Value = value;
  public ComplexValue(IEnumerable<TObject> values)
    => List = [.. values];
  public ComplexValue(IDictionary<TValue, TObject> values)
    => Map = new Dict(values);
}
