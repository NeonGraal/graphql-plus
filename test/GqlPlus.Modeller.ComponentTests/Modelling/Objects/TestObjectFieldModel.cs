using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Convert;

namespace GqlPlus.Modelling.Objects;

public abstract class TestObjectFieldModel<TObjField, TObjFieldAst, TObjBase>
  : TestModelBase<FieldInput>
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField<TObjBase>, TObjField
  where TObjBase : IGqlpObjBase
{
  [Theory, RepeatData(Repeats)]
  public void Model_Modifiers(FieldInput input)
    => FieldChecks.Field_Expected(
        FieldChecks.FieldAst(input) with { Modifiers = TestMods() },
        FieldChecks.ExpectedField(input, ["modifiers: [!_Modifier {modifierKind: !_ModifierKind List}, !_Modifier {modifierKind: !_ModifierKind Opt}]"], [])
      );

  [Theory, RepeatData(Repeats)]
  public void Model_DualTyped(FieldInput input)
    => FieldChecks
      .AddTypeKinds(TypeKindModel.Dual, input.Type)
      .Field_Expected(
        FieldChecks.FieldAst(input),
        FieldChecks.ExpectedDual(input)
      );

  [Theory, RepeatData(Repeats)]
  public void Model_Aliases(FieldInput input, string[] aliases)
    => FieldChecks.Field_Expected(
        FieldChecks.FieldAst(input) with { Aliases = aliases },
        FieldChecks.ExpectedField(input, [aliases.YamlJoin("aliases: [", "]")], [])
      );

  internal override ICheckModelBase<FieldInput> BaseChecks => FieldChecks;

  internal abstract ICheckObjectFieldModel<TObjFieldAst, TObjBase> FieldChecks { get; }
}

internal abstract class CheckObjectFieldModel<TObjField, TObjFieldAst, TObjBase, TModel>(
  IModeller<TObjField, TModel> field, IRenderer
  <TModel> rendering,
  TypeKindModel kind
) : CheckModelBase<FieldInput, TObjField, TModel>(field, rendering),
    ICheckObjectFieldModel<TObjFieldAst, TObjBase>
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField<TObjBase>, TObjField
  where TObjBase : IGqlpObjBase
  where TModel : IModelBase
{
  protected readonly TypeKindModel TypeKind = kind;
  protected readonly string TypeKindLower = $"{kind}".ToLowerInvariant();

  protected override TObjFieldAst NewBaseAst(FieldInput input)
    => NewFieldAst(input);
  protected override string[] ExpectedBase(FieldInput input)
    => ExpectedField(input, [], []);

  protected string[] ExpectedField(FieldInput input, string[] extras, string[] parameters)
    => [$"!_{TypeKind}Field", .. extras, "name: " + input.Name, .. parameters, $"type: !_{TypeKind}Base", $"  {TypeKindLower}: {input.Type}"];
  protected string[] ExpectedDual(FieldInput input)
    => [$"!_{TypeKind}Field", "name: " + input.Name, $"type: !_DualBase", "  dual: " + input.Type];

  protected abstract TObjFieldAst NewFieldAst(FieldInput name);

  void ICheckObjectFieldModel<TObjFieldAst, TObjBase>.Field_Expected(TObjFieldAst ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);
  TObjFieldAst ICheckObjectFieldModel<TObjFieldAst, TObjBase>.FieldAst(FieldInput input)
    => NewFieldAst(input);
  string[] ICheckObjectFieldModel<TObjFieldAst, TObjBase>.ExpectedField(FieldInput input, string[] extras, string[] parameters)
    => ExpectedField(input, extras, parameters);
  string[] ICheckObjectFieldModel<TObjFieldAst, TObjBase>.ExpectedDual(FieldInput input)
    => ExpectedDual(input);
}

internal interface ICheckObjectFieldModel<TObjFieldAst, TObjBase>
  : ICheckModelBase<FieldInput>
  where TObjFieldAst : AstObjField<TObjBase>
  where TObjBase : IGqlpObjBase
{
  TObjFieldAst FieldAst(FieldInput input);
  string[] ExpectedField(FieldInput input, string[] extras, string[] parameters);
  string[] ExpectedDual(FieldInput input);
  void Field_Expected(TObjFieldAst ast, string[] expected);
}
