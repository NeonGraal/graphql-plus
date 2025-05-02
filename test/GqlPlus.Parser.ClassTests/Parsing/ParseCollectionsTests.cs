namespace GqlPlus.Parsing;

public class ParseCollectionsTests
  : ParserClassTestBase
{
  private readonly ParseCollections _parseCollections = new();

  [Fact]
  public void Parse_ShouldReturnEmptyArray_WhenNoModifiersProvided()
  {
    // Arrange
    Tokenizer.Take('[').Returns(false);

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
    Tokenizer.Take('[').Returns(true, false);
    Tokenizer.Take(']').Returns(true);
    Tokenizer.At.Returns(AstNulls.At);

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
    Tokenizer.Take('[').Returns(true, false);
    Tokenizer.Identifier(out string? contents).Returns(OutString(value));
    Tokenizer.Take('?').Returns(true, false);
    Tokenizer.Take(']').Returns(true);
    Tokenizer.At.Returns(AstNulls.At);

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
    Tokenizer.Take('[').Returns(true, false);
    Tokenizer.Take('$').Returns(true);
    Tokenizer.Identifier(out string? _).Returns(OutString(paramName));
    Tokenizer.Take(']').Returns(true);
    Tokenizer.At.Returns(AstNulls.At);

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
    Tokenizer.Take('[').Returns(true);
    Tokenizer.Take('$').Returns(true);
    Tokenizer.Identifier(out string? _).Returns(false);
    Tokenizer.At.Returns(AstNulls.At);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArray<IGqlpModifier>>();
  }
}
