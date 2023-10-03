using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseSelectionTests
{
  [Theory, RepeatInlineData(Repeats, "..."), RepeatInlineData(Repeats, "|")]
  public void WithInline_ReturnsCorrectAst(string prefix, string field)
  {
    var parser = new OperationParser(Tokens(prefix + " {" + field + "}"));
    var expected = new InlineAst(field.Fields());

    parser.ParseSelection(out AstSelection result).Should().BeTrue();

    result.Should().BeOfType<InlineAst>().Equals(expected);
  }

  [Theory]
  [RepeatInlineData(Repeats, "...", " on ")]
  [RepeatInlineData(Repeats, "|", " on ")]
  [RepeatInlineData(Repeats, "...", ":")]
  [RepeatInlineData(Repeats, "|", ":")]
  public void WithInlineType_ReturnsCorrectAst(string inlinePrefix, string typePrefix, string field, string inlineType)
  {
    var parser = new OperationParser(Tokens(inlinePrefix + typePrefix + inlineType + "{" + field + "}"));
    var expected = new InlineAst(field.Fields()) {
      OnType = inlineType
    };

    parser.ParseSelection(out AstSelection result).Should().BeTrue();

    result.Should().BeOfType<InlineAst>().Equals(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithInlineDirective_ReturnsCorrectAst(string directive, string field)
  {
    var parser = new OperationParser(Tokens("|@" + directive + "{" + field + "}"));
    var expected = new InlineAst(field.Fields()) { Directives = directive.Directives() };

    parser.ParseSelection(out AstSelection result).Should().BeTrue();

    result.Should().BeOfType<InlineAst>().Equals(expected);
  }

  [Theory, RepeatInlineData(Repeats, "..."), RepeatInlineData(Repeats, "|")]
  public void WithSpread_ReturnsCorrectAst(string prefix, string fragment)
  {
    var parser = new OperationParser(Tokens(prefix + fragment));
    var expected = new SpreadAst(fragment);

    parser.ParseSelection(out AstSelection result).Should().BeTrue();

    result.Should().BeOfType<SpreadAst>().Equals(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithSpreadDirective_ReturnsCorrectAst(string fragment, string directive)
  {
    var parser = new OperationParser(Tokens($"|{fragment}@{directive}"));
    var expected = new SpreadAst(fragment) { Directives = directive.Directives() };

    parser.ParseSelection(out AstSelection result).Should().BeTrue();

    result.Should().BeOfType<SpreadAst>().Equals(expected);
  }
}
