using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus;

public record struct DomainRangeInput(decimal? Min, decimal? Max)
{
  private bool? _minLtMax;
  private bool MinLtMax
  {
    get {
      _minLtMax ??= Min is null || Max is null || Min <= Max;
      return _minLtMax.Value;
    }
  }

  public decimal? Lower => MinLtMax ? Min : Max;
  public decimal? Upper => MinLtMax ? Max : Min;

  public override string ToString()
  {
    if (Lower is null) {
      return $"< {Upper}";
    }

    string result = $"{Lower}";

    if (Upper is null) {
      result += " >";
    } else if (Upper != Lower) {
      result += $" ~ {Upper}";
    }

    return result;
  }

  internal DomainRangeAst[] DomainRange()
    => [new(AstNulls.At, false, Lower, Upper)];
}

public record struct AlternateInput(string Type)
  : IComparable<AlternateInput>
{
  public bool TypeParameter { get; private init; } = false;

  public AlternateInput MakeTypeParameter()
    => this with { TypeParameter = true };

  public readonly int CompareTo(AlternateInput other)
    => string.CompareOrdinal(Type, other.Type);
}

public record struct FieldInput(string Name, string Type)
  : IComparable<FieldInput>
{
  public bool TypeParameter { get; private init; } = false;

  public FieldInput MakeTypeParameter()
    => this with { TypeParameter = true };

  public readonly int CompareTo(FieldInput other)
  {
    int comp = string.CompareOrdinal(Name, other.Name);

    return comp == 0 ? string.CompareOrdinal(Type, other.Type) : comp;
  }
}
