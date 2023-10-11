using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseFragmentsTests
{
  [Theory]
  [RepeatInlineData(Repeats, "fragment ", " on ")]
  [RepeatInlineData(Repeats, "&", " on ")]
  [RepeatInlineData(Repeats, "fragment ", ":")]
  [RepeatInlineData(Repeats, "&", ":")]
  public void WithMinimum_ReturnsCorrectAst(string fragmentPrefix, string typePrefix, string fragment, string onType, string field)
    => Test.Expected(
      fragmentPrefix + fragment + typePrefix + onType + "{" + field + "}",
      new FragmentAst(fragment, onType, field.Fields()));

  [Theory, RepeatData(Repeats)]
  public void Directive_ReturnsCorrectAst(string fragment, string onType, string field, string directive)
    => Test.Expected(
      "&" + fragment + ":" + onType + "@" + directive + "{" + field + "}",
      new FragmentAst(fragment, onType, field.Fields()) { Directives = directive.Directives() });

  private static BaseArrayChecks<FragmentAst> Test => new((ref OperationParser parser)
    => parser.ParseFragments());
}
