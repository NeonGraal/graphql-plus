namespace GqlPlus;

public record struct EnumLabelInput(string EnumType, string Label)
  : IComparable<EnumLabelInput>
{
  public readonly int CompareTo(EnumLabelInput other)
    => string.CompareOrdinal(ToString(), other.ToString());
  public override readonly string ToString()
    => string.IsNullOrEmpty(EnumType) ? Label : $"{EnumType}.{Label}";
}

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
      return $"< {Upper:0.#####}";
    }

    string result = $"{Lower:0.#####}";

    if (Upper is null) {
      result += " >";
    } else if (Upper != Lower) {
      result += $" ~ {Upper:0.#####}";
    }

    return result;
  }
}

public record struct TypeInput(
  string Type
) : IComparable<TypeInput>
  , ITypeInput
{
  public bool TypeParam { get; private init; } = false;

  public TypeInput MakeTypeParam()
    => this with { TypeParam = true };

  public readonly int CompareTo(TypeInput other)
    => string.CompareOrdinal(Type, other.Type);
  public override readonly string? ToString()
    => Type;
}

internal interface ITypeInput
{
  string Type { get; }
  bool TypeParam { get; }
}

public record struct FieldInput(string Name, string Type)
  : IComparable<FieldInput>
  , ITypeInput
{
  public bool TypeParam { get; private init; } = false;

  public FieldInput MakeTypeParam()
    => this with { TypeParam = true };

  public readonly int CompareTo(FieldInput other)
  {
    int comp = string.CompareOrdinal(Name, other.Name);

    return comp == 0 ? string.CompareOrdinal(Type, other.Type) : comp;
  }

  public readonly override string? ToString() => $"{Name} : {Type}";
}

public record struct OperationInput(string Name, string Category);
