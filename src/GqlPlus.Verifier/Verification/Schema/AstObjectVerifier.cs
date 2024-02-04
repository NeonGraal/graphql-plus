using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema;

internal abstract class AstObjectVerifier<TObject, TField, TReference, TContext>(
  IVerifyAliased<TObject> aliased,
  IMerge<TypeParameterAst> mergeTypeParameters
) : AstParentItemVerifier<TObject, TReference, TContext, TypeParameterAst>(aliased, mergeTypeParameters)
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>
  where TReference : AstReference<TReference>
  where TContext : UsageContext
{
  protected override void UsageValue(TObject usage, TContext context)
  {
    base.UsageValue(usage, context);

    if (usage.Parent is not null) {
      context.CheckType(usage.Parent, false);
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

  protected virtual void UsageAlternate(AstAlternate<TReference> alternate, TContext context)
    => context
      .CheckType(alternate.Type)
      .CheckModifiers(alternate);

  protected virtual void UsageField(TField field, TContext context)
    => context
      .CheckType(field.Type)
      .CheckModifiers(field);

  protected override string GetParent(AstType<TReference> usage)
    => usage.Parent?.FullName ?? "";

  protected override bool GetParentType(TObject usage, string parent, TContext context, [NotNullWhen(true)] out AstType<TReference>? type)
  {
    if (parent.StartsWith('$')) {
      var parameter = parent[1..];
      if (usage.TypeParameters.All(p => p.Name != parameter)) {
        context.AddError(usage, usage.Label + " Parent", $"'{parent}' not defined");
      }

      type = null;
      return false;
    }

    return base.GetParentType(usage, parent, context, out type);
  }

  protected override IEnumerable<TypeParameterAst> GetItems(TObject usage)
    => usage.TypeParameters;
}
