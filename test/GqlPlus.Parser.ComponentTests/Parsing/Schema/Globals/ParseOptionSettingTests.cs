using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseOptionSettingTests(
  IOneChecksParser<IGqlpSchemaSetting> checks
)
{
  [Theory, RepeatData(Repeats)]
  public void WithValid_ReturnsCorrectAst(string name, string value)
    => checks.TrueExpected(
      name + "='" + value + "'",
      Setting(name, value));

  [Theory, RepeatData(Repeats)]
  public void WithNoName_ReturnsEmpty(string value)
    => checks.EmptyResult("='" + value + "'");

  [Theory, RepeatData(Repeats)]
  public void WithNoEquals_ReturnsFalse(string name, string value)
    => checks.FalseExpected(name + " '" + value + "'", CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithNoValue_ReturnsFalse(string name)
    => checks.FalseExpected(name + '=', CheckNull);

  private void CheckNull(IGqlpSchemaSetting? ast)
    => ast.Should().BeNull();

  private static OptionSettingAst Setting(string name, string value)
    => new(AstNulls.At, name, new(new FieldKeyAst(AstNulls.At, value)));
}
