namespace GqlPlus.Parsing;

public class ParseCollectionsTests
  : SubstituteBase
{
  private readonly ParseCollections _parseCollections = new();
  private readonly ITokenizer _tokenizer = For<ITokenizer>();

  [Fact]
  public void Parse_ShouldReturnEmptyArray_WhenNoModifiersProvided()
  {
    // Arrange
    _tokenizer.Take('[').Returns(false);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(_tokenizer, "testLabel");

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IGqlpModifier>>()
      .Required().ShouldBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnListModifier_WhenListModifierProvided()
  {
    // Arrange
    _tokenizer.Take('[').Returns(true, false);
    _tokenizer.Take(']').Returns(true);
    _tokenizer.At.Returns(AstNulls.At);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(_tokenizer, "testLabel");

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IGqlpModifier>>()
      .Required().ShouldHaveSingleItem()
      .ShouldBeOfType<ModifierAst>()
      .Kind.ShouldBe(ModifierKind.List);
  }

  [Fact]
  public void Parse_ShouldReturnDictModifier_WhenDictModifierProvided()
  {
    // Arrange
    _tokenizer.Take('[').Returns(true, false);
    _tokenizer.Identifier(out Arg.Any<string?>()).Returns(x => {
      x[0] = "string";
      return true;
    });
    _tokenizer.Take('?').Returns(true, false);
    _tokenizer.Take(']').Returns(true);
    _tokenizer.At.Returns(AstNulls.At);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(_tokenizer, "testLabel");

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IGqlpModifier>>()
      .Required().ShouldHaveSingleItem()
      .ShouldBeOfType<ModifierAst>()
      .ShouldSatisfyAllConditions(
        x => x.Kind.ShouldBe(ModifierKind.Dict),
        x => x.Key.ShouldBe("string"),
        x => x.IsOptional.ShouldBeTrue()
      );
  }

  [Fact]
  public void Parse_ShouldReturnParamModifier_WhenParamModifierProvided()
  {
    // Arrange
    _tokenizer.Take('[').Returns(true, false);
    _tokenizer.Take('$').Returns(true);
    _tokenizer.Identifier(out Arg.Any<string?>()).Returns(x => {
      x[0] = "paramName";
      return true;
    });
    _tokenizer.Take(']').Returns(true);
    _tokenizer.At.Returns(AstNulls.At);

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(_tokenizer, "testLabel");

    // Assert
    result.ShouldBeOfType<ResultArrayOk<IGqlpModifier>>()
      .Required().ShouldHaveSingleItem()
      .ShouldBeOfType<ModifierAst>()
      .ShouldSatisfyAllConditions(
        x => x.Kind.ShouldBe(ModifierKind.Param),
        x => x.Key.ShouldBe("paramName"),
        x => x.IsOptional.ShouldBeFalse()
      );
  }

  [Fact]
  public void Parse_ShouldReturnPartialArray_WhenInvalidTokenSequence()
  {
    // Arrange
    _tokenizer.Take('[').Returns(true);
    _tokenizer.Take('$').Returns(true);
    _tokenizer.Identifier(out Arg.Any<string?>()).Returns(false);
    _tokenizer.At.Returns(AstNulls.At);
    _tokenizer.PartialArray(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<Func<List<IGqlpModifier>>>())
        .Returns(Substitute.For<IResultArray<IGqlpModifier>>());

    // Act
    IResultArray<IGqlpModifier> result = _parseCollections.Parse(_tokenizer, "testLabel");

    // Assert
    result.ShouldNotBeNull();
    result.ShouldBeAssignableTo<IResultArray<IGqlpModifier>>();
  }
}
