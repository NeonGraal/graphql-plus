using GqlPlus.Token;

namespace GqlPlus.Ast;

public sealed record class ConstantAst(TokenAt At)
  : AstValue<ConstantAst>(At)
  , IEquatable<ConstantAst>
  , IGqlpConstant
{
  public FieldKeyAst? Value { get; set; }

  internal override string Abbr => "c";

  IGqlpFieldKey? IGqlpConstant.Value => Value;
  IEnumerable<IGqlpConstant> IGqlpValue<IGqlpConstant>.Values => Values;
  IGqlpFields<IGqlpConstant> IGqlpValue<IGqlpConstant>.Fields
    => Fields.ToFields(c => (IGqlpConstant)c);

  internal ConstantAst(FieldKeyAst value)
    : this(value.At)
    => Value = value;

  internal ConstantAst(TokenAt at, IEnumerable<ConstantAst> values)
    : this(at)
    => Values = [.. values];

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
