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

    Parser<IOptionParser<CategoryOption>, CategoryOption>.D option = OptionParserFor(out _option);
    Parser<CategoryOutput>.D definition = ParserFor(out _definition);

    _parser = new ParseCategory(name, ParamNull, Aliases, option, definition);

    NameReturns(null);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnCategory_WhenValid(string category, string label)
  {
    // Arrange
    IdentifierReturns(OutString(category));
    IGqlpTypeRef typeRef = A.Named<IGqlpTypeRef>(category);
    ParseOk(_definition, new CategoryOutput(typeRef));

    // Act
    IResult<IGqlpSchemaCategory> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSchemaCategory>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenInvalid(string label)
  {
    // Arrange
    IdentifierReturns(OutFail);
    ParseEmpty(_definition);

    // Act
    IResult<IGqlpSchemaCategory> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpSchemaCategory>>();
  }
}
