namespace GqlPlus.Parsing;

public class ParseKeyValueTests(
  IOneChecksParser<KeyValue<IGqlpConstant>> checks
)
{
  [Theory, RepeatData(Repeats)]
  public void WithKeyValueValid_ReturnsCorrectAst(string key, string value)
    => checks.TrueExpected(
      key + ':' + value,
      new KeyValue<IGqlpConstant>(key.FieldKey(), new ConstantAst(value.FieldKey())));

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueKeyNoEnumValue_ReturnsFalse(string key, string value)
    => checks.FalseExpected(
      key + ".:" + value);

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueValueNoEnumValue_ReturnsFalse(string key, string value)
    => checks.FalseExpected(
      key + ":" + value + ".");

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueNoKey_ReturnsFalse(string value)
    => checks.FalseExpected(':' + value, CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueNoColon_ReturnsFalse(string key, string value)
    => checks.FalseExpected(key + ' ' + value, CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueNoValue_ReturnsFalse(string key)
    => checks.FalseExpected(key + ' ', CheckNull);

  private void CheckNull(KeyValue<IGqlpConstant> result)
    => result.Should().Be((KeyValue<IGqlpConstant>)default);
}
