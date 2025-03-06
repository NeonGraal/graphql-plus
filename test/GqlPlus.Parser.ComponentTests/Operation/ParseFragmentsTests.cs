using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;
using GqlPlus.Parsing.Operation;

namespace GqlPlus.Operation;

public class ParseFragmentsTests(
  IManyChecksParser<IParserStartFragments, IGqlpFragment> startChecks,
  IManyChecksParser<IParserEndFragments, IGqlpFragment> endChecks
)
{
  [Theory, RepeatData(Repeats)]
  public void Start_WithMinimum_ReturnsCorrectAst(string fragment, string onType, string[] fields)
    => startChecks.TrueExpected(
      '&' + fragment + ':' + onType + "{" + fields.Joined() + "}",
      new FragmentAst(AstNulls.At, fragment, onType, fields.Fields()));

  [Theory, RepeatData(Repeats)]
  public void Start_WithNoName_ReturnsFalse(string onType, string[] fields)
    => startChecks.FalseExpected(
      "&:" + onType + "{" + fields.Joined() + "}");

  [Theory, RepeatData(Repeats)]
  public void Start_WithNoTypePrefix_ReturnsFalse(string fragment, string onType, string[] fields)
    => startChecks.FalseExpected(
      "&" + fragment + onType + "{" + fields.Joined() + "}");

  [Theory, RepeatData(Repeats)]
  public void Start_WithNoType_ReturnsFalse(string fragment, string[] fields)
    => startChecks.FalseExpected(
      "&" + fragment + ":{" + fields.Joined() + "}");

  [Theory, RepeatData(Repeats)]
  public void Start_WithNoFields_ReturnsFalse(string fragment, string onType)
    => startChecks.FalseExpected('&' + fragment + ':' + onType + "{}");

  [Theory]
  [RepeatInlineData(Repeats, "fragment ", " on ")]
  [RepeatInlineData(Repeats, "&", " on ")]
  [RepeatInlineData(Repeats, "fragment ", ":")]
  [RepeatInlineData(Repeats, "&", ":")]
  public void End_WithMinimum_ReturnsCorrectAst(string fragmentPrefix, string typePrefix, string fragment, string onType, string[] fields)
    => endChecks.TrueExpected(
      fragmentPrefix + fragment + typePrefix + onType + "{" + fields.Joined() + "}",
      new FragmentAst(AstNulls.At, fragment, onType, fields.Fields()));

  [Theory, RepeatData(Repeats)]
  public void Start_WithDirective_ReturnsCorrectAst(string fragment, string onType, string[] fields, string[] directives)
    => startChecks.TrueExpected(
      "&" + fragment + ":" + onType + directives.Joined(s => "@" + s) + "{" + fields.Joined() + "}",
      new FragmentAst(AstNulls.At, fragment, onType, fields.Fields()) { Directives = directives.Directives() });

  [Theory, RepeatData(Repeats)]
  public void Start_WithDirectiveBad_ReturnsFalse(string fragment, string onType, string[] fields)
    => startChecks.FalseExpected("&" + fragment + ":" + onType + "@{" + fields.Joined() + "}");

  [Theory]
  [RepeatInlineData(Repeats, "fragment ", " on ")]
  [RepeatInlineData(Repeats, "&", " on ")]
  [RepeatInlineData(Repeats, "fragment ", ":")]
  [RepeatInlineData(Repeats, "&", ":")]
  public void End_WithDirective_ReturnsCorrectAst(string fragmentPrefix, string typePrefix, string fragment, string onType, string[] fields, string[] directives)
    => endChecks.TrueExpected(
      fragmentPrefix + fragment + typePrefix + onType + directives.Joined(s => "@" + s) + "{" + fields.Joined() + "}",
      new FragmentAst(AstNulls.At, fragment, onType, fields.Fields()) { Directives = directives.Directives() });
}
