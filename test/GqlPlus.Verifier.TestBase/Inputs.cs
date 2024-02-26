using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier;

public record struct ScalarRangeInput(decimal? Min, decimal? Max)
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

    var result = $"{Lower}";

    if (Upper is null) {
      result += " >";
    } else if (Upper != Lower) {
      result += $" ~ {Upper}";
    }

    return result;
  }

  public ScalarRangeAst[] ScalarRange()
    => [new(AstNulls.At, false, Lower, Upper)];
}

public record struct FieldInput(string Name, string Type)
  : IComparable<FieldInput>
{
  public readonly int CompareTo(FieldInput other)
  {
    var comp = string.CompareOrdinal(Name, other.Name);

    return comp == 0 ? string.CompareOrdinal(Type, other.Type) : comp;
  }
}
