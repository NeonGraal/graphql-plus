using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyScalarTypes(
  IVerifyAliased<AstScalar> aliased,
  IEnumerable<IVerifyScalar> scalars
) : AstParentVerifier<AstScalar, string, EnumContext>(aliased)
{
  protected override string GetParent(AstType<string> usage)
    => usage.Parent ?? "";

  protected override EnumContext MakeContext(AstScalar usage, AstType[] aliased, ITokenMessages errors)
  {
    var validTypes = aliased.AliasedGroup()
      .ToMap(p => p.Key, p => (AstDescribed)p.First());

    return new(validTypes, errors, aliased.MakeEnumValues());
  }

  protected override void UsageValue(AstScalar usage, EnumContext context)
  {
    base.UsageValue(usage, context);

    foreach (var scalar in scalars) {
      scalar.Verify(usage, context);
    }
  }

  protected override bool CheckAstParent(AstScalar usage, AstScalar? parent, EnumContext context)
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

  protected override bool CanMergeItems(AstScalar usage, AstScalar parent, EnumContext context)
    => scalars.All(scalar => scalar.CanMergeItems(usage, parent, context));
}
