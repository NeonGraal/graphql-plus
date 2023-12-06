using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyOutputTypes : UsageAliasedVerifier<OutputAst, AstType>
{
  protected override string Label => "Outputs";
  protected override string UsageKey(OutputAst item) => item.Extends?.Name ?? "";
  protected override ITokenMessages UsageValue(OutputAst usage, IMap<AstType[]> byId) => TokenMessages.Empty;
}
