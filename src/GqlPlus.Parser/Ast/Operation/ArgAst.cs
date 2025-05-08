using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class ArgAst
  : AstValue<IGqlpArg>
  , IGqlpArg
{
  public string? Variable { get; }
  public IGqlpConstant? Constant { get; }

  internal override string Abbr => "a";

  internal ArgAst(ITokenAt at)
    : base(at) { }
  internal ArgAst(ITokenAt at, string variable)
    : base(at) => Variable = variable;
  internal ArgAst(IGqlpFieldKey field)
    : base((TokenAt)field.At) => Constant = new ConstantAst(field);
  internal ArgAst(IGqlpConstant constant)
    : base(constant.At) => Constant = constant;
  internal ArgAst(ITokenAt at, IEnumerable<IGqlpArg> values)
    : base(at, values) { }
  internal ArgAst(ITokenAt at, IGqlpFields<IGqlpArg> fields)
    : base(at, fields) { }

  public bool Equals(IGqlpArg? other)
    => base.Equals(other)
    && Variable.NullEqual(other.Variable)
    && Constant.NullEqual(other.Constant);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Variable, Constant);
  public bool Equals(ArgAst? other)
    => Equals(other as IGqlpArg);
  internal override IEnumerable<string?> GetFields()
    => Constant?.GetFields() ?? base.GetFields().Append(Variable.Prefixed("$"));
}
