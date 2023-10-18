using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Common;

namespace GqlPlus.Verifier.Operation.Parsing;

public class ParseFieldTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string field)
    => Test.TrueExpected(
      field,
      new FieldAst(AstNulls.At, field));

  [Theory, RepeatData(Repeats)]
  public void WithAlias_ReturnsCorrectAst(string field, string alias)
    => Test.TrueExpected(
      alias + ":" + field,
      new FieldAst(AstNulls.At, field) { Alias = alias });

  [Theory, RepeatData(Repeats)]
  public void WithArgument_ReturnsCorrectAst(string field, string argument)
    => Test.TrueExpected(
      field + $"(${argument})",
      new FieldAst(AstNulls.At, field) { Argument = new(AstNulls.At, argument) });

  [Theory, RepeatData(Repeats)]
  public void WithModifiers_ReturnsCorrectAst(string field)
    => Test.TrueExpected(
      field + "[]?",
      new FieldAst(AstNulls.At, field) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void WithDirectives_ReturnsCorrectAst(string field, string directive)
    => Test.TrueExpected(
      field + "@" + directive,
      new FieldAst(AstNulls.At, field) { Directives = directive.Directives() });

  [Theory, RepeatData(Repeats)]
  public void WithSelection_ReturnsCorrectAst(string field, string selection)
    => Test.TrueExpected(
      field + "{" + selection + "}",
      new FieldAst(AstNulls.At, field) { Selections = selection.Fields() });

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string field, string alias, string argument, string directive, string selection)
    => Test.TrueExpected(
      alias + ":" + field + "($" + argument + ")[]?@" + directive + "{" + selection + "}",
      new FieldAst(AstNulls.At, field) {
        Alias = alias,
        Argument = new(AstNulls.At, argument),
        Modifiers = TestMods(),
        Directives = directive.Directives(),
        Selections = selection.Fields(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithJustAlias_ReturnsFalse(string alias)
    => Test.False(alias + ":", DefaultCheck);

  private void DefaultCheck(AstSelection result)
    => result.Should().BeOfType<AstNulls.NullSelectionAst>();

  private static BaseOneChecks<OperationParser, AstSelection> Test => new(
    tokens => new OperationParser(tokens),
    (OperationParser parser, out AstSelection result) => parser.ParseField(out result));
}
