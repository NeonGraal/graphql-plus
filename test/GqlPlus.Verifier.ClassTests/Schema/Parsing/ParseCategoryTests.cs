using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Common;

namespace GqlPlus.Verifier.Schema.Parsing;

public class ParseCategoryTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string category)
    => Test.TrueExpected(
      "category " + category,
      new CategoryAst(AstNulls.At, category));

  [Theory, RepeatData(Repeats)]
  public void WithOption_ReturnsCorrectAst(string category, CategoryOption option)
    => Test.TrueExpected(
      "category " + category + " (" + option.ToString().ToLowerInvariant() + ")",
      new CategoryAst(AstNulls.At, category) { Option = option });

  [Theory, RepeatData(Repeats)]
  public void WithAlias_ReturnsCorrectAst(string category, string alias)
    => Test.TrueExpected(
      "category " + category + " " + alias,
      new CategoryAst(AstNulls.At, category) { Aliases = new[] { alias } });

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string category, CategoryOption option, string alias)
    => Test.TrueExpected(
      "category " + category + " (" + option.ToString().ToLowerInvariant() + ") " + alias,
      new CategoryAst(AstNulls.At, category) {
        Option = option,
        Aliases = new[] { alias },
      });

  private static BaseOneChecks<SchemaParser, CategoryAst> Test => new(
    tokens => new SchemaParser(tokens),
    (SchemaParser parser, out CategoryAst result) => parser.ParseCategory(out result));
}
