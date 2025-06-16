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

  [Theory, RepeatData]
  public void Parse_ShouldReturnDictModifier_WhenDictModifierProvided(string value)
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
  public void Parse_ShouldReturnParamModifier_WhenParamModifierProvided(string paramName)
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
}
