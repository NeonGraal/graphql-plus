namespace GqlPlus.Verifier.Parse.Operation;

public class ParseVarTypeTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimal_ReturnsCorrect(string varType)
    => _test.TrueExpected(varType, varType);

  [Theory, RepeatData(Repeats)]
  public void WithGraphQlNotNull_ReturnsCorrect(string varType)
    => _test.TrueExpected(varType + "!", varType + "!");

  [Theory, RepeatData(Repeats)]
  public void WithGraphQlList_ReturnsCorrect(string varType)
    => _test.TrueExpected($"[{varType}]", "[" + varType + "]");

  [Theory, RepeatData(Repeats)]
  public void WithGraphQlComplex_ReturnsCorrect(string varType)
    => _test.TrueExpected($"[[{varType}]!]!", "[[" + varType + "]!]!");

  [Fact]
  public void WithNoType_ReturnsFalse()
    => _test.False("[]");

  [Fact]
  public void WithNoEnd_ReturnsFalse()
    => _test.False("[test");

  private readonly OneChecksParser<IParserVarType, string> _test;

  public ParseVarTypeTests(Parser<IParserVarType, string>.D parser)
    => _test = new(parser);
}
