namespace GqlPlus.Verifier.Parse;

public class ParseKeyValueTests(
  Parser<AstKeyValue<ConstantAst>>.D parser
)
{
  [Theory, RepeatData(Repeats)]
  public void WithKeyValueValid_ReturnsCorrectAst(string key, string value)
    => _test.TrueExpected(
      key + ':' + value,
      new AstKeyValue<ConstantAst>(key.FieldKey(), value.FieldKey()));

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueKeyNoEnumValue_ReturnsFalse(string key, string value)
    => _test.False(
      key + ".:" + value);

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueValueNoEnumValue_ReturnsFalse(string key, string value)
    => _test.False(
      key + ":" + value + ".");

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueNoKey_ReturnsFalse(string value)
    => _test.False(':' + value, CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueNoColon_ReturnsFalse(string key, string value)
    => _test.False(key + ' ' + value, CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueNoValue_ReturnsFalse(string key)
    => _test.False(key + ' ', CheckNull);

  private void CheckNull(AstKeyValue<ConstantAst> result)
    => result.Should().Be((AstKeyValue<ConstantAst>)default);

  private readonly OneChecksParser<AstKeyValue<ConstantAst>> _test = new(parser);
}
