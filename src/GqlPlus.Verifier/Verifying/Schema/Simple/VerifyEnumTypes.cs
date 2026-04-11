using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyEnumTypes(IVerifierRepository verifiers) : AstSimpleVerifier<IAstEnum, UsageContext, IAstEnumLabel>(verifiers)
{
  protected override IEnumerable<IAstEnumLabel> GetItems(IAstEnum usage)
    => usage.Items;

  protected override UsageContext MakeContext(IAstEnum usage, IAstType[] aliased, IMessages errors)
    => MakeUsageContext(aliased, errors);
}
