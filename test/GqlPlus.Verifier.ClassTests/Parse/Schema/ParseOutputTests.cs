using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name, string other)
    => Test.TrueExpected(
      name + "=" + other,
      new OutputAst(AstNulls.At, name) { Alternates = other.OutputReferences() });

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameters_ReturnsCorrectAst(string name, string other, string parameter)
    => Test.TrueExpected(
      name + "<$" + parameter + " >=" + other,
      new OutputAst(AstNulls.At, name) {
        Alternates = other.OutputReferences(),
        Parameters = parameter.TypeParameters()
      });

  [Theory, RepeatData(Repeats)]
  public void WithAliases_ReturnsCorrectAst(string name, string other, string alias1, string alias2)
    => Test.TrueExpected(
      name + "[" + alias1 + " " + alias2 + " ]=" + other,
      new OutputAst(AstNulls.At, name) {
        Alternates = other.OutputReferences(),
        Aliases = new[] { alias1, alias2 }
      });

  [Theory, RepeatData(Repeats)]
  public void WithFields_ReturnsCorrectAst(string name, string field, string fieldType)
    => Test.TrueExpected(
      name + "={" + field + ":" + fieldType + "}",
      new OutputAst(AstNulls.At, name) { Fields = field.OutputFields(fieldType) });

  [Theory, RepeatData(Repeats)]
  public void WithExtendsFields_ReturnsCorrectAst(string name, string extends, string field, string fieldType)
    => Test.TrueExpected(
      name + "=" + extends + "{" + field + ":" + fieldType + "}",
      new OutputAst(AstNulls.At, name) {
        Extends = extends.OutputReferences()[0],
        Fields = field.OutputFields(fieldType),
      });

  //[Theory, RepeatData(Repeats)]
  //public void WithAll_ReturnsCorrectAst(string name, string name, OutputOption option, string alias1, string alias2)
  //  => Test.TrueExpected(
  //    name + "[" + alias1 + " " + alias2 + "](" + option.ToString().ToLowerInvariant() + ")=" + name,
  //    new OutputAst(AstNulls.At, name, name) {
  //      Option = option,
  //      Aliases = new[] { alias1, alias2 },
  //    });

  private static OneChecks<SchemaParser, OutputAst> Test => new(
    tokens => new SchemaParser(tokens),
    (SchemaParser parser, out OutputAst result) => parser.ParseOutput(out result, ""));
}
