using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseDirectiveTests
  : DeclarationClassTestBase
{
  private const string TestLabel = "testLabel";

  private readonly ParseDirective _parser;
  private readonly Parser<IGqlpInputParam>.IA _param;
  private readonly IOptionParser<DirectiveOption> _option;
  private readonly Parser<DirectiveLocation>.I _definition;

  public ParseDirectiveTests()
  {
    IDirectiveName name = A.Of<IDirectiveName>();
    NameParser = name;

    Parser<IGqlpInputParam>.DA param = ParserAFor(out _param);
    Parser<IOptionParser<DirectiveOption>, DirectiveOption>.D option = OptionParserFor(out _option);
    Parser<DirectiveLocation>.D definition = ParserFor(out _definition);

    _parser = new ParseDirective(name, param, Aliases, option, definition);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenSimple(string directive)
  {
    // Arrange
    NameReturns(directive);
    ParseOk(_definition, DirectiveLocation.Operation);

    // Act
    IResult<IGqlpSchemaDirective> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSchemaDirective>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenAll(string directive)
  {
    // Arrange
    NameReturns(directive);
    ParseOkA(_param);
    ParseOkOption(_option);
    ParseOk(_definition, DirectiveLocation.Operation);

    // Act
    IResult<IGqlpSchemaDirective> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSchemaDirective>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenNoName()
    => Check_ShouldReturnError_WhenNoName(_parser);

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenParamErrors(string directive)
  {
    // Arrange
    NameReturns(directive);
    ParseErrorA(_param);
    SetupError<IGqlpSchemaDirective>();

    // Act
    IResult<IGqlpSchemaDirective> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpSchemaDirective>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenNoBrace(string directive)
  {
    // Arrange
    NameReturns(directive);
    TakeReturns('{', false);
    SetupPartial<IGqlpSchemaDirective>();
    SetupError<IGqlpSchemaDirective>();

    // Act
    IResult<IGqlpSchemaDirective> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpSchemaDirective>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenInvalid(string directive)
  {
    // Arrange
    NameReturns(directive);
    ParseError(_definition);
    SetupError<IGqlpSchemaDirective>();

    // Act
    IResult<IGqlpSchemaDirective> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpSchemaDirective>>();
  }
}
