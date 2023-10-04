namespace GqlPlus.Verifier.Ast;

internal sealed record class ConstantAst : AstValues<ConstantAst>, IEquatable<ConstantAst>
{
  internal FieldKeyAst? Value { get; set; }

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
    => HashCode.Combine((AstValues<ConstantAst>)this, Value);

  internal override IEnumerable<string?> GetFields()
    => Value is not null ? Value.GetFields()
      : base.GetFields();
}
