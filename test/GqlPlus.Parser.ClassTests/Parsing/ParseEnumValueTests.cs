namespace GqlPlus.Parsing;

public class ParseEnumValueTests
  : ParserClassTestBase
{
  private readonly ParseEnumValue _parseEnumValue;

  public ParseEnumValueTests()
  {
    _parseEnumValue = new ParseEnumValue();

    SetupError<IGqlpEnumValue>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnumValueResult_WhenEnumTypeAndLabelAreParsed(string enumType, string enumLabel, string label)
  {
    // Arrange
    TakeReturns('.', true);
    IdentifierReturns(OutString(enumType), OutString(enumLabel));

    // Act
    IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpEnumValue>>()
      .Required().ShouldSatisfyAllConditions(
        e => e.EnumType.ShouldBe(enumType),
        e => e.EnumLabel.ShouldBe(enumLabel),
        e => e.EnumValue.ShouldBe($"{enumType}.{enumLabel}")
      );
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnumValueResult_WhenEnumLabelAreParsed(string enumLabel, string label)
  {
    // Arrange
    IdentifierReturns(OutString(enumLabel));

    // Act
    IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpEnumValue>>()
      .Required().ShouldSatisfyAllConditions(
        e => e.EnumType.ShouldBeEmpty(),
        e => e.EnumLabel.ShouldBe(enumLabel),
        e => e.EnumValue.ShouldBe(enumLabel)
      );
  }

  [Theory]
  [RepeatInlineData("true", "Boolean")]
  [RepeatInlineData("false", "Boolean")]
  [RepeatInlineData("null", "Null")]
  [RepeatInlineData("_", "Unit")]
  public void Parse_ShouldReturnEnumValueResult_WhenBuiltInEnumLabelAreParsed(string enumLabel, string expectedType, string label)
  {
    // Arrange
    IdentifierReturns(OutString(enumLabel));

    // Act
    IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpEnumValue>>()
      .Required().ShouldSatisfyAllConditions(
        e => e.EnumType.ShouldBe(expectedType),
        e => e.EnumLabel.ShouldBe(enumLabel),
        e => e.EnumValue.ShouldBe($"{expectedType}.{enumLabel}")
      );
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenInvalidEnumValue(string enumType, string label)
  {
    // Arrange
    IdentifierReturns(OutString(enumType));
    TakeReturns('.', true);

    // Act
    IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEmptyResult_WhenNoValidTokenIsParsed(string label)
  {
    // Act
    IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenDotWithoutSecondIdentifier(string enumType, string label)
  {
    // Arrange
    IdentifierReturns(OutString(enumType));
    TakeReturns('.', true);

    // Act
    IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnumValueResult_WhenNoDotAfterFirstIdentifier(string enumLabel, string label)
  {
    // Arrange
    IdentifierReturns(OutString(enumLabel));
    TakeReturns('.', false);

    // Act
    IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpEnumValue>>()
      .Required().ShouldSatisfyAllConditions(
        e => e.EnumType.ShouldBeEmpty(),
        e => e.EnumLabel.ShouldBe(enumLabel),
        e => e.EnumValue.ShouldBe(enumLabel)
      );
  }

  [Theory, RepeatData]
  public void Parse_ShouldHandleBuiltInValues_Correctly(string label)
  {
    (string, string)[] builtInValues =
    [
      ("true", "Boolean"),
      ("false", "Boolean"),
      ("null", "Null"),
      ("_", "Unit")
    ];

    foreach ((string builtInLabel, string expectedType) in builtInValues) {
      // Arrange
      IdentifierReturns(OutString(builtInLabel));

      // Act
      IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, label);

      // Assert
      result.ShouldBeAssignableTo<IResultOk<IGqlpEnumValue>>()
        .Required().ShouldSatisfyAllConditions(
          e => e.EnumType.ShouldBe(expectedType),
          e => e.EnumLabel.ShouldBe(builtInLabel),
          e => e.EnumValue.ShouldBe($"{expectedType}.{builtInLabel}")
        );
    }
  }
}
