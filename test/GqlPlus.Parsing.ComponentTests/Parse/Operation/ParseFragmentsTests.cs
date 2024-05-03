using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Parse.Operation;

public class ParseFragmentsTests(
  ParserArray<IParserStartFragments, IGqlpFragment>.DA startParser,
  ParserArray<IParserEndFragments, IGqlpFragment>.DA endParser)
{
  [Theory, RepeatData(Repeats)]
  public void Start_WithMinimum_ReturnsCorrectAst(string fragment, string onType, string[] fields)
    => _startChecks.TrueExpected(
      '&' + fragment + ':' + onType + "{" + fields.Joined() + "}",
      new FragmentAst(AstNulls.At, fragment, onType, fields.Fields()));

  [Theory, RepeatData(Repeats)]
  public void Start_WithNoName_ReturnsFalse(string onType, string[] fields)
    => _startChecks.False(
      "&:" + onType + "{" + fields.Joined() + "}");

  [Theory, RepeatData(Repeats)]
  public void Start_WithNoTypePrefix_ReturnsFalse(string fragment, string onType, string[] fields)
    => _startChecks.False(
      "&" + fragment + onType + "{" + fields.Joined() + "}");

  [Theory, RepeatData(Repeats)]
  public void Start_WithNoType_ReturnsFalse(string fragment, string[] fields)
    => _startChecks.False(
      "&" + fragment + ":{" + fields.Joined() + "}");

  [Theory, RepeatData(Repeats)]
  public void Start_WithNoFields_ReturnsFalse(string fragment, string onType)
    => _startChecks.False('&' + fragment + ':' + onType + "{}");

  [Theory]
  [RepeatInlineData(Repeats, "fragment ", " on ")]
  [RepeatInlineData(Repeats, "&", " on ")]
  [RepeatInlineData(Repeats, "fragment ", ":")]
  [RepeatInlineData(Repeats, "&", ":")]
  public void End_WithMinimum_ReturnsCorrectAst(string fragmentPrefix, string typePrefix, string fragment, string onType, string[] fields)
    => _endChecks.TrueExpected(
      fragmentPrefix + fragment + typePrefix + onType + "{" + fields.Joined() + "}",
      new FragmentAst(AstNulls.At, fragment, onType, fields.Fields()));

  [Theory, RepeatData(Repeats)]
  public void Start_WithDirective_ReturnsCorrectAst(string fragment, string onType, string[] fields, string[] directives)
    => _startChecks.TrueExpected(
      "&" + fragment + ":" + onType + directives.Joined(s => "@" + s) + "{" + fields.Joined() + "}",
      new FragmentAst(AstNulls.At, fragment, onType, fields.Fields()) { Directives = directives.Directives() });

  [Theory, RepeatData(Repeats)]
  public void Start_WithDirectiveBad_ReturnsFalse(string fragment, string onType, string[] fields)
    => _startChecks.False("&" + fragment + ":" + onType + "@{" + fields.Joined() + "}");

  [Theory]
  [RepeatInlineData(Repeats, "fragment ", " on ")]
  [RepeatInlineData(Repeats, "&", " on ")]
  [RepeatInlineData(Repeats, "fragment ", ":")]
  [RepeatInlineData(Repeats, "&", ":")]
  public void End_WithDirective_ReturnsCorrectAst(string fragmentPrefix, string typePrefix, string fragment, string onType, string[] fields, string[] directives)
    => _endChecks.TrueExpected(
      fragmentPrefix + fragment + typePrefix + onType + directives.Joined(s => "@" + s) + "{" + fields.Joined() + "}",
      new FragmentAst(AstNulls.At, fragment, onType, fields.Fields()) { Directives = directives.Directives() });

  private readonly ManyChecksParser<IParserStartFragments, IGqlpFragment> _startChecks = new(startParser);
  private readonly ManyChecksParser<IParserEndFragments, IGqlpFragment> _endChecks = new(endParser);
}
