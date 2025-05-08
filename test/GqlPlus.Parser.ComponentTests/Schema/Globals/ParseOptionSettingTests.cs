using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Schema.Globals;

public class ParseOptionSettingTests(
  IOneChecksParser<IGqlpSchemaSetting> checks
)
{
  [Theory, RepeatData]
  public void WithValid_ReturnsCorrectAst(string name, string value)
    => checks.TrueExpected(
      name + "='" + value + "'",
      Setting(name, value));

  [Theory, RepeatData]
  public void WithNoName_ReturnsEmpty(string value)
    => checks.EmptyResult("='" + value + "'");

  [Theory, RepeatData]
  public void WithNoEquals_ReturnsFalse(string name, string value)
    => checks.FalseExpected(name + " '" + value + "'", CheckNull);

  [Theory, RepeatData]
  public void WithNoValue_ReturnsFalse(string name)
    => checks.FalseExpected(name + '=', CheckNull);

  private void CheckNull(IGqlpSchemaSetting? ast)
    => ast.ShouldBeNull();

  private static OptionSettingAst Setting(string name, string value)
    => new(AstNulls.At, name, new ConstantAst(new FieldKeyAst(AstNulls.At, value)));
}
