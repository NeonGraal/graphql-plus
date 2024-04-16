using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public class ParseInputFieldTests
  : BaseFieldTests
{
  [Theory, RepeatData(Repeats)]
  public void WithDefault_ReturnsCorrectAst(string name, string fieldType, string content)
    => _checks.TrueExpected(
      name + ":" + fieldType + "='" + content + "'",
      _checks.Field(name, fieldType) with {
        Default = new FieldKeyAst(AstNulls.At, content)
      });

  internal override IBaseFieldChecks FieldChecks => _checks;

  private readonly BaseFieldChecks<InputFieldAst, InputReferenceAst> _checks;

  public ParseInputFieldTests(Parser<InputFieldAst>.D parser)
    => _checks = new(new InputFactories(), parser);
}
