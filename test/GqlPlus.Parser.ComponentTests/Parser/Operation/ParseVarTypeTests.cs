using GqlPlus.Parsing.Operation;

namespace GqlPlus.Parser.Operation;

public class ParseVarTypeTests(ComponentFixture<OperationParserTestServices> fixture)
  : IClassFixture<ComponentFixture<OperationParserTestServices>>
{
  private readonly IOneChecksParser<IParserVarType, string> checks
    = fixture.GetService<IOneChecksParser<IParserVarType, string>>();

  [Theory, RepeatData]
  public void WithMinimal_ReturnsCorrect(string varType)
    => checks.TrueExpected(varType, varType);

  [Theory, RepeatData]
  public void WithGraphQlNotNull_ReturnsCorrect(string varType)
    => checks.TrueExpected(varType + "!", varType + "!");

  [Theory, RepeatData]
  public void WithGraphQlList_ReturnsCorrect(string varType)
    => checks.TrueExpected($"[{varType}]", "[" + varType + "]");

  [Theory, RepeatData]
  public void WithGraphQlComplex_ReturnsCorrect(string varType)
    => checks.TrueExpected($"[[{varType}]!]!", "[[" + varType + "]!]!");

  [Fact]
  public void WithNoType_ReturnsFalse()
    => checks.FalseExpected("[]");

  [Fact]
  public void WithNoEnd_ReturnsFalse()
    => checks.FalseExpected("[test");
}
