using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseEnumTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name)
    => Test.TrueExpected(
      name + "=",
      new EnumAst(AstNulls.At, name));

  [Theory, RepeatData(Repeats)]
  public void WithAliases_ReturnsCorrectAst(string name, string alias1, string alias2)
    => Test.TrueExpected(
      name + "[" + alias1 + " " + alias2 + " ]=",
      new EnumAst(AstNulls.At, name) { Aliases = new[] { alias1, alias2 } });

  private static OneChecks<SchemaParser, EnumAst> Test => new(
    tokens => new SchemaParser(tokens),
    (SchemaParser parser, out EnumAst result) => parser.ParseEnum(out result, ""));
}
