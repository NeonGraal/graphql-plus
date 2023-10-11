﻿using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseFieldTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string field)
    => Test.TrueExpected(
      field,
      new FieldAst(field));

  [Theory, RepeatData(Repeats)]
  public void WithAlias_ReturnsCorrectAst(string field, string alias)
    => Test.TrueExpected(
      alias + ":" + field,
      new FieldAst(field) { Alias = alias });

  [Theory, RepeatData(Repeats)]
  public void WithArgument_ReturnsCorrectAst(string field, string argument)
    => Test.TrueExpected(
      field + $"(${argument})",
      new FieldAst(field) { Argument = new(argument) });

  [Theory, RepeatData(Repeats)]
  public void WithModifiers_ReturnsCorrectAst(string field)
    => Test.TrueExpected(
      field + "[]?",
      new FieldAst(field) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void WithDirectives_ReturnsCorrectAst(string field, string directive)
    => Test.TrueExpected(
      field + "@" + directive,
      new FieldAst(field) { Directives = directive.Directives() });

  [Theory, RepeatData(Repeats)]
  public void WithSelection_ReturnsCorrectAst(string field, string selection)
    => Test.TrueExpected(
      field + "{" + selection + "}",
      new FieldAst(field) { Selections = selection.Fields() });

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string field, string alias, string argument, string directive, string selection)
    => Test.TrueExpected(
      alias + ":" + field + "($" + argument + ")[]?@" + directive + "{" + selection + "}",
      new FieldAst(field) {
        Alias = alias,
        Argument = new(argument),
        Modifiers = TestMods(),
        Directives = directive.Directives(),
        Selections = selection.Fields(),
      });

  private static BaseOneChecks<AstSelection> Test => new((ref OperationParser parser, out AstSelection result)
    => parser.ParseField(out result));
}
