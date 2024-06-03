using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputFieldTests
  : TestObjectField
{
  [Theory, RepeatData(Repeats)]
  public void WithDefault_ReturnsCorrectAst(string name, string fieldType, string content)
    => _checks.TrueExpected(
      name + ":" + fieldType + "='" + content + "'",
      _checks.Field(name, fieldType) with {
        DefaultValue = new FieldKeyAst(AstNulls.At, content)
      });

  internal override ICheckObjectField FieldChecks => _checks;

  private readonly CheckObjectField<InputFieldAst, InputBaseAst> _checks;

  public ParseInputFieldTests(Parser<InputFieldAst>.D parser)
    => _checks = new(new InputFactories(), parser);
}
