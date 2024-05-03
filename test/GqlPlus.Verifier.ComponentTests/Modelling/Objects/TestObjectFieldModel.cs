using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling.Objects;

public abstract class TestObjectFieldModel<TObjField, TObjBase>
  : TestModelBase<FieldInput>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Modifiers(FieldInput input)
    => FieldChecks.Field_Expected(
        FieldChecks.FieldAst(input) with { Modifiers = TestMods() },
        FieldChecks.ExpectedField(input, ["modifiers: [!_Modifier List, !_Modifier Optional]"], [])
      );

  [Theory, RepeatData(Repeats)]
  public void Model_DualTyped(FieldInput input)
    => FieldChecks
      .AddTypeKinds(TypeKindModel.Dual, input.Type)
      .Field_Expected(
        FieldChecks.FieldAst(input),
        FieldChecks.ExpectedDual(input)
      );

  internal override ICheckModelBase<FieldInput> BaseChecks => FieldChecks;

  internal abstract ICheckObjectFieldModel<TObjField, TObjBase> FieldChecks { get; }
}

internal abstract class CheckObjectFieldModel<TObjField, TObjBase, TModel>(
  IModeller<TObjField, TModel> field,
  TypeKindModel kind
) : CheckModelBase<FieldInput, TObjField, TModel>(field),
    ICheckObjectFieldModel<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
  where TModel : IRendering
{
  protected readonly TypeKindModel TypeKind = kind;
  protected readonly string TypeKindLower = $"{kind}".ToLowerInvariant();

  protected override TObjField NewBaseAst(FieldInput input)
    => NewFieldAst(input);
  protected override string[] ExpectedBase(FieldInput input)
    => ExpectedField(input, [], []);

  protected string[] ExpectedField(FieldInput input, string[] extras, string[] parameters)
    => [$"!_{TypeKind}Field", .. extras, "name: " + input.Name, .. parameters, $"type: !_{TypeKind}Base " + input.Type];
  protected string[] ExpectedDual(FieldInput input)
    => [$"!_{TypeKind}Field", "name: " + input.Name, $"type: !_DualBase " + input.Type];

  protected abstract TObjField NewFieldAst(FieldInput name);

  void ICheckObjectFieldModel<TObjField, TObjBase>.Field_Expected(TObjField ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);
  TObjField ICheckObjectFieldModel<TObjField, TObjBase>.FieldAst(FieldInput input)
    => NewFieldAst(input);
  string[] ICheckObjectFieldModel<TObjField, TObjBase>.ExpectedField(FieldInput input, string[] extras, string[] parameters)
    => ExpectedField(input, extras, parameters);
  string[] ICheckObjectFieldModel<TObjField, TObjBase>.ExpectedDual(FieldInput input)
    => ExpectedDual(input);
}

internal interface ICheckObjectFieldModel<TObjField, TObjBase>
  : ICheckModelBase<FieldInput>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  TObjField FieldAst(FieldInput input);
  string[] ExpectedField(FieldInput input, string[] extras, string[] parameters);
  string[] ExpectedDual(FieldInput input);
  void Field_Expected(TObjField ast, string[] expected);
}
