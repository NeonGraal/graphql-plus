using GqlPlus.Ast.Operation;

namespace GqlPlus.Parse.Operation;

public class ParseArgumentTests(Parser<IParserArgument, ArgumentAst>.D parser)
{
  [Theory, RepeatData(Repeats)]
  public void WithVariable_ReturnsCorrectAst(string variable)
    => _checks.TrueExpected(
      "($" + variable + ")",
      new ArgumentAst(AstNulls.At, variable));

  [Theory, RepeatData(Repeats)]
  public void WithConstant_ReturnsCorrectAst(string enumValue)
    => _checks.TrueExpected(
      "(" + enumValue + ")",
      new ArgumentAst(enumValue.FieldKey()));

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string enumValue)
    => _checks.TrueExpected(
      "($" + enumValue + ' ' + enumValue + ')',
      new ArgumentAst(AstNulls.At, enumValue.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void WithListComma_ReturnsCorrectAst(string enumValue)
    => _checks.TrueExpected(
      "($" + enumValue + ',' + enumValue + ')',
      new ArgumentAst(AstNulls.At, enumValue.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string enumValue)
    => _checks.False(
      "($" + enumValue + '|' + enumValue + ')',
      CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithField_ReturnsTrue(string enumValue)
    => _checks.TrueExpected(
      '(' + enumValue + ":$" + enumValue + ')',
      new ArgumentAst(AstNulls.At, enumValue.ArgumentObject(enumValue)));

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string enumValue)
    => _checks.TrueExpected(
      '(' + key + ":$" + enumValue + ' ' + enumValue + ':' + key + ')',
      new ArgumentAst(AstNulls.At, enumValue.ArgumentObject(key)),
      key == enumValue);

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObjectSemi_ReturnsCorrectAst(string key, string enumValue)
    => _checks.TrueExpected(
      '(' + key + ":$" + enumValue + ',' + enumValue + ':' + key + ')',
      new ArgumentAst(AstNulls.At, enumValue.ArgumentObject(key)),
      key == enumValue);

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObjectSemiEnumValue_ReturnsFalse(string key, string enumValue)
    => _checks.False(
      '(' + key + ":$" + enumValue + ',' + enumValue + ')',
      CheckNull,
      key == enumValue);

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObjectFieldBad_ReturnsFalse(string key, string enumValue)
    => _checks.False(
      '(' + key + ":)",
      CheckNull,
      key == enumValue);

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsFalse(string key, string enumValue)
    => _checks.False(
      '(' + key + ':' + enumValue + ';' + enumValue + ':' + key + ')',
      CheckNull,
      key == enumValue);

  private void CheckNull(ArgumentAst? result)
    => result.Should().BeNull();

  private readonly CheckOne<IParserArgument, ArgumentAst> _checks = new(parser);
}
