namespace GqlPlus.Verifier.Ast;

internal sealed record class ConstantAst : AstValues<ConstantAst>, IEquatable<ConstantAst>
{
  internal FieldKeyAst? Value { get; set; }

  internal ConstantAst() : base() { }

  internal ConstantAst(string content)
    : base() => Value = new FieldKeyAst(content);
  internal ConstantAst(decimal number)
    : base() => Value = new FieldKeyAst(number);
  internal ConstantAst(string theType, string label)
    : base() => Value = new FieldKeyAst(theType, label);

  internal ConstantAst(ConstantAst[] values)
    : base(values) { }
  internal ConstantAst(ObjectAst fields)
    : base(fields) { }

  public static implicit operator ConstantAst(FieldKeyAst field)
    => new() { Value = field };

  public bool Equals(ConstantAst? other)
    => base.Equals(other)
    && Value.NullEqual(other.Value);
  public override int GetHashCode()
    => HashCode.Combine((AstValues<ConstantAst>)this, Value);

  internal override IEnumerable<string?> GetFields()
    => Value is not null ? Value.GetFields()
      : base.GetFields();
}
