using GqlPlus.Verifier.Ast.Schema.Globals;

namespace GqlPlus.Verifier.Parse.Schema.Globals;

public sealed class ParseDirectiveTests
  : TestAliased<string>
{
  [Theory, RepeatData(Repeats)]
  public void WithRepeatable_ReturnsCorrectAst(string name)
    => _checks.TrueExpected(
      "@" + name + "{(repeatable)operation}",
      new DirectiveDeclAst(AstNulls.At, name) {
        Option = DirectiveOption.Repeatable,
        Locations = DirectiveLocation.Operation,
      });

  [Theory, RepeatData(Repeats)]
  public void WithOptionBad_ReturnsFalse(string name)
    => _checks.False("@" + name + "{(repeatable operation}");

  [Theory, RepeatData(Repeats)]
  public void WithOptionNone_ReturnsFalse(string name)
    => _checks.False("@" + name + "{()operation}");

  [Theory, RepeatData(Repeats)]
  public void WithParameters_ReturnsCorrectAst(string name, string[] parameters)
    => _checks.TrueExpected(
      "@" + name + "(" + parameters.Joined() + "){operation}",
      new DirectiveDeclAst(AstNulls.At, name) {
        Parameters = parameters.Parameters(),
        Locations = DirectiveLocation.Operation,
      });

  [Theory, RepeatData(Repeats)]
  public void WithParameterBad_ReturnsFalse(string name, string parameter)
    => _checks.False("@" + name + "(" + parameter + "{operation}");

  [Theory, RepeatData(Repeats)]
  public void WithParameterNone_ReturnsFalse(string name)
    => _checks.False("@" + name + "(){operation}");

  [Theory, RepeatData(Repeats)]
  public void WithLocations_ReturnsCorrectAst(string name)
    => _checks.TrueExpected(
      "@" + name + "{operation Field FRAGMENT}",
      new DirectiveDeclAst(AstNulls.At, name) {
        Locations = DirectiveLocation.Operation | DirectiveLocation.Field | DirectiveLocation.Fragment,
      });

  [Theory, RepeatData(Repeats)]
  public void WithLocationsBad_ReturnsFalse(string name)
    => _checks.False("@" + name + "{random}");

  [Theory, RepeatData(Repeats)]
  public void WithLocationsNone_ReturnsFalse(string name)
    => _checks.False("@" + name + "{}");

  internal override ICheckAliased<string> AliasChecks => _checks;

  private readonly ParseDirectiveChecks _checks;

  public ParseDirectiveTests(Parser<DirectiveDeclAst>.D parser)
    => _checks = new(parser);
}

internal sealed class ParseDirectiveChecks(
  Parser<DirectiveDeclAst>.D parser
) : CheckAliased<string, DirectiveDeclAst>(parser)
{
  protected internal override DirectiveDeclAst NamedFactory(string input)
    => new(AstNulls.At, input) { Locations = DirectiveLocation.Operation };

  protected internal override string AliasesString(string input, string aliases)
    => "@" + input + aliases + "{operation}";
}
