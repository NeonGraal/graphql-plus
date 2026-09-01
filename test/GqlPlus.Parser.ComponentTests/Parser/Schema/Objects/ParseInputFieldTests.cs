using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public class ParseInputFieldTests(ComponentFixture<SchemaParserTestServices> fixture)
  : TestObjectField<IAstInputField>(fixture.GetService<ICheckObjectField<IAstInputField>>())
  , IClassFixture<ComponentFixture<SchemaParserTestServices>>
{
  private readonly ICheckObjectField<IAstInputField> checks = fixture.GetService<ICheckObjectField<IAstInputField>>();

  [Theory, RepeatData]
  public void WithDefault_ReturnsCorrectAst(string name, string fieldType, string content)
    => checks.TrueExpected(
      name + ":" + fieldType + "='" + content + "'",
      new InputFieldAst(AstNulls.At, name, new ObjBaseAst(AstNulls.At, fieldType, "")) {
        DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, content))
      });
}

internal sealed class ParseInputFieldChecks(
  IParserRepository parsers
) : CheckObjectField<IAstInputField, InputFieldAst>(new InputFactories(), parsers);
