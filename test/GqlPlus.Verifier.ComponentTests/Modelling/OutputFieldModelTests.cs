using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class OutputFieldModelTests(
  IModeller<OutputFieldAst, OutputFieldModel> modeller
) : TestFieldModel<OutputFieldAst, OutputReferenceAst>
{
  [Theory, RepeatData(Repeats)]
  public void Model_EnumValue(FieldInput input, string enumValue)
    => FieldChecks.Field_Expected(
      FieldChecks.FieldAst(input) with {
        Type = _checks.NewReferenceAst(input.Type) with { EnumValue = enumValue }
      },
      _checks.ExpectedEnum(input, enumValue)
      );

  [Theory, RepeatData(Repeats)]
  public void Model_Parameter(FieldInput input, string[] parameters)
    => FieldChecks.Field_Expected(
      FieldChecks.FieldAst(input) with { Parameters = parameters.Parameters() },
      FieldChecks.ExpectedField(input, [], _checks.ExpectedParameters(parameters))
      );

  internal override ICheckFieldModel<OutputFieldAst, OutputReferenceAst> FieldChecks => _checks;

  private readonly OutputFieldModelChecks _checks = new(modeller);
}

internal sealed class OutputFieldModelChecks(
  IModeller<OutputFieldAst, OutputFieldModel> modeller
) : CheckFieldModel<OutputFieldAst, OutputReferenceAst, OutputFieldModel>(modeller, TypeKindModel.Output)
{
  protected override OutputFieldAst NewFieldAst(FieldInput input)
    => new(AstNulls.At, input.Name, NewReferenceAst(input.Type));

  internal OutputReferenceAst NewReferenceAst(string input)
    => new(AstNulls.At, input);

  internal string[] ExpectedParameters(string[] parameters)
    => [.. ItemsExpected(
       "parameters:",
        parameters,
        p => ["- !_Parameter", "  type: !_InputBase " + p])];
  internal string[] ExpectedEnum(FieldInput input, string enumValue)
    => [$"!_OutputEnum", "field: " + input.Name, $"kind: !_SimpleKind Enum", "name: " + input.Type, "value: " + enumValue];
}
