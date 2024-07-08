﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Parsing.Schema.Globals;

public sealed class ParseDirectiveTests
  : BaseAliasedTests<string>
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
    => _checks.FalseExpected("@" + name + "{(repeatable operation}");

  [Theory, RepeatData(Repeats)]
  public void WithOptionNone_ReturnsFalse(string name)
    => _checks.FalseExpected("@" + name + "{()operation}");

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
    => _checks.FalseExpected("@" + name + "(" + parameter + "{operation}");

  [Theory, RepeatData(Repeats)]
  public void WithParameterNone_ReturnsFalse(string name)
    => _checks.FalseExpected("@" + name + "(){operation}");

  [Theory, RepeatData(Repeats)]
  public void WithLocations_ReturnsCorrectAst(string name)
    => _checks.TrueExpected(
      "@" + name + "{operation Field FRAGMENT}",
      new DirectiveDeclAst(AstNulls.At, name) {
        Locations = DirectiveLocation.Operation | DirectiveLocation.Field | DirectiveLocation.Fragment,
      });

  [Theory, RepeatData(Repeats)]
  public void WithLocationsBad_ReturnsFalse(string name)
    => _checks.FalseExpected("@" + name + "{random}");

  [Theory, RepeatData(Repeats)]
  public void WithLocationsNone_ReturnsFalse(string name)
    => _checks.FalseExpected("@" + name + "{}");

  internal override IBaseAliasedChecks<string> AliasChecks => _checks;

  private readonly ParseDirectiveChecks _checks;

  public ParseDirectiveTests(Parser<IGqlpSchemaDirective>.D parser)
    => _checks = new(parser);
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
