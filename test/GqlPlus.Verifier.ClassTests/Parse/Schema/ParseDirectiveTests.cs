﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseDirectiveTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name)
    => Test.TrueExpected(
      "@" + name + "=operation",
      new DirectiveAst(AstNulls.At, name) {
        Locations = DirectiveLocation.Operation,
      });

  [Theory, RepeatData(Repeats)]
  public void WithAliases_ReturnsCorrectAst(string name, string[] aliases)
    => Test.TrueExpected(
      "@" + name + aliases.Bracket("[", "]=operation").Joined(),
      new DirectiveAst(AstNulls.At, name) {
        Aliases = aliases,
        Locations = DirectiveLocation.Operation,
      });

  [Theory, RepeatData(Repeats)]
  public void WithRepeatable_ReturnsCorrectAst(string name)
    => Test.TrueExpected(
      "@" + name + "=(repeatable)operation",
      new DirectiveAst(AstNulls.At, name) {
        Option = DirectiveOption.Repeatable,
        Locations = DirectiveLocation.Operation,
      });

  [Theory, RepeatData(Repeats)]
  public void WithParameter_ReturnsCorrectAst(string name, string parameter)
    => Test.TrueExpected(
      "@" + name + "(" + parameter + ")=operation",
      new DirectiveAst(AstNulls.At, name) {
        Parameter = new(AstNulls.At, parameter),
        Locations = DirectiveLocation.Operation,
      });

  [Theory, RepeatData(Repeats)]
  public void WithLocations_ReturnsCorrectAst(string name)
    => Test.TrueExpected(
      "@" + name + "=operation|Field|FRAGMENT",
      new DirectiveAst(AstNulls.At, name) {
        Locations = DirectiveLocation.Operation | DirectiveLocation.Field | DirectiveLocation.Fragment,
      });

  private static OneChecks<SchemaParser, DirectiveAst> Test => new(
    tokens => new SchemaParser(tokens),
    (SchemaParser parser, out DirectiveAst result) => parser.ParseDirective(out result, ""));
}
