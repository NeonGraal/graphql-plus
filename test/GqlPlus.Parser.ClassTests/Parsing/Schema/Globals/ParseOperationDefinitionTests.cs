using GqlPlus.Ast.Operation;
using GqlPlus.Ast.Schema;
using GqlPlus.Parsing.Operation;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseOperationDefinitionTests
  : ModifiersClassTestBase
{
  private readonly ParseOperationDefinition _parser;
  private readonly IParserArg _argumentParser;
  private readonly IParserArray<IAstDirective> _directivesParser;
  private readonly IParserStartFragments _fragmentsParser;
  private readonly IParserArray<IAstSelection> _objectParser;
  private readonly IParser<IAstTypeRef> _resultTypeParser;
  private readonly IParserArray<IAstVariable> _variablesParser;

  public ParseOperationDefinitionTests()
  {
    ConfigureRepoInterface<IParserArg, IAstArg>(Parsers, out _argumentParser);
    ConfigureRepoArray(Parsers, out _directivesParser);
    ConfigureRepoArrayInterface<IParserStartFragments, IAstFragment>(Parsers, out _fragmentsParser);
    ConfigureRepoArray(Parsers, out _objectParser);
    ConfigureRepo(Parsers, out _resultTypeParser);
    ConfigureRepoArray(Parsers, out _variablesParser);
    _parser = new ParseOperationDefinition(Parsers);

    SetupError<OperationDefinition>();
    SetupPartial(new OperationDefinition(""));
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenResultTypeParsed(string category)
  {
    // Arrange
    IdentifierReturns(OutString(category));
    ParseOkA(_variablesParser);
    ParseOkA(_directivesParser);
    ParseOkA(_fragmentsParser);
    TakeReturns(':', true);
    ParseOk(_resultTypeParser);
    ParseOk(_argumentParser);
    ParseAModifier();
    TakeReturns('}', true);

    // Act
    IResult<OperationDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<OperationDefinition>>()
      .Required().ShouldSatisfyAllConditions(
        x => x.Category.ShouldBe(category),
        x => x.Domain.ShouldNotBeNull()
      );
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenObjectParsed(string category)
  {
    // Arrange
    IdentifierReturns(OutString(category));
    ParseOkA(_variablesParser);
    ParseOkA(_directivesParser);
    ParseOkA(_fragmentsParser);
    TakeReturns(':', false);
    ParseOkA(_objectParser);
    ParseAModifier();
    TakeReturns('}', true);

    // Act
    IResult<OperationDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<OperationDefinition>>()
      .Required().Category.ShouldBe(category);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenNoCategory()
  {
    // Act
    IResult<OperationDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenVariablesFail(string category)
  {
    // Arrange
    IdentifierReturns(OutString(category));
    ParseErrorA(_variablesParser);

    // Act
    IResult<OperationDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<OperationDefinition>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenResultTypeErrors(string category)
  {
    // Arrange
    IdentifierReturns(OutString(category));
    ParseOkA(_variablesParser);
    TakeReturns(':', true);
    ParseError(_resultTypeParser);

    // Act
    IResult<OperationDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<OperationDefinition>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenArgumentErrors(string category)
  {
    // Arrange
    IdentifierReturns(OutString(category));
    ParseOkA(_variablesParser);
    TakeReturns(':', true);
    ParseOk(_resultTypeParser);
    ParseError(_argumentParser);

    // Act
    IResult<OperationDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<OperationDefinition>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenObjectParsingFails(string category)
  {
    // Arrange
    IdentifierReturns(OutString(category));
    ParseOkA(_variablesParser);
    TakeReturns(':', false);
    ParseErrorA(_objectParser);

    // Act
    IResult<OperationDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<OperationDefinition>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenModifiersError(string category)
  {
    // Arrange
    IdentifierReturns(OutString(category));
    ParseOkA(_variablesParser);
    TakeReturns(':', true);
    ParseOk(_resultTypeParser);
    ParseOk(_argumentParser);
    ParseModifiersError();

    // Act
    IResult<OperationDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<OperationDefinition>>();
  }
}
