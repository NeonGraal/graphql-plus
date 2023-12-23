using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification.Schema;

internal abstract class AstObjectVerifier<TObject, TField, TReference, TContext>(
  IVerifyAliased<TObject> aliased
) : AstTypeVerifier<TObject, TContext>(aliased)
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>
  where TReference : AstReference<TReference>
  where TContext : UsageContext
{
  protected override void UsageValue(TObject usage, TContext context)
  {
    if (usage.Extends is not null) {
      context.CheckType(usage.Extends);
    }

    foreach (var field in usage.Fields) {
      UsageField(field, context);
    }

    foreach (var alternate in usage.Alternates) {
      UsageAlternate(alternate, context);
    }

    foreach (var typeParameter in usage.TypeParameters) {
      if (!context.Used.Contains("$" + typeParameter.Name)) {
        context.AddError(typeParameter, usage.Label, $"'${typeParameter.Name}' not used");
      }
    }
  }

  protected virtual void UsageAlternate(AlternateAst<TReference> alternate, TContext context)
    => context
      .CheckType(alternate.Type)
      .CheckModifiers(alternate);

  protected virtual void UsageField(TField field, TContext context)
    => context
      .CheckType(field.Type)
      .CheckModifiers(field);
}
