using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseTypeParamsTests
  : ParserClassTestBase
{
  private readonly ParseTypeParams _parser;

  public ParseTypeParamsTests()
    => _parser = new ParseTypeParams();

  [Theory, RepeatData]
  public void Valid_WithConstraint_ShouldReturnCorrect(string paramName, string constraint)
  {
    // Arrange
    TakeReturns('<', true);
    PrefixReturns('$', OutStringAt(paramName), OutPass);
    TakeReturns(':', true);
    IdentifierReturns(OutString(constraint), OutFail);
    TakeReturns('>', false, true);

    // Act
    IResultArray<IGqlpTypeParam> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpTypeParam>>()
      .Required().ShouldHaveSingleItem()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(paramName),
        r => r.Constraint.ShouldBe(constraint));
  }

  [Theory, RepeatInlineData('^'), RepeatInlineData('_'), RepeatInlineData('*')]
  public void Valid_WithConstraintChar_ShouldReturnCorrect(char typeChar, string paramName)
  {
    // Arrange
    TakeReturns('<', true);
    PrefixReturns('$', OutStringAt(paramName), OutPass);
    TakeReturns(':', true);
    Tokenizer.TakeAny(out char charType, typeChar).ReturnsForAnyArgs(OutChar(typeChar), OutFail);
    TakeReturns('>', false, true);

    // Act
    IResultArray<IGqlpTypeParam> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpTypeParam>>()
      .Required().ShouldHaveSingleItem()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(paramName),
        r => r.Constraint.ShouldBe($"{typeChar}"));
  }

  [Theory, RepeatData]
  public void Valid_WithConstraintZero_ShouldReturnCorrect(string paramName)
  {
    // Arrange
    TakeReturns('<', true);
    PrefixReturns('$', OutStringAt(paramName), OutPass);
    TakeReturns(':', true);
    Tokenizer.TakeZero().Returns(true, false);
    TakeReturns('>', false, true);

    // Act
    IResultArray<IGqlpTypeParam> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpTypeParam>>()
      .Required().ShouldHaveSingleItem()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(paramName),
        r => r.Constraint.ShouldBe("0"));
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenNoTypeParams()
  {
    // Arrange
    TakeReturns('<', true);
    PrefixReturns('$', OutFail);
    SetupPartial<IGqlpTypeParam>();

    // Act
    IResultArray<IGqlpTypeParam> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpTypeParam>>();
  }
}

