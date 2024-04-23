using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast;

public sealed record class ConstantAst(TokenAt At)
  : AstValue<ConstantAst>(At), IEquatable<ConstantAst>
{
  public FieldKeyAst? Value { get; set; }

  internal override string Abbr => "c";

  internal ConstantAst(FieldKeyAst value)
    : this(value.At)
    => Value = value;

  internal ConstantAst(TokenAt at, ConstantAst[] values)
    : this(at)
    => Values = values;

  internal ConstantAst(TokenAt at, AstFields<ConstantAst> fields)
    : this(at)
    => Fields = fields;

  public static implicit operator ConstantAst(FieldKeyAst field)
  {
    ArgumentNullException.ThrowIfNull(field);

    return new(field);
  }

  public bool Equals(ConstantAst? other)
    => base.Equals(other)
    && Value.NullEqual(other.Value);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Value);

  internal override IEnumerable<string?> GetFields()
    => Value?.GetFields() ?? base.GetFields();
}
