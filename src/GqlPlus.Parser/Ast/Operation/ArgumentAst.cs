using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class ArgumentAst
  : AstValue<IGqlpArgument>
  , IEquatable<ArgumentAst>
  , IGqlpArgument
{
  public string? Variable { get; }
  public IGqlpConstant? Constant { get; }

  internal override string Abbr => "a";

  internal ArgumentAst(TokenAt at)
    : base(at) { }
  internal ArgumentAst(TokenAt at, string variable)
    : base(at) => Variable = variable;
  internal ArgumentAst(IGqlpFieldKey field)
    : base((TokenAt)field.At) => Constant = new ConstantAst(field);
  internal ArgumentAst(ConstantAst constant)
    : base(constant.At) => Constant = constant;
  internal ArgumentAst(TokenAt at, IEnumerable<IGqlpArgument> values)
    : base(at, values) { }
  internal ArgumentAst(TokenAt at, IGqlpFields<IGqlpArgument> fields)
    : base(at, fields) { }

  public bool Equals(ArgumentAst? other)
    => base.Equals(other)
    && Variable.NullEqual(other.Variable)
    && Constant.NullEqual(other.Constant);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Variable, Constant);

  internal override IEnumerable<string?> GetFields()
    => Constant?.GetFields() ?? base.GetFields().Append(Variable.Prefixed("$"));
}
