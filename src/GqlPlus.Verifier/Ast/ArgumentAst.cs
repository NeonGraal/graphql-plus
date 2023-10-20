namespace GqlPlus.Verifier.Ast;

internal sealed record class ArgumentAst
  : AstValues<ArgumentAst>, IEquatable<ArgumentAst>
{
  public string? Variable { get; }
  public ConstantAst? Constant { get; }

  internal override string Abbr => "A";

  internal ArgumentAst(ParseAt at)
    : base(at) { }
  internal ArgumentAst(ParseAt at, string variable)
    : base(at) => Variable = variable;
  internal ArgumentAst(ConstantAst constant)
    : base(constant.At) => Constant = constant;
  internal ArgumentAst(ParseAt at, ArgumentAst[] values)
    : base(at, values) { }
  internal ArgumentAst(ParseAt at, ObjectAst fields)
    : base(at, fields) { }

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
