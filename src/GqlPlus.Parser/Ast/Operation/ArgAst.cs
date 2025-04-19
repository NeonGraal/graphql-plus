﻿using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class ArgAst
  : AstValue<IGqlpArg>
  , IEquatable<ArgAst>
  , IGqlpArg
{
  public string? Variable { get; }
  public IGqlpConstant? Constant { get; }

  internal override string Abbr => "a";

  internal ArgAst(TokenAt at)
    : base(at) { }
  internal ArgAst(TokenAt at, string variable)
    : base(at) => Variable = variable;
  internal ArgAst(IGqlpFieldKey field)
    : base((TokenAt)field.At) => Constant = new ConstantAst(field);
  internal ArgAst(ConstantAst constant)
    : base(constant.At) => Constant = constant;
  internal ArgAst(TokenAt at, IEnumerable<IGqlpArg> values)
    : base(at, values) { }
  internal ArgAst(TokenAt at, IGqlpFields<IGqlpArg> fields)
    : base(at, fields) { }

  public bool Equals(ArgAst? other)
    => base.Equals(other)
    && Variable.NullEqual(other.Variable)
    && Constant.NullEqual(other.Constant);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Variable, Constant);

  internal override IEnumerable<string?> GetFields()
    => Constant?.GetFields() ?? base.GetFields().Append(Variable.Prefixed("$"));
}
