﻿using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseDirectivesTests(
  IManyChecksParser<IGqlpDirective> checks
)
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string directives)
    => checks.TrueExpected(
      "@" + directives,
      new DirectiveAst(AstNulls.At, directives));

  [Theory, RepeatData(Repeats)]
  public void WithArgument_ReturnsCorrectAst(string directives, string variable)
    => checks.TrueExpected(
      "@" + directives + "($" + variable + ")",
      new DirectiveAst(AstNulls.At, directives) { Argument = new ArgumentAst(AstNulls.At, variable) });

  [Theory, RepeatData(Repeats)]
  public void WithArgumentBad_ReturnsFalse(string directives)
    => checks.FalseExpected("@" + directives + "($)");

  [Theory, RepeatData(Repeats)]
  public void WithSecondBad_ReturnsFalse(string directives)
    => checks.FalseExpected("@" + directives + "@");
}
