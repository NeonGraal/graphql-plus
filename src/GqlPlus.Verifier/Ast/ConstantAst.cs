namespace GqlPlus.Verifier.Ast;

internal sealed record class ConstantAst
  : AstValues<ConstantAst>, IEquatable<ConstantAst>
{
  public FieldKeyAst? Value { get; set; }

  internal override string Abbr => "C";

  internal ConstantAst(ParseAt at)
    : base(at) { }

  internal ConstantAst(FieldKeyAst value)
    : base(value.At)
    => Value = value;

  internal ConstantAst(ParseAt at, ConstantAst[] values)
    : base(at, values) { }

  internal ConstantAst(ParseAt at, ObjectAst fields)
    : base(at, fields) { }

  public static implicit operator ConstantAst(FieldKeyAst field)
    => new(field);

  public bool Equals(ConstantAst? other)
    => base.Equals(other)
    && Value.NullEqual(other.Value);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Value);

  internal override IEnumerable<string?> GetFields()
    => Value?.GetFields() ?? base.GetFields();
}
