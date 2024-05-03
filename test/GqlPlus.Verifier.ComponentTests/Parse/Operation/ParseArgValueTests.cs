using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class ParseArgValueTests(Parser<ArgumentAst>.D parser)
{
  [Theory, RepeatData(Repeats)]
  public void WithVariable_ReturnsCorrectAst(string variable)
    => _checks.TrueExpected(
      "$" + variable,
      new ArgumentAst(AstNulls.At, variable));

  [Theory, RepeatData(Repeats)]
  public void WithVariableBad_ReturnsFalse(string variable)
    => _checks.False("$ " + variable);

  [Theory, RepeatData(Repeats)]
  public void WithConstant_ReturnsCorrectAst(string enumValue)
    => _checks.TrueExpected(
      enumValue,
      new ArgumentAst(enumValue.FieldKey()));

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string enumValue)
    => _checks.TrueExpected(
      "[$" + enumValue + ' ' + enumValue + ']',
      new ArgumentAst(AstNulls.At, enumValue.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void WithListComma_ReturnsCorrectAst(string enumValue)
    => _checks.TrueExpected(
      "[$" + enumValue + ',' + enumValue + ']',
      new ArgumentAst(AstNulls.At, enumValue.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string enumValue)
    => _checks.False(
      '[' + enumValue + ':' + enumValue + ']',
      CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithListDoubleComma_ReturnsFalse(string enumValue)
    => _checks.False(
      '[' + enumValue + ",," + enumValue + ']',
      CheckNull);

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string enumValue)
    => _checks.TrueExpected(
      '{' + key + ":$" + enumValue + ' ' + enumValue + ':' + key + '}',
      new ArgumentAst(AstNulls.At, enumValue.ArgumentObject(key)),
      key == enumValue);

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObjectSemi_ReturnsCorrectAst(string key, string enumValue)
    => _checks.TrueExpected(
      '{' + key + ":$" + enumValue + ',' + enumValue + ':' + key + '}',
      new ArgumentAst(AstNulls.At, enumValue.ArgumentObject(key)),
      key == enumValue);

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsFalse(string key, string enumValue)
    => _checks.False(
      '{' + key + ':' + enumValue + ':' + enumValue + ':' + key + '}',
      CheckNull,
      key == enumValue);

  private void CheckNull(ArgumentAst? result)
    => result.Should().BeNull();

  private readonly CheckOne<ArgumentAst> _checks = new(parser);
}
