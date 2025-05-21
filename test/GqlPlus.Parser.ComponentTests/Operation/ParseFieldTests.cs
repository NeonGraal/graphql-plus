using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Operation;

public class ParseFieldTests(
  IOneChecksParser<IGqlpField> checks
)
{
  [Theory, RepeatData]
  public void WithMinimum_ReturnsCorrectAst(string field)
    => checks.TrueExpected(
      field,
      new FieldAst(AstNulls.At, field));

  [Theory, RepeatData]
  public void WithAlias_ReturnsCorrectAst(string field, string alias)
    => checks.TrueExpected(
      alias + ":" + field,
      new FieldAst(AstNulls.At, field) { FieldAlias = alias });

  [Theory, RepeatData]
  public void WithArg_ReturnsCorrectAst(string field, string argument)
    => checks.TrueExpected(
      field + $"(${argument})",
      new FieldAst(AstNulls.At, field) { Arg = new ArgAst(AstNulls.At, argument) });

  [Theory, RepeatData]
  public void WithModifiers_ReturnsCorrectAst(string field)
    => checks.TrueExpected(
      field + "[]?",
      new FieldAst(AstNulls.At, field) { Modifiers = TestMods() });

  [Theory, RepeatData]
  public void WithModifiersBad_ReturnsFalse(string field)
    => checks.FalseExpected(field + "[?]");

  [Theory, RepeatData]
  public void WithDirectives_ReturnsCorrectAst(string field, string[] directives)
    => checks.TrueExpected(
      field + directives.Joined(s => "@" + s),
      new FieldAst(AstNulls.At, field) { Directives = directives.Directives() });

  [Theory, RepeatData]
  public void WithSelection_ReturnsCorrectAst(string field, string[] selections)
    => checks.TrueExpected(
      field + selections.Bracket("{", "}").Joined(),
      new FieldAst(AstNulls.At, field) { Selections = selections.Fields() });

  [Theory, RepeatData]
  public void WithSelectionBad_ReturnsFalse(string field)
    => checks.FalseExpected(field + "{}");

  [Theory, RepeatData]
  public void WithAll_ReturnsCorrectAst(string field, string alias, string argument, string[] directives, string[] selections)
    => checks.TrueExpected(
      alias + ":" + field + "($" + argument + ")[]?" + directives.Joined(s => "@" + s) + selections.Bracket("{", "}").Joined(),
      new FieldAst(AstNulls.At, field) {
        FieldAlias = alias,
        Arg = new ArgAst(AstNulls.At, argument),
        Modifiers = TestMods(),
        Directives = directives.Directives(),
        Selections = selections.Fields(),
      });

  [Theory, RepeatData]
  public void WithJustAlias_ReturnsFalse(string alias)
    => checks.FalseExpected(alias + ":", DefaultNull);

  private void DefaultNull(IGqlpSelection? result)
    => result.ShouldBeNull();
}
