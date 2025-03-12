﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class OutputArgAstTests
  : AstObjectArgTests<IGqlpOutputArg>
{
  [Theory, RepeatData]
  public void HashCode_WithEnumValue(string name, string enumMember)
      => _checks.HashCode(
        () => new OutputArgAst(AstNulls.At, name) { EnumMember = enumMember });

  [Theory, RepeatData]
  public void String_WithEnumValue(string name, string enumMember)
    => _checks.Text(
      () => new OutputArgAst(AstNulls.At, name) { EnumMember = enumMember },
      $"( {name}.{enumMember} )");

  [Theory, RepeatData]
  public void Equality_WithEnumValue(string name, string enumMember)
    => _checks.Equality(
      () => new OutputArgAst(AstNulls.At, name) { EnumMember = enumMember });

  [Theory, RepeatData]
  public void Inequality_BetweenEnumValues(string name, string enumValue1, string enumValue2)
    => _checks.InequalityBetween(enumValue1, enumValue2,
      enumMember => new OutputArgAst(AstNulls.At, name) { EnumMember = enumMember },
      enumValue1 == enumValue2);

  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjArgChecks<IGqlpOutputArg, OutputArgAst> _checks
    = new(name => new OutputArgAst(AstNulls.At, name));

  internal override IAstObjArgChecks<IGqlpOutputArg> ObjArgChecks => _checks;
}
