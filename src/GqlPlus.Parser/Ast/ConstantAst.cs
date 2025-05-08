using GqlPlus.Token;

namespace GqlPlus.Ast;

internal sealed record class ConstantAst(
  TokenAt At
) : AstValue<IGqlpConstant>(At)
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
    => other is IGqlpConstant constant && Equals(constant);
  public bool Equals(IGqlpConstant? other)
    => base.Equals(other)
    && Value.NullEqual(other.Value);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Value);

  internal override IEnumerable<string?> GetFields()
    => Value?.GetFields() ?? base.GetFields();
}
