namespace GqlPlus;

public enum GqlpScalarKind
{
  Boolean,
  Number,
  Identifier,
  Text,
}

public sealed class GqlpScalar
  : GqlpValue
  , IGqlpScalar
{
  public GqlpScalarKind Kind { get; }
  public bool? Boolean { get; }
  public decimal? Number { get; }
  public string? Text { get; }

  public GqlpScalar(bool value, string? tag = null)
    : base(tag) => (Kind, Boolean) = (GqlpScalarKind.Boolean, value);
  public GqlpScalar(decimal value, string? tag = null)
    : base(tag) => (Kind, Number) = (GqlpScalarKind.Number, value);
  public GqlpScalar(string value, string? tag = null, bool isIdentifier = false)
    : base(tag) => (Kind, Text) = (isIdentifier ? GqlpScalarKind.Identifier : GqlpScalarKind.Text, value);

  protected override bool ValueEquals(GqlpValue other)
    => other is GqlpScalar scalar
      && Kind == scalar.Kind
      && Boolean == scalar.Boolean
      && Number == scalar.Number
      && string.Equals(Text, scalar.Text, StringComparison.Ordinal);

  protected override int ValueHash()
    => Combine((int)Kind, Boolean.GetHashCode(), Number.GetHashCode(), Text is null ? 0 : StringComparer.Ordinal.GetHashCode(Text));

  public override string ToString()
    => Kind switch {
      GqlpScalarKind.Boolean => $"{Boolean}",
      GqlpScalarKind.Number => $"{Number}",
      _ => Text ?? "",
    };
}

public interface IGqlpScalar : IGqlpValue;
