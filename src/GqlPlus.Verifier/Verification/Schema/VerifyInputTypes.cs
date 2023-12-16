using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyInputTypes(
  IVerifyAliased<InputDeclAst> aliased
) : AstObjectTypesVerifier<InputDeclAst, InputFieldAst, InputReferenceAst, UsageContext>(aliased)
{
  public override string Label => "Input";

  protected override UsageContext MakeContext(InputDeclAst usage, IMap<AstType[]> byId, ITokenMessages errors)
  {
    var validTypes = byId
      .Select(p => (Id: p.Key, Type: (AstDescribed)p.Value.First()))
      .Concat(usage.TypeParameters.Select(p => (Id: "$" + p.Name, Type: (AstDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors);
  }

  protected override void UsageField(InputFieldAst field, UsageContext context)
  {
    base.UsageField(field, context);

    if (field.Default?.Value?.EnumValue == "Null.null" && !(field.Modifiers.LastOrDefault()?.Kind == ModifierKind.Optional)) {
      context.AddError(field, $"Invalid Input Field Default. 'null' default requires Optional type, not '{field.ModifiedType}'.");
    }
  }
}
