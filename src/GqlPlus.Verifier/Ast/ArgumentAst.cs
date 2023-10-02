namespace GqlPlus.Verifier.Ast;

internal sealed record class ArgumentAst : ValuesAst<ArgumentAst>, IEquatable<ArgumentAst>
{
  internal string? Variable { get; }
  internal ConstantAst? Constant { get; }

  internal ArgumentAst() : base() { }
  internal ArgumentAst(string variable)
   : base() => Variable = variable;
  internal ArgumentAst(ConstantAst constant)
   : base() => Constant = constant;
  internal ArgumentAst(ArgumentAst[] values)
    : base(values) { }
  internal ArgumentAst(ObjectAst fields)
    : base(fields) { }

  public bool Equals(ArgumentAst? other)
    => base.Equals(other)
    && Variable.NullEqual(other.Variable)
    && Constant.NullEqual(other.Constant);
  public override int GetHashCode()
    => HashCode.Combine((ValuesAst<ArgumentAst>)this, Variable, Constant);

  internal override IEnumerable<string?> GetFields()
    => Constant is not null ? Constant.GetFields()
      : base.GetFields().Append("$" + Variable);
}
