using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class AstObjFieldBaseTests
  : AstAliasedBaseTests<FieldInput>
{
  internal sealed override IAstAliasedChecks<FieldInput> AliasedChecks => FieldChecks;

  internal abstract IAstObjectFieldChecks FieldChecks { get; }
}

internal class AstObjectFieldChecks<TObjField>(
  AstObjectFieldChecks<TObjField>.FieldBy createField
) : AstAliasedChecks<FieldInput, TObjField>(input => createField(input, ObjBaseFactory.Create(input)))
  , IAstObjectFieldChecks
  where TObjField : AstObjField
{
  internal delegate TObjField FieldBy(FieldInput input, IGqlpObjBase objBase);

  protected override string InputName(FieldInput input) => input.Name;
}

internal static class ObjBaseFactory
{
  internal static ObjBaseAst Create<TInput>(TInput input)
    where TInput : ITypeInput
    => new(AstNulls.At, input.Type, "");
}

internal interface IAstObjectFieldChecks
  : IAstAliasedChecks<FieldInput>
{ }
