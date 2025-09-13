using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class ParseInputFieldTests(
  ICheckObjectField<IGqlpInputField> checks
) : TestObjectField<IGqlpInputField>(checks)
{
  [Theory, RepeatData]
  public void WithDefault_ReturnsCorrectAst(string name, string fieldType, string content)
    => checks.TrueExpected(
      name + ":" + fieldType + "='" + content + "'",
      new InputFieldAst(AstNulls.At, name, new InputBaseAst(AstNulls.At, fieldType)) {
        DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, content))
      });
}

internal sealed class ParseInputFieldChecks(
  Parser<IGqlpInputField>.D parser
) : CheckObjectField<IGqlpInputField, InputFieldAst, IGqlpInputBase, InputBaseAst, IGqlpObjArg, InputArgAst>(new InputFactories(), parser)
{ }
