namespace GqlPlus.Parsing.Schema;

public class ArrayParserTests
  : ParserClassTestBase
{
  private readonly Parser<string>.I _itemParser;
  private readonly ArrayParser<string> _parser;

  public ArrayParserTests()
  {
    Parser<string>.D itemParser = ParserFor(out _itemParser);

    _parser = new ArrayParser<string>(itemParser);
  }

  [Fact]
  public void Parse_ShouldReturnArray_WhenValid()
  {
    // Arrange
    Parse(_itemParser, "item1".Ok(), "item2".Ok(), "".Empty());

    // Act
    IResultArray<string> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<string>>()
      .Required().ShouldBe(["item1", "item2"]);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenItemParsingFails()
  {
    // Arrange
    ParseError(_itemParser);

    // Act
    IResultArray<string> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<string>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyArray_WhenNoItems()
  {
    // Arrange
    ParseEmpty(_itemParser);

    // Act
    IResultArray<string> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<string>>()
      .Required().ShouldBeEmpty();
  }
}
