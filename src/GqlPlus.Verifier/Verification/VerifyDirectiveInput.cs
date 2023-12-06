using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyDirectiveInput : UsageAliasedVerifier<DirectiveDeclAst, InputDeclAst>
{
  protected override ITokenMessages UsageValue(DirectiveDeclAst usage, IMap<InputDeclAst[]> byId) => new TokenMessages();
}
