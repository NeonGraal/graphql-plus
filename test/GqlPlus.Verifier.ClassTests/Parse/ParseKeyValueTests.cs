namespace GqlPlus.Verifier.Parse;

public class ParseKeyValueTests
{
  [Theory, RepeatData(Repeats)]
  public void WithKeyValueValid_ReturnsCorrectAst(string key, string label)
    => _test.TrueExpected(
      key + ':' + label,
      new AstKeyValue<ConstantAst>(key.FieldKey(), label.FieldKey()));

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueKeyNoLabel_ReturnsFalse(string key, string label)
    => _test.False(
      key + ".:" + label);

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueValueNoLabel_ReturnsFalse(string key, string label)
    => _test.False(
      key + ":" + label + ".");

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueNoKey_ReturnsFalse(string label)
    => _test.False(':' + label, CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueNoColon_ReturnsFalse(string key, string label)
    => _test.False(key + ' ' + label, CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithKeyValueNoValue_ReturnsFalse(string key)
    => _test.False(key + ' ', CheckNull);

  private void CheckNull(AstKeyValue<ConstantAst> result)
    => result.Should().Be((AstKeyValue<ConstantAst>)default);

  private readonly OneChecksParser<AstKeyValue<ConstantAst>> _test;

  public ParseKeyValueTests(Parser<AstKeyValue<ConstantAst>>.D parser)
    => _test = new(parser);
}
