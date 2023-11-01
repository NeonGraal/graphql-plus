namespace GqlPlus.Verifier.Parse.Operation;

public class ParseVarTypeTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimal_ReturnsCorrect(string varType)
    => Test.TrueExpected(varType, varType);

  [Theory, RepeatData(Repeats)]
  public void WithGraphQlNotNull_ReturnsCorrect(string varType)
    => Test.TrueExpected(varType + "!", varType + "!");

  [Theory, RepeatData(Repeats)]
  public void WithGraphQlList_ReturnsCorrect(string varType)
    => Test.TrueExpected($"[{varType}]", "[" + varType + "]");

  [Theory, RepeatData(Repeats)]
  public void WithGraphQlComplex_ReturnsCorrect(string varType)
    => Test.TrueExpected($"[[{varType}]!]!", "[[" + varType + "]!]!");

  [Fact]
  public void WithNoType_ReturnsFalse()
    => Test.False("[]");

  [Fact]
  public void WithNoEnd_ReturnsFalse()
    => Test.False("[test");

  private static OneChecks<OperationParser, string> Test => new(
    tokens => new OperationParser(tokens),
    (OperationParser parser, out string result) => parser.ParseVarType(out result));
}
