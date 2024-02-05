using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Verifier.Rendering;

public record class RenderValue : IComparable<RenderValue>
{
  public bool IsEmpty
    => string.IsNullOrEmpty(Identifier)
    && string.IsNullOrEmpty(String)
    && Boolean is null
    && Decimal is null;

  public bool? Boolean { get; }
  public string? Identifier { get; }
  public string? String { get; private init; }
  public decimal? Decimal { get; }

  public RenderValue(bool? value)
    => Boolean = value;
  public RenderValue(string? value)
    => Identifier = value;
  public RenderValue(decimal? value)
    => Decimal = value;

  private RenderValue() { }

  public static RenderValue Str(string? value)
    => new() { String = value };

  public int CompareTo(RenderValue? other)
    => BothValued(other?.Boolean, Boolean) ? Boolean.Value.CompareTo(other.Boolean)
    : BothValued(other?.Decimal, Decimal) ? Decimal.Value.CompareTo(other.Decimal)
    : BothValued(other?.Identifier, Identifier) ? string.Compare(Identifier, other.Identifier, StringComparison.Ordinal)
    : BothValued(other?.String, String) ? string.Compare(String, other.String, StringComparison.Ordinal)
    : -1;

  private bool BothValued<T>([NotNullWhen(true)] T? left, [NotNullWhen(true)] T? right)
    => left is not null && right is not null;
}
