using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputFieldTests(
  Parser<InputFieldAst>.D parser
) : TestObjectField
{
  [Theory, RepeatData(Repeats)]
  public void WithDefault_ReturnsCorrectAst(string name, string fieldType, string content)
    => _checks.TrueExpected(
      name + ":" + fieldType + "='" + content + "'",
      _checks.Field(name, fieldType) with
      {
        DefaultValue = new FieldKeyAst(AstNulls.At, content)
      });

  internal override ICheckObjectField FieldChecks => _checks;

  private readonly CheckObjectField<InputFieldAst, IGqlpInputBase, InputBaseAst> _checks = new(new InputFactories(), parser);
}
