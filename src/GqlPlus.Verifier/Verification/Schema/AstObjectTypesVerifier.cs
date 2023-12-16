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

    var validTypes = byId
      .Select(p => (Id: p.Key, Type: (AstDescribed)p.Value.First()))
      .Concat(usage.TypeParameters.Select(p => (Id: "$" + p.Name, Type: (AstDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    ObjectContext context = new(validTypes, errors, []);

    foreach (var field in usage.Fields) {
      UsageField(field, context);
    }

    foreach (var alternate in usage.Alternates) {
      UsageAlternate(alternate, context);
    }

    foreach (var typeParameter in usage.TypeParameters) {
      if (!context.Used.Contains("$" + typeParameter.Name)) {
        errors.AddError(typeParameter, $"Invalid {Label}. '${typeParameter.Name}' not used.");
      }
    }
  }

  protected virtual void UsageAlternate(AlternateAst<TReference> alternate, ObjectContext context)
  {
    if (context.Types.ContainsKey(alternate.Type.TypeName)) {
      context.Used.Add(alternate.Type.TypeName);
    } else {
      context.AddError(alternate, $"Invalid {Label} Alternate. '{alternate.Type.TypeName}' not defined.");
    }
  }

  protected virtual void UsageField(TField field, ObjectContext context)
  {
    if (context.Types.ContainsKey(field.Type.TypeName)) {
      context.Used.Add(field.Type.TypeName);
    } else {
      context.AddError(field, $"Invalid {Label} Field. '{field.Type.TypeName}' not defined.");
    }
  }
}

internal record struct ObjectContext(IMap<AstDescribed> Types, ITokenMessages Errors, HashSet<string> Used)
{
  public readonly void AddError<TAst>(TAst item, string message)
      where TAst : AstBase
      => Errors.AddError(item, message);
}
