using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyEnumTypes : UsageAliasedVerifier<EnumAst, AstType>
{
  protected override string Label => "Enums";
  protected override string UsageKey(EnumAst item) => item.Extends ?? "";
  protected override ITokenMessages UsageValue(EnumAst usage, IMap<AstType[]> byId) => TokenMessages.Empty;
}
