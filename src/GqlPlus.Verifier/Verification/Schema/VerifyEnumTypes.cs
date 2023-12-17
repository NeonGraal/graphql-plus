using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyEnumTypes(
  IVerifyAliased<EnumDeclAst> aliased
) : UsageVerifier<EnumDeclAst, EnumDeclAst, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(EnumDeclAst usage, IMap<EnumDeclAst[]> byId, ITokenMessages errors)
    => MakeUsageContext(byId, errors);

  protected override void UsageValue(EnumDeclAst usage, UsageContext context)
  {
    if (usage.Extends is not null && !context.GetType(usage.Extends, out var _)) {
      context.AddError(usage, "Enum Base", $"'{usage.Extends}' not defined");
    }
  }
}
