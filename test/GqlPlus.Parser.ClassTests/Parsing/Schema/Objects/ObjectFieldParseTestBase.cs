using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public abstract class ObjectFieldParseTestBase<TField>
  : AliasesClassTestBase
  where TField : class, IGqlpObjField
{

  private readonly Parser<IGqlpObjBase>.I _parseBase;
  protected Parser<IGqlpObjBase>.D ParseBase { get; }
  protected abstract Parser<TField>.I Parser { get; }

  protected ObjectFieldParseTestBase()
    => ParseBase = ParserFor(out _parseBase);

  [Theory, RepeatData]
  public void Parse_ShouldReturnField_WhenValid(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true);
    ParseOk(_parseBase);

    // Act
    IResult<TField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<TField>>()
      .Required().Name.ShouldBe(fieldName);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnField_WhenValidWithAliases(string fieldName, string[] aliases)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true);
    ParseOk(_parseBase);
    ParseAliasesOk(aliases);

    // Act
    IResult<TField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<TField>>()
      .Required().Aliases.ShouldBe(aliases);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenAliasesError(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    ParseAliasesError();

    // Act
    IResult<TField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnField_WhenValidWithModifiers(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true);
    ParseOk(_parseBase);
    IGqlpModifier modifer = A.Modifier(ModifierKind.List);
    ParseModifiersOk(modifer);

    // Act
    IResult<TField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<TField>>()
      .Required().Modifiers.ShouldContain(modifer);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenModifiersError(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true);
    ParseOk(_parseBase);
    ParseModifiersError();

    // Act
    IResult<TField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<TField>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenNoFieldName()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<TField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenNoColon(string fieldName, string[] aliases)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName), OutString(fieldName));
    ParseAliasesOk(aliases);
    SetupPartial<TField>();

    // Act
    IResult<TField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<TField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnumField_WhenValidLabel(string fieldName, string[] aliases)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName), OutString(TestLabel));
    TakeReturns('=', true);
    ParseAliasesOk(aliases);

    // Act
    IResult<TField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<TField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnumField_WhenValidEnum(string fieldName, string[] aliases, string type)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName), OutString(type), OutString(TestLabel));
    TakeReturns('=', true);
    ParseAliasesOk(aliases);
    TakeReturns('.', true);

    // Act
    IResult<TField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<TField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenInvalidLabel(string fieldName, string[] aliases)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName), OutFail);
    TakeReturns('=', true);
    ParseAliasesOk(aliases);
    SetupPartial<TField>();

    // Act
    IResult<TField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<TField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenInvalidEnum(string fieldName, string[] aliases, string type)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName), OutString(type), OutFail);
    TakeReturns('=', true);
    ParseAliasesOk(aliases);
    TakeReturns('.', true);
    SetupPartial<TField>();

    // Act
    IResult<TField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<TField>>();
  }

  protected void ParseBaseOk()
    => ParseOk(_parseBase);
}
