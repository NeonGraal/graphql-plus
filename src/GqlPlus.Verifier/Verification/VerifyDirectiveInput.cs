using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyDirectiveInput : UsageAliasedVerifier<DirectiveDeclAst, InputDeclAst>
{
  protected override ITokenMessages UsageValue(DirectiveDeclAst usage, IMap<InputDeclAst[]> byId)
    => new TokenMessages(usage.Parameters
      .SelectMany(p =>
        byId.ContainsKey(p.Input.Name)
        ? new TokenMessages()
        : [p.Error($"Invalid Directive Parameter. '{p.Input}' not defined")]));
}
