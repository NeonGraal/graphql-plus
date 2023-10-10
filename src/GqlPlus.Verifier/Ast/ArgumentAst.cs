namespace GqlPlus.Verifier.Ast;

internal sealed record class ArgumentAst : AstValues<ArgumentAst>, IEquatable<ArgumentAst>
{
  public string? Variable { get; }
  public ConstantAst? Constant { get; }

  protected override string Abbr => "A";

  internal ArgumentAst() : base() { }
  internal ArgumentAst(string variable)
   : base() => Variable = variable;
  internal ArgumentAst(ConstantAst constant)
   : base() => Constant = constant;
  internal ArgumentAst(ArgumentAst[] values)
    : base(values) { }
  internal ArgumentAst(ObjectAst fields)
    : base(fields) { }

  public static implicit operator ArgumentAst(FieldKeyAst field)
    => new(field);
  public static implicit operator ArgumentAst(ConstantAst constant)
    => new(constant);

  public bool Equals(ArgumentAst? other)
    => base.Equals(other)
    && Variable.NullEqual(other.Variable)
    && Constant.NullEqual(other.Constant);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Variable, Constant);

  internal override IEnumerable<string?> GetFields()
    => Constant?.GetFields() ?? base.GetFields().Append(Variable.Prefixed("$"));
}
