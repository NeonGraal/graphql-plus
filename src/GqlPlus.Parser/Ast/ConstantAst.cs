using GqlPlus.Token;

namespace GqlPlus.Ast;

internal sealed record class ConstantAst(
  ITokenAt At
) : AstValue<IAstConstant>(At)
  , IAstConstant
{
  public IAstFieldKey? Value { get; set; }

  internal override string Abbr => "c";

  internal ConstantAst(IAstFieldKey value)
    : this((TokenAt)value.At)
    => Value = value;

  internal ConstantAst(ITokenAt at, IEnumerable<IAstConstant> values)
    : this(at)
    => Values = [.. values];

  internal ConstantAst(ITokenAt at, IAstFields<IAstConstant> fields)
    : this(at)
    => Fields = fields;

  public bool Equals(ConstantAst? other)
    => other is IAstConstant constant && Equals(constant);
  public bool Equals(IAstConstant? other)
    => base.Equals(other)
    && Value.NullEqual(other.Value);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Value.NullHashCode());

  internal override IEnumerable<string?> GetFields()
    => Value?.GetFields() ?? base.GetFields();
}
