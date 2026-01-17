using System.Xml.Xsl;

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

  public static StructureValue Empty(string? tag = null) => new(default(string), tag);

  public StructureValue(bool? value, string? tag = null)
    : base(value, tag) { }
  public StructureValue(string? value, string? tag = null)
    : base(value, tag) => Identifier = value.IsIdentifier() ? value : null;
  public StructureValue(decimal? value, string? tag = null)
    : base(value, tag) { }

  public int CompareTo(StructureValue? other)
    => string.Equals(Tag, other?.Tag, StringComparison.Ordinal)
      ? Apply(
        b => b.CompareTo(other?.Boolean),
        i => string.Compare(i, other?.Identifier, StringComparison.Ordinal),
        n => n.CompareTo(other?.Number),
        t => string.Compare(t, other?.Text, StringComparison.Ordinal),
        other?.IsEmpty == true ? 0 : -1
        ) : -1;

  public override bool Equals(object obj) => Equals(obj as StructureValue);
  public bool Equals(StructureValue? other)
    => ScalarEquals(other, () => Identifier.BothValued(other?.Identifier)
      ? string.Equals(Identifier, other.Identifier, StringComparison.Ordinal)
      : IsEmpty && other?.IsEmpty == true);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Identifier);

  public string AsString
    => Apply(
      b => b.TrueFalse(),
      i => i,
      n => $"{n:0.#####}",
      t => t,
      ""
    );

  public override string ToString()
    => Tag.Suffixed("!")
    + Apply(
      b => "B:" + b.TrueFalse(),
      i => "I:" + i,
      n => $"N:{n:0.#####}",
      t => "T:" + t,
      "E"
    );

  private T Apply<T>(Func<bool, T> boolFunc, Func<string, T> idFunc, Func<decimal, T> numFunc, Func<string, T> txtFunc, T empty)
    => this switch {
      { Boolean: not null } => boolFunc(Boolean.Value),
      { Identifier: not null } when !string.IsNullOrWhiteSpace(Identifier) => idFunc(Identifier),
      { Number: not null } => numFunc(Number.Value),
      { Text: not null } when !string.IsNullOrEmpty(Text) => txtFunc(Text),
      _ => empty,
    };
}
