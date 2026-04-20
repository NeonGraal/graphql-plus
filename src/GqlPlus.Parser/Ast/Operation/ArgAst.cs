using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class ArgAst
  : AstValue<IAstArg>
  , IAstArg
{
  public string? Variable { get; internal init; }
  public IAstConstant? Constant { get; }

  internal override string Abbr => "a";

  internal ArgAst(ITokenAt at)
    : base(at) { }
  internal ArgAst(ITokenAt at, string variable)
    : base(at) => Variable = variable;
  internal ArgAst(IAstFieldKey field)
    : base((TokenAt)field.At) => Constant = new ConstantAst(field);
  internal ArgAst(IAstConstant constant)
    : base(constant.At) => Constant = constant;
  internal ArgAst(ITokenAt at, IEnumerable<IAstArg> values)
    : base(at, values) { }
  internal ArgAst(ITokenAt at, IAstFields<IAstArg> fields)
    : base(at, fields) { }

  public bool Equals(ArgAst? other)
    => other is IAstArg arg && Equals(arg);
  public bool Equals(IAstArg? other)
    => base.Equals(other)
    && Variable.NullEqual(other.Variable)
    && Constant.NullEqual(other.Constant);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Variable, Constant.NullHashCode());
  internal override IEnumerable<string?> GetFields()
    => Constant?.GetFields() ?? base.GetFields().Append(Variable.Prefixed("$"));
}
