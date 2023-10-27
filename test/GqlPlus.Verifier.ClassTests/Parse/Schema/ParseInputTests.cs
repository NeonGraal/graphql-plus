using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseInputTests : BaseObjectTests
{
  //[Theory, RepeatData(Repeats)]
  //public void WithAll_ReturnsCorrectAst(string name, string name, InputOption option, string alias1, string alias2)
  //  => Test.TrueExpected(
  //    name + "[" + alias1 + " " + alias2 + "](" + option.ToString().ToLowerInvariant() + ")=" + name,
  //    new InputAst(AstNulls.At, name, name) {
  //      Option = option,
  //      Aliases = new[] { alias1, alias2 },
  //    });

  internal override IBaseObjectChecks Checks => Test;

  private static BaseObjectChecks<InputAst, InputFieldAst, InputReferenceAst> Test => new(
    new InputFactories(),
    (SchemaParser parser, out InputAst result) => parser.ParseInput(out result, ""));
}
