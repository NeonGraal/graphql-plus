namespace GqlPlus.Parsing;

public class ParseModifiersTests
  : ModifiersClassTestBase
{
  private readonly ParseModifiers _parseModifiers;

  public ParseModifiersTests()
    => _parseModifiers = new ParseModifiers(Collections);

  [Theory, RepeatData]
  public void Parse_ShouldReturnModifiersArray_WhenCollectionsParserSucceeds(string label)
  {
    // Arrange
    IGqlpModifier[] modifiers = ParseAModifier();

    // Act
    IResultArray<IGqlpModifier> result = _parseModifiers.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpModifier>>()
      .Required().ShouldBe(modifiers);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOptionalModifier_WhenQuestionMarkIsPresent(string label)
  {
    // Arrange
    TakeReturns('?', true);

    // Act
    IResultArray<IGqlpModifier> result = _parseModifiers.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpModifier>>()
      .Required().ShouldHaveSingleItem()
      .ModifierKind.ShouldBe(ModifierKind.Opt);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenCollectionsParserFails(string label)
  {
    // Arrange
    ParseModifiersError();

    // Act
    IResultArray<IGqlpModifier> result = _parseModifiers.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEmptyResult_WhenNoModifiersAreParsed(string label)
  {
    // Arrange
    ParseModifiersEmpty();
    TakeReturns('?', false);

    // Act
    IResultArray<IGqlpModifier> result = _parseModifiers.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpModifier>>()
      .Required().ShouldBeEmpty();
  }
}
