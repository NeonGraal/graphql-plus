﻿using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class ParseFieldTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string field)
    => _test.TrueExpected(
      field,
      new FieldAst(AstNulls.At, field));

  [Theory, RepeatData(Repeats)]
  public void WithAlias_ReturnsCorrectAst(string field, string alias)
    => _test.TrueExpected(
      alias + ":" + field,
      new FieldAst(AstNulls.At, field) { Alias = alias });

  [Theory, RepeatData(Repeats)]
  public void WithArgument_ReturnsCorrectAst(string field, string argument)
    => _test.TrueExpected(
      field + $"(${argument})",
      new FieldAst(AstNulls.At, field) { Argument = new(AstNulls.At, argument) });

  [Theory, RepeatData(Repeats)]
  public void WithModifiers_ReturnsCorrectAst(string field)
    => _test.TrueExpected(
      field + "[]?",
      new FieldAst(AstNulls.At, field) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void WithModifiersBad_ReturnsFalse(string field)
    => _test.False(field + "[?]");

  [Theory, RepeatData(Repeats)]
  public void WithDirectives_ReturnsCorrectAst(string field, string[] directives)
    => _test.TrueExpected(
      field + directives.Joined("@"),
      new FieldAst(AstNulls.At, field) { Directives = directives.Directives() });

  [Theory, RepeatData(Repeats)]
  public void WithSelection_ReturnsCorrectAst(string field, string[] selections)
    => _test.TrueExpected(
      field + selections.Bracket("{", "}").Joined(),
      new FieldAst(AstNulls.At, field) { Selections = selections.Fields() });

  [Theory, RepeatData(Repeats)]
  public void WithSelectionBad_ReturnsFalse(string field)
    => _test.False(field + "{}");

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string field, string alias, string argument, string[] directives, string[] selections)
    => _test.TrueExpected(
      alias + ":" + field + "($" + argument + ")[]?" + directives.Joined("@") + selections.Bracket("{", "}").Joined(),
      new FieldAst(AstNulls.At, field) {
        Alias = alias,
        Argument = new(AstNulls.At, argument),
        Modifiers = TestMods(),
        Directives = directives.Directives(),
        Selections = selections.Fields(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithJustAlias_ReturnsFalse(string alias)
    => _test.False(alias + ":", DefaultNull);

  private void DefaultNull(IAstSelection? result)
    => result.Should().BeNull();

  private readonly OneChecksParser<FieldAst> _test;

  public ParseFieldTests(Parser<FieldAst>.D parser)
    => _test = new(parser);
}
