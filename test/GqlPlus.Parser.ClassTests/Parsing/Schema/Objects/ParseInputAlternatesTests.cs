﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputAlternatesTests
  : ModifiersClassTestBase
{
  private readonly Parser<IGqlpInputBase>.I _parseBase;
  private readonly ParseInputAlternates _parser;

  public ParseInputAlternatesTests()
  {
    Parser<IGqlpInputBase>.D parseBase = ParserFor(out _parseBase);
    _parser = new ParseInputAlternates(Collections, parseBase);
  }

  [Fact]
  public void Parse_ShouldReturnInputAlternate_WhenValid()
  {
    // Arrange
    TakeReturns('|', true);
    ParseOk(_parseBase);

    // Act
    IResultArray<IGqlpInputAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpInputAlternate>>()
      .Required().ShouldNotBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenEmpty()
  {
    // Arrange
    TakeReturns('|', false);

    // Act
    IResultArray<IGqlpInputAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpInputAlternate>>()
      .Required().ShouldBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    TakeReturns('|', true);
    ParseError(_parseBase);
    SetupPartial<IGqlpInputAlternate>();

    // Act
    IResultArray<IGqlpInputAlternate> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpInputAlternate>>();
  }
}
