using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Rendering;

#pragma warning disable CA1036 // Override methods on comparable types
public sealed record class RenderValue
  : IComparable<RenderValue> //, IEquatable<RenderValue>
{
  public bool IsEmpty
    => string.IsNullOrEmpty(Identifier)
    && string.IsNullOrEmpty(Text)
    && Boolean is null
    && Number is null;

  public bool? Boolean { get; }
  public string? Identifier { get; }
  public string? Text { get; private init; }
  public decimal? Number { get; }

  public string Tag { get; private init; } = "";

  public RenderValue(bool? value, string tag = "")
    => (Boolean, Tag) = (value, tag);
  public RenderValue(string? value, string tag = "")
    => (Identifier, Tag) = (value, tag);
  public RenderValue(decimal? value, string tag = "")
    => (Number, Tag) = (value, tag);

  private RenderValue() { }

  public static RenderValue Str(string? value, string tag = "")
    => new() { Text = value, Tag = tag };

  public int CompareTo(RenderValue? other)
    => string.Equals(Tag, other?.Tag, StringComparison.Ordinal)
      ? BothValued(other?.Boolean, Boolean) ? Boolean.Value.CompareTo(other.Boolean)
      : BothValued(other?.Number, Number) ? Number.Value.CompareTo(other.Number)
      : BothValued(other?.Identifier, Identifier) ? string.Compare(Identifier, other.Identifier, StringComparison.Ordinal)
      : BothValued(other?.Text, Text) ? string.Compare(Text, other.Text, StringComparison.Ordinal)
      : -1
    : -1;

  public string AsString
  {
    get {
      if (Identifier is not null) {
        return Identifier;
      } else if (Boolean is not null) {
        return Boolean.Value.TrueFalse();
      } else if (Number is not null) {
        return $"{Number}";
      } else if (Text is not null) {
        return Text;
      }

      return string.Empty;
    }
  }

  private static bool BothValued<T>([NotNullWhen(true)] T? left, [NotNullWhen(true)] T? right)
    => left is not null && right is not null;
}
