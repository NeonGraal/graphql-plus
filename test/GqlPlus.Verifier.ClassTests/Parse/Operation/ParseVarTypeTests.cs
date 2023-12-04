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

  private readonly OneChecksParser<IParserVarType, string> Test;

  public ParseVarTypeTests(Parser<IParserVarType, string>.D parser)
    => Test = new(parser);
}
