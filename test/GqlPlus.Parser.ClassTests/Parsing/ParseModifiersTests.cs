namespace GqlPlus.Parsing;

public class ParseModifiersTests
  : ParserClassTestBase
{
  private readonly ParseModifiers _parseModifiers;
  private readonly Parser<IGqlpModifier>.IA _collectionsParser;

  public ParseModifiersTests()
  {
    ParserArray<IParserCollections, IGqlpModifier>.DA collections = ParserAFor<IParserCollections, IGqlpModifier>(out _collectionsParser);
    _parseModifiers = new ParseModifiers(collections);
  }

  [Fact]
  public void Parse_ShouldReturnModifiersArray_WhenCollectionsParserSucceeds()
  {
    // Arrange
    IGqlpModifier modifier = For<IGqlpModifier>();
    ParseOkA(_collectionsParser, [modifier]);

    // Act
    IResultArray<IGqlpModifier> result = _parseModifiers.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpModifier>>()
      .Required().ShouldHaveSingleItem()
      .ShouldBe(modifier);
  }

  [Fact]
  public void Parse_ShouldReturnOptionalModifier_WhenQuestionMarkIsPresent()
  {
    // Arrange
    Tokenizer.Take('?').Returns(true);

    // Act
    IResultArray<IGqlpModifier> result = _parseModifiers.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpModifier>>()
      .Required().ShouldHaveSingleItem()
      .ModifierKind.ShouldBe(ModifierKind.Opt);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenCollectionsParserFails()
  {
    // Arrange
    ParseErrorA(_collectionsParser, "error");

    // Act
    var result = _parseModifiers.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoModifiersAreParsed()
  {
    // Arrange
    ParseEmptyA(_collectionsParser);
    Tokenizer.Take('?').Returns(false);

    // Act
    IResultArray<IGqlpModifier> result = _parseModifiers.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpModifier>>()
      .Required().ShouldBeEmpty();
  }
}
