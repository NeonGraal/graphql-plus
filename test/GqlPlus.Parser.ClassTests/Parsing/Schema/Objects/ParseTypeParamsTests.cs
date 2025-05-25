using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseTypeParamsTests
  : ParserClassTestBase
{
  private readonly ParseTypeParams _parser;

  public ParseTypeParamsTests()
    => _parser = new ParseTypeParams();

  [Theory, RepeatData]
  public void Parse_ShouldReturnTypeParams_WhenValid(string param1, string param2)
  {
    // Arrange
    TakeReturns('<', true);
    PrefixReturns('$', OutStringAt(param1), OutStringAt(param2), OutPass);
    TakeReturns('>', false, true);

    // Act
    IResultArray<IGqlpTypeParam> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpTypeParam>>()
      .Required().ShouldHaveSingleItem();
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

