﻿using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class ParseFragmentsTests
{
  [Theory, RepeatData(Repeats)]
  public void Start_WithMinimum_ReturnsCorrectAst(string fragment, string onType, string[] fields)
    => TestStart.TrueExpected(
      '&' + fragment + ':' + onType + "{" + fields.Joined() + "}",
      new FragmentAst(AstNulls.At, fragment, onType, fields.Fields()));

  [Theory]
  [RepeatInlineData(Repeats, "fragment ", " on ")]
  [RepeatInlineData(Repeats, "&", " on ")]
  [RepeatInlineData(Repeats, "fragment ", ":")]
  [RepeatInlineData(Repeats, "&", ":")]
  public void End_WithMinimum_ReturnsCorrectAst(string fragmentPrefix, string typePrefix, string fragment, string onType, string[] fields)
    => TestEnd.TrueExpected(
      fragmentPrefix + fragment + typePrefix + onType + "{" + fields.Joined() + "}",
      new FragmentAst(AstNulls.At, fragment, onType, fields.Fields()));

  [Theory, RepeatData(Repeats)]
  public void Start_WithDirective_ReturnsCorrectAst(string fragment, string onType, string[] fields, string[] directives)
    => TestStart.TrueExpected(
      "&" + fragment + ":" + onType + directives.Joined("@") + "{" + fields.Joined() + "}",
      new FragmentAst(AstNulls.At, fragment, onType, fields.Fields()) { Directives = directives.Directives() });

  [Theory]
  [RepeatInlineData(Repeats, "fragment ", " on ")]
  [RepeatInlineData(Repeats, "&", " on ")]
  [RepeatInlineData(Repeats, "fragment ", ":")]
  [RepeatInlineData(Repeats, "&", ":")]
  public void End_WithDirective_ReturnsCorrectAst(string fragmentPrefix, string typePrefix, string fragment, string onType, string[] fields, string[] directives)
    => TestEnd.TrueExpected(
      fragmentPrefix + fragment + typePrefix + onType + directives.Joined("@") + "{" + fields.Joined() + "}",
      new FragmentAst(AstNulls.At, fragment, onType, fields.Fields()) { Directives = directives.Directives() });

  private static ManyChecks<OperationParser, FragmentAst> TestStart => new(
    tokens => new OperationParser(tokens),
    parser => parser.ParseFragStart());

  private static ManyChecks<OperationParser, FragmentAst> TestEnd => new(
    tokens => new OperationParser(tokens),
    parser => parser.ParseFragEnd(Array.Empty<FragmentAst>()));
}
