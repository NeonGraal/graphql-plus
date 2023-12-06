using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyScalarTypes : UsageAliasedVerifier<ScalarAst, AstType>
{
  protected override string Label => "Scalars";
  protected override string UsageKey(ScalarAst item) => item.Kind.ToString();
  protected override ITokenMessages UsageValue(ScalarAst usage, IMap<AstType[]> byId) => TokenMessages.Empty;
}
