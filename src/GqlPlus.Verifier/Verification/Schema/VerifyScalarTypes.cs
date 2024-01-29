using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyScalarTypes(
  IVerifyAliased<AstScalar> aliased,
  IEnumerable<IVerifyContext<AstScalar>> scalars
) : AstParentVerifier<AstScalar, string, UsageContext>(aliased)
{
  protected override string GetParent(AstType<string> usage)
    => usage.Parent ?? "";

  protected override UsageContext MakeContext(AstScalar usage, IMap<AstType[]> byId, ITokenMessages errors)
    => MakeUsageContext(byId, errors);

  protected override void UsageValue(AstScalar usage, UsageContext context)
  {
    base.UsageValue(usage, context);

    foreach (var scalar in scalars) {
      scalar.Verify(usage, context);
    }
  }

  protected override bool CheckAstParent(AstScalar usage, AstScalar? parent, UsageContext context)
  {
    if (base.CheckAstParent(usage, parent, context)) {
      if (usage.Kind == parent.Kind) {
        return true;
      } else {
        context.AddError(usage, usage.Label + " Parent", $"'{parent.Name}' invalid kind. Found '{parent.Kind}'");
      }
    }

    return false;
  }
}
