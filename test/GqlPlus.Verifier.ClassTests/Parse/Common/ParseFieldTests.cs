namespace GqlPlus.Verifier.Parse.Common;

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

  private readonly OneChecks<Field<ConstantAst>> Test;

  public ParseFieldTests(IParser<Field<ConstantAst>> parser)
    => Test = new(tokens => parser.Parse(tokens, "test"));
}
