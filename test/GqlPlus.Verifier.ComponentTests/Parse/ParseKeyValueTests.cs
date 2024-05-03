namespace GqlPlus.Verifier.Parse;

public class ParseKeyValueTests(
  Parser<KeyValue<ConstantAst>>.D parser
)
{
  [Theory, RepeatData(Repeats)]
  public void WithKeyValueValid_ReturnsCorrectAst(string key, string value)
    => _test.TrueExpected(
      key + ':' + value,
      new KeyValue<ConstantAst>(key.FieldKey(), value.FieldKey()));

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

  private void CheckNull(KeyValue<ConstantAst> result)
    => result.Should().Be((KeyValue<ConstantAst>)default);

  private readonly CheckOne<KeyValue<ConstantAst>> _test = new(parser);
}
