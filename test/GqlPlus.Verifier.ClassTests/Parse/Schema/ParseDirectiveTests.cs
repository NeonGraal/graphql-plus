using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseDirectiveTests
  : BaseAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void WithNameBad_ReturnsFalse(decimal id)
    => Test.False($"@{id}{{operation}}");

  [Theory, RepeatData(Repeats)]
  public void WithRepeatable_ReturnsCorrectAst(string name)
    => Test.TrueExpected(
      "@" + name + "{(repeatable)operation}",
      new DirectiveAst(AstNulls.At, name) {
        Option = DirectiveOption.Repeatable,
        Locations = DirectiveLocation.Operation,
      });

  [Theory, RepeatData(Repeats)]
  public void WithOptionBad_ReturnsFalse(string name)
    => Test.False("@" + name + "{(repeatable operation}");

  [Theory, RepeatData(Repeats)]
  public void WithOptionNone_ReturnsFalse(string name)
    => Test.False("@" + name + "{()operation}");

  [Theory, RepeatData(Repeats)]
  public void WithParameter_ReturnsCorrectAst(string name, string parameter)
    => Test.TrueExpected(
      "@" + name + "(" + parameter + "){operation}",
      new DirectiveAst(AstNulls.At, name) {
        Parameter = new(AstNulls.At, parameter),
        Locations = DirectiveLocation.Operation,
      });

  [Theory, RepeatData(Repeats)]
  public void WithParameterBad_ReturnsFalse(string name, string parameter)
    => Test.False("@" + name + "(" + parameter + "{operation}");

  [Theory, RepeatData(Repeats)]
  public void WithParameterNone_ReturnsFalse(string name)
    => Test.False("@" + name + "(){operation}");

  [Theory, RepeatData(Repeats)]
  public void WithLocations_ReturnsCorrectAst(string name)
    => Test.TrueExpected(
      "@" + name + "{operation Field FRAGMENT}",
      new DirectiveAst(AstNulls.At, name) {
        Locations = DirectiveLocation.Operation | DirectiveLocation.Field | DirectiveLocation.Fragment,
      });

  [Theory, RepeatData(Repeats)]
  public void WithLocationsBad_ReturnsFalse(string name)
    => Test.False("@" + name + "{random}");

  [Theory, RepeatData(Repeats)]
  public void WithLocationsNone_ReturnsFalse(string name)
    => Test.False("@" + name + "{}");

  private static ParseDirectiveChecks Test => new();

  internal override IBaseAliasedChecks<string> AliasChecks => Test;

  //private ParseDirectiveChecks Test;

  //public ParseDirectiveTests(IParser<DirectiveAst> parser)
  //  => Test = new(parser);
}
