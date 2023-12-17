using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyEnumTypes(
  IVerifyAliased<EnumDeclAst> aliased
) : AstTypeVerifier<EnumDeclAst, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(EnumDeclAst usage, IMap<AstType[]> byId, ITokenMessages errors)
    => MakeUsageContext(byId, errors);

  protected override void UsageValue(EnumDeclAst usage, UsageContext context)
  {
    if (usage.Extends is not null) {
      if (context.GetType(usage.Extends, out var baseType) && baseType is AstType type) {
        if (type.Label != "Enum") {
          context.AddError(usage, "Enum Base", $"Type kind mismatch for {usage.Extends}. Found {type?.Label}");
        }
      } else {
        context.AddError(usage, "Enum Base", $"'{usage.Extends}' not defined");
      }
    }
  }
}
