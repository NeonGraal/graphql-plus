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

public class BaseValue
  : IValue
{
  public BaseValue(bool? value, string tag = "")
    => (Boolean, Tag) = (value, tag);
  public BaseValue(string? value, string tag = "")
    => (Text, Tag) = (value, tag);
  public BaseValue(decimal? value, string tag = "")
    => (Number, Tag) = (value, tag);

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
