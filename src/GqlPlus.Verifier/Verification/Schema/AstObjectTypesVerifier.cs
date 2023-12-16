using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal abstract class AstObjectTypesVerifier<TObject, TField, TReference, TContext>(
  IVerifyAliased<TObject> aliased
) : UsageAliasedVerifier<TObject, AstType, TContext>(aliased)
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>
  where TReference : AstReference<TReference>
  where TContext : UsageContext
{
  public abstract string Label { get; }

  //protected ObjectContext MakeContext(TObject usage, IMap<AstType[]> byId, ITokenMessages errors)
  //{
  //  var validTypes = byId
  //    .Select(p => (Id: p.Key, Type: (AstDescribed)p.Value.First()))
  //    .Concat(usage.TypeParameters.Select(p => (Id: "$" + p.Name, Type: (AstDescribed)p)))
  //    .ToMap(p => p.Id, p => p.Type);

  //  throw new(validTypes, errors, []);
  //}

  protected override void UsageValue(TObject usage, TContext context)
  {
    if (usage.Extends is not null) {
      CheckType(usage.Extends, context);
    }

    foreach (var field in usage.Fields) {
      UsageField(field, context);
    }

    foreach (var alternate in usage.Alternates) {
      UsageAlternate(alternate, context);
    }

    foreach (var typeParameter in usage.TypeParameters) {
      if (!context.Used.Contains("$" + typeParameter.Name)) {
        context.AddError(typeParameter, $"Invalid {Label}. '${typeParameter.Name}' not used.");
      }
    }
  }

  protected virtual void UsageAlternate(AlternateAst<TReference> alternate, TContext context)
    => CheckType(alternate.Type, context);

  protected virtual void UsageField(TField field, TContext context)
    => CheckType(field.Type, context);

  protected virtual void CheckArgumentType(TReference type, TContext context)
    => CheckType(type, context);

  protected virtual void CheckType(TReference type, TContext context)
  {
    if (context.GetType(type.TypeName, out AstDescribed? value)) {
      var numArgs = type.Arguments.Length;
      if (value is AstObject<TField, TReference> definition) {
        var numParams = definition.TypeParameters.Length;
        if (numParams != numArgs) {
          context.AddError(type, $"Invalid {Label}. Arguments mismatch, expected {numParams} given {numArgs}");
        }
      }

      foreach (var arg in type.Arguments) {
        CheckArgumentType(arg, context);
      }
    } else {
      context.AddError(type, $"Invalid {Label}. '{type.TypeName}' not defined.");
    }
  }
}
