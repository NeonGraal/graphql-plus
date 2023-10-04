using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseFieldTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string field)
  {
    var parser = new OperationParser(Tokens(field));
    var expected = new FieldAst(field);

    parser.ParseField(out AstSelection result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithAlias_ReturnsCorrectAst(string field, string alias)
  {
    var parser = new OperationParser(Tokens(alias + ":" + field));
    var expected = new FieldAst(field) { Alias = alias };

    parser.ParseField(out AstSelection result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithArgument_ReturnsCorrectAst(string field, string argument)
  {
    var parser = new OperationParser(Tokens(field + $"(${argument})"));
    var expected = new FieldAst(field) { Argument = new(argument) };

    parser.ParseField(out AstSelection result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithModifiers_ReturnsCorrectAst(string field)
  {
    var parser = new OperationParser(Tokens(field + "[]?"));
    var expected = new FieldAst(field) { Modifiers = TestMods() };

    parser.ParseField(out AstSelection result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithDirectives_ReturnsCorrectAst(string field, string directive)
  {
    var parser = new OperationParser(Tokens(field + "@" + directive));
    var expected = new FieldAst(field) { Directives = directive.Directives() };

    parser.ParseField(out AstSelection result).Should().BeTrue();

    result.Should().Be(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithSelection_ReturnsCorrectAst(string field, string selection)
  {
    var parser = new OperationParser(Tokens(field + "{" + selection + "}"));
    var expected = new FieldAst(field) { Selections = selection.Fields() };

    parser.ParseField(out AstSelection result).Should().BeTrue();

    result.Should().Be(expected);
  }
}
