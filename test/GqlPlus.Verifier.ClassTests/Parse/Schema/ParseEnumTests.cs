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
  public void WithAliases_ReturnsCorrectAst(string name, string label, string[] aliases)
    => Test.TrueExpected(
      name + aliases.Bracket("[", "]=").Joined() + label,
      new EnumAst(AstNulls.At, name) {
        Aliases = aliases,
        Labels = label.EnumLabels(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithExtends_ReturnsCorrectAst(string name, string extends, string label)
    => Test.TrueExpected(
      name + "=:" + extends + " " + label,
      new EnumAst(AstNulls.At, name) {
        Extends = extends,
        Labels = label.EnumLabels(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithLabels_ReturnsCorrectAst(string name, string label1, string label2, string label3)
    => Test.TrueExpected(
      name + "=" + label1 + "|" + label2 + "|" + label3,
      new EnumAst(AstNulls.At, name) {
        Labels = label1.EnumLabels(label2, label3),
      });

  private static OneChecks<SchemaParser, EnumAst> Test => new(
    tokens => new SchemaParser(tokens),
    (SchemaParser parser, out EnumAst result) => parser.ParseEnum(out result, ""));
}
