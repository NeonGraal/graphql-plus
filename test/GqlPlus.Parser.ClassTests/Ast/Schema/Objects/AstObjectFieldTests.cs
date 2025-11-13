using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class AstObjectFieldTests
  : AstAliasedTests<FieldInput>
{
  internal sealed override IAstAliasedChecks<FieldInput> AliasedChecks => FieldChecks;

  protected override string InputName(FieldInput input) => input.Name;

  internal abstract IAstObjectFieldChecks FieldChecks { get; }
}

internal sealed class AstObjectFieldChecks<TObjField>(
  AstObjectFieldChecks<TObjField>.FieldBy createField,
  BaseAstChecks<TObjField>.CloneBy<FieldInput> cloneField
) : AstAliasedChecks<FieldInput, TObjField>(input => createField(input, BaseBy(input)), cloneField)
  , IAstObjectFieldChecks
  where TObjField : AstObjField
{
  internal delegate TObjField FieldBy(FieldInput input, IGqlpObjBase objBase);

  internal static ObjBaseAst BaseBy(FieldInput input)
    => new(AstNulls.At, input.Type, "") { IsTypeParam = input.TypeParam };
}

internal interface IAstObjectFieldChecks
  : IAstAliasedChecks<FieldInput>
{ }
