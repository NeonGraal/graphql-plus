using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseCategoryTests
  : DeclarationClassTestBase
{

  private readonly IOptionParser<CategoryOption> _option;
  private readonly Parser<CategoryOutput>.I _definition;
  private readonly ParseCategory _parser;

  public ParseCategoryTests()
  {
    ICategoryName name = Substitute.For<ICategoryName>();
    NameParser = name;
    Parsers.GetName<ICategoryName>().Returns(name);
    ConfigureRepoInterface<IOptionParser<CategoryOption>, CategoryOption>(Parsers, out _option);
    ConfigureRepo<CategoryOutput>(Parsers, out _definition);
    _parser = new ParseCategory(Parsers);
    NameReturns(null);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnCategory_WhenValid(string category)
  {
    // Arrange
    IdentifierReturns(OutString(category));
    IAstTypeRef typeRef = A.Named<IAstTypeRef>(category);
    ParseOk(_definition, new CategoryOutput(typeRef));

    // Act
    IResult<IAstSchemaCategory> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstSchemaCategory>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);
    ParseEmpty(_definition);

    // Act
    IResult<IAstSchemaCategory> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstSchemaCategory>>();
  }
}
