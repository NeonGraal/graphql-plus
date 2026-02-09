using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public abstract class ParseDomainClassTestBase<TItem>
  : ParserClassTestBase
  where TItem : IGqlpDomainItem
{
  [Fact]
  public void Kind_ShouldReturnDomainKind()
  {
    // Arrange

    // Act
    DomainKind kind = Parser.Kind;

    // Assert
    kind.ShouldBe(_kind);
  }

  [Fact]
  public void ParseItems_ShouldReturnDomainDefinition_WhenValid()
  {
    // Arrange
    TakeReturns('}', true);
    DomainDefinition initial = new() { Kind = _kind };
    ParseOkA(ItemsParser, NewItem());

    // Act
    IResult<DomainDefinition> result = Parser.Parser(Tokenizer, "testLabel", initial);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<DomainDefinition>>();
  }

  [Fact]
  public void ParseItems_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    DomainDefinition initial = new() { Kind = _kind };
    ParseErrorA(ItemsParser);

    // Act
    IResult<DomainDefinition> result = Parser.Parser(Tokenizer, "testLabel", initial);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnDomainItem_WhenValid()
  {
    // Arrange
    ArrangeValidItem();

    // Act
    IResult<TItem> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<TItem>>();
  }


  [Fact]
  public void Parse_ShouldReturnEmpty_WhenInvalid()
  {
    // Arrange
    // Tokenizer.Regex(out _).Returns(OutFail);

    // Act
    IResult<TItem> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  protected Parser<TItem>.IA ItemsParser { get; }
  private readonly Lazy<ParseDomainItem<TItem>> _parser;
  private readonly DomainKind _kind;

  internal ParseDomainItem<TItem> Parser => _parser.Value;

  protected ParseDomainClassTestBase(DomainKind kind)
  {
    _kind = kind;
    Parser<TItem>.DA itemsFactory = ParserAFor(out Parser<TItem>.IA itemsParser);
    ItemsParser = itemsParser;
    _parser = new(() => MakeParser(itemsFactory));
  }

  internal abstract ParseDomainItem<TItem> MakeParser(Parser<TItem>.DA itemsParser);
  protected abstract TItem NewItem();
  protected abstract void ArrangeValidItem();
}
