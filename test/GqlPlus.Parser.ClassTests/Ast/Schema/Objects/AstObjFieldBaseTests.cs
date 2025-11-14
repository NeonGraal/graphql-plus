using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class AstObjFieldBaseTests
  : AstAliasedBaseTests<FieldInput>
{
  internal sealed override IAstAliasedChecks<FieldInput> AliasedChecks => FieldChecks;

  internal abstract IAstObjectFieldChecks FieldChecks { get; }
}

internal class AstObjectFieldChecks<TObjField>(
  AstObjectFieldChecks<TObjField>.FieldBy createField,
  BaseAstChecks<TObjField>.CloneBy<FieldInput> cloneField
) : AstAliasedChecks<FieldInput, TObjField>(input => createField(input, BaseBy(input)), cloneField)
  , IAstObjectFieldChecks
  where TObjField : AstObjField
{
  internal delegate TObjField FieldBy(FieldInput input, IGqlpObjBase objBase);

  internal static ObjBaseAst BaseBy(FieldInput input)
    => new(AstNulls.At, input.Type, "") { IsTypeParam = input.TypeParam };

  protected override string InputName(FieldInput input) => input.Name;
}

internal interface IAstObjectFieldChecks
  : IAstAliasedChecks<FieldInput>
{ }
