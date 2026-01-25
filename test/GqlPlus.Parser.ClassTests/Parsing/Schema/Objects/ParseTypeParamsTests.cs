using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseTypeParamsTests
  : ParserClassTestBase
{
  private readonly ParseTypeParams _parser;

  public ParseTypeParamsTests()
  {
    _parser = new ParseTypeParams();

    SetupPartial<IGqlpTypeParam>();
  }

  [Theory, RepeatData]
  public void Parse_WithConstraint_ShouldReturnCorrect(string paramName, string constraint, string label)
  {
    // Arrange
    TakeReturns('<', true);
    PrefixReturns('$', OutStringAt(paramName), OutPass);
    TakeReturns(':', true);
    IdentifierReturns(OutString(constraint));
    TakeReturns('>', false, true);

    // Act
    IResultArray<IGqlpTypeParam> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpTypeParam>>()
      .Required().ShouldHaveSingleItem()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(paramName),
        r => r.Constraint.ShouldBe(constraint));
  }

  [Theory]
  [RepeatInlineData('^')]
  [RepeatInlineData('_')]
  [RepeatInlineData('*')]
  public void Parse_WithConstraintChar_ShouldReturnCorrect(char typeChar, string paramName, string label)
  {
    // Arrange
    TakeReturns('<', true);
    PrefixReturns('$', OutStringAt(paramName), OutPass);
    TakeReturns(':', true);
    TakeAnyReturns(OutChar(typeChar));
    TakeReturns('>', false, true);

    // Act
    IResultArray<IGqlpTypeParam> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpTypeParam>>()
      .Required().ShouldHaveSingleItem()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(paramName),
        r => r.Constraint.ShouldBe($"{typeChar}"));
  }

  [Theory, RepeatData]
  public void Parse_WithConstraintZero_ShouldReturnCorrect(string paramName, string label)
  {
    // Arrange
    TakeReturns('<', true);
    PrefixReturns('$', OutStringAt(paramName), OutPass);
    TakeReturns(':', true);
    Tokenizer.TakeZero().Returns(true, false);
    TakeReturns('>', false, true);

    // Act
    IResultArray<IGqlpTypeParam> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpTypeParam>>()
      .Required().ShouldHaveSingleItem()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(paramName),
        r => r.Constraint.ShouldBe("0"));
  }

  [Theory, RepeatData]
  public void Parse_WithMissingConstraintType_ShouldReturnPartial(string paramName, string label)
  {
    // Arrange
    TakeReturns('<', true);
    PrefixReturns('$', OutStringAt(paramName), OutPass);
    TakeReturns(':', true);
    TakeReturns('>', false, true);

    // Act
    IResultArray<IGqlpTypeParam> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpTypeParam>>()
      .Optional().ShouldHaveSingleItem()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(paramName),
        r => r.Constraint.ShouldBe(""));
  }

  [Theory, RepeatData]
  public void Parse_WithMissingConstraint_ShouldReturnPartial(string paramName, string label)
  {
    // Arrange
    TakeReturns('<', true);
    PrefixReturns('$', OutStringAt(paramName), OutPass);
    TakeReturns('>', false, true);

    // Act
    IResultArray<IGqlpTypeParam> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpTypeParam>>()
      .Optional().ShouldHaveSingleItem()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(paramName),
        r => r.Constraint.ShouldBe(""));
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenNoTypeParams(string label)
  {
    // Arrange
    TakeReturns('<', true);
    PrefixReturns('$', OutFail);

    // Act
    IResultArray<IGqlpTypeParam> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpTypeParam>>();
  }
}
