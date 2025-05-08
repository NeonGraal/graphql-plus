namespace GqlPlus.Structures;

#pragma warning disable CA1036 // Override methods on comparable types
public sealed class StructureValue
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

  public override bool Equals(object obj) => Equals(obj as StructureValue);
  public bool Equals(StructureValue? other)
    => string.Equals(Tag, other?.Tag, StringComparison.Ordinal) && (Boolean.BothValued(other?.Boolean) ? Boolean.Value == other.Boolean
      : Number.BothValued(other?.Number) ? Number.Value == other.Number
      : Identifier.BothValued(other?.Identifier) ? string.Equals(Identifier, other.Identifier, StringComparison.Ordinal)
      : Text.BothValued(other?.Text) && string.Equals(Text, other.Text, StringComparison.Ordinal));
  public override int GetHashCode()
    => HashCode.Combine(Tag,
      Boolean?.GetHashCode() ?? 0,
      Number?.GetHashCode() ?? 0,
      Identifier?.GetHashCode() ?? 0,
      Text?.GetHashCode() ?? 0);

  public string AsString => this switch {
    { Boolean: not null } => Boolean.Value.TrueFalse(),
    { Identifier: not null } => Identifier,
    { Number: not null } => $"{Number}",
    { Text: not null } => Text,
    _ => string.Empty,
  };
}
