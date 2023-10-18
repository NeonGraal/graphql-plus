using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Common;

namespace GqlPlus.Verifier.Operation.Parsing;

public class ParseFragmentsTests
{
  [Theory, RepeatData(Repeats)]
  public void Start_WithMinimum_ReturnsCorrectAst(string fragment, string onType, string field)
    => TestStart.Expected(
      '&' + fragment + ':' + onType + "{" + field + "}",
      new FragmentAst(AstNulls.At, fragment, onType, field.Fields()));

  [Theory]
  [RepeatInlineData(Repeats, "fragment ", " on ")]
  [RepeatInlineData(Repeats, "&", " on ")]
  [RepeatInlineData(Repeats, "fragment ", ":")]
  [RepeatInlineData(Repeats, "&", ":")]
  public void End_WithMinimum_ReturnsCorrectAst(string fragmentPrefix, string typePrefix, string fragment, string onType, string field)
    => TestEnd.Expected(
      fragmentPrefix + fragment + typePrefix + onType + "{" + field + "}",
      new FragmentAst(AstNulls.At, fragment, onType, field.Fields()));

  [Theory, RepeatData(Repeats)]
  public void Start_WithDirective_ReturnsCorrectAst(string fragment, string onType, string field, string directive)
    => TestStart.Expected(
      "&" + fragment + ":" + onType + "@" + directive + "{" + field + "}",
      new FragmentAst(AstNulls.At, fragment, onType, field.Fields()) { Directives = directive.Directives() });

  [Theory]
  [RepeatInlineData(Repeats, "fragment ", " on ")]
  [RepeatInlineData(Repeats, "&", " on ")]
  [RepeatInlineData(Repeats, "fragment ", ":")]
  [RepeatInlineData(Repeats, "&", ":")]
  public void End_WithDirective_ReturnsCorrectAst(string fragmentPrefix, string typePrefix, string fragment, string onType, string field, string directive)
    => TestEnd.Expected(
      fragmentPrefix + fragment + typePrefix + onType + "@" + directive + "{" + field + "}",
      new FragmentAst(AstNulls.At, fragment, onType, field.Fields()) { Directives = directive.Directives() });

  private static BaseArrayChecks<OperationParser, FragmentAst> TestStart => new(
    tokens => new OperationParser(tokens),
    parser => parser.ParseFragStart());

  private static BaseArrayChecks<OperationParser, FragmentAst> TestEnd => new(
    tokens => new OperationParser(tokens),
    parser => parser.ParseFragEnd(Array.Empty<FragmentAst>()));
}
