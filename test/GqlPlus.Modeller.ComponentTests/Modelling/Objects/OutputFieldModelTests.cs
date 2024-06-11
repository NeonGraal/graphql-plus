using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class OutputFieldModelTests(
  IModeller<IGqlpOutputField, OutputFieldModel> modeller,
  IRenderer<OutputFieldModel> rendering
) : TestObjectFieldModel<IGqlpOutputField, OutputFieldAst, IGqlpOutputBase>
{
  [Theory, RepeatData(Repeats)]
  public void Model_EnumValue(FieldInput input, string enumMember)
    => FieldChecks.Field_Expected(
      FieldChecks.FieldAst(input) with {
        Type = _checks.NewObjBaseAst(input.Type) with { EnumMember = enumMember }
      },
      _checks.ExpectedEnum(input, enumMember)
      );

  [Theory, RepeatData(Repeats)]
  public void Model_Parameter(FieldInput input, string[] parameters)
    => FieldChecks.Field_Expected(
      FieldChecks.FieldAst(input) with { Parameters = parameters.Parameters() },
      FieldChecks.ExpectedField(input, [], _checks.ExpectedParameters(parameters))
      );

  internal override ICheckObjectFieldModel<OutputFieldAst, IGqlpOutputBase> FieldChecks => _checks;

  private readonly OutputFieldModelChecks _checks = new(modeller, rendering);
}

internal sealed class OutputFieldModelChecks(
  IModeller<IGqlpOutputField, OutputFieldModel> modeller,
  IRenderer<OutputFieldModel> rendering
) : CheckObjectFieldModel<IGqlpOutputField, OutputFieldAst, IGqlpOutputBase, OutputFieldModel>(modeller, rendering, TypeKindModel.Output)
{
  protected override OutputFieldAst NewFieldAst(FieldInput input)
    => new(AstNulls.At, input.Name, NewObjBaseAst(input.Type));

  internal OutputBaseAst NewObjBaseAst(string input)
    => new(AstNulls.At, input);

  internal string[] ExpectedParameters(string[] parameters)
    => [.. ItemsExpected(
       "parameters:",
        parameters,
        p => ["- !_InputParameter", "  input: " + p])];
  internal string[] ExpectedEnum(FieldInput input, string enumMember)
    => [$"!_OutputEnum", "field: " + input.Name, "member: " + enumMember, "name: " + input.Type, $"typeKind: !_SimpleKind Enum"];
}
