namespace GqlPlus.Parsing;

public class ParseKeyValueTests(
  Parser<KeyValue<IGqlpConstant>>.D parser
)
{
  [Theory, RepeatData(Repeats)]
  public void WithKeyValueValid_ReturnsCorrectAst(string key, string value)
    => _test.TrueExpected(
      key + ':' + value,
      new KeyValue<IGqlpConstant>(key.FieldKey(), new ConstantAst(value.FieldKey())));

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueKeyNoEnumValue_ReturnsFalse(string key, string value)
    => _test.FalseExpected(
      key + ".:" + value);

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueValueNoEnumValue_ReturnsFalse(string key, string value)
    => _test.FalseExpected(
      key + ":" + value + ".");

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueNoKey_ReturnsFalse(string value)
    => _test.FalseExpected(':' + value, CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueNoColon_ReturnsFalse(string key, string value)
    => _test.FalseExpected(key + ' ' + value, CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueNoValue_ReturnsFalse(string key)
    => _test.FalseExpected(key + ' ', CheckNull);

  private void CheckNull(KeyValue<IGqlpConstant> result)
    => result.Should().Be((KeyValue<IGqlpConstant>)default);

  private readonly OneChecksParser<KeyValue<IGqlpConstant>> _test = new(parser);
}
