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
    => other?.Boolean is not null && Boolean.HasValue ? Boolean.Value.CompareTo(other.Boolean)
    : other?.Decimal is not null && Decimal.HasValue ? Decimal.Value.CompareTo(other.Decimal)
    : other?.Identifier is not null && Identifier is not null ? string.Compare(Identifier, other.Identifier, StringComparison.Ordinal)
    : other?.String is not null && String is not null ? string.Compare(String, other.String, StringComparison.Ordinal)
    : -1;
}
