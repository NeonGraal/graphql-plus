namespace GqlPlus.Structures;

#pragma warning disable CA1036 // Override methods on comparable types
public sealed class StructureValue
  : ScalarValue
  , IComparable<StructureValue?>
  , IEquatable<StructureValue?>
{
  public override bool IsEmpty
    => string.IsNullOrWhiteSpace(Identifier)
    && base.IsEmpty;

  public string? Identifier { get; private init; }

  public StructureValue(bool? value, string? tag = null)
    : base(value, tag) { }
  public StructureValue(string? value, string? tag = null)
    : base(value, tag) => Identifier = value.IsIdentifier() ? value : null;
  public StructureValue(decimal? value, string? tag = null)
    : base(value, tag) { }

  public int CompareTo(StructureValue? other)
    => string.Equals(Tag, other?.Tag, StringComparison.Ordinal)
      ? Boolean.BothValued(other?.Boolean) ? Boolean.Value.CompareTo(other.Boolean)
      : Identifier.BothValued(other?.Identifier) ? string.Compare(Identifier, other.Identifier, StringComparison.Ordinal)
      : Number.BothValued(other?.Number) ? Number.Value.CompareTo(other.Number)
      : Text.BothValued(other?.Text) ? string.Compare(Text, other.Text, StringComparison.Ordinal)
      : 0
    : -1;

  public override bool Equals(object obj) => Equals(obj as StructureValue);
  public bool Equals(StructureValue? other)
    => ScalarEquals(other, () => Identifier.BothValued(other?.Identifier)
      ? string.Equals(Identifier, other.Identifier, StringComparison.Ordinal)
      : IsEmpty && other?.IsEmpty == true);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Identifier);

  public string AsString => this switch {
    { Boolean: not null } => Boolean.Value.TrueFalse(),
    { Identifier: not null } when !string.IsNullOrWhiteSpace(Identifier) => Identifier,
    { Number: not null } => $"{Number:0.#####}",
    { Text: not null } when !string.IsNullOrEmpty(Text) => Text,
    _ => "",
  };

  public override string ToString()
    => Tag.Suffixed("!")
    + this switch {
      { Boolean: not null } => "B:" + Boolean.Value.TrueFalse(),
      { Identifier: not null } when !string.IsNullOrWhiteSpace(Identifier) => "I:" + Identifier,
      { Number: not null } => $"N:{Number:0.#####}",
      { Text: not null } when !string.IsNullOrEmpty(Text) => "T:" + Text,
      _ => "E",
    };
}
