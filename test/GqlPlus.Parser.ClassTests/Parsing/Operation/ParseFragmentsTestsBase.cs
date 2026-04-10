using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public abstract class ParseFragmentsTestsBase
  : ParserClassTestBase
{
  protected ParseFragmentsTestsBase()
  {
    SetupError<IAstFragment>();
    SetupPartial<IAstFragment>();
  }

  protected abstract Parser<IAstFragment>.IA Parser { get; }
  protected abstract Parser<IAstDirective>.IA DirectivesParser { get; }
  protected abstract Parser<IAstSelection>.IA ObjectParser { get; }

  [Theory, RepeatData]
  public void Parse_ShouldReturnFragmentsArray_WhenFragmentsAreParsed(string fragmentName, string onType)
  {
    // Arrange
    SetupFragmentPrefix(true);
    SetupTypePrefix(true);

    IdentifierReturns(OutString(fragmentName), OutString(onType));

    IAstDirective[] directives = ParseOkA(DirectivesParser);
    IAstSelection[] selections = ParseOkA(ObjectParser);

    // Act
    IResultArray<IAstFragment> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstFragment>>()
      .Required().ShouldSatisfyAllConditions(
        x => x.ShouldHaveSingleItem(),
        x => x.First().Identifier.ShouldBe(fragmentName),
        x => x.First().OnType.ShouldBe(onType),
        x => x.First().Directives.ShouldBe(directives),
        x => x.First().Selections.ShouldBe(selections)
      );
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenFragmentNameIsMissing()
  {
    // Arrange
    SetupFragmentPrefix(true);
    IdentifierReturns(OutFail);

    // Act
    IResultArray<IAstFragment> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayError<IAstFragment>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenTypePrefixIsMissing(string fragmentName)
  {
    // Arrange
    SetupFragmentPrefix(true);
    IdentifierReturns(OutString(fragmentName));
    SetupTypePrefix(false);

    // Act
    IResultArray<IAstFragment> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayError<IAstFragment>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialResult_WhenDirectivesParsingFails(string fragmentName, string onType)
  {
    // Arrange
    SetupFragmentPrefix(true);
    SetupTypePrefix(true);

    IdentifierReturns(OutString(fragmentName), OutString(onType));

    ParseErrorA(DirectivesParser);

    // Act
    IResultArray<IAstFragment> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IAstFragment>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoFragmentsAreParsed()
  {
    // Arrange
    SetupFragmentPrefix(false);

    // Act
    IResultArray<IAstFragment> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstFragment>>()
      .Required().ShouldBeEmpty();
  }

  protected abstract void SetupFragmentPrefix(bool value);
  protected abstract void SetupTypePrefix(bool value);
}
