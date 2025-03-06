using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;
using GqlPlus.Parsing.Operation;

namespace GqlPlus.Operation;

public class ParseArgTests(
  IOneChecksParser<IParserArg, IGqlpArg> checks
)
{
  [Theory, RepeatData(Repeats)]
  public void WithVariable_ReturnsCorrectAst(string variable)
    => checks
      .TrueExpected(
        "($" + variable + ")",
        new ArgAst(AstNulls.At, variable));

  [Theory, RepeatData(Repeats)]
  public void WithConstant_ReturnsCorrectAst(string enumValue)
    => checks
      .TrueExpected(
        "(" + enumValue + ")",
        new ArgAst(enumValue.FieldKey()));

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string enumValue)
    => checks
      .TrueExpected(
        "($" + enumValue + ' ' + enumValue + ')',
        new ArgAst(AstNulls.At, enumValue.ArgList()));

  [Theory, RepeatData(Repeats)]
  public void WithListComma_ReturnsCorrectAst(string enumValue)
    => checks
      .TrueExpected(
        "($" + enumValue + ',' + enumValue + ')',
        new ArgAst(AstNulls.At, enumValue.ArgList()));

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string enumValue)
    => checks
      .FalseExpected(
        "($" + enumValue + '|' + enumValue + ')',
        CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithField_ReturnsTrue(string enumValue)
    => checks
      .TrueExpected(
        '(' + enumValue + ":$" + enumValue + ')',
        new ArgAst(AstNulls.At, enumValue.ArgObject(enumValue)));

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string enumValue)
    => checks
      .SkipIf(key == enumValue)
      .TrueExpected(
        '(' + key + ":$" + enumValue + ' ' + enumValue + ':' + key + ')',
        new ArgAst(AstNulls.At, enumValue.ArgObject(key)));

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObjectSemi_ReturnsCorrectAst(string key, string enumValue)
    => checks
      .SkipIf(key == enumValue)
      .TrueExpected(
        '(' + key + ":$" + enumValue + ',' + enumValue + ':' + key + ')',
        new ArgAst(AstNulls.At, enumValue.ArgObject(key)));

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObjectSemiEnumValue_ReturnsFalse(string key, string enumValue)
    => checks
      .SkipIf(key == enumValue)
      .FalseExpected(
        '(' + key + ":$" + enumValue + ',' + enumValue + ')',
        CheckNull);

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObjectFieldBad_ReturnsFalse(string key, string enumValue)
    => checks
      .SkipIf(key == enumValue)
      .FalseExpected(
        '(' + key + ":)",
        CheckNull);

  [SkippableTheory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsFalse(string key, string enumValue)
    => checks
      .SkipIf(key == enumValue)
      .FalseExpected(
        '(' + key + ':' + enumValue + ';' + enumValue + ':' + key + ')',
        CheckNull);

  private void CheckNull(IGqlpArg? result)
    => result.Should().BeNull();
}
