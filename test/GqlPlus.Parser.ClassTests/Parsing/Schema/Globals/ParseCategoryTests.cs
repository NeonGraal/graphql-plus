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
    ConfigureRepoInterface<IOptionParser<CategoryOption>, CategoryOption>(Parsers, out _option);
    ConfigureRepo<CategoryOutput>(Parsers, out _definition);
    _parser = new ParseCategory(name, Parsers);
    NameReturns(null);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnCategory_WhenValid(string category)
  {
    // Arrange
    IdentifierReturns(OutString(category));
    IGqlpTypeRef typeRef = A.Named<IGqlpTypeRef>(category);
    ParseOk(_definition, new CategoryOutput(typeRef));

    // Act
    IResult<IGqlpSchemaCategory> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSchemaCategory>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);
    ParseEmpty(_definition);

    // Act
    IResult<IGqlpSchemaCategory> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpSchemaCategory>>();
  }
}
