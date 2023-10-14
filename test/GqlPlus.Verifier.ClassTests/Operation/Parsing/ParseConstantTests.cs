using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation.Parsing;

public class ParseConstantTests
{
  [Theory, RepeatData(Repeats)]
  public void WithNumber_ReturnsCorrectAst(decimal number)
    => Test.TrueExpected(
      number.ToString(),
      new FieldKeyAst(AstNulls.At, number));

  [Theory, RepeatData(Repeats)]
  public void WithString_ReturnsCorrectAst(string contents)
    => Test.TrueExpected(
      contents.Quote(),
      new FieldKeyAst(AstNulls.At, contents));

  [Theory, RepeatData(Repeats)]
  public void WithLabel_ReturnsCorrectAst(string label)
    => Test.TrueExpected(
      label,
      new FieldKeyAst(AstNulls.At, "", label));

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabel_ReturnsCorrectAst(string enumType, string label)
    => Test.TrueExpected(
      enumType + "." + label,
      new FieldKeyAst(AstNulls.At, enumType, label));

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string label)
    => Test.TrueExpected(
      '[' + label + ' ' + label + ']',
      new ConstantAst(AstNulls.At, label.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void WithListComma_ReturnsCorrectAst(string label)
    => Test.TrueExpected(
      '[' + label + ',' + label + ']',
      new ConstantAst(AstNulls.At, label.ConstantList()));

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string label)
    => Test.False(
      '[' + label + ':' + label + ']',
      CheckDefault);

  [Theory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string label)
    => Test.TrueExpected(
      '{' + key + ':' + label + ' ' + label + ':' + key + '}',
      new ConstantAst(AstNulls.At, label.ConstantObject(key)),
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectSemi_ReturnsCorrectAst(string key, string label)
    => Test.TrueExpected(
      '{' + key + ':' + label + ';' + label + ':' + key + '}',
      new ConstantAst(AstNulls.At, label.ConstantObject(key)),
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsFalse(string key, string label)
    => Test.False(
      '{' + key + ':' + label + ',' + label + ':' + key + '}',
      CheckDefault,
      key == label);

  private void CheckDefault(ConstantAst result)
    => result.Should().Be(new ConstantAst(AstNulls.At));

  private static BaseOneChecks<ConstantAst> Test => new((ref OperationParser parser, out ConstantAst result)
    => parser.ParseConstant(out result));
}
