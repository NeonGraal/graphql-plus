using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Parser.Schema.Globals;

public sealed class ParseDirectiveTests(
  IBaseAliasedChecks<string, IAstSchemaDirective> checks
) : BaseAliasedTests<string, IAstSchemaDirective>(checks)
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
  public void WithParams_ReturnsCorrectAst(string name, string parameter)
    => checks.TrueExpected(
      "@" + name + "(" + parameter + "){operation}",
      new DirectiveDeclAst(AstNulls.At, name) {
        Parameter = parameter.Param(),
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
  IParserRepository parsers
) : BaseAliasedChecks<string, DirectiveDeclAst, IAstSchemaDirective>(parsers)
{
  protected internal override DirectiveDeclAst NamedFactory(string input)
    => new(AstNulls.At, input) { Locations = DirectiveLocation.Operation };

  protected internal override string AliasesString(string input, string aliases)
    => "@" + input + aliases + "{operation}";
}
