﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseCategoryTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string output)
    => Test.TrueExpected(
      "=" + output,
      new CategoryAst(AstNulls.At, output));

  [Theory, RepeatData(Repeats)]
  public void WithOption_ReturnsCorrectAst(string output, CategoryOption option)
    => Test.TrueExpected(
      "=(" + option.ToString().ToLowerInvariant() + ")" + output,
      new CategoryAst(AstNulls.At, output) { Option = option });

  [Theory, RepeatData(Repeats)]
  public void WithAliases_ReturnsCorrectAst(string output, string alias1, string alias2)
    => Test.TrueExpected(
      "[" + alias1 + " " + alias2 + " ]=" + output,
      new CategoryAst(AstNulls.At, output) { Aliases = new[] { alias1, alias2 } });

  [Theory, RepeatData(Repeats)]
  public void WithName_ReturnsCorrectAst(string output, string name)
    => Test.TrueExpected(
      name + "=" + output,
      new CategoryAst(AstNulls.At, name, output));

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string name, string output, CategoryOption option, string alias1, string alias2)
    => Test.TrueExpected(
      name + "[" + alias1 + " " + alias2 + "]=(" + option.ToString().ToLowerInvariant() + ")" + output,
      new CategoryAst(AstNulls.At, name, output) {
        Option = option,
        Aliases = new[] { alias1, alias2 },
      });

  private static OneChecks<SchemaParser, CategoryAst> Test => new(
    tokens => new SchemaParser(tokens),
    (SchemaParser parser, out CategoryAst result) => parser.ParseCategory(out result, ""));
}
