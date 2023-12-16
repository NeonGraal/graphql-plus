using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyEnumTypes(
  IVerifyAliased<EnumDeclAst> aliased
) : UsageAliasedVerifier<EnumDeclAst, EnumDeclAst>(aliased)
{
  protected override void UsageValue(EnumDeclAst usage, IMap<EnumDeclAst[]> byId, ITokenMessages errors)
  {
    if (usage.Extends is not null && !byId.ContainsKey(usage.Extends)) {
      errors.AddError(usage, $"Invalid Enum Base. '{usage.Extends}' not defined.");
    }
  }
}
