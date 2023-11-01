using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseEnumTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name, string[] labels)
    => Test.TrueExpected(
      name + "=" + string.Join("|", labels),
      new EnumAst(AstNulls.At, name) {
        Labels = labels.EnumLabels(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithAliases_ReturnsCorrectAst(string name, string[] labels, string[] aliases)
    => Test.TrueExpected(
      name + aliases.Bracket("[", "]=").Joined() + string.Join("|", labels),
      new EnumAst(AstNulls.At, name) {
        Aliases = aliases,
        Labels = labels.EnumLabels(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithAliasesBad_ReturnsFalse(string name, string[] labels, string[] aliases)
    => Test.False(
      name + aliases.Bracket("[", "=").Joined() + string.Join("|", labels),
      ast => { });

  [Theory, RepeatData(Repeats)]
  public void WithExtends_ReturnsCorrectAst(string name, string extends, string[] labels)
    => Test.TrueExpected(
      name + "=:" + extends + " " + string.Join("|", labels),
      new EnumAst(AstNulls.At, name) {
        Extends = extends,
        Labels = labels.EnumLabels(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithExtendsBad_ReturnsFalse(string name, string extends, string label)
    => Test.False(
      name + "=:" + extends + "|" + label,
      ast => { });

  [Theory, RepeatData(Repeats)]
  public void WithLabels_ReturnsCorrectAst(string name, string[] labels)
    => Test.TrueExpected(
      name + "=" + string.Join("|", labels),
      new EnumAst(AstNulls.At, name) {
        Labels = labels.EnumLabels(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithLabelsBad_ReturnsFalse(string name, string[] labels)
    => Test.False(
      name + "=" + string.Join("||", labels),
      ast => { },
      labels.Length < 2);

  private static OneChecks<SchemaParser, EnumAst> Test => new(
    tokens => new SchemaParser(tokens),
    (SchemaParser parser, out EnumAst result) => parser.ParseEnum(out result, ""));
}
