using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyEnumsAliasedTests
  : AliasedVerifierTestsBase<IAstEnum>
{
  internal override GroupedVerifier<IAstEnum> NewGroupedVerifier()
    => new VerifyEnumsAliased(VerifierRepo);
}
