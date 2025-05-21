using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public abstract class ParseFragmentsTestsBase
  : ParserClassTestBase
{
  protected ParseFragmentsTestsBase()
  {
    SetupError<IGqlpFragment>();
    SetupPartial<IGqlpFragment>();
  }

  protected abstract Parser<IGqlpFragment>.IA Parser { get; }
  protected abstract Parser<IGqlpDirective>.IA DirectivesParser { get; }
  protected abstract Parser<IGqlpSelection>.IA ObjectParser { get; }

  [Theory, RepeatData]
  public void Parse_ShouldReturnFragmentsArray_WhenFragmentsAreParsed(string fragmentName, string onType)
  {
    // Arrange
    SetupFragmentPrefix(true);
    SetupTypePrefix(true);

    IdentifierReturns(OutString(fragmentName), OutString(onType));

    IGqlpDirective[] directives = ParseOkA(DirectivesParser);
    IGqlpSelection[] selections = ParseOkA(ObjectParser);

    // Act
    IResultArray<IGqlpFragment> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpFragment>>()
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
    IResultArray<IGqlpFragment> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayError<IGqlpFragment>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenTypePrefixIsMissing(string fragmentName)
  {
    // Arrange
    SetupFragmentPrefix(true);
    IdentifierReturns(OutString(fragmentName));
    SetupTypePrefix(false);

    // Act
    IResultArray<IGqlpFragment> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayError<IGqlpFragment>>();
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
    IResultArray<IGqlpFragment> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpFragment>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoFragmentsAreParsed()
  {
    // Arrange
    SetupFragmentPrefix(false);

    // Act
    IResultArray<IGqlpFragment> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpFragment>>()
      .Required().ShouldBeEmpty();
  }

  protected abstract void SetupFragmentPrefix(bool value);
  protected abstract void SetupTypePrefix(bool value);
}
