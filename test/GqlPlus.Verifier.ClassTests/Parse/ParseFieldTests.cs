namespace GqlPlus.Verifier.Parse;

public class ParseFieldTests
{
  [Theory, RepeatData(Repeats)]
  public void WithFieldValid_ReturnsCorrectAst(string key, string label)
    => _test.TrueExpected(
      key + ':' + label,
      new AstKeyValue<ConstantAst>(key.FieldKey(), label.FieldKey()));

  [Theory, RepeatData(Repeats)]
  public void WithFieldKeyNoLabel_ReturnsFalse(string key, string label)
    => _test.False(
      key + ".:" + label);

  [Theory, RepeatData(Repeats)]
  public void WithFieldValueNoLabel_ReturnsFalse(string key, string label)
    => _test.False(
      key + ":" + label + ".");

  [Theory, RepeatData(Repeats)]
  public void WithFieldNoKey_ReturnsFalse(string label)
    => _test.False(':' + label, CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithFieldNoColon_ReturnsFalse(string key, string label)
    => _test.False(key + ' ' + label, CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithFieldNoValue_ReturnsFalse(string key)
    => _test.False(key + ' ', CheckNull);

  private void CheckNull(AstKeyValue<ConstantAst> result)
    => result.Should().Be((AstKeyValue<ConstantAst>)default);

  private readonly OneChecks<AstKeyValue<ConstantAst>> _test;

  public ParseFieldTests(IParser<AstKeyValue<ConstantAst>> parser)
    => _test = new(parser);
}
