using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseEnumTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name, string label)
    => Test.TrueExpected(
      name + "=" + label,
      new EnumAst(AstNulls.At, name) {
        Labels = label.EnumLabels(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithAliases_ReturnsCorrectAst(string name, string label, string alias1, string alias2)
    => Test.TrueExpected(
      name + "[" + alias1 + " " + alias2 + " ]=" + label,
      new EnumAst(AstNulls.At, name) {
        Aliases = new[] { alias1, alias2 },
        Labels = label.EnumLabels(),
      });

  private static OneChecks<SchemaParser, EnumAst> Test => new(
    tokens => new SchemaParser(tokens),
    (SchemaParser parser, out EnumAst result) => parser.ParseEnum(out result, ""));
}
