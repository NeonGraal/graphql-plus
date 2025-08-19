using Newtonsoft.Json.Linq;

namespace GqlPlus.Parsing;

public class ParseCollectionsTests
  : ParserClassTestBase
{
  private readonly ParseCollections _parseCollections = new();

  [Fact]
  public void Parse_ShouldReturnEmptyArray_WhenNoModifiersProvided()
  {
    // Arrange
    TakeReturns('[', false);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IGqlpModifier>>()
      .Required().ShouldBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnListModifier_WhenListModifierProvided()
  {
    // Arrange
    TakeReturns('[', true);
    TakeReturns(']', true);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IGqlpModifier>>()
      .Required().ShouldHaveSingleItem()
      .ShouldBeOfType<ModifierAst>()
      .Kind.ShouldBe(ModifierKind.List);
  }

  [Fact]
  public void Parse_ShouldReturnDictModifier_WhenZeroKeyProvided()
  {
    // Arrange
    TakeReturns('[', true);
    Tokenizer.TakeZero().Returns(true);
    TakeReturns(']', true);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IGqlpModifier>>()
      .Required().ShouldHaveSingleItem()
      .ShouldBeOfType<ModifierAst>()
      .ShouldSatisfyAllConditions(
        x => x.Kind.ShouldBe(ModifierKind.Dict),
        x => x.Key.ShouldBe("0"),
        x => x.IsOptional.ShouldBeFalse()
      );
  }

  [Theory, InlineData('^'), InlineData('_'), InlineData('*')]
  public void Parse_ShouldReturnDictModifier_WhenCharKeyProvided(char key)
  {
    // Arrange
    TakeReturns('[', true);
    TakeAnyReturns(OutChar(key));
    TakeReturns(']', true);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IGqlpModifier>>()
      .Required().ShouldHaveSingleItem()
      .ShouldBeOfType<ModifierAst>()
      .ShouldSatisfyAllConditions(
        x => x.Kind.ShouldBe(ModifierKind.Dict),
        x => x.Key.ShouldBe($"{key}"),
        x => x.IsOptional.ShouldBeFalse()
      );
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDictModifier_WhenKeyProvided(string value)
  {
    // Arrange
    TakeReturns('[', true);
    IdentifierReturns(OutString(value));
    TakeReturns('?', true);
    TakeReturns(']', true);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpModifier>>()
      .Required().ShouldHaveSingleItem()
      .ShouldBeOfType<ModifierAst>()
      .ShouldSatisfyAllConditions(
        x => x.Kind.ShouldBe(ModifierKind.Dict),
        x => x.Key.ShouldBe(value),
        x => x.IsOptional.ShouldBeTrue()
      );
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnParamModifier_WhenParamKeyProvided(string paramName)
  {
    // Arrange
    TakeReturns('[', true);
    TakeReturns('$', true);
    IdentifierReturns(OutString(paramName));
    TakeReturns(']', true);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IGqlpModifier>>()
      .Required().ShouldHaveSingleItem()
      .ShouldBeOfType<ModifierAst>()
      .ShouldSatisfyAllConditions(
        x => x.Kind.ShouldBe(ModifierKind.Param),
        x => x.Key.ShouldBe(paramName),
        x => x.IsOptional.ShouldBeFalse()
      );
  }

  [Fact]
  public void Parse_ShouldReturnPartialArray_WhenInvalidTokenSequence()
  {
    // Arrange
    TakeReturns('[', true);
    TakeReturns('$', true);
    IdentifierReturns(OutFail);
    SetupPartial<IGqlpModifier>();

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpModifier>>()
      .Result.ShouldHaveSingleItem();
  }

  [Fact]
  public void Parse_ShouldReturnPartialArray_WhenNoEndBracket()
  {
    // Arrange
    TakeReturns('[', true);
    SetupPartial<IGqlpModifier>();

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeOfType<ResultArrayPartial<IGqlpModifier>>();
  }
}
