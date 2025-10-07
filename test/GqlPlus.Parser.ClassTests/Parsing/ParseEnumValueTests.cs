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
  public void Parse_ShouldReturnEnumValueResult_WhenEnumTypeAndLabelAreParsed(string enumType, string enumLabel)
  {
    // Arrange
    TakeReturns('.', true);
    IdentifierReturns(OutString(enumType), OutString(enumLabel));

    // Act
    IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpEnumValue>>()
      .Required().ShouldSatisfyAllConditions(
        e => e.EnumType.ShouldBe(enumType),
        e => e.EnumLabel.ShouldBe(enumLabel),
        e => e.EnumValue.ShouldBe($"{enumType}.{enumLabel}")
      );
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnumValueResult_WhenEnumLabelAreParsed(string enumLabel)
  {
    // Arrange
    IdentifierReturns(OutString(enumLabel));

    // Act
    IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpEnumValue>>()
      .Required().ShouldSatisfyAllConditions(
        e => e.EnumType.ShouldBeEmpty(),
        e => e.EnumLabel.ShouldBe(enumLabel),
        e => e.EnumValue.ShouldBe(enumLabel)
      );
  }

  [Theory, InlineData("true", "Boolean"), InlineData("false", "Boolean"), InlineData("null", "Null"), InlineData("_", "Unit")]
  public void Parse_ShouldReturnEnumValueResult_WhenBuiltInEnumLabelAreParsed(string enumLabel, string expectedType)
  {
    // Arrange
    IdentifierReturns(OutString(enumLabel));

    // Act
    IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpEnumValue>>()
      .Required().ShouldSatisfyAllConditions(
        e => e.EnumType.ShouldBe(expectedType),
        e => e.EnumLabel.ShouldBe(enumLabel),
        e => e.EnumValue.ShouldBe($"{expectedType}.{enumLabel}")
      );
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenInvalidEnumValue(string enumType)
  {
    // Arrange
    IdentifierReturns(OutString(enumType));
    TakeReturns('.', true);

    // Act
    IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoValidTokenIsParsed()
  {
    // Act
    IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenDotWithoutSecondIdentifier(string enumType)
  {
    // Arrange
    IdentifierReturns(OutString(enumType));
    TakeReturns('.', true);

    // Act
    IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnumValueResult_WhenNoDotAfterFirstIdentifier(string enumLabel)
  {
    // Arrange
    IdentifierReturns(OutString(enumLabel));
    TakeReturns('.', false);

    // Act
    IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpEnumValue>>()
      .Required().ShouldSatisfyAllConditions(
        e => e.EnumType.ShouldBeEmpty(),
        e => e.EnumLabel.ShouldBe(enumLabel),
        e => e.EnumValue.ShouldBe(enumLabel)
      );
  }

  [Fact]
  public void Parse_ShouldHandleBuiltInValues_Correctly()
  {
    var builtInValues = new[]
    {
      ("true", "Boolean"),
      ("false", "Boolean"),
      ("null", "Null"),
      ("_", "Unit")
    };

    foreach (var (label, expectedType) in builtInValues) {
      // Arrange
      IdentifierReturns(OutString(label));

      // Act
      IResult<IGqlpEnumValue> result = _parseEnumValue.Parse(Tokenizer, "testLabel");

      // Assert
      result.ShouldBeAssignableTo<IResultOk<IGqlpEnumValue>>()
        .Required().ShouldSatisfyAllConditions(
          e => e.EnumType.ShouldBe(expectedType),
          e => e.EnumLabel.ShouldBe(label),
          e => e.EnumValue.ShouldBe($"{expectedType}.{label}")
        );
    }
  }
}
