using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseOperationDeclTests
  : DeclarationClassTestBase
{

  private readonly ParseOperationDecl _parser;
  private readonly Parser<OperationDefinition>.I _definition;

  public ParseOperationDeclTests()
  {
    ConfigureRepo(Parsers, out _definition);
    _parser = new ParseOperationDecl(Parsers);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOperation_WhenValid(string operation, string category)
  {
    // Arrange
    NameReturns(operation);
    ParseOk(_definition, new OperationDefinition(category));

    // Act
    IResult<IGqlpSchemaOperation> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSchemaOperation>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenInvalid(string option)
  {
    // Arrange
    NameReturns(option);
    SetupError<IGqlpSchemaOperation>();

    // Act
    IResult<IGqlpSchemaOperation> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpSchemaOperation>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenNoName()
    => Check_ShouldReturnError_WhenNoName(_parser);
}
