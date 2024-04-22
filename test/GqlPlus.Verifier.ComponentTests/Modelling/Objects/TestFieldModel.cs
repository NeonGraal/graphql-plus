using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling.Objects;

public abstract class TestFieldModel<TField, TRef>
  : TestModelBase<FieldInput>
  where TField : AstField<TRef>
  where TRef : AstReference<TRef>
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

  internal abstract ICheckFieldModel<TField, TRef> FieldChecks { get; }
}

internal abstract class CheckFieldModel<TField, TRef, TModel>(
  IModeller<TField, TModel> field,
  TypeKindModel kind
) : CheckModelBase<FieldInput, TField, TModel>(field),
    ICheckFieldModel<TField, TRef>
  where TField : AstField<TRef>
  where TRef : AstReference<TRef>
  where TModel : IRendering
{
  protected readonly TypeKindModel TypeKind = kind;
  protected readonly string TypeKindLower = $"{kind}".ToLowerInvariant();

  protected override TField NewBaseAst(FieldInput input)
    => NewFieldAst(input);
  protected override string[] ExpectedBase(FieldInput input)
    => ExpectedField(input, [], []);

  protected string[] ExpectedField(FieldInput input, string[] extras, string[] parameters)
    => [$"!_{TypeKind}Field", .. extras, "name: " + input.Name, .. parameters, $"type: !_{TypeKind}Base " + input.Type];
  protected string[] ExpectedDual(FieldInput input)
    => [$"!_{TypeKind}Field", "name: " + input.Name, $"type: !_DualBase " + input.Type];

  protected abstract TField NewFieldAst(FieldInput name);

  void ICheckFieldModel<TField, TRef>.Field_Expected(TField ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);
  TField ICheckFieldModel<TField, TRef>.FieldAst(FieldInput input)
    => NewFieldAst(input);
  string[] ICheckFieldModel<TField, TRef>.ExpectedField(FieldInput input, string[] extras, string[] parameters)
    => ExpectedField(input, extras, parameters);
  string[] ICheckFieldModel<TField, TRef>.ExpectedDual(FieldInput input)
    => ExpectedDual(input);
}

internal interface ICheckFieldModel<TField, TRef>
  : ICheckModelBase<FieldInput>
  where TField : AstField<TRef>
  where TRef : AstReference<TRef>
{
  TField FieldAst(FieldInput input);
  string[] ExpectedField(FieldInput input, string[] extras, string[] parameters);
  string[] ExpectedDual(FieldInput input);
  void Field_Expected(TField ast, string[] expected);
}
