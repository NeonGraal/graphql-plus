namespace GqlPlus.Parsing;

public class ParseModifiersTests
  : ModifiersClassTestBase
{

  private readonly ParseModifiers _parseModifiers;

  public ParseModifiersTests()
    => _parseModifiers = new ParseModifiers(Collections);

  [Fact]
  public void Parse_ShouldReturnModifiersArray_WhenCollectionsParserSucceeds()
  {
    // Arrange
    IGqlpModifier[] modifiers = ParseAModifier();

    // Act
    IResultArray<IGqlpModifier> result = _parseModifiers.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpModifier>>()
      .Required().ShouldBe(modifiers);
  }

  [Fact]
  public void Parse_ShouldReturnOptionalModifier_WhenQuestionMarkIsPresent()
  {
    // Arrange
    TakeReturns('?', true);

    // Act
    IResultArray<IGqlpModifier> result = _parseModifiers.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpModifier>>()
      .Required().ShouldHaveSingleItem()
      .ModifierKind.ShouldBe(ModifierKind.Opt);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenCollectionsParserFails()
  {
    // Arrange
    ParseModifiersError();

    // Act
    IResultArray<IGqlpModifier> result = _parseModifiers.Parse(Tokenizer, TestLabel);

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
    IResultArray<IGqlpModifier> result = _parseModifiers.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpModifier>>()
      .Required().ShouldBeEmpty();
  }
}
