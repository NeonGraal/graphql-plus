﻿using System.Globalization;
using GqlPlus.Parsing;

namespace GqlPlus;

public class ParseDefaultTests(
  IOneChecksParser<IParserDefault, IGqlpConstant> checks
)
{
  [Fact]
  public void WithEmpty_ReturnsEmpty()
    => checks.EmptyResult("");

  [Fact]
  public void WithInvalid_ReturnsFalse()
    => checks.FalseExpected("=");

  [Theory, RepeatData]
  public void WithNumber_ReturnsCorrectAst(decimal number)
    => checks.TrueExpected(
      "=" + number.ToString(CultureInfo.InvariantCulture),
      new ConstantAst(new FieldKeyAst(AstNulls.At, number)));

  [Theory, RepeatData]
  public void WithString_ReturnsCorrectAst(string contents)
    => checks.TrueExpected(
      "=" + contents.Quote(),
      new ConstantAst(new FieldKeyAst(AstNulls.At, contents)));

  [Theory, RepeatData]
  public void WithEnumValue_ReturnsCorrectAst(string enumValue)
    => checks.TrueExpected(
      "=" + enumValue,
      new ConstantAst(enumValue.FieldKey()));

  [Theory, RepeatData]
  public void WithEnumValueInvalid_ReturnsFalse(string enumValue)
    => checks.FalseExpected("=." + enumValue);

  [Theory, RepeatData]
  public void WithEnumTypeAndValue_ReturnsCorrectAst(string enumType, string enumValue)
    => checks.TrueExpected(
      "=" + enumType + "." + enumValue,
      new ConstantAst(new FieldKeyAst(AstNulls.At, enumType, enumValue)));

  [Theory, RepeatData]
  public void WithEnumInvalid_ReturnsFalse(string enumType)
    => checks.FalseExpected("=" + enumType + ".");

  [Theory, RepeatData]
  public void WithList_ReturnsCorrectAst(string enumValue)
    => checks.TrueExpected(
      "=" + '[' + enumValue + ' ' + enumValue + ']',
      new ConstantAst(AstNulls.At, enumValue.ConstantList()));

  [Theory, RepeatData]
  public void WithListInvalid_ReturnsFalse(string enumValue)
    => checks.FalseExpected(
      "=" + '[' + enumValue + ':' + enumValue + ']',
      CheckNull);

  [Theory, RepeatData]
  public void WithObject_ReturnsCorrectAst(string key, string enumValue)
    => checks
      .SkipIf(key == enumValue)
      .TrueExpected(
        "=" + '{' + key + ':' + enumValue + ' ' + enumValue + ':' + key + '}',
        new ConstantAst(AstNulls.At, enumValue.ConstantObject(key)));

  [Theory, RepeatData]
  public void WithObjectInvalid_ReturnsFalse(string key, string enumValue)
    => checks
      .SkipIf(key == enumValue)
      .FalseExpected(
        "=" + '{' + key + ':' + enumValue + ':' + key + '}',
        CheckNull);

  private void CheckNull(IGqlpConstant? result)
    => result.ShouldBeNull();
}
