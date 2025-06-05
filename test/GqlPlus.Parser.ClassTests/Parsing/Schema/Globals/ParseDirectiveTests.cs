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
    IDirectiveName name = For<IDirectiveName>();
    NameParser = name;

    Parser<IGqlpInputParam>.DA param = ParserAFor(out _param);
    Parser<IOptionParser<DirectiveOption>, DirectiveOption>.D option = OptionParserFor<DirectiveOption>(out _option);
    Parser<DirectiveLocation>.D definition = ParserFor(out _definition);

    _parser = new ParseDirective(name, param, Aliases, option, definition);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDirective_WhenValid(string directive)
  {
    // Arrange
    NameReturns(directive);
    ParseOk(_definition, DirectiveLocation.Operation);

    // Act
    IResult<IGqlpSchemaDirective> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSchemaDirective>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenNoName()
    => Check_ShouldReturnError_WhenNoName(_parser);

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenInvalid(string directive)
  {
    // Arrange
    NameReturns(directive);
    ParseError(_definition);
    SetupError<IGqlpSchemaDirective>();

    // Act
    IResult<IGqlpSchemaDirective> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpSchemaDirective>>();
  }
}
