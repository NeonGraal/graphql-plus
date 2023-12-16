using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal abstract class AstObjectTypesVerifier<TObject, TField, TReference>(
  IVerifyAliased<TObject> aliased
) : UsageAliasedVerifier<TObject, AstType>(aliased)
  where TObject : AstObject<TField, TReference> where TField : AstField<TReference> where TReference : AstReference<TReference>
{
  public abstract string Label { get; }

  protected override void UsageValue(TObject usage, IMap<AstType[]> byId, ITokenMessages errors)
  {
    if (usage.Extends is not null && !byId.ContainsKey(usage.Extends.Name)) {
      errors.AddError(usage, $"Invalid {Label} Base. '{usage.Extends}' not defined.");
    }

    foreach (var field in usage.Fields) {
      UsageField(field, byId, errors);
    }

    foreach (var alternate in usage.Alternates) {
      UsageAlternate(alternate, byId, errors);
    }
  }

  protected virtual void UsageAlternate(AlternateAst<TReference> alternate, IMap<AstType[]> byId, ITokenMessages errors)
  {
    if (!byId.ContainsKey(alternate.Type.Name)) {
      errors.AddError(alternate, $"Invalid {Label} Alternate. '{alternate.Type}' not defined.");
    }
  }

  protected virtual void UsageField(TField field, IMap<AstType[]> byId, ITokenMessages errors)
  {
    if (!byId.ContainsKey(field.Type.Name)) {
      errors.AddError(field, $"Invalid {Label} Field. '{field.Type}' not defined.");
    }
  }
}
