namespace GqlPlus.Parsing;

public class ParseCollectionsTests
  : ParserClassTestBase
{
  private readonly ParseCollections _parseCollections = new();

  [Theory, RepeatData]
  public void Parse_ShouldReturnEmptyArray_WhenNoModifiersProvided(string label)
  {
    // Arrange
    TakeReturns('[', false);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IGqlpModifier>>()
      .Required().ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnListModifier_WhenListModifierProvided(string label)
  {
    // Arrange
    TakeReturns('[', true);
    TakeReturns(']', true);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IGqlpModifier>>()
      .Required().ShouldHaveSingleItem()
      .ShouldBeOfType<ModifierAst>()
      .Kind.ShouldBe(ModifierKind.List);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDictModifier_WhenZeroKeyProvided(string label)
  {
    // Arrange
    TakeReturns('[', true);
    Tokenizer.TakeZero().Returns(true);
    TakeReturns(']', true);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, label);

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

  [Theory, InlineData('^', "testLabel"), InlineData('_', "testLabel"), InlineData('*', "testLabel")]
  public void Parse_ShouldReturnDictModifier_WhenCharKeyProvided(char key, string label)
  {
    // Arrange
    TakeReturns('[', true);
    TakeAnyReturns(OutChar(key));
    TakeReturns(']', true);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, label);

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
  public void Parse_ShouldReturnDictModifier_WhenKeyProvided(string value, string label)
  {
    // Arrange
    TakeReturns('[', true);
    IdentifierReturns(OutString(value));
    TakeReturns('?', true);
    TakeReturns(']', true);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, label);

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
  public void Parse_ShouldReturnParamModifier_WhenParamKeyProvided(string paramName, string label)
  {
    // Arrange
    TakeReturns('[', true);
    TakeReturns('$', true);
    IdentifierReturns(OutString(paramName));
    TakeReturns(']', true);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, label);

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

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialArray_WhenInvalidTokenSequence(string label)
  {
    // Arrange
    TakeReturns('[', true);
    TakeReturns('$', true);
    IdentifierReturns(OutFail);
    SetupPartial<IGqlpModifier>();

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IGqlpModifier>>()
      .Result.ShouldHaveSingleItem();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartialArray_WhenNoEndBracket(string label)
  {
    // Arrange
    TakeReturns('[', true);
    SetupPartial<IGqlpModifier>();

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeOfType<ResultArrayPartial<IGqlpModifier>>();
  }
}
