namespace GqlPlus.Ast.Schema.Objects;

internal class AstObjectFieldChecks<TObjField>(
  TypeBy<FieldInput, TObjField> createField
) : AstAliasedChecks<FieldInput, TObjField>(ObjFieldTypeChecks<FieldInput, TObjField>.ToCreateBy(createField))
  where TObjField : AstObjField
{
  protected override string InputName(FieldInput input) => input.Name;
}
