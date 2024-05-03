using GqlPlus.Ast.Operation;

namespace GqlPlus.Parse.Operation;

public class ParseFieldTests(Parser<FieldAst>.D parser)
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string field)
    => _checks.TrueExpected(
      field,
      new FieldAst(AstNulls.At, field));

  [Theory, RepeatData(Repeats)]
  public void WithAlias_ReturnsCorrectAst(string field, string alias)
    => _checks.TrueExpected(
      alias + ":" + field,
      new FieldAst(AstNulls.At, field) { Alias = alias });

  [Theory, RepeatData(Repeats)]
  public void WithArgument_ReturnsCorrectAst(string field, string argument)
    => _checks.TrueExpected(
      field + $"(${argument})",
      new FieldAst(AstNulls.At, field) { Argument = new(AstNulls.At, argument) });

  [Theory, RepeatData(Repeats)]
  public void WithModifiers_ReturnsCorrectAst(string field)
    => _checks.TrueExpected(
      field + "[]?",
      new FieldAst(AstNulls.At, field) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void WithModifiersBad_ReturnsFalse(string field)
    => _checks.False(field + "[?]");

  [Theory, RepeatData(Repeats)]
  public void WithDirectives_ReturnsCorrectAst(string field, string[] directives)
    => _checks.TrueExpected(
      field + directives.Joined(s => "@" + s),
      new FieldAst(AstNulls.At, field) { Directives = directives.Directives() });

  [Theory, RepeatData(Repeats)]
  public void WithSelection_ReturnsCorrectAst(string field, string[] selections)
    => _checks.TrueExpected(
      field + selections.Bracket("{", "}").Joined(),
      new FieldAst(AstNulls.At, field) { Selections = selections.Fields() });

  [Theory, RepeatData(Repeats)]
  public void WithSelectionBad_ReturnsFalse(string field)
    => _checks.False(field + "{}");

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string field, string alias, string argument, string[] directives, string[] selections)
    => _checks.TrueExpected(
      alias + ":" + field + "($" + argument + ")[]?" + directives.Joined(s => "@" + s) + selections.Bracket("{", "}").Joined(),
      new FieldAst(AstNulls.At, field) {
        Alias = alias,
        Argument = new(AstNulls.At, argument),
        Modifiers = TestMods(),
        Directives = directives.Directives(),
        Selections = selections.Fields(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithJustAlias_ReturnsFalse(string alias)
    => _checks.False(alias + ":", DefaultNull);

  private void DefaultNull(IAstSelection? result)
    => result.Should().BeNull();

  private readonly CheckOne<FieldAst> _checks = new(parser);
}
