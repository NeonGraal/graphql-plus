using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyInputTypes(
  IVerifyAliased<InputDeclAst> aliased
) : AstObjectVerifier<InputDeclAst, InputFieldAst, InputReferenceAst, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(InputDeclAst usage, AstType[] aliased, ITokenMessages errors)
  {
    var validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (AstDescribed)p.First()))
      .Concat(usage.TypeParameters.Select(p => (Id: "$" + p.Name, Type: (AstDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors);
  }

  protected override void UsageField(InputFieldAst field, UsageContext context)
  {
    base.UsageField(field, context);

    if (field.Default?.Value?.EnumValue == "Null.null" && !(field.Modifiers.LastOrDefault()?.Kind == ModifierKind.Optional)) {
      context.AddError(field, "Input Field Default", $"'null' default requires Optional type, not '{field.ModifiedType}'");
    }
  }
}
