using GqlPlus.Parsing.Operation;

namespace GqlPlus.Operation;

public class ParseVarTypeTests(
  IOneChecksParser<IParserVarType, string> checks
)
{
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
