using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class OutputFieldModelTests(
  IOutputFieldModelChecks checks
) : TestObjectFieldModel<IGqlpOutputField, IGqlpOutputBase, OutputFieldModel>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void Model_EnumValue(FieldInput input, string enumMember)
    => checks.Field_Expected(
      new OutputFieldAst(AstNulls.At, input.Name, new OutputBaseAst(AstNulls.At, input.Type) { EnumMember = enumMember }),
      checks.ExpectedEnum(input, enumMember)
      );

  [Theory, RepeatData(Repeats)]
  public void Model_Parameter(FieldInput input, string[] parameters)
    => checks.Field_Expected(
      new OutputFieldAst(AstNulls.At, input.Name, new OutputBaseAst(AstNulls.At, input.Type)) { Parameters = parameters.Parameters() },
      checks.ExpectedField(input, [], checks.ExpectedParameters(parameters))
      );
}

internal sealed class OutputFieldModelChecks(
  IModeller<IGqlpOutputField, OutputFieldModel> modeller,
  IRenderer<OutputFieldModel> rendering
) : CheckObjectFieldModel<IGqlpOutputField, OutputFieldAst, IGqlpOutputBase, OutputFieldModel>(modeller, rendering, TypeKindModel.Output)
  , IOutputFieldModelChecks
{
  internal override OutputFieldAst NewFieldAst(FieldInput input, string[] aliases, bool withModifiers)
    => new(AstNulls.At, input.Name, NewObjBaseAst(input.Type)) {
      Aliases = aliases,
      Modifiers = withModifiers ? TestMods() : [],
    };

  internal OutputBaseAst NewObjBaseAst(string input)
    => new(AstNulls.At, input);

  public string[] ExpectedParameters(string[] parameters)
    => [.. ItemsExpected(
       "parameters:",
        parameters,
        p => ["- !_InputParameter", "  input: " + p])];

  public string[] ExpectedEnum(FieldInput input, string enumMember)
    => [$"!_OutputEnum", "field: " + input.Name, "member: " + enumMember, "name: " + input.Type, $"typeKind: !_SimpleKind Enum"];
}

public interface IOutputFieldModelChecks
  : ICheckObjectFieldModel<IGqlpOutputField, OutputFieldModel>
{
  string[] ExpectedParameters(string[] parameters);
  string[] ExpectedEnum(FieldInput input, string enumMember);
}
