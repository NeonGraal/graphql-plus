namespace GqlPlus.Parsing;

public class ParseModifiersTests
  : ModifiersClassTestBase
{

  private readonly ParseModifiers _parseModifiers;

  public ParseModifiersTests()
    => _parseModifiers = new ParseModifiers(Parsers);

  [Fact]
  public void Parse_ShouldReturnModifiersArray_WhenCollectionsParserSucceeds()
  {
    // Arrange
    IAstModifier[] modifiers = ParseAModifier();

    // Act
    IResultArray<IAstModifier> result = _parseModifiers.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstModifier>>()
      .Required().ShouldBe(modifiers);
  }

  [Fact]
  public void Parse_ShouldReturnOptionalModifier_WhenQuestionMarkIsPresent()
  {
    // Arrange
    TakeReturns('?', true);

    // Act
    IResultArray<IAstModifier> result = _parseModifiers.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstModifier>>()
      .Required().ShouldHaveSingleItem()
      .ModifierKind.ShouldBe(ModifierKind.Opt);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenCollectionsParserFails()
  {
    // Arrange
    ParseModifiersError();

    // Act
    IResultArray<IAstModifier> result = _parseModifiers.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoModifiersAreParsed()
  {
    // Arrange
    ParseModifiersEmpty();
    TakeReturns('?', false);

    // Act
    IResultArray<IAstModifier> result = _parseModifiers.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstModifier>>()
      .Required().ShouldBeEmpty();
  }
}
