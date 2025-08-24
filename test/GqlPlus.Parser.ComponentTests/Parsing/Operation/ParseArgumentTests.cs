using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseArgTests(
  IOneChecksParser<IParserArg, IGqlpArg> checks
)
{
  [Theory, RepeatData]
  public void WithVariable_ReturnsCorrectAst(string variable)
    => checks
      .TrueExpected(
        "($" + variable + ")",
        new ArgAst(AstNulls.At, variable));

  [Theory, RepeatData]
  public void WithConstant_ReturnsCorrectAst(string enumValue)
    => checks
      .TrueExpected(
        "(" + enumValue + ")",
        new ArgAst(enumValue.FieldKey()));

  [Theory, RepeatData]
  public void WithList_ReturnsCorrectAst(string enumValue)
    => checks
      .TrueExpected(
        "($" + enumValue + ' ' + enumValue + ')',
        new ArgAst(AstNulls.At, enumValue.ArgList()));

  [Theory, RepeatData]
  public void WithListComma_ReturnsCorrectAst(string enumValue)
    => checks
      .TrueExpected(
        "($" + enumValue + ',' + enumValue + ')',
        new ArgAst(AstNulls.At, enumValue.ArgList()));

  [Theory, RepeatData]
  public void WithListInvalid_ReturnsFalse(string enumValue)
    => checks
      .FalseExpected(
        "($" + enumValue + '|' + enumValue + ')',
        CheckNull);

  [Theory, RepeatData]
  public void WithField_ReturnsTrue(string enumValue)
    => checks
      .TrueExpected(
        '(' + enumValue + ":$" + enumValue + ')',
        new ArgAst(AstNulls.At, enumValue.ArgObject(enumValue)));

  [Theory, RepeatData]
  public void WithObject_ReturnsCorrectAst(string key, string enumValue)
    => checks
      .SkipEqual(key, enumValue)
      .TrueExpected(
        '(' + key + ":$" + enumValue + ' ' + enumValue + ':' + key + ')',
        new ArgAst(AstNulls.At, enumValue.ArgObject(key)));

  [Theory, RepeatData]
  public void WithObjectSemi_ReturnsCorrectAst(string key, string enumValue)
    => checks
      .SkipEqual(key, enumValue)
      .TrueExpected(
        '(' + key + ":$" + enumValue + ',' + enumValue + ':' + key + ')',
        new ArgAst(AstNulls.At, enumValue.ArgObject(key)));

  [Theory, RepeatData]
  public void WithObjectSemiEnumValue_ReturnsFalse(string key, string enumValue)
    => checks
      .SkipEqual(key, enumValue)
      .FalseExpected(
        '(' + key + ":$" + enumValue + ',' + enumValue + ')',
        CheckNull);

  [Theory, RepeatData]
  public void WithObjectFieldBad_ReturnsFalse(string key, string enumValue)
    => checks
      .SkipEqual(key, enumValue)
      .FalseExpected(
        '(' + key + ":)",
        CheckNull);

  [Theory, RepeatData]
  public void WithObjectInvalid_ReturnsFalse(string key, string enumValue)
    => checks
      .SkipEqual(key, enumValue)
      .FalseExpected(
        '(' + key + ':' + enumValue + ';' + enumValue + ':' + key + ')',
        CheckNull);

  private void CheckNull(IGqlpArg? result)
    => result.ShouldBeNull();
}
