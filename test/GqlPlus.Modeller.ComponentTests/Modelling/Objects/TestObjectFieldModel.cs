using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Convert;

namespace GqlPlus.Modelling.Objects;

public abstract class TestObjectFieldModel<TObjField, TObjBase>
  : TestModelBase<FieldInput>
  where TObjField : IGqlpObjField
  where TObjBase : IGqlpObjBase
{
  [Theory, RepeatData(Repeats)]
  public void Model_Modifiers(FieldInput input)
    => FieldChecks.Field_Expected(
        FieldChecks.FieldAst(input, [], true),
        FieldChecks.ExpectedField(input, ["modifiers: [!_Modifier {modifierKind: !_ModifierKind List}, !_Modifier {modifierKind: !_ModifierKind Opt}]"], [])
      );

  [Theory, RepeatData(Repeats)]
  public void Model_DualTyped(FieldInput input)
    => FieldChecks
      .AddTypeKinds(TypeKindModel.Dual, input.Type)
      .Field_Expected(
        FieldChecks.FieldAst(input, [], false),
        FieldChecks.ExpectedDual(input)
      );

  [Theory, RepeatData(Repeats)]
  public void Model_Aliases(FieldInput input, string[] aliases)
    => FieldChecks.Field_Expected(
        FieldChecks.FieldAst(input, aliases, false),
        FieldChecks.ExpectedField(input, [aliases.YamlJoin("aliases: [", "]")], [])
      );

  internal override ICheckModelBase<FieldInput> BaseChecks => FieldChecks;

  internal abstract ICheckObjectFieldModel<TObjField> FieldChecks { get; }
}

internal abstract class CheckObjectFieldModel<TObjField, TObjFieldAst, TObjBase, TModel>(
  IModeller<TObjField, TModel> field, IRenderer
  <TModel> rendering,
  TypeKindModel kind
) : CheckModelBase<FieldInput, TObjField, TModel>(field, rendering),
    ICheckObjectFieldModel<TObjField>
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField<TObjBase>, TObjField
  where TObjBase : IGqlpObjBase
  where TModel : IModelBase
{
  protected readonly TypeKindModel TypeKind = kind;
  protected readonly string TypeKindLower = $"{kind}".ToLowerInvariant();

  protected override TObjFieldAst NewBaseAst(FieldInput input)
    => NewFieldAst(input, [], false);
  protected override string[] ExpectedBase(FieldInput input)
    => ExpectedField(input, [], []);

  protected string[] ExpectedField(FieldInput input, string[] extras, string[] parameters)
    => [$"!_{TypeKind}Field", .. extras, "name: " + input.Name, .. parameters, $"type: !_{TypeKind}Base", $"  {TypeKindLower}: {input.Type}"];
  protected string[] ExpectedDual(FieldInput input)
    => [$"!_{TypeKind}Field", "name: " + input.Name, $"type: !_DualBase", "  dual: " + input.Type];

  internal abstract TObjFieldAst NewFieldAst(FieldInput name, string[] aliases, bool withModifiers);

  void ICheckObjectFieldModel<TObjField>.Field_Expected(TObjField ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);
  TObjField ICheckObjectFieldModel<TObjField>.FieldAst(FieldInput input, string[] aliases, bool withModifiers)
    => NewFieldAst(input, aliases, withModifiers);
  string[] ICheckObjectFieldModel<TObjField>.ExpectedField(FieldInput input, string[] extras, string[] parameters)
    => ExpectedField(input, extras, parameters);
  string[] ICheckObjectFieldModel<TObjField>.ExpectedDual(FieldInput input)
    => ExpectedDual(input);
}

internal interface ICheckObjectFieldModel<TObjField>
  : ICheckModelBase<FieldInput>
  where TObjField : IGqlpObjField
{
  TObjField FieldAst(FieldInput input, string[] aliases, bool withModifiers);
  string[] ExpectedField(FieldInput input, string[] extras, string[] parameters);
  string[] ExpectedDual(FieldInput input);
  void Field_Expected(TObjField ast, string[] expected);
}
