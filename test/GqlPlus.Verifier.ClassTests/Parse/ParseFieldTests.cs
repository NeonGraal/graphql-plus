namespace GqlPlus.Verifier.Parse;

public class ParseFieldTests
{
  [Theory, RepeatData(Repeats)]
  public void WithFieldValid_ReturnsCorrectAst(string key, string label)
    => Test.TrueExpected(
      key + ':' + label,
      new Field<ConstantAst>(key.FieldKey(), label.FieldKey()));

  [Theory, RepeatData(Repeats)]
  public void WithFieldKeyNoLabel_ReturnsFalse(string key, string label)
    => Test.False(
      key + ".:" + label);

  [Theory, RepeatData(Repeats)]
  public void WithFieldValueNoLabel_ReturnsFalse(string key, string label)
    => Test.False(
      key + ":" + label + ".");

  [Theory, RepeatData(Repeats)]
  public void WithFieldNoKey_ReturnsFalse(string label)
    => Test.False(':' + label, CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithFieldNoColon_ReturnsFalse(string key, string label)
    => Test.False(key + ' ' + label, CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithFieldNoValue_ReturnsFalse(string key)
    => Test.False(key + ' ', CheckNull);

  private void CheckNull(Field<ConstantAst> result)
    => result.Should().Be((Field<ConstantAst>)default);

  private static OneChecks<CommonParser, Field<ConstantAst>> Test => new(
    tokens => new CommonParser(tokens),
    parser => parser.ParseField("Constant", parser.ParseConstant));
}
