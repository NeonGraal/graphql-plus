using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputTests : BaseObjectTests
{
  //[Theory, RepeatData(Repeats)]
  //public void WithAll_ReturnsCorrectAst(string name, string name, OutputOption option, string alias1, string alias2)
  //  => Test.TrueExpected(
  //    name + "[" + alias1 + " " + alias2 + "](" + option.ToString().ToLowerInvariant() + ")=" + name,
  //    new OutputAst(AstNulls.At, name, name) {
  //      Option = option,
  //      Aliases = new[] { alias1, alias2 },
  //    });

  internal override IBaseObjectChecks Checks => Test;

  private static BaseObjectChecks<OutputAst, OutputFieldAst, OutputReferenceAst> Test => new(
    new OutputFactories(),
    (SchemaParser parser, out OutputAst result) => parser.ParseOutput(out result, ""));
}
