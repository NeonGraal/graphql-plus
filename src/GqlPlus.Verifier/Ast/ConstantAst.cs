namespace GqlPlus.Verifier.Ast;

internal sealed record class ConstantAst : AstValues<ConstantAst>, IEquatable<ConstantAst>
{
  public FieldKeyAst? Value { get; set; }

  protected override string Abbr => "C";

  internal ConstantAst()
    : base() { }

  internal ConstantAst(FieldKeyAst value)
    : base() => Value = value;

  internal ConstantAst(ConstantAst[] values)
    : base(values) { }

  internal ConstantAst(ObjectAst fields)
    : base(fields) { }

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
