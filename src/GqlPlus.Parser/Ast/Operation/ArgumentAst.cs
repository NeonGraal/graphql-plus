using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

public sealed record class ArgumentAst
  : AstValue<ArgumentAst>
  , IEquatable<ArgumentAst>
  , IGqlpArgument
{
  public string? Variable { get; }
  public ConstantAst? Constant { get; }

  internal override string Abbr => "a";

  IGqlpConstant? IGqlpArgument.Constant => Constant;
  IEnumerable<IGqlpArgument> IGqlpValue<IGqlpArgument>.Values => Values;
  IGqlpFields<IGqlpArgument> IGqlpValue<IGqlpArgument>.Fields
    => Fields.ToFields(a => (IGqlpArgument)a);

  internal ArgumentAst(TokenAt at)
    : base(at) { }
  internal ArgumentAst(TokenAt at, string variable)
    : base(at) => Variable = variable;
  internal ArgumentAst(ConstantAst constant)
    : base(constant.At) => Constant = constant;
  internal ArgumentAst(TokenAt at, IEnumerable<ArgumentAst> values)
    : base(at, values) { }
  internal ArgumentAst(TokenAt at, AstFields<ArgumentAst> fields)
    : base(at, fields) { }

  public static implicit operator ArgumentAst(FieldKeyAst field)
    => new(field);
  public static implicit operator ArgumentAst(ConstantAst constant)
  {
    ArgumentNullException.ThrowIfNull(constant);
    return new(constant);
  }

  public bool Equals(ArgumentAst? other)
    => base.Equals(other)
    && Variable.NullEqual(other.Variable)
    && Constant.NullEqual(other.Constant);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Variable, Constant);

  internal override IEnumerable<string?> GetFields()
    => Constant?.GetFields() ?? base.GetFields().Append(Variable.Prefixed("$"));
}
