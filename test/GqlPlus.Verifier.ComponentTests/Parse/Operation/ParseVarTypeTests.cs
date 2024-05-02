namespace GqlPlus.Verifier.Parse.Operation;

public class ParseVarTypeTests(Parser<IParserVarType, string>.D parser)
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimal_ReturnsCorrect(string varType)
    => _checks.TrueExpected(varType, varType);

  [Theory, RepeatData(Repeats)]
  public void WithGraphQlNotNull_ReturnsCorrect(string varType)
    => _checks.TrueExpected(varType + "!", varType + "!");

  [Theory, RepeatData(Repeats)]
  public void WithGraphQlList_ReturnsCorrect(string varType)
    => _checks.TrueExpected($"[{varType}]", "[" + varType + "]");

  [Theory, RepeatData(Repeats)]
  public void WithGraphQlComplex_ReturnsCorrect(string varType)
    => _checks.TrueExpected($"[[{varType}]!]!", "[[" + varType + "]!]!");

  [Fact]
  public void WithNoType_ReturnsFalse()
    => _checks.False("[]");

  [Fact]
  public void WithNoEnd_ReturnsFalse()
    => _checks.False("[test");

  private readonly CheckOne<IParserVarType, string> _checks = new(parser);
}
