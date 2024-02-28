using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Verifier.Rendering;

[SuppressMessage("Design", "CA1036:Override methods on comparable types")]
public record class RenderValue
  : IComparable<RenderValue>
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

  public RenderValue(bool? value)
    => Boolean = value;
  public RenderValue(string? value)
    => Identifier = value;
  public RenderValue(decimal? value)
    => Number = value;

  private RenderValue() { }

  public static RenderValue Str(string? value)
    => new() { Text = value };

  public int CompareTo(RenderValue? other)
    => BothValued(other?.Boolean, Boolean) ? Boolean.Value.CompareTo(other.Boolean)
    : BothValued(other?.Number, Number) ? Number.Value.CompareTo(other.Number)
    : BothValued(other?.Identifier, Identifier) ? string.Compare(Identifier, other.Identifier, StringComparison.Ordinal)
    : BothValued(other?.Text, Text) ? string.Compare(Text, other.Text, StringComparison.Ordinal)
    : -1;

  private static bool BothValued<T>([NotNullWhen(true)] T? left, [NotNullWhen(true)] T? right)
    => left is not null && right is not null;
}
