namespace GqlPlus.Structures;

#pragma warning disable CA1036 // Override methods on comparable types
public sealed record class StructureValue
  : IComparable<StructureValue>
  , IEquatable<StructureValue>
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

  public StructureValue(bool? value, string tag = "")
    => (Boolean, Tag) = (value, tag);
  public StructureValue(string? value, string tag = "")
    => (Identifier, Tag) = (value, tag);
  public StructureValue(decimal? value, string tag = "")
    => (Number, Tag) = (value, tag);

  private StructureValue() { }

  public static StructureValue Str(string? value, string tag = "")
    => new() { Text = value, Tag = tag };

  public int CompareTo(StructureValue? other)
    => string.Equals(Tag, other?.Tag, StringComparison.Ordinal)
      ? Boolean.BothValued(other?.Boolean) ? Boolean.Value.CompareTo(other.Boolean)
      : Number.BothValued(other?.Number) ? Number.Value.CompareTo(other.Number)
      : Identifier.BothValued(other?.Identifier) ? string.Compare(Identifier, other.Identifier, StringComparison.Ordinal)
      : Text.BothValued(other?.Text) ? string.Compare(Text, other.Text, StringComparison.Ordinal)
      : -1
    : -1;

  public bool Equals(StructureValue? other)
    => string.Equals(Tag, other?.Tag, StringComparison.Ordinal) && (Boolean.BothValued(other?.Boolean) ? Boolean.Value == other.Boolean
      : Number.BothValued(other?.Number) ? Number.Value == other.Number
      : Identifier.BothValued(other?.Identifier) ? string.Equals(Identifier, other.Identifier, StringComparison.Ordinal)
      : Text.BothValued(other?.Text) && string.Equals(Text, other.Text, StringComparison.Ordinal));
  public override int GetHashCode()
    => HashCode.Combine(Tag,
      Boolean?.GetHashCode() ?? 0,
      Number?.GetHashCode() ?? 0,
      Identifier?.GetHashCode(StringComparison.Ordinal) ?? 0,
      Text?.GetHashCode(StringComparison.Ordinal) ?? 0);

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
}
