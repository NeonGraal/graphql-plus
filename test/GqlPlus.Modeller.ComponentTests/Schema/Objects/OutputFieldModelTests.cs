using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Objects;

public class OutputFieldModelTests(
  IOutputFieldModelChecks checks
) : TestObjectFieldModel<IGqlpOutputField, OutputFieldModel>(checks)
{
  [Theory, RepeatData]
  public void Model_EnumValue(FieldInput input, string enumLabel)
    => checks.Field_Expected(
      new OutputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, "")) { EnumLabel = enumLabel },
      checks.ExpectedEnum(input, enumLabel)
      );

  [Theory, RepeatData]
  public void Model_Param(FieldInput input, string[] parameters)
    => checks.Field_Expected(
      new OutputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, "")) { Params = parameters.Params() },
      checks.ExpectedField(input, [], checks.ExpectedParams(parameters))
      );
}

internal sealed class OutputFieldModelChecks(
  IModeller<IGqlpOutputField, OutputFieldModel> modeller,
  IEncoder<OutputFieldModel> encoding
) : CheckObjectFieldModel<IGqlpOutputField, OutputFieldAst, OutputFieldModel>(modeller, encoding, TypeKindModel.Output)
  , IOutputFieldModelChecks
{
  internal override OutputFieldAst NewFieldAst(FieldInput input, string[] aliases, bool withModifiers)
    => new(AstNulls.At, input.Name, NewObjBaseAst(input.Type)) {
      Aliases = aliases,
      Modifiers = withModifiers ? TestMods() : [],
    };

  internal ObjBaseAst NewObjBaseAst(string input)
    => new(AstNulls.At, input, "");

  public string[] ExpectedParams(string[] parameters)
    => [.. ItemsExpected(
       "parameters:",
        parameters,
        p => ["  - !_InputParam", "    name: " + p])];

  public string[] ExpectedEnum(FieldInput input, string enumLabel)
    => [$"!_OutputEnum", "field: " + input.Name, "label: " + enumLabel, "name: " + input.Type, $"typeKind: !_SimpleKind Enum"];
}

public interface IOutputFieldModelChecks
  : ICheckObjectFieldModel<IGqlpOutputField, OutputFieldModel>
{
  string[] ExpectedParams(string[] parameters);
  string[] ExpectedEnum(FieldInput input, string enumLabel);
}
