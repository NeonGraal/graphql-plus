using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseSelectionTests
{
  [Theory, RepeatInlineData(Repeats, "..."), RepeatInlineData(Repeats, "|")]
  public void WithInline_ReturnsCorrectAst(string prefix, string field)
    => ParseSelectionTrueExpected(
      prefix + " {" + field + "}",
      new InlineAst(field.Fields()));

  [Theory]
  [RepeatInlineData(Repeats, "...", " on ")]
  [RepeatInlineData(Repeats, "|", " on ")]
  [RepeatInlineData(Repeats, "...", ":")]
  [RepeatInlineData(Repeats, "|", ":")]
  public void WithInlineType_ReturnsCorrectAst(string inlinePrefix, string typePrefix, string field, string inlineType)
    => ParseSelectionTrueExpected(
      inlinePrefix + typePrefix + inlineType + "{" + field + "}",
      new InlineAst(field.Fields()) { OnType = inlineType });

  [Theory, RepeatData(Repeats)]
  public void WithInlineDirective_ReturnsCorrectAst(string directive, string field)
    => ParseSelectionTrueExpected(
      "|@" + directive + "{" + field + "}",
      new InlineAst(field.Fields()) { Directives = directive.Directives() });

  [Theory, RepeatInlineData(Repeats, "..."), RepeatInlineData(Repeats, "|")]
  public void WithSpread_ReturnsCorrectAst(string prefix, string fragment)
    => ParseSelectionTrueExpected(
      prefix + fragment,
      new SpreadAst(fragment));

  [Theory, RepeatData(Repeats)]
  public void WithSpreadDirective_ReturnsCorrectAst(string fragment, string directive)
    => ParseSelectionTrueExpected(
      $"|{fragment}@{directive}",
      new SpreadAst(fragment) { Directives = directive.Directives() });

  private void ParseSelectionTrueExpected<T>(string input, T expected)
  {
    var parser = new OperationParser(Tokens(input));

    parser.ParseSelection(out AstSelection result).Should().BeTrue();

    result.Should().BeOfType<T>().Equals(expected);
  }
}
