using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Parse.Schema.Globals;

public class ParseOptionSettingTests(
  Parser<OptionSettingAst>.D parser
)
{
  [Theory, RepeatData(Repeats)]
  public void WithValid_ReturnsCorrectAst(string name, string value)
    => _test.TrueExpected(
      name + "='" + value + "'",
      Setting(name, value));

  [Theory, RepeatData(Repeats)]
  public void WithNoName_ReturnsEmpty(string value)
    => _test.Empty("='" + value + "'");

  [Theory, RepeatData(Repeats)]
  public void WithNoEquals_ReturnsFalse(string name, string value)
    => _test.False(name + " '" + value + "'", CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithNoValue_ReturnsFalse(string name)
    => _test.False(name + '=', CheckNull);

  private void CheckNull(OptionSettingAst? ast)
    => ast.Should().BeNull();

  private readonly CheckOne<OptionSettingAst> _test = new(parser);

  private static OptionSettingAst Setting(string name, string value)
    => new(AstNulls.At, name, new FieldKeyAst(AstNulls.At, value));
}
