using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Parsing;

namespace GqlPlus.Schema.Globals;

public sealed class ParseDirectiveTests(
  IBaseAliasedChecks<string, IGqlpSchemaDirective> checks
) : BaseAliasedTests<string, IGqlpSchemaDirective>(checks)
{
  [Theory, RepeatData]
  public void WithRepeatable_ReturnsCorrectAst(string name)
    => checks.TrueExpected(
      "@" + name + "{(repeatable)operation}",
      new DirectiveDeclAst(AstNulls.At, name) {
        Option = DirectiveOption.Repeatable,
        Locations = DirectiveLocation.Operation,
      });

  [Theory, RepeatData]
  public void WithOptionBad_ReturnsFalse(string name)
    => checks.FalseExpected("@" + name + "{(repeatable operation}");

  [Theory, RepeatData]
  public void WithOptionNone_ReturnsFalse(string name)
    => checks.FalseExpected("@" + name + "{()operation}");

  [Theory, RepeatData]
  public void WithParams_ReturnsCorrectAst(string name, string[] parameters)
    => checks.TrueExpected(
      "@" + name + "(" + parameters.Joined() + "){operation}",
      new DirectiveDeclAst(AstNulls.At, name) {
        Params = parameters.Params(),
        Locations = DirectiveLocation.Operation,
      });

  [Theory, RepeatData]
  public void WithParamBad_ReturnsFalse(string name, string parameter)
    => checks.FalseExpected("@" + name + "(" + parameter + "{operation}");

  [Theory, RepeatData]
  public void WithParamNone_ReturnsFalse(string name)
    => checks.FalseExpected("@" + name + "(){operation}");

  [Theory, RepeatData]
  public void WithLocations_ReturnsCorrectAst(string name)
    => checks.TrueExpected(
      "@" + name + "{operation Field FRAGMENT}",
      new DirectiveDeclAst(AstNulls.At, name) {
        Locations = DirectiveLocation.Operation | DirectiveLocation.Field | DirectiveLocation.Fragment,
      });

  [Theory, RepeatData]
  public void WithLocationsBad_ReturnsFalse(string name)
    => checks.FalseExpected("@" + name + "{random}");

  [Theory, RepeatData]
  public void WithLocationsNone_ReturnsFalse(string name)
    => checks.FalseExpected("@" + name + "{}");
}

internal sealed class ParseDirectiveChecks(
  Parser<IGqlpSchemaDirective>.D parser
) : BaseAliasedChecks<string, DirectiveDeclAst, IGqlpSchemaDirective>(parser)
{
  protected internal override DirectiveDeclAst NamedFactory(string input)
    => new(AstNulls.At, input) { Locations = DirectiveLocation.Operation };

  protected internal override string AliasesString(string input, string aliases)
    => "@" + input + aliases + "{operation}";
}
