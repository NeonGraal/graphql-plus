using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseDirectiveTests
  : DeclarationClassTestBase
{

  private readonly ParseDirective _parser;
  private readonly Parser<IGqlpInputParam>.IA _param;
  private readonly IOptionParser<DirectiveOption> _option;
  private readonly Parser<DirectiveLocation>.I _definition;

  public ParseDirectiveTests()
  {
    IDirectiveName name = A.Of<IDirectiveName>();
    NameParser = name;
    Parsers.GetName<IDirectiveName>().Returns(name);
    ConfigureRepoArray<IGqlpInputParam>(Parsers, out _param);
    ConfigureRepoInterface<IOptionParser<DirectiveOption>, DirectiveOption>(Parsers, out _option);
    ConfigureRepo<DirectiveLocation>(Parsers, out _definition);
    _parser = new ParseDirective(Parsers);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenSimple(string directive)
  {
    // Arrange
    NameReturns(directive);
    ParseOk(_definition, DirectiveLocation.Operation);

    // Act
    IResult<IAstSchemaDirective> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstSchemaDirective>>();
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
    IResult<IAstSchemaDirective> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstSchemaDirective>>();
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
    SetupError<IAstSchemaDirective>();

    // Act
    IResult<IAstSchemaDirective> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstSchemaDirective>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenNoBrace(string directive)
  {
    // Arrange
    NameReturns(directive);
    TakeReturns('{', false);
    SetupPartial<IAstSchemaDirective>();
    SetupError<IAstSchemaDirective>();

    // Act
    IResult<IAstSchemaDirective> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstSchemaDirective>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenInvalid(string directive)
  {
    // Arrange
    NameReturns(directive);
    ParseError(_definition);
    SetupError<IAstSchemaDirective>();

    // Act
    IResult<IAstSchemaDirective> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstSchemaDirective>>();
  }
}
