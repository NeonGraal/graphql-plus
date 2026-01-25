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

  [Theory, RepeatData]
  public void Parse_ShouldReturnArray_WhenValid(string label)
  {
    // Arrange
    Parse(_itemParser, "item1".Ok(), "item2".Ok(), string.Empty.Empty());

    // Act
    IResultArray<string> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<string>>()
      .Required().ShouldBe(["item1", "item2"]);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenItemParsingFails(string label)
  {
    // Arrange
    ParseError(_itemParser);

    // Act
    IResultArray<string> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<string>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEmptyArray_WhenNoItems(string label)
  {
    // Arrange
    ParseEmpty(_itemParser);

    // Act
    IResultArray<string> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<string>>()
      .Required().ShouldBeEmpty();
  }
}
