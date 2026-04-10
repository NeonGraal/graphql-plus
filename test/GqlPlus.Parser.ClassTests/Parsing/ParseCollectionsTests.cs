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
    IResultArray<IAstModifier> result = _parseCollections.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IAstModifier>>()
      .Required().ShouldBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnListModifier_WhenListModifierProvided()
  {
    // Arrange
    TakeReturns('[', true);
    TakeReturns(']', true);

    // Act
    IResultArray<IAstModifier> result = _parseCollections.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IAstModifier>>()
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
    IResultArray<IAstModifier> result = _parseCollections.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IAstModifier>>()
      .Required().ShouldHaveSingleItem()
      .ShouldBeOfType<ModifierAst>()
      .ShouldSatisfyAllConditions(
        x => x.Kind.ShouldBe(ModifierKind.Dict),
        x => x.Key.ShouldBe("0"),
        x => x.IsOptional.ShouldBeFalse()
      );
  }

  [Theory]
  [RepeatInlineData('^')]
  [RepeatInlineData('_')]
  [RepeatInlineData('*')]
  public void Parse_ShouldReturnDictModifier_WhenCharKeyProvided(char key)
  {
    // Arrange
    TakeReturns('[', true);
    TakeAnyReturns(OutChar(key));
    TakeReturns(']', true);

    // Act
    IResultArray<IAstModifier> result = _parseCollections.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IAstModifier>>()
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
    IResultArray<IAstModifier> result = _parseCollections.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstModifier>>()
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
    IResultArray<IAstModifier> result = _parseCollections.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IAstModifier>>()
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
    SetupPartial<IAstModifier>();

    // Act
    IResultArray<IAstModifier> result = _parseCollections.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<IAstModifier>>()
      .Result.ShouldHaveSingleItem();
  }

  [Fact]
  public void Parse_ShouldReturnPartialArray_WhenNoEndBracket()
  {
    // Arrange
    TakeReturns('[', true);
    SetupPartial<IAstModifier>();

    // Act
    IResultArray<IAstModifier> result = _parseCollections.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeOfType<ResultArrayPartial<IAstModifier>>();
  }
}
