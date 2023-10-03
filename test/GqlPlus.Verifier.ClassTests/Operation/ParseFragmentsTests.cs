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
  {
    var parser = new OperationParser(Tokens(fragmentPrefix + fragment + typePrefix + onType + "{" + field + "}"));
    var expected = new FragmentAst(fragment, onType, field.Fields());

    FragmentAst[] result = parser.ParseFragments();

    result.Should().Equal(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Directive_ReturnsCorrectAst(string fragment, string onType, string field, string directive)
  {
    var parser = new OperationParser(Tokens("&" + fragment + ":" + onType + "@" + directive + "{" + field + "}"));
    var expected = new FragmentAst(fragment, onType, field.Fields()) { Directives = directive.Directives() };

    FragmentAst[] result = parser.ParseFragments();

    result.Should().Equal(expected);
  }
}
