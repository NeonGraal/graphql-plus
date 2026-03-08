using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualTests
  : DeclarationClassTestBase
{

  private readonly Parser<IGqlpTypeParam>.IA _param;
  private readonly Parser<ObjectDefinition<IGqlpDualField>>.I _definition;
  private readonly ObjectParser<IGqlpDualField> _parser;

  public ParseDualTests()
  {
    ConfigureRepoArray<IGqlpTypeParam>(Parsers, out _param);
    ConfigureRepo<ObjectDefinition<IGqlpDualField>>(Parsers, out _definition);
    _parser = new ObjectParser<IGqlpDualField>(TypeKind.Dual, Parsers);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDualObject_WhenValid(string dualName)
  {
    // Arrange
    NameReturns(dualName);
    ParseOk(_definition, new ObjectDefinition<IGqlpDualField>());

    // Act
    IResult<IGqlpObject<IGqlpDualField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpObject<IGqlpDualField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    Tokenizer.Identifier(out _).Returns(false);
    SetupError<IGqlpObject<IGqlpDualField>>();

    // Act
    IResult<IGqlpObject<IGqlpDualField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
