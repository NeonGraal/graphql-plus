using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Objects;

public abstract class TestObjectFieldModel<TObjField, TModel>(
  ICheckObjectFieldModel<TObjField, TModel> fieldChecks
) : TestModelBase<FieldInput, TModel>(fieldChecks)
  where TObjField : IGqlpObjField
  where TModel : IObjFieldModel
{
  [Theory, RepeatData]
  public void Model_Modifiers(FieldInput input)
    => fieldChecks.Field_Expected(
        fieldChecks.FieldAst(input, [], true),
        fieldChecks.ExpectedField(input, ["modifiers: [!_Modifier{modifierKind:!_ModifierKind List},!_Modifier{modifierKind:!_ModifierKind Opt}]"], [])
      );

  [Theory, RepeatData]
  public void Model_DualTyped(FieldInput input)
    => fieldChecks
      .AddTypeKinds(TypeKindModel.Dual, input.Type)
      .Field_Expected(
        fieldChecks.FieldAst(input, [], false),
        fieldChecks.ExpectedDual(input)
      );

  [Theory, RepeatData]
  public void Model_Aliases(FieldInput input, string[] aliases)
    => fieldChecks.Field_Expected(
        fieldChecks.FieldAst(input, aliases, false),
        fieldChecks.ExpectedField(input, [aliases.Surround("aliases: [", "]", ",")], [])
      );
}

internal abstract class CheckObjectFieldModel<TObjField, TObjFieldAst, TModel>(
  IModeller<TObjField, TModel> field, IEncoder
  <TModel> encoding,
  TypeKindModel kind
) : CheckModelBase<FieldInput, TObjField, TModel>(field, encoding),
    ICheckObjectFieldModel<TObjField, TModel>
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField, TObjField
  where TModel : IObjFieldModel
{
  protected readonly TypeKindModel TypeKind = kind;

  protected override TObjFieldAst NewBaseAst(FieldInput input)
    => NewFieldAst(input, [], false);
  protected override string[] ExpectedBase(FieldInput input)
    => ExpectedField(input, [], []);

  protected string[] ExpectedField(FieldInput input, string[] extras, string[] parameters)
    => [$"!_{TypeKind}Field", .. extras, "name: " + input.Name, .. parameters, "type: !_ObjBase", $"  name: {input.Type}"];
  protected string[] ExpectedDual(FieldInput input)
    => [$"!_{TypeKind}Field", "name: " + input.Name, "type: !_ObjBase", "  name: " + input.Type];

  internal abstract TObjFieldAst NewFieldAst(FieldInput name, string[] aliases, bool withModifiers);

  void ICheckObjectFieldModel<TObjField, TModel>.Field_Expected(TObjField ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);
  TObjField ICheckObjectFieldModel<TObjField, TModel>.FieldAst(FieldInput input, string[] aliases, bool withModifiers)
    => NewFieldAst(input, aliases, withModifiers);
  string[] ICheckObjectFieldModel<TObjField, TModel>.ExpectedField(FieldInput input, string[] extras, string[] parameters)
    => ExpectedField(input, extras, parameters);
  string[] ICheckObjectFieldModel<TObjField, TModel>.ExpectedDual(FieldInput input)
    => ExpectedDual(input);
}

public interface ICheckObjectFieldModel<TObjField, TModel>
  : ICheckModelBase<FieldInput, TModel>
  where TObjField : IGqlpObjField
  where TModel : IObjFieldModel
{
  TObjField FieldAst(FieldInput input, string[] aliases, bool withModifiers);
  string[] ExpectedField(FieldInput input, string[] extras, string[] parameters);
  string[] ExpectedDual(FieldInput input);
  void Field_Expected(TObjField ast, string[] expected);
}
