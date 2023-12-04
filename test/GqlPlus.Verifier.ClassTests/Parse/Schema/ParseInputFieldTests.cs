using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseInputFieldTests
  : BaseFieldTests
{
  [Theory, RepeatData(Repeats)]
  public void WithDefault_ReturnsCorrectAst(string name, string fieldType, string content)
    => _test.TrueExpected(
      name + ":" + fieldType + "='" + content + "'",
      _test.Field(name, fieldType) with {
        Default = new FieldKeyAst(AstNulls.At, content)
      });

  internal override IBaseFieldChecks Checks => _test;

  private readonly BaseFieldParserChecks<InputFieldAst, InputReferenceAst> _test;

  public ParseInputFieldTests(Parser<InputFieldAst>.D parser)
    => _test = new(new InputFactories(), parser);
}
