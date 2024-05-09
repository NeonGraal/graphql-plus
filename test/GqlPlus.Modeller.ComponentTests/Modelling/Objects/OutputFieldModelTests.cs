using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class OutputFieldModelTests(
  IModeller<OutputFieldAst, OutputFieldModel> modeller
) : TestObjectFieldModel<OutputFieldAst, OutputBaseAst>
{
  [Theory, RepeatData(Repeats)]
  public void Model_EnumValue(FieldInput input, string enumValue)
    => FieldChecks.Field_Expected(
      FieldChecks.FieldAst(input) with {
        Type = _checks.NewObjBaseAst(input.Type) with { EnumValue = enumValue }
      },
      _checks.ExpectedEnum(input, enumValue)
      );

  [Theory, RepeatData(Repeats)]
  public void Model_Parameter(FieldInput input, string[] parameters)
    => FieldChecks.Field_Expected(
      FieldChecks.FieldAst(input) with { Parameters = parameters.Parameters() },
      FieldChecks.ExpectedField(input, [], _checks.ExpectedParameters(parameters))
      );

  internal override ICheckObjectFieldModel<OutputFieldAst, OutputBaseAst> FieldChecks => _checks;

  private readonly OutputFieldModelChecks _checks = new(modeller);
}

internal sealed class OutputFieldModelChecks(
  IModeller<OutputFieldAst, OutputFieldModel> modeller
) : CheckObjectFieldModel<OutputFieldAst, OutputBaseAst, OutputFieldModel>(modeller, TypeKindModel.Output)
{
  protected override OutputFieldAst NewFieldAst(FieldInput input)
    => new(AstNulls.At, input.Name, NewObjBaseAst(input.Type));

  internal OutputBaseAst NewObjBaseAst(string input)
    => new(AstNulls.At, input);

  internal string[] ExpectedParameters(string[] parameters)
    => [.. ItemsExpected(
       "parameters:",
        parameters,
        p => ["- !_InputParameter", "  type: !_InputBase " + p])];
  internal string[] ExpectedEnum(FieldInput input, string enumValue)
    => [$"!_OutputEnum", "field: " + input.Name, "name: " + input.Type, $"typeKind: !_SimpleKind Enum", "value: " + enumValue];
}
