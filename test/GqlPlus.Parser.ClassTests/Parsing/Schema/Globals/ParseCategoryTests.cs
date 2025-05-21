using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseCategoryTests
  : DeclarationClassTestBase
{
  private readonly Parser<CategoryOption>.I _option;
  private readonly Parser<CategoryOutput>.I _definition;
  private readonly ParseCategory _parser;

  public ParseCategoryTests()
  {
    ICategoryName name = Substitute.For<ICategoryName>();
    NameParser = name;

    Parser<IOptionParser<CategoryOption>, CategoryOption>.D option = ParserFor<IOptionParser<CategoryOption>, CategoryOption>(out _option);
    Parser<CategoryOutput>.D definition = ParserFor(out _definition);

    _parser = new ParseCategory(name, ParamNull, Aliases, option, definition);

    NameReturns(null);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnCategory_WhenValid(string category)
  {
    // Arrange
    IdentifierReturns(OutString(category));
    IGqlpTypeRef typeRef = NFor<IGqlpTypeRef>(category);
    ParseOk(_definition, new CategoryOutput(typeRef));

    // Act
    IResult<IGqlpSchemaCategory> result = _parser.Parse(Tokenizer, "testLabel");

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
    IResult<IGqlpSchemaCategory> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpSchemaCategory>>();
  }
}
