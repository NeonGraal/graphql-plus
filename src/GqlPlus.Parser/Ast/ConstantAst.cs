using GqlPlus.Token;

namespace GqlPlus.Ast;

internal sealed record class ConstantAst(
  ITokenAt At
) : AstValue<IGqlpConstant>(At)
  , IEquatable<ConstantAst>
  , IGqlpConstant
{
  public IGqlpFieldKey? Value { get; set; }

  internal override string Abbr => "c";

  internal ConstantAst(IGqlpFieldKey value)
    : this((TokenAt)value.At)
    => Value = value;

  internal ConstantAst(TokenAt at, IEnumerable<IGqlpConstant> values)
    : this(at)
    => Values = [.. values];

  internal ConstantAst(TokenAt at, IGqlpFields<IGqlpConstant> fields)
    : this(at)
    => Fields = fields;

  public bool Equals(ConstantAst? other)
    => base.Equals(other)
    && Value.NullEqual(other.Value);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Value);

  internal override IEnumerable<string?> GetFields()
    => Value?.GetFields() ?? base.GetFields();

  bool IEquatable<IGqlpConstant>.Equals(IGqlpConstant? other)
    => Equals(other as ConstantAst);
}
