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

  private void CheckNull(KeyValue<IGqlpConstant> result)
    => result.Should().Be((KeyValue<IGqlpConstant>)default);

  private readonly OneChecksParser<KeyValue<IGqlpConstant>> _test = new(parser);
}
