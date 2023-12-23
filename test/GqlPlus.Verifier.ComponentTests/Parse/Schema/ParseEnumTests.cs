using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseEnumTests
  : BaseAliasedTests<EnumInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithNameBad_ReturnsFalse(decimal id, string value)
    => _test.False($"{id}{{{value}}}");

  [Theory, RepeatData(Repeats)]
  public void WithExtends_ReturnsCorrectAst(EnumInput input, string extends)
    => _test.TrueExpected(input.Type + "{:" + extends + " " + input.Value + "}",
      _test.AliasedFactory(input) with {
        Extends = extends,
      });

  [Theory, RepeatData(Repeats)]
  public void WithExtendsBad_ReturnsFalse(string name)
    => _test.False(name + "{:}");

  [Theory, RepeatData(Repeats)]
  public void WithEnumValues_ReturnsCorrectAst(string name, string[] values)
    => _test.TrueExpected(
      name + values.Bracket("{", "}").Joined(),
      new EnumDeclAst(AstNulls.At, name) {
        Values = values.EnumValues(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithEnumValuesBad_ReturnsFalse(string name, string[] values)
    => _test.False(name + "{" + string.Join("|", values) + "}",
      skipIf: values.Length < 2);

  [Theory, RepeatData(Repeats)]
  public void WithEnumValuesNone_ReturnsFalse(string name)
    => _test.False(name + "{}");

  internal override IBaseAliasedChecks<EnumInput> AliasChecks => _test;

  private readonly ParseEnumChecks _test;

  public ParseEnumTests(Parser<EnumDeclAst>.D parser)
    => _test = new(parser);
}
