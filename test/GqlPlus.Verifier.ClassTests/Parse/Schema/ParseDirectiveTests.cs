using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseDirectiveTests
  : BaseAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void WithNameBad_ReturnsFalse(decimal id)
    => _test.False($"@{id}{{operation}}");

  [Theory, RepeatData(Repeats)]
  public void WithRepeatable_ReturnsCorrectAst(string name)
    => _test.TrueExpected(
      "@" + name + "{(repeatable)operation}",
      new DirectiveAst(AstNulls.At, name) {
        Option = DirectiveOption.Repeatable,
        Locations = DirectiveLocation.Operation,
      });

  [Theory, RepeatData(Repeats)]
  public void WithOptionBad_ReturnsFalse(string name)
    => _test.False("@" + name + "{(repeatable operation}");

  [Theory, RepeatData(Repeats)]
  public void WithOptionNone_ReturnsFalse(string name)
    => _test.False("@" + name + "{()operation}");

  [Theory, RepeatData(Repeats)]
  public void WithParameters_ReturnsCorrectAst(string name, string[] parameters)
    => _test.TrueExpected(
      "@" + name + "(" + parameters.Joined() + "){operation}",
      new DirectiveAst(AstNulls.At, name) {
        Parameters = parameters.Parameters(),
        Locations = DirectiveLocation.Operation,
      });

  [Theory, RepeatData(Repeats)]
  public void WithParameterBad_ReturnsFalse(string name, string parameter)
    => _test.False("@" + name + "(" + parameter + "{operation}");

  [Theory, RepeatData(Repeats)]
  public void WithParameterNone_ReturnsFalse(string name)
    => _test.False("@" + name + "(){operation}");

  [Theory, RepeatData(Repeats)]
  public void WithLocations_ReturnsCorrectAst(string name)
    => _test.TrueExpected(
      "@" + name + "{operation Field FRAGMENT}",
      new DirectiveAst(AstNulls.At, name) {
        Locations = DirectiveLocation.Operation | DirectiveLocation.Field | DirectiveLocation.Fragment,
      });

  [Theory, RepeatData(Repeats)]
  public void WithLocationsBad_ReturnsFalse(string name)
    => _test.False("@" + name + "{random}");

  [Theory, RepeatData(Repeats)]
  public void WithLocationsNone_ReturnsFalse(string name)
    => _test.False("@" + name + "{}");

  internal override IBaseAliasedChecks<string> AliasChecks => _test;

  private readonly ParseDirectiveChecks _test;

  public ParseDirectiveTests(IParser<DirectiveAst> parser)
    => _test = new(parser);
}
