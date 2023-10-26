using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseInputTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name, string other)
    => Test.TrueExpected(
      name + "=" + other,
      new InputAst(AstNulls.At, name) { Alternates = other.InputReferences() });

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameters_ReturnsCorrectAst(string name, string other, string parameter)
    => Test.TrueExpected(
      name + "<$" + parameter + " >=" + other,
      new InputAst(AstNulls.At, name) {
        Alternates = other.InputReferences(),
        Parameters = parameter.TypeParameters()
      });

  [Theory, RepeatData(Repeats)]
  public void WithAliases_ReturnsCorrectAst(string name, string other, string alias1, string alias2)
    => Test.TrueExpected(
      name + "[" + alias1 + " " + alias2 + " ]=" + other,
      new InputAst(AstNulls.At, name) {
        Alternates = other.InputReferences(),
        Aliases = new[] { alias1, alias2 }
      });

  [Theory, RepeatData(Repeats)]
  public void WithFields_ReturnsCorrectAst(string name, string field, string fieldType)
    => Test.TrueExpected(
      name + "={" + field + ":" + fieldType + "}",
      new InputAst(AstNulls.At, name) { Fields = field.InputFields(fieldType) });

  [Theory, RepeatData(Repeats)]
  public void WithExtendsFields_ReturnsCorrectAst(string name, string extends, string field, string fieldType)
    => Test.TrueExpected(
      name + "=" + extends + "{" + field + ":" + fieldType + "}",
      new InputAst(AstNulls.At, name) {
        Extends = extends.InputReferences()[0],
        Fields = field.InputFields(fieldType),
      });

  //[Theory, RepeatData(Repeats)]
  //public void WithAll_ReturnsCorrectAst(string name, string name, InputOption option, string alias1, string alias2)
  //  => Test.TrueExpected(
  //    name + "[" + alias1 + " " + alias2 + "](" + option.ToString().ToLowerInvariant() + ")=" + name,
  //    new InputAst(AstNulls.At, name, name) {
  //      Option = option,
  //      Aliases = new[] { alias1, alias2 },
  //    });

  private static OneChecks<SchemaParser, InputAst> Test => new(
    tokens => new SchemaParser(tokens),
    (SchemaParser parser, out InputAst result) => parser.ParseInput(out result, ""));
}
