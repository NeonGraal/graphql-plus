﻿namespace GqlPlus.Parsing;

public class ValueListParserTests
  : ParserClassTestBase
{
  private readonly ValueListParser<IGqlpConstant> _parser;
  private readonly Parser<IGqlpConstant>.I _valueParser;

  public ValueListParserTests()
  {
    Parser<IGqlpConstant>.D valueParser = ParserFor(out _valueParser);
    _parser = new ValueListParser<IGqlpConstant>(valueParser);

    SetupError<IGqlpConstant>();
  }

  [Fact]
  public void Parse_ShouldReturnList_WhenSuccessful()
  {
    // Arrange
    TakeReturns('[', true);
    ParseOk(_valueParser, AtFor<IGqlpConstant>());
    TakeReturns(']', true);

    // Act
    IResultArray<IGqlpConstant> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpConstant>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyList_WhenBracketsAreMissing()
  {
    // Arrange
    TakeReturns('[', false);

    // Act
    IResultArray<IGqlpConstant> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayEmpty<IGqlpConstant>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenValueParsingFails()
  {
    // Arrange
    TakeReturns('[', true);
    ParseError(_valueParser, "Value parsing error");

    // Act
    IResultArray<IGqlpConstant> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenClosingBracketIsMissing()
  {
    // Arrange
    TakeReturns('[', true);
    ParseOk(_valueParser, AtFor<IGqlpConstant>());
    TakeReturns(']', false);

    // Act
    IResultArray<IGqlpConstant> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayError<IGqlpConstant>>();
  }
}
